using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Item
    {
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
    }
}