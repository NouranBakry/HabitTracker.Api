using HabitTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
public class GetHabitEntriesHandler
{
    private readonly AppDbContext _context;

    public GetHabitEntriesHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<HabitEntryResponse>> Handle(GetHabitEntriesQuery query)
    {
        return await _context.HabitEntries
            .Where(e => e.HabitId == query.HabitId)
            .OrderByDescending(e => e.Date)
            .Select(e => new HabitEntryResponse(e.Id, e.Date, e.Completed))
            .ToListAsync();
    }
}