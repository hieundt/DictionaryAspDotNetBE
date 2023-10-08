using DictionaryApi.Domain;
using DictionaryApi.Repository;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService _vocabularyService;
        public VocabularyController(IVocabularyService vocabularyService)
        {
            _vocabularyService = vocabularyService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVocabulary(Vocabulary obj)
        {
            try
            {
                var vocabulary = await _vocabularyService.AddVocabularyAsync(obj);
                return Ok(vocabulary);
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
                var vocabularies = await _vocabularyService.GetAllVocabularyAsync();
                return Ok(vocabularies);
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
                var vocabulary = await _vocabularyService.GetVocabularyByIdAsync(id);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdataVocabulary(string id, Vocabulary obj)
        {
            try
            {
                var vocabulary = await _vocabularyService.UpdateVocabularyAsync(id,obj);
                return Ok(vocabulary);
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
                var vocabulary = await _vocabularyService.RemoveVocabularyAsync(id);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
