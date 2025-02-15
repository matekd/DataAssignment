using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _customerService.CreateCustomerAsync(form);

        return result ? Created("", result) : Problem("Something went wrong");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _customerService.GetCustomersAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _customerService.GetCustomerByIdAsync(id);
        return result != null ? Ok(result) : NotFound($"Service with id {id} not found");
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CustomerUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _customerService.UpdateCustomerAsync(form);

        return result ? Ok(result) : BadRequest("Customer was not updated");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _customerService.DeleteCustomerAsync(id);

        return result ? Ok(result) : BadRequest("Customer was not deleted");
    }
}
