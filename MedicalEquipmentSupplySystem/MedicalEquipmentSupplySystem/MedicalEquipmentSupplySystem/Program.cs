using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using MedicalEquipmentSupplySystem.DataAccess;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

//Add email config
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true
    );


var contextFactory = new MedicalEquipmentSupplySystemContextFactory();
string connectionString = "server=localhost;database=medicalequipmentsupplysystem;uid=root;pwd=root;Old Guids=true";
var context = contextFactory.CreateDbContext(new string[] { connectionString });

var supplyCompanyRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.SupplyCompanyRepository(context);
var userRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.UserRepository(context);

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISupplyCompanyService>(_ => new SupplyCompanyService(supplyCompanyRepository));
builder.Services.AddScoped<IUserService>(_ => new UserService(userRepository));
builder.Services.AddScoped<IAuthService>(_ => new AuthService(userRepository));


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
