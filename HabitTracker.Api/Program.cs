using Microsoft.EntityFrameworkCore;
using HabitTracker.Infrastructure;
using Scalar.AspNetCore;
using HabitTracker.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// 2. Database (PostgreSQL)
// 1. Try to get it from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Default");

// 2. FALLBACK: If it's null, use the hardcoded string (matching your migrations)
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("⚠️ WARNING: Could not find 'Default' in appsettings.json. Using fallback.");
    connectionString = "Host=localhost;Port=5432;Database=HabitTrackerDb;Username=postgres;Password=postgres";
}
else
{
    Console.WriteLine($"✅ Database Connection String loaded successfully.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 3. Dependency Injection
builder.Services.AddScoped<IHabitRepository, HabitRepository>();
builder.Services.AddScoped<CreateHabitHandler>();
builder.Services.AddScoped<GetHabitHandler>();
builder.Services.AddScoped<GetAllHabitsHandler>();

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