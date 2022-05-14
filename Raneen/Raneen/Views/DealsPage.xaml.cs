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
    public partial class DealsPage : ContentPage
    {

        public DealsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;

            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetCategories();
            CategoryTile.ItemsSource = categoriesList.data.data;
            var productsList = await httpClient.GetProducts("43");
            firstDeals.ItemsSource = productsList.data.data;
            secondDeals.ItemsSource = productsList.data.data;
            secondDeals2.ItemsSource = productsList.data.data;

        }

        private void tabedCommandList(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var obj = e.ItemData as catItems;
            Navigation.PushAsync(new ProductsPage(obj.id.ToString()));
        }

        private void productTabed(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var obj = e.ItemData as Items;
            Navigation.PushAsync(new detailes(obj));
        }


        private void tabedCommand(object sender, EventArgs e)
        {

        }
    }
}