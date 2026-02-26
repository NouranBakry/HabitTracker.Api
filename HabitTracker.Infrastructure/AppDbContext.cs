namespace HabitTracker.Infrastructure;

using HabitTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public DbSet<Habit> Habits => Set<Habit>();

    public DbSet<HabitEntry> HabitEntries => Set<HabitEntry>();
    

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}