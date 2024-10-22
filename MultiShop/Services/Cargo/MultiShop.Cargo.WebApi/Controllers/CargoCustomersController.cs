using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Constants;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        // GET: api/CargoCustomers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CargoCustomerList()
        {
            try
            {
                var values = _cargoCustomerService.TGetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCustomerMessages.ServerError, error = ex.Message });
            }
        }

        // POST: api/CargoCustomers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCargoCustomer([FromBody] CreateCargoCustomerDto createCargoCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = CargoCustomerMessages.InvalidModelState });
            }

            try
            {
                CargoCustomer cargoCustomer = new CargoCustomer
                {
                    Name = createCargoCustomerDto.Name,
                    Surname = createCargoCustomerDto.Surname,
                    Email = createCargoCustomerDto.Email,
                    Phone = createCargoCustomerDto.Phone,
                    District = createCargoCustomerDto.District,
                    City = createCargoCustomerDto.City,
                    Address = createCargoCustomerDto.Address
                };

                _cargoCustomerService.TInsert(cargoCustomer);
                return CreatedAtAction(nameof(GetCargoCustomerById), new { id = cargoCustomer.CargoCustomerId }, cargoCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCustomerMessages.CargoCustomerCreationFailed, error = ex.Message });
            }
        }

        // DELETE: api/CargoCustomers/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveCargoCustomer(int id)
        {
            try
            {
                var existingCustomer = _cargoCustomerService.TGetById(id);
                if (existingCustomer == null)
                {
                    return NotFound(new { message = CargoCustomerMessages.CargoCustomerNotFound });
                }

                _cargoCustomerService.TDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCustomerMessages.CargoCustomerDeleteFailed, error = ex.Message });
            }
        }

        // GET: api/CargoCustomers/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCargoCustomerById(int id)
        {
            var cargoCustomer = _cargoCustomerService.TGetById(id);
            if (cargoCustomer == null)
            {
                return NotFound(new { message = CargoCustomerMessages.CargoCustomerNotFound });
            }

            return Ok(new { message = CargoCustomerMessages.CargoCustomerFetched, data = cargoCustomer });
        }

        // PUT: api/CargoCustomers
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCargoCustomer([FromBody] UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = CargoCustomerMessages.InvalidModelState });
            }

            try
            {
                var existingCustomer = _cargoCustomerService.TGetById(updateCargoCustomerDto.CargoCustomerId);
                if (existingCustomer == null)
                {
                    return NotFound(new { message = CargoCustomerMessages.CargoCustomerNotFound });
                }

                existingCustomer.Name = updateCargoCustomerDto.Name;
                existingCustomer.Surname = updateCargoCustomerDto.Surname;
                existingCustomer.Email = updateCargoCustomerDto.Email;
                existingCustomer.Phone = updateCargoCustomerDto.Phone;
                existingCustomer.District = updateCargoCustomerDto.District;
                existingCustomer.City = updateCargoCustomerDto.City;
                existingCustomer.Address = updateCargoCustomerDto.Address;

                _cargoCustomerService.TUpdate(existingCustomer);
                return Ok(new { message = CargoCustomerMessages.CargoCustomerUpdated, data = existingCustomer });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoCustomerMessages.CargoCustomerUpdateFailed, error = ex.Message });
            }
        }
    }
}
