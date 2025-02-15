using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTypeController(IStatusTypeService statusTypeService) : ControllerBase
{
    private readonly IStatusTypeService _statusTypeService = statusTypeService;

    [HttpPost]
    public async Task<IActionResult> Create(StatusTypeRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _statusTypeService.CreateStatusTypeAsync(form);

        return result ? Created("", result) : Problem("Something went wrong");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _statusTypeService.GetStatusTypesAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _statusTypeService.GetStatusTypeByIdAsync(id);
        return result != null ? Ok(result) : NotFound($"StatusType with id {id} not found");
    }

    [HttpPatch]
    public async Task<IActionResult> Update(StatusTypeUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _statusTypeService.UpdateStatusTypeAsync(form);

        return result ? Ok(result) : BadRequest("StatusType was not updated");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _statusTypeService.DeleteStatusTypeAsync(id);

        return result ? Ok(result) : BadRequest("StatusType was not deleted");
    }
}

