using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class CustomerUserDTO : ApplicationUserDTO
    {
        //public string Id { get; set; }

        //public string UserName { get; set; }

        public string Email { get; set; }

        public IList<OrderDTO> Orders { get; set; }

    }
}