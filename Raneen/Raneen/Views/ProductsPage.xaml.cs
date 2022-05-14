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
        public ProductsPage(string _id)
        {
            InitializeComponent();
            id = _id;

            //SelectionCommand = new Command<object>(OnItemSelected);
            //ContactsInfo = new ObservableCollection<Contacts>();
            //SelectionCommand = new Command<object>(OnItemSelected);
            //GenerateInfo();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Requests httpClient = new Requests(); ;
            var categoriesList = await httpClient.GetProducts(id);
            ListViewTile.ItemsSource = categoriesList.data.data;
            this.BindingContext = categoriesList.data.data;
        }

        private void itemTaped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var product = e.ItemData as Items;
            Navigation.PushAsync(new detailes(product));

        }
    }


}