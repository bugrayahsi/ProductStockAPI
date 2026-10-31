using AutoMapper;
using ProductStockAPI.DTOs.Products;
using ProductStockAPI.Models;

namespace ProductStockAPI.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();
        }
    }
}