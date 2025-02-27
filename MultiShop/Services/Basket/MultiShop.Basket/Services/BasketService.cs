﻿using MultiShop.Basket.Constants;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Exceptions;
using MultiShop.Basket.Services.Interfaces;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasketAsync(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (existBasket.IsNullOrEmpty)
            {
                throw new BasketNotFoundException(ErrorMessages.BasketNotFound);
            }

            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            if (basketTotalDto == null || string.IsNullOrEmpty(basketTotalDto.UserId))
            {
                throw new ArgumentException(ErrorMessages.InvalidBasket);
            }

            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
