using DictionaryApi.Domain;
using DictionaryApi.Service;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreateFavoriteUnit(FavoriteUnit obj)
        {
            try
            {
                var favoriteUnit = await _favoriteUnitService.AddFavoriteUnitAsync(obj);
                return Ok(favoriteUnit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllFavoriteUnitOfUser(string userId)
        {
            try
            {
                var favoriteUnit = await _favoriteUnitService.GetAllFavoriteUnitOfUserAsync(userId);
                return Ok(favoriteUnit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteUnit(string id)
        {
            try
            {
                var favoriteUnit = await _favoriteUnitService.RemoveFavoriteUnitAsync(id);
                return Ok(favoriteUnit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
