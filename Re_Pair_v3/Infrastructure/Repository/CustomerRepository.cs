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
    public class CustomerRepository : GenericRepository<CustomerUser>
    {
        private ApplicationUserManager manager;

        public CustomerRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }

        protected override IQueryable<CustomerUser> Include(IQueryable<CustomerUser> query)
        {
            return query.Include(c => c.Orders)
                        
                         .Include(c => c.UserAddresses);
        }

        // Hide the single argument Add
        public new void Add(CustomerUser customer)
        {
            throw new InvalidOperationException("Please use Add(CustomerUser, string) to add Customers");
        }

        public void Add(CustomerUser customer, string password)
        {
            manager.Create(customer, password);
        }

        public CustomerUser FindById(string id, string customerusername)
        {
            return (from c in Table
                    where c.Id == id && c.UserName == customerusername
                    select c).FirstOrDefault();
        }

        public CustomerUser FindByCustomerUserName(string customerusername)
        {
            return (from c in Table
                    where c.UserName == customerusername
                    select c).FirstOrDefault();
        }

        //public IList<CustomerUser> FindByBusinessUserName(string businessusername)
        //{
        //    return (from c in Table
        //            from o in c.Orders
        //            where o.Business.UserName == businessusername
                    
        //            select c).ToList();
        //}

        public CustomerUser FindByCustomerEmail(string customeremail)
        {
            return (from c in Table
                    where c.UserName == customeremail
                    select c).FirstOrDefault();
        }


    }
}