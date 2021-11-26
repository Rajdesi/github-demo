using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApi.Model
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public String OrderAddress { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public string DeliveryDate { get; set; }
        public string PaymentMode { get; set; }
    }
}
