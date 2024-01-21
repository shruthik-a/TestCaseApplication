using Microsoft.AspNetCore.Mvc;
using TestCaseApplication.Model;

namespace TestCaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IService _service;

        public ProjectController(IService service)
        {
            _service = service;
        }

        [HttpPost("addProjects")]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Invalid project data");
                }
                await _service.CreateProject(project);

                return Ok("Project added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("getAllProjects")]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            try
            {
                var projects = await _service.GetAllProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving projects: {ex.Message}");
            }
        }

    }
}
