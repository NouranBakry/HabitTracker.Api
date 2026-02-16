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
    public IActionResult GetById(Guid id)
    {
        return Ok(); // implement later
    }
}