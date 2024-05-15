using GutoShopping.Web.Models;

namespace GutoShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
    }
}
