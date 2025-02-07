using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.Services.OfferDiscountService;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _OfferDiscountService;

        public OfferDiscountsController(IOfferDiscountService OfferDiscountService)
        {
            _OfferDiscountService = OfferDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _OfferDiscountService.GetAllOfferDiscountAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no OfferDiscount found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var existingOfferDiscount = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);
            if (existingOfferDiscount == null)
            {
                return NotFound(); // HTTP 404 Not Found if the OfferDiscount doesn't exist
            }

            await _OfferDiscountService.DeleteOfferDiscountAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var existingOfferDiscount = await _OfferDiscountService.GetByIdOfferDiscountAsync(updateOfferDiscountDto.OfferDiscountId);
            if (existingOfferDiscount == null)
            {
                return NotFound(); // HTTP 404 Not Found if the OfferDiscount doesn't exist
            }

            await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
