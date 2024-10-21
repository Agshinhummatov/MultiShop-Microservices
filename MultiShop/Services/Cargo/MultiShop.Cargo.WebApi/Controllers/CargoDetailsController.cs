using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Constants;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        
            private readonly ICargoDetailService _cargoDetailService;

            public CargoDetailsController(ICargoDetailService cargoDetailService)
            {
                _cargoDetailService = cargoDetailService;
            }

            // GET: api/CargoDetails
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public IActionResult CargoDetailList()
            {
                try
                {
                    var values = _cargoDetailService.TGetAll();
                    return Ok(values);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoDetailMessages.ServerError, error = ex.Message });
                }
            }

            // POST: api/CargoDetails
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult CreateCargoDetail([FromBody] CreateCargoDetailDto createCargoDetailDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = CargoDetailMessages.InvalidModelState });
                }

                try
                {
                    CargoDetail cargoDetail = new CargoDetail
                    {
                        SenderCustomer = createCargoDetailDto.SenderCustomer,
                        ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                        Barcode = createCargoDetailDto.Barcode,
                        CargoCompanyId = createCargoDetailDto.CargoCompanyId
                    };

                    _cargoDetailService.TInsert(cargoDetail);
                    return CreatedAtAction(nameof(GetCargoDetailById), new { id = cargoDetail.CargoDetailId }, cargoDetail);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoDetailMessages.CargoDetailCreationFailed, error = ex.Message });
                }
            }

            // DELETE: api/CargoDetails/{id}
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult RemoveCargoDetail(int id)
            {
                try
                {
                    var existingCargoDetail = _cargoDetailService.TGetById(id);
                    if (existingCargoDetail == null)
                    {
                        return NotFound(new { message = CargoDetailMessages.CargoDetailNotFound });
                    }

                    _cargoDetailService.TDelete(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoDetailMessages.CargoDetailDeleteFailed, error = ex.Message });
                }
            }

            // GET: api/CargoDetails/{id}
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult GetCargoDetailById(int id)
            {
                var cargoDetail = _cargoDetailService.TGetById(id);
                if (cargoDetail == null)
                {
                    return NotFound(new { message = CargoDetailMessages.CargoDetailNotFound });
                }

                return Ok(new { message = CargoDetailMessages.CargoDetailFetched, data = cargoDetail });
            }

            // PUT: api/CargoDetails
            [HttpPut]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public IActionResult UpdateCargoDetail([FromBody] UpdateCargoDetailDto updateCargoDetailDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = CargoDetailMessages.InvalidModelState });
                }

                try
                {
                    var existingCargoDetail = _cargoDetailService.TGetById(updateCargoDetailDto.CargoDetailId);
                    if (existingCargoDetail == null)
                    {
                        return NotFound(new { message = CargoDetailMessages.CargoDetailNotFound });
                    }

                    existingCargoDetail.SenderCustomer = updateCargoDetailDto.SenderCustomer;
                    existingCargoDetail.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
                    existingCargoDetail.Barcode = updateCargoDetailDto.Barcode;
                    existingCargoDetail.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;

                    _cargoDetailService.TUpdate(existingCargoDetail);
                    return Ok(new { message = CargoDetailMessages.CargoDetailUpdated, data = existingCargoDetail });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = CargoDetailMessages.CargoDetailUpdateFailed, error = ex.Message });
                }
            }
        
    }
}
