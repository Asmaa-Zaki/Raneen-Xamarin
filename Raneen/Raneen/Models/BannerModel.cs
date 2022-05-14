using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{

    class Banners
    {
        public List<BannerModel> data;

    }

    public class BannerModel
    {
        public int id { get; set; }
        public string image { get; set; }
        public string category { get; set; }
        public string product { get; set; }

    }
}
