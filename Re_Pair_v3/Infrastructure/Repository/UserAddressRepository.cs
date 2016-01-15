using CoderCamps.Infrastructure.Repository;
using Re_Pair_v3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Infrastructure.Repository
{
    public class UserAddressRepository: GenericRepository<UserAddress>
    {

        public UserAddressRepository(DbContext db) : base(db) { }

        protected override IQueryable<UserAddress> Include(IQueryable<UserAddress> query)
        {
            return query.Include(a => a.User);
        }

        public IList<UserAddress> FindByLastName(string lastname)
        {
            return (from a in Table
                    where a.LastName == lastname
                    select a).ToList();
        }

        public IList<UserAddress> FindByUser(string username)
        {
            return (from a in Table
                    where a.User.UserName == username
                    select a).ToList();
        }

        public UserAddress FindById(int id, string username)
        {
            return (from a in Table
                    where a.Id==id && a.User.UserName == username
                    select a).FirstOrDefault();
        }
    }
}