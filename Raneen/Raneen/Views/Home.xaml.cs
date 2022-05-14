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
    public partial class HomePage : ContentPage
    {

        public HomePage()
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
            //var bannersList = await httpClient.GetBanners();


            //banerImage.Source = new Uri(bannersList.data[0].image.ToString());

            var homeData = await httpClient.GetHomeData();
            var bannersList = homeData.data.banners;
            var ProductsList = homeData.data.products;

            banerImage.Source = new Uri(bannersList[0].image.ToString());
            banerImage2.Source = new Uri(bannersList[1].image.ToString());
            banerImage3.Source = new Uri(bannersList[2].image.ToString());
            productsView.ItemsSource = ProductsList;
            listView.ItemsSource = new ObservableCollection<ProductModel>(ProductsList.Where(x => x.id % 3 == 0).ToList());


            //CategoryTile.ItemsSource = bannersList;
            //var products1 = await httpClient.GetProducts(ids[0]);
            //var products2 = await httpClient.GetProducts(ids[1]);
            //var products3 = await httpClient.GetProducts(ids[2]);
            //deals1.ItemsSource = products1.data.data;
            //deals2.ItemsSource = products2.data.data;
            //deals3.ItemsSource = products3.data.data;

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
            if (sender == but1 || sender == banerImage2)
            {
                Navigation.PushAsync(new ProductsPage(ids[0]));
            }
            else if (sender == but2 || sender == banerImage3)
            {
                Navigation.PushAsync(new ProductsPage(ids[1]));
            }
            else if (sender == banerImage)
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