using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using MedicalEquipmentSupplySystem.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var contextFactory = new MedicalEquipmentSupplySystemContextFactory();
string connectionString = "server=localhost;database=medicalequipmentsupplysystem;uid=root;pwd=root;Old Guids=true";
var context = contextFactory.CreateDbContext(new string[] { connectionString });

var supplyCompanyRepository = new MedicalEquipmentSupplySystem.DataAccess.Repository.SupplyCompanyRepository(context);

builder.Services.AddScoped<ISupplyCompanyService>(_ => new SupplyCompanyService(supplyCompanyRepository));

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
