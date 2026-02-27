public class CreateHabitEntryCommand
{
    public Guid HabitId { get; set; }
    public DateTime Date { get; set; }
    public bool Completed { get; set; }
}