namespace HabitTracker.Domain.Entities;

public class Habit
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public List<HabitLog> Logs { get; set; } = new();
}
