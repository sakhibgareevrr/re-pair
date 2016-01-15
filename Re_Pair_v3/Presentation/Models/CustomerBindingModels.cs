using Re_Pair_v3.Models;
using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Presentation.Models
{
    public class RegisterCustomerBindingModel : RegisterBindingModel
    {

        public UserAddressDTO PrimaryAddress { get; set; }

        public OrderDTO Order { get; set; }
    }
}