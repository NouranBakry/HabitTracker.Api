using HabitTracker.Domain.Entities;

public interface IHabitEntryRepository
{
    Task<HabitEntry?> GetByIdAsync(Guid id);
    Task AddAsync(HabitEntry entry);
    Task UpdateAsync(HabitEntry entry);
    Task DeleteAsync(Guid id);
}
