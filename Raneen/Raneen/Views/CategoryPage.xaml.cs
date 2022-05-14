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
    public partial class CategoryPage : ContentPage
    {

        public CategoryPage()
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

        }

        private void tabedCommandList(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var obj = e.ItemData as catItems;
            Navigation.PushAsync(new ProductsPage(obj.id.ToString()));
        }
    }
}