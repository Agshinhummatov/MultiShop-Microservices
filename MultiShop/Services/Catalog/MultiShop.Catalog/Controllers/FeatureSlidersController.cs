using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _featureSliderService = FeatureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no data found for the given id
            }
            return Ok(values); // HTTP 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var featureSlider = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            if (featureSlider == null)
            {
                return NotFound(); // HTTP 404 Not Found if the feature slider does not exist
            }

            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var existingFeatureSlider = await _featureSliderService.GetByIdFeatureSliderAsync(updateFeatureSliderDto.FeatureSliderId);
            if (existingFeatureSlider == null)
            {
                return NotFound(); // HTTP 404 Not Found if the feature slider does not exist
            }

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return NoContent();
        }
    }
}
