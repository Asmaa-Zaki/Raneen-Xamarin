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
        public List<ProductModel> data;
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