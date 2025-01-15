using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountService;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
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
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IOfferDiscountService, OfferDiscountService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();

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
