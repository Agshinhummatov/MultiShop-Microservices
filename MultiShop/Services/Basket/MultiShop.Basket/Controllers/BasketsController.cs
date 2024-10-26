using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Constants;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services.Interfaces;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketServices;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketServices, ILoginService loginService)
        {
            _basketServices = basketServices;
            _loginService = loginService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            try
            {
               
                var basket = await _basketServices.GetBasketAsync(_loginService.GetUserId);

                if (basket == null)
                {
                    return NotFound(new { message = ErrorMessages.BasketNotFound });
                }

                return Ok(basket);
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new { message = ErrorMessages.FetchBasketError, details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            if (basketTotalDto == null)
            {
                return BadRequest(new { message = ErrorMessages.NullBasketData });
            }

            try
            {
                basketTotalDto.UserId = _loginService.GetUserId;

                await _basketServices.SaveBasketAsync(basketTotalDto);
                return Ok(new { message = ErrorMessages.BasketSavedSuccessfully });
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new { message = ErrorMessages.SaveBasketError, details = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            try
            {
          
                await _basketServices.DeleteBasketAsync(_loginService.GetUserId);
                return Ok(new { message = ErrorMessages.BasketDeletedSuccessfully });
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new { message = ErrorMessages.DeleteBasketError, details = ex.Message });
            }
        }
    }
}
