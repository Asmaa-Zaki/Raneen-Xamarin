using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    public class Categories
    {
        public catData data;
    }
    public class catData
    {
        public List<catItems> data;
    }
    public class catItems
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
