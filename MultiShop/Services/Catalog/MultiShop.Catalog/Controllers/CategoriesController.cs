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
        public async Task<IActionResult> GetCatgeoyrById(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
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
            await _categoryService.DeleteCategoryAsync(id);
            return Ok(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok(StatusCodes.Status200OK);
        }
    }
}
