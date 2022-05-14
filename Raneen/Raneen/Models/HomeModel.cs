using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{

    public class HomeData
    {
        public HomeModel data;
    }

    public class HomeModel
    {
        public List<BannerModel> banners;
        public List<ProductModel> products;
        public string ad { get; set; }
    }

}
