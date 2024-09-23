using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;
using System.Reflection;

namespace MultiShop.Catalog.Registration
{
    public static class ServiceRegistration
    {
        public static void AddCatalogServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register category, product, product detail, and product image services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();

            // Configure DatabaseSettings from the app's configuration
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            // Register IDatabaseSettings to provide access to the configured DatabaseSettings
            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            // Register AutoMapper for object mapping
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
