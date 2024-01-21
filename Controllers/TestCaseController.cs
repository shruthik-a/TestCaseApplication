using Microsoft.AspNetCore.Mvc;
using TestCaseApplication.Model;

namespace TestCaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestcaseController : ControllerBase
    {
        private readonly IService _service;

        public TestcaseController(IService service)
        {
            _service = service;
        }

        [HttpPost("Addition")]
        public async Task<IActionResult> PerformAddition([FromBody] TestCaseInputDto testCaseInput)
        {
            try
            {
                string result = await _service.PerformAddition(testCaseInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to perform addition");
            }
        }
        [HttpPost("Subtraction")]
        public async Task<IActionResult> PerformSubtraction([FromBody] TestCaseInputDto testCaseInput)
        {
            try
            {
                string result = await _service.PerformSubtraction(testCaseInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to perform addition");
            }
        }

        [HttpPost("Multiplication")]
        public async Task<IActionResult> PerformMultiplication([FromBody] TestCaseInputDto testCaseInput)
        {
            try
            {
                string result = await _service.PerformMultiplication(testCaseInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to perform addition");
            }
        }

        [HttpGet("getAllTestCases")]
        public async Task<IActionResult> GetAllTestCases()
        {
            try
            {
                List<TestCase> testCases = await _service.GetAllTestCases();
                return Ok(testCases);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get all test cases");
            }
        }



    }
}
