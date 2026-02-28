using HabitTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/habits/{habitId}/entries")]
public class HabitEntryController : ControllerBase
{
    private readonly CreateHabitEntryHandler _createHandler;
    private readonly GetHabitEntriesHandler _getHandler;
    public HabitEntryController(CreateHabitEntryHandler createHandler, GetHabitEntriesHandler getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }


    [HttpPost]
    public async Task<IActionResult> CreateEntry(Guid habitId, [FromBody] CreateHabitEntryRequest request)
    {
        var id = await _createHandler.Handle(new CreateHabitEntryCommand(habitId, request.Date, request.Completed));
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetEntries(Guid habitId)
    {
        var entries = await _getHandler.Handle(new GetHabitEntriesQuery(habitId));
        return Ok(entries);
    }
}