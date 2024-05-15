using GutoShopping.CouponAPI.Data.ValueObjects;

namespace GutoShopping.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string CouponCode);
    }
}
