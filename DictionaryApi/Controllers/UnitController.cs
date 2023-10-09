using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVocabulary(Unit obj)
        {
            try
            {
                var unit = await _unitService.AddUnitAsync(obj);
                return Ok(unit);
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
                var unit = await _unitService.GetAllUnitAsync();
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVocabularyById(string id)
        {
            try
            {
                var unit = await _unitService.GetUnitByIdAsync(id);
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUnit(string id, Unit obj)
        {
            try
            {
                var unit = await _unitService.UpdateUnitAsync(id, obj);
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVocabulary(string id)
        {
            try
            {
                var unit = await _unitService.RemoveUnitAsync(id);
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
