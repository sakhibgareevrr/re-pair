using Re_Pair_v3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Presentation.Models
{

    public class OrderBindingModel
    {
        public string BusinessUserName { get; set; }

        public string CustomerUserName { get; set; }

        public string ServiceName { get; set; }

        public string OrderDate { get; set; }

        public string CompletionDate { get; set; }

        public decimal Price { get; set; }

        public int ServiceQuality { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompleted { get; set; }

    }
}