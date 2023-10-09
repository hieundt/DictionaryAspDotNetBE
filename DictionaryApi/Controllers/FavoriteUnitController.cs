using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteUnitController : ControllerBase
    {
        private readonly IFavoriteUnitService _favoriteUnitService;
        public FavoriteUnitController(IFavoriteUnitService favoriteUnitService)
        {
            _favoriteUnitService = favoriteUnitService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVocabulary(FavoriteUnit obj)
        {
            try
            {
                var favoriteVoca = await _favoriteUnitService.AddFavoriteUnitAsync(obj);
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
                var favoriteVoca = await _favoriteUnitService.GetAllFavoriteUnitOfUserAsync(unitId);
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
                var favoriteVoca = await _favoriteUnitService.RemoveFavoriteUnitAsync(id);
                return Ok(favoriteVoca);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
