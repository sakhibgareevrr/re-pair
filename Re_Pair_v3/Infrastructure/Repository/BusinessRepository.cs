using CoderCamps.Infrastructure.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Re_Pair_v3.Domain.Models;
using Re_Pair_v3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Infrastructure.Repository
{
    public class BusinessRepository : GenericRepository<BusinessUser>
    {
        private ApplicationUserManager manager;

        public BusinessRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }

        protected override IQueryable<BusinessUser> Include(IQueryable<BusinessUser> query)
        {
            return query.Include(b => b.Orders)
                .Include(c => c.UserAddresses);
        }

        // Hide the single argument Add
        public new void Add(BusinessUser customer)
        {
            throw new InvalidOperationException("Please use Add(CustomerUser, string) to add Customers");
        }

        public void Add(BusinessUser business, string password)
        {
            manager.Create(business, password);
        }

        public BusinessUser FindById(string id, string businessusername)
        {
            return (from b in Table
                    where b.Id == id && b.UserName == businessusername
                    select b).FirstOrDefault();
        }

        public BusinessUser FindByBusinessUserName(string businessusername)
        {
            return (from b in Table
                    where b.UserName == businessusername
                    select b).FirstOrDefault();
        }

        public BusinessUser FindByBusinessEmail(string businessemail)
        {
            return (from b in Table
                    where b.UserName == businessemail
                    select b).FirstOrDefault();
        }

        public IList<BusinessUser> ListAll()
        {
            return (from b in Table
                    select b).ToList();
        }


    }
}