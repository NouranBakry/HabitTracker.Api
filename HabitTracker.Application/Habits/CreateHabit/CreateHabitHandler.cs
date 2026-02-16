using HabitTracker.Domain.Entities;
public class CreateHabitHandler
{
    private readonly IHabitRepository _repository;

    public CreateHabitHandler(IHabitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateHabitCommand command)
    {
        var habit = new Habit(command.Name);
        await _repository.AddAsync(habit);
        return habit.Id;
    }
}