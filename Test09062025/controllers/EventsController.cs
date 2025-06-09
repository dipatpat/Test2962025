using Microsoft.AspNetCore.Mvc;
using Test09062025.dtos;
using Test09062025.services;

namespace Test09062025.controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;
   public EventsController(IEventService service) => _service = service;

   [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var result = await _service.GetEventDetailsAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventDto dto)
   {
       if (!ModelState.IsValid) return BadRequest(ModelState);

      //var (success, error) = await _service.UpdateEventAsync(id, dto);
      //if (!success) return BadRequest(new { error });
        return Ok();
    }
}