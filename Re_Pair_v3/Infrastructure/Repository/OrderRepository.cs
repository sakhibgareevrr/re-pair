using CoderCamps.Infrastructure.Repository;
using Re_Pair_v3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Infrastructure.Repository
{
    public class OrderRepository: GenericRepository<Order>
    {

        public OrderRepository(DbContext db) : base(db) { }

        protected override IQueryable<Order> Include(IQueryable<Order> query)
        {
            return query.Include(o => o.Customer.UserAddresses)
                        .Include(o => o.Business);
        }

        public Order FindByIdBusiness(int id, string businessusername)
        {
            return (from o in Table
                    where o.Id == id && o.Business.UserName == businessusername
                    select o).FirstOrDefault();
        }

        public Order FindByIdCustomer(int id, string customerusername)
        {
            return (from o in Table
                    where o.Id == id && o.Customer.UserName == customerusername
                    select o).FirstOrDefault();
        }

        public IList<Order> FindByCustomerId(string customerid)
        {
            return (from o in Table
                    where o.Customer.Id == customerid
                    select o).ToList();
        }

        public IList<Order> FindByCustomerUserName(string customerusername)
        {
            return (from o in Table
                    where o.Customer.UserName == customerusername
                    select o).ToList();
        }

        public IList<Order> FindByCustomerEmail(string customeremail)
        {
            return (from o in Table
                    where o.Customer.Email == customeremail
                    select o).ToList();
        }

        public IList<Order> FindByBusinessId(string id)
        {
            return (from o in Table
                    where o.Business.Id == id
                    select o).ToList();
        }

        public IList<Order> FindByBusinessUserName(string businessusername)
        {
            return (from o in Table
                    where o.Customer.UserName == businessusername
                    select o).ToList();
        }

        public IList<Order> FindByBusinessEmail(string businessemail)
        {
            return (from o in Table
                    where o.Business.Email == businessemail
                    select o).ToList();
        }

        public IList<Order> FindByUserName(string username)
        {
            return (from o in Table
                    where o.Business.UserName == username || o.Customer.UserName == username
                    select o).ToList();
        }

        public Order FindById(int id, string username)
        {
            return (from o in Table
                    where o.Id == id && (o.Business.UserName==username || o.Customer.UserName==username)
                    select o).FirstOrDefault();
        }



    }
}