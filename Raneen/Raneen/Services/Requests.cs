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
        public const string ProductDetialesURL = "https://student.valuxapps.com/api/products/";
        public const string ProductsURL = "https://student.valuxapps.com/api/categories/";
        public const string CategoryURL = "https://student.valuxapps.com/api/categories";

        HttpClient httpClient = new HttpClient();

        public async Task<Categories> GetCategories()
        {
            string allCategoriesasString = await httpClient.GetStringAsync(CategoryURL);
            Categories allCat = JsonConvert.DeserializeObject<Categories>(allCategoriesasString);
            return allCat;
        }
        public async Task<Products> GetProducts(string id)
        {
            string allProductsasString = await httpClient.GetStringAsync(ProductsURL + id);
            Products allProducts = JsonConvert.DeserializeObject<Products>(allProductsasString);
            return allProducts;
        }

        public async Task<Products> GetProductDetiales(string id)
        {
            string allProductsasString = await httpClient.GetStringAsync(ProductsURL + id);
            Products allProducts = JsonConvert.DeserializeObject<Products>(allProductsasString);
            return allProducts;
        }



    }
}
