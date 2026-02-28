using HabitTracker.Domain.Interfaces;

public class GetAllHabitsHandler
{
    private readonly IHabitRepository _repository;

    public GetAllHabitsHandler(IHabitRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HabitResponse>> Handle(GetAllHabitsQuery query)
    {
        var habits = await _repository.GetAllAsync();
        return habits.Select(h => new HabitResponse(h.Id, h.Name, h.CreatedAt));
    }
}