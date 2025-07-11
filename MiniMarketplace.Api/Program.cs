using DotNetEnv;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MiniMarketplace.Application;
using MiniMarketplace.Application.Mappers;
using MiniMarketplace.Application.Validators;
using MiniMarketplace.Persistence.Data;
using MiniMarketplace.Persistence.Repositories;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateRequestValidator>();


var connectionString =
    $"Host={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" +
    $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
    $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";

builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register your services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

// OpenAPI/Swagger configuration
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
app.MapControllers();

app.Run();