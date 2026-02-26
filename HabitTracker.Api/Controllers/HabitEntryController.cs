using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/habits")]
public class HabitEntryController : ControllerBase
{
    private readonly CreateHabitEntryHandler _handler;

    public HabitEntryController(CreateHabitEntryHandler handler)
    {
        _handler = handler;
    }


    [HttpPost("{habitId}/entries")]
    public async Task<IActionResult> CreateEntry(Guid habitId, CreateHabitEntryCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { habitId, id }, null);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(); // implement later
    }
}