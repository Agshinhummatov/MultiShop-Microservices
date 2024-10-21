using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Constants;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
            private readonly ICargoCompanyService _cargoCompanyService;

            public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
            {
                _cargoCompanyService = cargoCompanyService;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public IActionResult CargoCompanyList()
            {
                try
                {
                    var values = _cargoCompanyService.TGetAll();
                    return Ok(values);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCompanyMessages.ServerError, error = ex.Message });
                }
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult CreateCargoCompany([FromBody] CreateCargoCompanyDto createCargoCompanyDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = CargoCompanyMessages.InvalidModelState });
                }

                try
                {
                    CargoCompany cargoCompany = new CargoCompany
                    {
                        CargoCompanyName = createCargoCompanyDto.CargoCompanyName,
                    };
                    _cargoCompanyService.TInsert(cargoCompany);
                    return CreatedAtAction(nameof(GetCargoCompanyById), new { id = cargoCompany.CargoCompanyId }, cargoCompany);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCompanyMessages.CargoCompanyCreationFailed, error = ex.Message });
                }
            }

            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult RemoveCargoCompany(int id)
            {
                try
                {
                    var existingCompany = _cargoCompanyService.TGetById(id);
                    if (existingCompany == null)
                    {
                        return NotFound(new { message = CargoCompanyMessages.CargoCompanyNotFound });
                    }

                    _cargoCompanyService.TDelete(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCompanyMessages.CargoCompanyDeleteFailed, error = ex.Message });
                }
            }

            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult GetCargoCompanyById(int id)
            {
                var cargoCompany = _cargoCompanyService.TGetById(id);
                if (cargoCompany == null)
                {
                    return NotFound(new { message = CargoCompanyMessages.CargoCompanyNotFound });
                }

                return Ok(new { message = CargoCompanyMessages.CargoCompanyFetched, data = cargoCompany });
            }

            [HttpPut]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult UpdateCargoCompany([FromBody] UpdateCargoCompanyDto updateCargoCompanyDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = CargoCompanyMessages.InvalidModelState });
                }

                try
                {
                    var existingCompany = _cargoCompanyService.TGetById(updateCargoCompanyDto.CargoCompanyId);
                    if (existingCompany == null)
                    {
                        return NotFound(new { message = CargoCompanyMessages.CargoCompanyNotFound });
                    }

                    existingCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
                    _cargoCompanyService.TUpdate(existingCompany);
                    return Ok(new { message = CargoCompanyMessages.CargoCompanyUpdated, data = existingCompany });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCompanyMessages.CargoCompanyUpdateFailed, error = ex.Message });
                }
            }


    }

}

