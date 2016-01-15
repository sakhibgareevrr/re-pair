using Re_Pair_v3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Re_Pair_v3.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        
        public BusinessUser Business { get; set; }

        
        public CustomerUser Customer { get; set; }

        public string ServiceName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public decimal Price { get; set; }

        public int ServiceQuality { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompleted { get; set; }

    }
}