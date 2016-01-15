using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Re_Pair_v3.Domain.Models;
using System.Collections.Generic;

namespace Re_Pair_v3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public IList<UserAddress> UserAddresses { get; set; }
    }

    public class BusinessUser : ApplicationUser
    {
        public string CompanyName { get; set; }

        public string ServiceCategory { get; set; }

        public string Description { get; set; }

        public IList<Order> Orders { get; set; }
    }

    public class CustomerUser : ApplicationUser
    {
        public IList<Order> Orders { get; set; }
    }


}