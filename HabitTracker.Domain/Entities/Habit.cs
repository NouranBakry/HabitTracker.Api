namespace HabitTracker.Domain.Entities;

public class Habit
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public int FrequencyPerWeek { get; set; }

    public DateTime CreatedAt { get; set; }

    private Habit() { }

    public static Habit Create(string name, int frequencyPerWeek)
    {
        return new Habit
        {
            Id = Guid.NewGuid(),
            Name = name,
            FrequencyPerWeek = frequencyPerWeek,
            CreatedAt = DateTime.UtcNow
        };
    }
}