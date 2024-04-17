namespace GutoShopping.Web.Models
{
    public class CartDetailViewModel
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderViewModel CardHeader { get; set; }
        public long ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
