using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(IServiceService serviceService) : ControllerBase
{
    private readonly IServiceService _serviceService = serviceService;

    [HttpPost]
    public async Task<IActionResult> Create(ServiceRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _serviceService.CreateServiceAsync(form);

        return result ? Created("", result) : Problem("Something went wrong");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _serviceService.GetServicesAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _serviceService.GetServiceByIdAsync(id);
        return result != null ? Ok(result) : NotFound($"Service with id {id} not found");
    }

    [HttpPatch]
    public async Task<IActionResult> Update(ServiceUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _serviceService.UpdateServiceAsync(form);

        return result ? Ok(result) : BadRequest("Service was not updated");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _serviceService.DeleteServiceAsync(id);

        return result ? Ok(result) : BadRequest("Service was not deleted");
    }
}
