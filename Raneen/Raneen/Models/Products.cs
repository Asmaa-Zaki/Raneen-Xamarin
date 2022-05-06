using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    class cat
    {
       public Data data;

    }
    class Data
    {
        public List<Items> data;
    }
    class Items
    {
        public int id { get; set; }
        public double price { get; set; }
        public double old_price { get; set; }
        public double discount { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> images;
        public bool in_favorites;
        public bool in_cart;
    }


    class catInf
    {
        public catData data;

    }
    class catData
    {
        public List<catItems> data;
    }
    class catItems
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}