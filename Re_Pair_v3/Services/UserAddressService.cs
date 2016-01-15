using Re_Pair_v3.Domain.Models;
using Re_Pair_v3.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class UserAddressServices
    {
        private UserAddressRepository _repo;

        public UserAddressServices(UserAddressRepository repo)
        {
            _repo = repo;
        }

        public IList<UserAddressDTO> FindByLastName(string lastname)
        {
            return (from a in _repo.FindByLastName(lastname)
                    select Map(a)).ToList();
        }

        public IList<UserAddressDTO> List(string username)
        {
            return (from a in _repo.FindByUser(username)
                    select Map(a)).ToList();
        }

        public UserAddressDTO FindById(int id, string username)
        {
            return Map(_repo.FindById(id, username));
        }

        private UserAddressDTO Map(UserAddress dbUserAddress)
        {
            return dbUserAddress != null ? new UserAddressDTO()
            {
                Id = dbUserAddress.Id,
                User = new ApplicationUserDTO()
                {
                    Id = dbUserAddress.User.Id,
                    UserName = dbUserAddress.User.UserName
                },
                FirstName = dbUserAddress.FirstName,
                LastName = dbUserAddress.LastName,
                Phone = dbUserAddress.Phone,
                AddressLine1 = dbUserAddress.AddressLine1,
                AddressLine2 = dbUserAddress.AddressLine2,
                City = dbUserAddress.City,
                State = dbUserAddress.State,
                Zipcode = dbUserAddress.Zipcode
            } : null;
        }




    }
}