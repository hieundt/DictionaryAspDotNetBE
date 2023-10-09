using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteVocabularyController : ControllerBase
    {
        private readonly IFavoriteVocabularyService _favoriteVocaService;
        public FavoriteVocabularyController(IFavoriteVocabularyService favoriteVocaService)
        {
            _favoriteVocaService = favoriteVocaService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVocabulary(FavoriteVocabulary obj)
        {
            try
            {
                var favoriteVoca = await _favoriteVocaService.AddFavoriteVocabularyAsync(obj);
                return Ok(favoriteVoca);
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
                var favoriteVoca = await _favoriteVocaService.GetAllFavoriteVocabularyOfUserAsync(unitId);
                return Ok(favoriteVoca);
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
                var favoriteVoca = await _favoriteVocaService.RemoveFavoriteVocabularyAsync(id);
                return Ok(favoriteVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
