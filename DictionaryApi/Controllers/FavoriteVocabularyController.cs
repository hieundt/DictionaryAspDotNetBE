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
        public async Task<IActionResult> CreateFavoriteVocabulary(FavoriteVocabulary obj)
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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllFavoriteVocabularyOfUser(string userId)
        {
            try
            {
                var favoriteVoca = await _favoriteVocaService.GetAllFavoriteVocabularyOfUserAsync(userId);
                return Ok(favoriteVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteVocabulary(string favoVocaId)
        {
            try
            {
                var favoriteVoca = await _favoriteVocaService.RemoveFavoriteVocabularyAsync(favoVocaId);
                return Ok(favoriteVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
