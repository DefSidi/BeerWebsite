using BeerApp.BU.Interfaces;
using BeerApp.BU.Services;
using BeerApp.DAL.Context;
using BeerApp.DAL.Interfaces;
using BeerApp.DAL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<DbBeerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("BeersDB"),
    sqlOptions => sqlOptions.MigrationsAssembly("BeerApp.DAL")));

builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IBeerService, BeerService>();



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
