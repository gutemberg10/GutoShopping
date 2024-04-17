using AutoMapper;
using GutoShopping.CartAPI.Data.ValueObjects;
using GutoShopping.CartAPI.Model;
//using GutoShopping.ProductAPI.Data.ValueObjects;
//using GutoShopping.ProductAPI.Model;

namespace GutoShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
