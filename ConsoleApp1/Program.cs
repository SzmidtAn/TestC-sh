using ConsoleApp1.Entities;
using ConsoleApp1.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

 string _connectionString = "server=localhost; database=localhost; user=root; password=insert_password";
builder.Services.AddDbContext<ApplicationContext>(options =>
    
    options
        .UseMySql(
        _connectionString,
        ServerVersion.AutoDetect(_connectionString)));

builder.Services.AddScoped<IAnimalRepo, AnimalRepo>();


var app = builder.Build();






// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();