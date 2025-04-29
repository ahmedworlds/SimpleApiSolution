using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (previously in ConfigureServices)
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Basic Swagger setup
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Simple API", 
        Version = "v1",
        Description = "A simple API - Version 1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline (previously in Configure)
// Add custom error handling middleware at the beginning of the pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple API");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
});

app.UseRouting();

app.MapControllers();

app.Run();


