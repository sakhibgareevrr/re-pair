using Re_Pair_v3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Owin.BuilderProperties;
using Re_Pair_v3.Domain.Models;

namespace Re_Pair_v3.Infrastructure
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<CustomerUser> Customers { get; set; }
        public IDbSet<BusinessUser> Businesses { get; set; }
        public IDbSet<UserAddress> UserAddresses { get; set; }
        public IDbSet<Order> Orders { get; set; }

    }

}