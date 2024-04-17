using AutoMapper;
using GutoShopping.ProductAPI.Data.ValueObjects;
using GutoShopping.ProductAPI.Model;

namespace GutoShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
