using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreService.Models
{
    public class Product
    {
        public String category { get; set; }
        public String price { get; set; }
        public Boolean stocked { get; set; }
        public String name { get; set; }

    }
}