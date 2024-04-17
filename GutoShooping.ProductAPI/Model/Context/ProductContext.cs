using Microsoft.EntityFrameworkCore;

namespace GutoShopping.ProductAPI.Model.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Alexa",
                Price = 274,
                Description = "Echo Pop Smart speaker compacto com som envolvente e Alexa Cor Preta",
                CategoryName = "eletrônicos",
                ImageURL = "https://m.media-amazon.com/images/I/81WOd456CjL._AC_SY450_.jpg"
            });
        }
    }
}
