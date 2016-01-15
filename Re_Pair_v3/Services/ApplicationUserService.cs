using Microsoft.AspNet.Identity.EntityFramework;
using Re_Pair_v3.Infrastructure.Repository;
using Re_Pair_v3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class ApplicationUserService
    {
        private UserAddressRepository _userAddressRepo;

        private ApplicationUserManager _userManager;

        public ApplicationUserService(UserAddressRepository userAddressRepo, DbContext context)
        {
            _userAddressRepo = userAddressRepo;

            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
        }

    }
}