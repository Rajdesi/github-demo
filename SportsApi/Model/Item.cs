using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApi.Model
{
    public class Item
    {
        
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemColor { get; set; }
        public string ItemSize { get; set; }
        public string price { get; set; }
    }
}
