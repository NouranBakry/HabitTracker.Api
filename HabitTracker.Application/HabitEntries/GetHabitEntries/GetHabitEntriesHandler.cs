using HabitTracker.Domain.Interfaces;
public class GetHabitEntriesHandler
{
    private readonly IHabitRepository _repository;

    public GetHabitEntriesHandler(IHabitRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<HabitEntryResponse>> Handle(GetHabitEntriesQuery query)
    {
        var entries = await _repository.GetEntriesByHabitIdAsync(query.HabitId);
        return entries.Select(e => new HabitEntryResponse(e.Id, e.Date, e.Completed)).ToList();
    }
}