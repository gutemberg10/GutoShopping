using AutoMapper;
using GutoShopping.CouponAPI.Data.ValueObjects;
using GutoShopping.CouponAPI.Model;
//using GutoShopping.ProductAPI.Data.ValueObjects;
//using GutoShopping.ProductAPI.Model;

namespace GutoShopping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
