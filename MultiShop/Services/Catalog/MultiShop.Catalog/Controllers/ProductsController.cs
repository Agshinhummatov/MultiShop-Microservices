using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Services.ProductServices;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatgeoyrById(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var existingProduct = await _productService.GetByIdProductAsync(id);
            if (existingProduct == null)
            {
                return NotFound(); // HTTP 404 Not Found if the product does not exist
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productService.GetByIdProductAsync(updateProductDto.ProductId);
            if (existingProduct == null)
            {
                return NotFound(); // HTTP 404 Not Found if the product does not exist
            }

            await _productService.UpdateProductAsync(updateProductDto);
            return NoContent();
        }


        [HttpGet("ProductListWithCategory")]

        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategoryByCategoryId")]

        public async Task<IActionResult> ProductListWithCategoryByCategoryId( string categoryId)
        {
            var values = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(categoryId);
            return Ok(values);
        }
    }
}
