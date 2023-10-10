using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTest(Test obj)
        {
            try
            {
                var test = await _testService.AddTestAsync(obj);
                return Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTest()
        {
            try
            {
                var tests = await _testService.GetAllTestAsync();
                return Ok(tests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestById(string id)
        {
            try
            {
                var test = await _testService.GetTestByIdAsync(id);
                return Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTest(string id, Test obj)
        {
            try
            {
                var Test = await _testService.UpdateTestAsync(id, obj);
                return Ok(Test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTest(string id)
        {
            try
            {
                var test = await _testService.RemoveTestAsync(id);
                return Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
