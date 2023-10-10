using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;
        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOption(Option obj)
        {
            try
            {
                var option = await _optionService.AddOptionAsync(obj);
                return Ok(option);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVocabulary()
        {
            try
            {
                var options = await _optionService.GetAllOptionAsync();
                return Ok(options);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(string id)
        {
            try
            {
                var option = await _optionService.GetOptionByIdAsync(id);
                return Ok(option);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOption(string id)
        {
            try
            {
                var option = await _optionService.RemoveOptionAsync(id);
                return Ok(option);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
