using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestHistoryController : ControllerBase
    {
        private readonly ITestHistoryService _testHistoryService;
        public TestHistoryController(ITestHistoryService testHistoryService)
        {
            _testHistoryService = testHistoryService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestHistory(TestHistory obj)
        {
            try
            {
                var history = await _testHistoryService.AddTestHistoryAsync(obj);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllTestHistoryOfUser(string userId)
        {
            try
            {
                var history = await _testHistoryService.GetAllTestHistoryOfUserAsync(userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestHistory(string id)
        {
            try
            {
                var history = await _testHistoryService.RemoveTestHistoryAsync(id);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
