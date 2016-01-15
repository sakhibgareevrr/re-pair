using Re_Pair_v3.Models;
using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Presentation.Models
{
    public class RegisterBusinessBindingModel : RegisterBindingModel
    {

        public string CompanyName { get; set; }

        public string ServiceCategory { get; set; }

        public string Description { get; set; }

        public UserAddressDTO PrimaryAddress { get; set; }

    }
}