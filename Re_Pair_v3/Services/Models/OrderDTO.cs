using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Services
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public BusinessUserDTO Business { get; set; }

        public CustomerUserDTO Customer { get; set; }

        public string ServiceName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public decimal Price { get; set; }

        public int ServiceQuality { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompleted { get; set; }

    }
}