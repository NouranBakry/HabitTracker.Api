namespace HabitTracker.Domain.Entities;

public class HabitEntry
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }

    public Guid HabitId { get; set; }

    private HabitEntry() { }

    public HabitEntry(Guid habitId, DateTime date, bool completed)
    {
        Id = Guid.NewGuid();
        HabitId = habitId;
        Date = date.Date; // Store only the date part
        Completed = completed;
    }
}
