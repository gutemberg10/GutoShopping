using GutoShopping.IdentityServer.Configuration;
using GutoShopping.IdentityServer.Model;
using GutoShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GutoShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ProductContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(ProductContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin))
                .GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client))
                            .GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "gutemberg-admin",
                Email = "gutemberg-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (88) 992399623",
                FirstName = "Gutemberg",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Guto123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "gutemberg-client",
                Email = "gutemberg-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (88) 992399623",
                FirstName = "Gutemberg",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Guto123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
