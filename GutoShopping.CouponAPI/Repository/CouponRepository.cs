using AutoMapper;
using GutoShopping.CouponAPI.Data.ValueObjects;
using GutoShopping.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GutoShopping.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ProductContext _context;
        private IMapper _mapper;

        public CouponRepository(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string CouponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == CouponCode);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
