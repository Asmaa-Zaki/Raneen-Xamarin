using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    internal class Products
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rate rating { get; set; }

    }

    class Rate
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
}
