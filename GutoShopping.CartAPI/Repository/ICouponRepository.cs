using GutoShopping.CartAPI.Data.ValueObjects;

namespace GutoShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string CouponCode, string token);
    }
}
