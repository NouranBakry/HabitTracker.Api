using Microsoft.EntityFrameworkCore;
using HabitTracker.Infrastructure;
using Scalar.AspNetCore; 

var builder = WebApplication.CreateBuilder(args);

// 1. Register Services
builder.Services.AddControllers();
builder.Services.AddOpenApi(); 

// 2. Database (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// 3. Dependency Injection
builder.Services.AddScoped<IHabitRepository, HabitRepository>();
builder.Services.AddScoped<CreateHabitHandler>();

var app = builder.Build();

// 4. Configure the HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();          
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.MapControllers();

// Health check for the root URL
app.MapGet("/", () => "Habit Tracker API is running! Access docs at /scalar/v1");

app.Run();