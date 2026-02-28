using HabitTracker.Domain.Entities;
using HabitTracker.Domain.Interfaces;
using HabitTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Habit>> GetAllAsync()
        => await _context.Habits.ToListAsync();

    public async Task<Habit?> GetByIdAsync(Guid id)
    {
        // Use .Include so the AI can see the entries attached to the habit
        return await _context.Habits
            .Include(h => h.Entries)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task AddAsync(Habit habit)
    {
        await _context.Habits.AddAsync(habit);
        await _context.SaveChangesAsync();
    }

    // New Merged Methods
    public async Task AddEntryAsync(HabitEntry entry)
    {
        await _context.HabitEntries.AddAsync(entry);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HabitEntry>> GetEntriesByHabitIdAsync(Guid habitId)
    {
        return await _context.HabitEntries
            .Where(e => e.HabitId == habitId)
            .OrderByDescending(e => e.Date)
            .ToListAsync();
    }

    public Task UpdateAsync(Habit habit)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    // ... (implement Delete/Update as needed)
}