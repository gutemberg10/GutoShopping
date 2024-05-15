using Microsoft.EntityFrameworkCore;

namespace GutoShopping.OrderAPI.Model.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<OrderHeader> Headers { get; set; } 
    }
}
