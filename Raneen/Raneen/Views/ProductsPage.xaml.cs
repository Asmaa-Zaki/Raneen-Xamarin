using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raneen.Models;
using Raneen.Services;
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

        ObservableCollection<Items> products;
        public ProductsPage(string _id)
        {
            InitializeComponent();
            id = _id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetProducts(id);
            SortPiker.ItemsSource = sortOptions;
            FilterPiker.ItemsSource = filterOptions;
            this.BindingContext = products;
            //products = categoriesList.data.data as ObservableCollection<Items>;
            products = new ObservableCollection<Items>(categoriesList.data.data);
            ListViewTile.ItemsSource = products;
        }

        private void itemTaped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var product = e.ItemData as Items;
            Navigation.PushAsync(new detailes(product));

        }

        private void changePiker(object sender, EventArgs e)
        {

            List<Items> unSortedList = new List<Items>(products);
            List<Items> sortedList;
            switch (SortPiker.SelectedItem)
            {
                case "price":
                    sortedList = unSortedList.OrderBy(product => product.price).ToList<Items>();
                    products = new ObservableCollection<Items>(sortedList);
                    break;
                case "name":
                    sortedList = unSortedList.OrderBy(product => product.name).ToList<Items>();
                    products = new ObservableCollection<Items>(sortedList);
                    break;
            }
            ListViewTile.ItemsSource = products;
        }

        ObservableCollection<Items> GetAllProducts(string _filterKeyword = null)
        {
            if (!string.IsNullOrWhiteSpace(_filterKeyword))
            {
                if (_filterKeyword == "0")
                {
                    return new ObservableCollection<Items>(products.Where(x => x.price <= 500).ToList());
                }
                else if (_filterKeyword == "1")
                {
                    return new ObservableCollection<Items>(products.Where(x => (x.price >= 500 && x.price <= 1000)).ToList());
                }
                else
                {
                    return new ObservableCollection<Items>(products.Where(x => x.price >= 1000).ToList());
                }
            }
            else
            {
                return new ObservableCollection<Items>(products);
            }

        }

        private void filterPiker(object sender, EventArgs e)
        {
            ListViewTile.ItemsSource = GetAllProducts(FilterPiker.SelectedIndex.ToString());
        }
    }


}