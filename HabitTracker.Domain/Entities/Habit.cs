namespace HabitTracker.Domain.Entities;

public class Habit
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    private Habit() { }

    public Habit(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Habit name cannot be empty.", nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

}