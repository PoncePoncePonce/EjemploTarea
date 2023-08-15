using Business.Interfaces;
using Business.Services;
using Infraestructura.Context;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connection = builder.Configuration.GetConnectionString("SQLConnectionString");
builder.Services.AddDbContext<SQLServerContext>(opt => opt.UseSqlServer(connection));

builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
// Add services to the container.

builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
