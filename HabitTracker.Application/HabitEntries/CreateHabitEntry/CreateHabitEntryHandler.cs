using HabitTracker.Infrastructure;
using HabitTracker.Domain.Entities;

public class CreateHabitEntryHandler
{
    private readonly AppDbContext _context;

    public CreateHabitEntryHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateHabitEntryCommand command)
    {
        var habit = await _context.Habits.FindAsync(command.HabitId);
        if (habit == null) throw new Exception("Habit not found");

        // 2. Create the entry
        var entry = new HabitEntry(
            command.HabitId,
            command.Date ?? DateTime.UtcNow,
            command.Completed
        );

        _context.HabitEntries.Add(entry);
        await _context.SaveChangesAsync();

        return entry.Id;
    }
}
