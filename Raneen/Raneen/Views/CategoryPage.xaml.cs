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

        public Command OpenXamlPage { get; set; }

        public CategoryPage()
        {
            InitializeComponent();

            //CategoryTile.ItemTapped += taped;
            OpenXamlPage = new Command(itemTaped);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;

            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetCategories();
            CategoryTile.ItemsSource = categoriesList.data.data;

        }

        private void itemTaped(object e)
        {
            if (CategoryTile.SelectedItem != null)
            {
                DisplayAlert("pppp", $"cliced", "Oooooh");
            }
            DisplayAlert("kkk", $"cliced", "OK");
            //Navigation.PushAsync(new ProductsPage());

        }

        private void taped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            DisplayAlert("kkk", $"cliced", "OK");
        }
    }
}