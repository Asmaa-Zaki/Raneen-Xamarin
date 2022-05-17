using Newtonsoft.Json.Linq;
using Raneen.Models;
using Raneen.Services;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage
    {
        string id;
        List<string> sortOptions = new List<string>()
            {
                "name",
                "price"
            };
        List<string> filterOptions = new List<string>()
            {
                "0 : price : 500",
                "500 : price : 1000",
                "1000 : price",
            };

        ObservableCollection<ProductModel> products;
        public ProductsPage(string _id)
        {
            InitializeComponent();
            id = _id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Requests httpClient = new Requests();
            var categoriesList = await httpClient.GetProducts(id);
            SortPiker.ItemsSource = sortOptions;
            FilterPiker.ItemsSource = filterOptions;
            this.BindingContext = products;
            products = new ObservableCollection<ProductModel>(categoriesList.data.data);
            ListViewTile.ItemsSource = products;
        }

        private void itemTaped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var product = e.ItemData as ProductModel;
            Navigation.PushAsync(new DetailPage(product));
            //DisplayAlert("hi", $"{product.id}", "ox");
            //Navigation.PushAsync(new DetailPage(product));

        }

        private void changePiker(object sender, EventArgs e)
        {

            List<ProductModel> unSortedList = new List<ProductModel>(products);
            List<ProductModel> sortedList;
            switch (SortPiker.SelectedItem)
            {
                case "price":
                    sortedList = unSortedList.OrderBy(product => product.price).ToList<ProductModel>();
                    products = new ObservableCollection<ProductModel>(sortedList);
                    break;
                case "name":
                    sortedList = unSortedList.OrderBy(product => product.name).ToList<ProductModel>();
                    products = new ObservableCollection<ProductModel>(sortedList);
                    break;
            }
            ListViewTile.ItemsSource = products;
        }

        ObservableCollection<ProductModel> GetAllProducts(string _filterKeyword = null)
        {
            if (!string.IsNullOrWhiteSpace(_filterKeyword))
            {
                if (_filterKeyword == "0")
                {
                    return new ObservableCollection<ProductModel>(products.Where(x => x.price <= 500).ToList());
                }
                else if (_filterKeyword == "1")
                {
                    return new ObservableCollection<ProductModel>(products.Where(x => (x.price >= 500 && x.price <= 1000)).ToList());
                }
                else
                {
                    return new ObservableCollection<ProductModel>(products.Where(x => x.price >= 1000).ToList());
                }
            }
            else
            {
                return new ObservableCollection<ProductModel>(products);
            }

        }

        private void filterPiker(object sender, EventArgs e)
        {
            ListViewTile.ItemsSource = GetAllProducts(FilterPiker.SelectedIndex.ToString());
        }

        private async void AddToCart(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("Email"))
            {
                var product = (sender as SfButton).CommandParameter as ProductModel;
                var email = Application.Current.Properties["Email"].ToString();
                await UserCart.AddProductToCart(email, product.id);
                var v = await UserCart.getProductsByUserIdAndProductId(email, product.id);
            }
            else
            {
                await DisplayAlert("Warning", "You must sign in first", "Cancel");
            }

        }
    }
}