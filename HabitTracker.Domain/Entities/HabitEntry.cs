namespace HabitTracker.Domain.Entities;

public class HabitEntry
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }

    public Guid HabitId { get; set; }
    public Habit Habit { get; set; } = null!;
}
