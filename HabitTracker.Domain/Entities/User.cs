namespace HabitTracker.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public List<Habit> Habits { get; set; } = new();
}
