using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public IList<UserAddressDTO> UserAddresses { get; set; }

    }
}