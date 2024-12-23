using AutoMapper;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Mapping
{
    public class GenralMapping : Profile
    {
        public GenralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();


            CreateMap<ProductImage,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage,CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,GetByIdProductImageDto>().ReverseMap();



            CreateMap<FeatureSlider,ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,GetByIdFeatureSliderDto>().ReverseMap();






        }
    }
}
