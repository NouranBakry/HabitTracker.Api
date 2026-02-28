using HabitTracker.Domain.Entities;
using HabitTracker.Domain.Interfaces;

public class CreateHabitEntryHandler
{
    private readonly IHabitRepository repository;

    public CreateHabitEntryHandler(IHabitRepository repository)
    {
        this.repository = repository;
    }
    public async Task<Guid> Handle(CreateHabitEntryCommand command)
    {
        var habit = await repository.GetByIdAsync(command.HabitId);
        if (habit == null) throw new Exception("Habit not found");

        // 2. Create the entry
        var entry = new HabitEntry(
            command.HabitId,
            command.Date ?? DateTime.UtcNow,
            command.Completed
        );

        await repository.AddEntryAsync(entry);

        return entry.Id;
    }
}
