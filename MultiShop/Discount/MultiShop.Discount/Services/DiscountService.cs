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

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
            var parametrs = new DynamicParameters();
            parametrs.Add("@code", createCouponDto.Code);
            parametrs.Add("@rate", createCouponDto.Rate);
            parametrs.Add("@isActive", createCouponDto.IsActive);
            parametrs.Add("@validDate", createCouponDto.ValidDate);
            using(var connection = _dapperContext.CreateConnection())
            {
              await connection.ExecuteAsync(query, parametrs);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parametrs = new DynamicParameters();
            parametrs.Add("couponId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }



        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";

            var paramerts = new DynamicParameters();

            paramerts.Add("couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                return  await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
               
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";

            var parametrs = new DynamicParameters();
            parametrs.Add("@code", updateCouponDto.Code);
            parametrs.Add("@rate", updateCouponDto.Rate);
            parametrs.Add("@isActive", updateCouponDto.IsActive);
            parametrs.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
