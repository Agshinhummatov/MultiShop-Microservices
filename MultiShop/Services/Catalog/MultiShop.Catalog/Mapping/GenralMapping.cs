﻿using AutoMapper;
using MultiShop.Catalog.Dtos.FeatureDTOs;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.DTOs.BrandDTOs;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.DTOs.OfferDiscountDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
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
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();


            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();



            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();



        }
    }
}
