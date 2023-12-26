using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitHasVocabularyController : ControllerBase
    {
        private readonly IUnitHasVocabularyService _unitVocaService;
        public UnitHasVocabularyController(IUnitHasVocabularyService unitVocaService)
        {
            _unitVocaService = unitVocaService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVocabulary(UnitHasVocabulary obj)
        {
            try
            {
                var unitVoca = await _unitVocaService.AddUnitHasVocabularyAsync(obj);
                return Ok(unitVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{unitId}")]
        public async Task<IActionResult> GetAllVocabularyOfUnit(string unitId)
        {
            try
            {
                var unitVoca = await _unitVocaService.GetAllVocabularyOfUnitAsync(unitId);
                return Ok(unitVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocabulary(string id)
        {
            try
            {
                var unitVoca = await _unitVocaService.RemoveUnitHasVocabularyAsync(id);
                return Ok(unitVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
