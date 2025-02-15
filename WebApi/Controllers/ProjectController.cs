using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _projectService.CreateProjectAsync(form);

        return result ? Created("", result) : Problem("Something went wrong");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetProjectsAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _projectService.GetProjectByIdAsync(id);
        return result != null ? Ok(result) : NotFound($"Project with id {id} not found");
    }

    [HttpPatch]
    public async Task<IActionResult> Update(ProjectUpdateForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool result = await _projectService.UpdateProjectAsync(form);

        return result ? Ok(result) : BadRequest("Project was not updated");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _projectService.DeleteProjectAsync(id);

        return result ? Ok(result) : BadRequest("Project was not deleted");
    }
}
