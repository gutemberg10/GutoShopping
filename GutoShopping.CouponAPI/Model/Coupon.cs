using GutoShopping.CouponAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GutoShopping.CouponAPI.Model
{
    [Table("coupon")]
    public class Coupon : BaseEntity
    {
        [Column("coupon_Code")]
        [Required]
        [StringLength(30)]
        public string CouponCode { get; set; }

        [Column("discount_Amount")]
        [Required]
        public decimal DiscountAmount { get; set; }
    }
}
