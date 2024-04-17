using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GutoShopping.IdentityServer.Model.Context
{
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        protected ProductContext()
        {
        }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        
    }
}
