using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageServices;
using static System.Net.Mime.MediaTypeNames;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {

        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var images = await _productImageService.GetAllProductImageAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatgeoyrById(string id)
        {
            var image = await _productImageService.GetByIdProductImageAsync(id);
            if (image == null) return NotFound();
            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var existingImage = await _productImageService.GetByIdProductImageAsync(id);
            if (existingImage == null)
                return NotFound(); 

            await _productImageService.DeleteProductImageAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var existingImage = await _productImageService.GetByIdProductImageAsync(updateProductImageDto.ProductImageId);
            if (existingImage == null)
                return NotFound(); 
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return NoContent();
        }
    }
}
