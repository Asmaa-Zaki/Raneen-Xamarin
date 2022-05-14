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
        List<String> ids = new List<String>(){
            "44","46","43"
            };
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;

            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetCategories();
            var categories = categoriesList.data.data;
            categories.RemoveAt(3);
            CategoryTile.ItemsSource = categories;
            var products1 = await httpClient.GetProducts(ids[0]);
            var products2 = await httpClient.GetProducts(ids[1]);
            var products3 = await httpClient.GetProducts(ids[2]);
            deals1.ItemsSource = products1.data.data;
            deals2.ItemsSource = products2.data.data;
            deals3.ItemsSource = products3.data.data;

        }

        private void tabedCommandList(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var obj = e.ItemData as catItems;
            Navigation.PushAsync(new ProductsPage(obj.id.ToString()));
        }

        private void productTabed(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var obj = e.ItemData as ProductModel;
            Navigation.PushAsync(new DetailPage(obj));
        }

        private void ShowMore(object sender, EventArgs e)
        {
            if (sender == but1)
            {
                Navigation.PushAsync(new ProductsPage(ids[0]));
            }
            else if (sender == but2)
            {
                Navigation.PushAsync(new ProductsPage(ids[1]));
            }
            else if (sender == but3)
            {
                Navigation.PushAsync(new ProductsPage(ids[2]));
            }
            else
            {
                return;
            }
        }

        private void AddToCart(object sender, EventArgs e)
        {

        }
    }
}