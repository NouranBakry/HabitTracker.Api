using HabitTracker.Domain.Entities;

public interface IHabitRepository
{
    Task AddAsync(Habit habit);
    Task<Habit?> GetByIdAsync(Guid id);
    Task<List<Habit>> GetAllAsync();
}