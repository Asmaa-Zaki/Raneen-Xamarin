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
        public const string URL = "https://fakestoreapi.com/products";

        HttpClient httpClient = new HttpClient();

        ObservableCollection<Products> allProducts = new ObservableCollection<Products>();

        public ProductPage()
        {
            InitializeComponent();

        }


        private async void load(object sender, EventArgs e)
        {
            string allProductsasString = await httpClient.GetStringAsync(URL);
          
            allProducts = JsonConvert.DeserializeObject<ObservableCollection<Products>>(allProductsasString); 

            productName.Text = allProducts[1].title;
            productImage.Source = allProducts[1].image;
        }
    }
}   