using Catalog.API.Products.CreateProduct;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalog Microservice",
        Version = "v1",
    });
});

// Add services to the DI container

var app = builder.Build();

// Configure the HTTP request pipeline

app.UseSwagger();
app.UseSwaggerUI();

var groupProducts = app.MapGroup("/products");

groupProducts.MapCreateProductEndpoint();

app.Run();
