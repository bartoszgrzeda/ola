using System.Net;
using Api.Commands;
using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ActivityService _service;

    public ActivityController(ActivityService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateActivity command)
    {
        var id = await _service.Create(command.Title, command.Description, command.DueDate, command.Priority);
        return Ok(id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActivity command)
    {
        await _service.Update(id, command.Title, command.Description, command.DueDate, command.Priority);
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ActivityDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var activity = await _service.GetById(id);
        return Ok(activity);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ActivityDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _service.GetAll();
        return Ok(activities);
    }
}