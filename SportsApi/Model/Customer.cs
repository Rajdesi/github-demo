using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApi.Model
{
    public class Customer
    {
        public String Name { get; set; }
        public int CustomerId { get; set; }
        public String ContactNumber { get; set; }
        public String Address { get; set; }
        public String EmailId { get; set; }
    }
}
