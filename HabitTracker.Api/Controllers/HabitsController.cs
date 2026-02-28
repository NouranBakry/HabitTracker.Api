using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/habits")]
public class HabitsController : ControllerBase
{
    private readonly CreateHabitHandler _handler;

    public HabitsController(CreateHabitHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHabitCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, [FromServices] GetHabitHandler handler)
    {
        var habit = await handler.Handle(new GetHabitQuery(id));
        if (habit == null) return NotFound();
        return Ok(habit);
    }
}