using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    public class Products
    {
        public Data data;

    }
    public class Data
    {
        public List<Items> data;
    }
    public class Items
    {
        public int id { get; set; }
        public double price { get; set; }
        public double old_price { get; set; }
        public double discount { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> images { get; set; }
        public bool in_favorites { get; set; }
        public bool in_cart { get; set; }
    }



}