public class GetHabitHandler
{
    private readonly IHabitRepository _repository;

    public GetHabitHandler(IHabitRepository repository)
    {
        _repository = repository;
    }

    public async Task<HabitResponse?> Handle(GetHabitQuery query)
    {
        var habit = await _repository.GetByIdAsync(query.Id);
        if (habit == null) return null;

        return new HabitResponse(habit.Id, habit.Name, habit.CreatedAt);
    }
}