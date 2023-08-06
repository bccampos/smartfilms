
using Microsoft.EntityFrameworkCore;
using bruno.CatalogFilms.API;
using bruno.CatalogFilms.Infrastructure;
using bruno.CatalogFilms.Contracts;
using bruno.CatalogFilms.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddContracts();


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
