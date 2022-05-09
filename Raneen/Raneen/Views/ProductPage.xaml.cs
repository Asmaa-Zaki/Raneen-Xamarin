using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raneen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public const string URL = "https://student.valuxapps.com/api/categories/44";
        public const string URL2 = "https://student.valuxapps.com/api/categories";

        HttpClient httpClient = new HttpClient();

        Products allProducts = new Products();
        Categories allCat = new Categories();


        public ProductPage()
        {
            InitializeComponent();
        }


        //products
        private async void load(object sender, EventArgs e)
        {
            string allProductsasString = await httpClient.GetStringAsync(URL);
            allProducts = JsonConvert.DeserializeObject<Products>(allProductsasString);
            await DisplayAlert("kkk", $"{allProducts.data.data[0].name}", "OK");

            productName.Text = allProducts.data.data[0].name;
            productName.TextColor = Color.Black;
            //  productImage.Source = allProducts.Products[0].Image;
        }


        //Categories
        private async void loadTany(object sender, EventArgs e)
        {
            string allProductsasString = await httpClient.GetStringAsync(URL2);
            allCat = JsonConvert.DeserializeObject<Categories>(allProductsasString);
            await DisplayAlert("kkk", $"{allCat.data.data[0].name}", "OK");

            productName.Text = allCat.data.data[0].name;
            productName.TextColor = Color.Black;
            //  productImage.Source = allProducts.Products[0].Image;
        }
    }
}