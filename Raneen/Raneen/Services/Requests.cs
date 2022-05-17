using Newtonsoft.Json;
using Raneen.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raneen.Services
{
    internal class Requests
    {
        public const string ProductsURL = "https://student.valuxapps.com/api/categories/";
        public const string CategoryURL = "https://student.valuxapps.com/api/categories";
        public const string ProductURL = "https://student.valuxapps.com/api/products";
        public const string BannersURL = "https://student.valuxapps.com/api/banners";
        public const string HomeURL = "https://student.valuxapps.com/api/home";

        HttpClient httpClient = new HttpClient();

        public async Task<Categories> GetCategories()
        {
            string allCategoriesasString = await httpClient.GetStringAsync(CategoryURL);
            Categories allCat = JsonConvert.DeserializeObject<Categories>(allCategoriesasString);
            return allCat;
        }
        public async Task<cat> GetProducts(string id)
        {
            string allProductsPerCategory = await httpClient.GetStringAsync(ProductsURL + id);
            cat allProducts = JsonConvert.DeserializeObject<cat>(allProductsPerCategory);
            return allProducts;
        }
        public async Task<cat> GetAllProducts()
        {
            string allProductsasString = await httpClient.GetStringAsync(ProductURL);
            cat allProducts = JsonConvert.DeserializeObject<cat>(allProductsasString);
            return allProducts;
        }
        public async Task<Banners> GetBanners()
        {
            string allBannersasString = await httpClient.GetStringAsync(BannersURL);
            Banners allBanners = JsonConvert.DeserializeObject<Banners>(allBannersasString);
            return allBanners;
        }

        public async Task<HomeData> GetHomeData()
        {
            string homeasString = await httpClient.GetStringAsync(HomeURL);
            HomeData homeData = JsonConvert.DeserializeObject<HomeData>(homeasString);
            return homeData;
        }

    }
}
