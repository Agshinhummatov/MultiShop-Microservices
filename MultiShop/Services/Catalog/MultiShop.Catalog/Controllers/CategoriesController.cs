using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Services.CategoryServices;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
          var values =  await  _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no category found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var existingCategory = await _categoryService.GetByIdCategoryAsync(id);
            if (existingCategory == null)
            {
                return NotFound(); // HTTP 404 Not Found if the category doesn't exist
            }

            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = await _categoryService.GetByIdCategoryAsync(updateCategoryDto.CategoryId);
            if (existingCategory == null)
            {
                return NotFound(); // HTTP 404 Not Found if the category doesn't exist
            }

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
