using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class UserAddressDTO
    {

        public int Id { get; set; }

        public ApplicationUserDTO User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

    }
}