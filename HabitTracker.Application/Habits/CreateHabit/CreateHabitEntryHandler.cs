using HabitTracker.Domain.Entities;

public class CreateHabitEntryHandler
{
    private readonly IHabitEntryRepository _repository;

    public CreateHabitEntryHandler(IHabitEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateHabitEntryCommand command)
    {
        var entry = new HabitEntry(command.HabitId, command.Date, command.Completed);
        await _repository.AddAsync(entry);
        return entry.Id;
    }
}
