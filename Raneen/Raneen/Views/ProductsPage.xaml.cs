using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raneen.Models;
using Raneen.Services;
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
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetProducts();
            ListViewTile.ItemsSource = categoriesList.data.data;
            this.BindingContext = categoriesList.data.data;
        }


    }
}