using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddDiscountServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DapperContext>();
            services.AddScoped<IDiscountService, DiscountService>();


        }
    }
}
