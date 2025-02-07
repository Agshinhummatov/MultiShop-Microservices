using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _specialOfferService = SpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no SpecialOffer found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var existingSpecialOffer = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            if (existingSpecialOffer == null)
            {
                return NotFound(); // HTTP 404 Not Found if the SpecialOffer doesn't exist
            }

            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var existingSpecialOffer = await _specialOfferService.GetByIdSpecialOfferAsync(updateSpecialOfferDto.SpecialOfferId);
            if (existingSpecialOffer == null)
            {
                return NotFound(); // HTTP 404 Not Found if the SpecialOffer doesn't exist
            }

            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
