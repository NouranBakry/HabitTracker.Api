using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HabitTracker.Infrastructure;

// This class tells EF exactly how to create the DbContext during migrations
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // HARDCODE your dev string here temporarily just to get the DB built.
        // This is a common "Senior" trick to bypass configuration loading issues during local setup.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HabitTrackerDb;Username=postgres;Password=postgres");

        return new AppDbContext(optionsBuilder.Options);
    }
}