using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Constants;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        // GET: api/CargoOperations
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CargoOperationList()
        {
            try
            {
                var values = _cargoOperationService.TGetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoOperationMessages.ServerError, error = ex.Message });
            }
        }

        // POST: api/CargoOperations
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCargoOperation([FromBody] CreateCargoOperationDto createCargoOperationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = CargoOperationMessages.InvalidModelState });
            }

            try
            {
                CargoOperation cargoOperation = new CargoOperation
                {
                    Barcode = createCargoOperationDto.Barcode,
                    Description = createCargoOperationDto.Description,
                    OperationDate = createCargoOperationDto.OperationDate
                };

                _cargoOperationService.TInsert(cargoOperation);
                return CreatedAtAction(nameof(GetCargoOperationById), new { id = cargoOperation.CargoOperationId }, cargoOperation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoOperationMessages.CargoOperationCreationFailed, error = ex.Message });
            }
        }

        // GET: api/CargoOperations/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCargoOperationById(int id)
        {
            var cargoOperation = _cargoOperationService.TGetById(id);
            if (cargoOperation == null)
            {
                return NotFound(new { message = CargoOperationMessages.CargoOperationNotFound });
            }

            return Ok(new { message = CargoOperationMessages.CargoOperationFetched, data = cargoOperation });
        }

        // PUT: api/CargoOperations
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCargoOperation([FromBody] UpdateCargoOperationDto updateCargoOperationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = CargoOperationMessages.InvalidModelState });
            }

            try
            {
                var existingCargoOperation = _cargoOperationService.TGetById(updateCargoOperationDto.CargoOperationId);
                if (existingCargoOperation == null)
                {
                    return NotFound(new { message = CargoOperationMessages.CargoOperationNotFound });
                }

                existingCargoOperation.Barcode = updateCargoOperationDto.Barcode;
                existingCargoOperation.Description = updateCargoOperationDto.Description;
                existingCargoOperation.OperationDate = updateCargoOperationDto.OperationDate;

                _cargoOperationService.TUpdate(existingCargoOperation);
                return Ok(new { message = CargoOperationMessages.CargoOperationUpdated, data = existingCargoOperation });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoOperationMessages.CargoOperationUpdateFailed, error = ex.Message });
            }
        }

        // DELETE: api/CargoOperations/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveCargoOperation(int id)
        {
            try
            {
                var existingCargoOperation = _cargoOperationService.TGetById(id);
                if (existingCargoOperation == null)
                {
                    return NotFound(new { message = CargoOperationMessages.CargoOperationNotFound });
                }

                _cargoOperationService.TDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoOperationMessages.CargoOperationDeleteFailed, error = ex.Message });
            }
        }
    }
}
