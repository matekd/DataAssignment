using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _employeeService.CreateEmployeeAsync(form);

        return result ? Created("", result) : Problem("Something went wrong");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.GetEmployeesAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _employeeService.GetEmployeeByIdAsync(id);
        return result != null ? Ok(result) : NotFound($"Employee with id {id} not found");
    }

    [HttpPatch]
    public async Task<IActionResult> Update(EmployeeUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _employeeService.UpdateEmployeeAsync(form);

        return result ? Ok(result) : BadRequest("Employee was not updated");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _employeeService.DeleteEmployeeAsync(id);

        return result ? Ok(result) : BadRequest("Employee was not deleted");
    }
}
