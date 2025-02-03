using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.Services.BrandServices;


namespace MultiShop.Catalog.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService BrandService)
        {
            _brandService = BrandService;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _brandService.GetAllBrandAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _brandService.GetByIdBrandAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no Brand found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var existingBrand = await _brandService.GetByIdBrandAsync(id);
            if (existingBrand == null)
            {
                return NotFound(); // HTTP 404 Not Found if the Brand doesn't exist
            }

            await _brandService.DeleteBrandAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var existingBrand = await _brandService.GetByIdBrandAsync(updateBrandDto.BrandId);
            if (existingBrand == null)
            {
                return NotFound(); // HTTP 404 Not Found if the Brand doesn't exist
            }

            await _brandService.UpdateBrandAsync(updateBrandDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
