using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@code", createDiscountCouponDto.Code);
            parametrs.Add("@rate", createDiscountCouponDto.Rate);
            parametrs.Add("@isActive", createDiscountCouponDto.IsActive);
            parametrs.Add("@validDate", createDiscountCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }

        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parametrs = new DynamicParameters();
            parametrs.Add("couponId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }



        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";

            var paramerts = new DynamicParameters();

            paramerts.Add("couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, paramerts);

            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@code", updateDiscountCouponDto.Code);
            parametrs.Add("@rate", updateDiscountCouponDto.Rate);
            parametrs.Add("@isActive", updateDiscountCouponDto.IsActive);
            parametrs.Add("@validDate", updateDiscountCouponDto.ValidDate);
            parametrs.Add("@couponId", updateDiscountCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }

}
