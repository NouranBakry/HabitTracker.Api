using HabitTracker.Domain.Entities;
using HabitTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class HabitEntryRepository : IHabitEntryRepository
{
    private readonly AppDbContext _context;

    public HabitEntryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HabitEntry?> GetByIdAsync(Guid id)
    {
        return await _context.HabitEntries.FindAsync(id);
    }

    public async Task AddAsync(HabitEntry entry)
    {
        await _context.HabitEntries.AddAsync(entry);
    }

    public async Task UpdateAsync(HabitEntry entry)
    {
        _context.HabitEntries.Update(entry);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entry = await GetByIdAsync(id);
        if (entry != null)
        {
            _context.HabitEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }
    }
}
