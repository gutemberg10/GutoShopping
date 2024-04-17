using GutoShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GutoShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        public long CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CardHeader { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Column("count")]
        public int Count { get; set; }
    }
}
