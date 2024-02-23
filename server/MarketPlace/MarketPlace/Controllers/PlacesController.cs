using MarketPlace.API.Contracts.PlaceDTO;
using MarketPlace.Core.Interfaces.DataIntefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private IPlacesService _placesService;
        public PlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        } 

        [AllowAnonymous]
        [HttpGet("PlacesList")]
        public IActionResult PlacesList()
        {
            var response = _placesService.GetPlaces();
            return Ok(response);
        }

        [HttpPut("AddPlace")]
        public async Task<IActionResult> AddPlace(PlaceRequestDTO requestDTO)
        {
            var response = await _placesService.AddPlace(Guid.NewGuid(), requestDTO.City, requestDTO.Street);

            if (response.Item1 == Guid.Empty)
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [HttpPut("UpdatePlace")]
        public async Task<IActionResult> UpdatePlace(PlaceRequestDTO requestDTO)
        {
            var id = requestDTO.Id ?? Guid.Empty;

            if (id == Guid.Empty)
                return BadRequest($"Request place id cannot be null");

            var response = await _placesService.UpdatePlace(id, requestDTO.City, requestDTO.Street);

            if(response.Item1 == Guid.Empty)
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [HttpDelete("DeletePlace")]
        public async Task<IActionResult> DeletePlace(Guid id)
        {
            var response = await _placesService.DeletePlace(id);
            return Ok(response);
        }
    }
}