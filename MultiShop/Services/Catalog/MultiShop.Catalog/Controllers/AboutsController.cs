using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService AboutService)
        {
            _aboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await _aboutService.GetByIdAboutAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no About found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var existingAbout = await _aboutService.GetByIdAboutAsync(id);
            if (existingAbout == null)
            {
                return NotFound(); // HTTP 404 Not Found if the About doesn't exist
            }

            await _aboutService.DeleteAboutAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var existingAbout = await _aboutService.GetByIdAboutAsync(updateAboutDto.AboutId);
            if (existingAbout == null)
            {
                return NotFound(); // HTTP 404 Not Found if the About doesn't exist
            }

            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
