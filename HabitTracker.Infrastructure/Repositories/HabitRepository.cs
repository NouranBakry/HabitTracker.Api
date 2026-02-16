using HabitTracker.Domain.Entities;
using HabitTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
    }

    public async Task<Habit?> GetByIdAsync(Guid id)
    {
        return await _context.Habits.FindAsync(id);
    }

    public async Task<List<Habit>> GetAllAsync()
    {
        return await _context.Habits.ToListAsync();
    }
}