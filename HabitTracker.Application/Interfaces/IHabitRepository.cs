using HabitTracker.Domain.Entities;

namespace HabitTracker.Domain.Interfaces;

public interface IHabitRepository
{
    // Habit Methods
    Task<IEnumerable<Habit>> GetAllAsync();
    Task<Habit?> GetByIdAsync(Guid id);
    Task AddAsync(Habit habit);
    Task UpdateAsync(Habit habit);
    Task DeleteAsync(Guid id);

    Task AddEntryAsync(HabitEntry entry);
    Task<IEnumerable<HabitEntry>> GetEntriesByHabitIdAsync(Guid habitId);
}