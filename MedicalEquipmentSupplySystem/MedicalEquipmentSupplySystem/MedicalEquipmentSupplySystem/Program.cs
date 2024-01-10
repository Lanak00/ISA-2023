using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalEquipmentSupplySystem.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

var mySpecificOrigins = "_mySpecificOrigins";


//Add email config
builder.Services.Configure<EmailConfiguration>(config.GetSection("MailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true
    );
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));

var contextFactory = new MedicalEquipmentSupplySystemContextFactory();
string connectionString = "server=localhost;database=medicalequipmentsupplysystem;uid=root;pwd=root;Old Guids=true";
var context = contextFactory.CreateDbContext(new string[] { connectionString });

var supplyCompanyRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.SupplyCompanyRepository(context);
var userRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.UserRepository(context);
var equipmentRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.EquipmentRepository(context);
var equipmentReservationRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.EquipmentReservationRepository(context);


builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISupplyCompanyService>(_ => new SupplyCompanyService(supplyCompanyRepository));
builder.Services.AddScoped<IUserService>(_ => new UserService(userRepository));
builder.Services.AddScoped<IAuthService>(_ => new AuthService(userRepository));
builder.Services.AddScoped<IEquipmentService>(_ => new EquipmentService(equipmentRepository));
builder.Services.AddScoped<IEquipmentReservationService>(_ => new EquipmentReservationService(equipmentReservationRepository, _.GetRequiredService<IEmailService>(),
        userRepository, equipmentRepository));


var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HospitalWorkerPolicy", policy =>
        policy.RequireRole("HospitalWorker"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
