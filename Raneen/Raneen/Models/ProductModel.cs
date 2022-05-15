using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    public class ProductModel
    {
        [Unique]
        public int id { get; set; }
        public int count { get; set; }
        [Ignore]
        public double price { get; set; }
        [Ignore]
        public double old_price { get; set; }
        [Ignore]
        public double discount { get; set; }
        [Ignore]
        public string image { get; set; }
        [Ignore]
        public string name { get; set; }
        [Ignore]
        public string description { get; set; }
        public List<string> images;
        public bool in_favorites;
        public bool in_cart;
    }
}
