using Raneen.Models;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    { 
        bool emptyCart;
        int newId;

        public CartPage()
        {
            InitializeComponent();            
        }
        ObservableCollection<ProductModel> cartItems = new ObservableCollection<ProductModel>();

        protected override void OnAppearing()
        {
            cartItems.Add(new ProductModel() { id = 1, name = "fvbbv ghgh ghh bhjbjnhb hjgjgj mghjg jghjgj jghjhgj jhgjg", price = 15.00, });
            cartItems.Add(new ProductModel() { id = 2, name = "s", price = 1, });
            cartItems.Add(new ProductModel() {id = 3, name = "s", price = 1 });
            cartItems.Add(new ProductModel() { id = 4, name = "s", price = 1, });
            TotalCost.Text = cartItems.Sum(item => item.price).ToString();

            base.OnAppearing();
            if(cartItems.ToList().Count()> 0)
            {
                emptyCart = false;
                listView.ItemsSource = cartItems;
            }
            else
            {
                emptyCart= true;
            }
            emptyCard.IsVisible = emptyCart;
            notEmptyCard.IsVisible = !emptyCart;
        }

       

        private void removeProduct(object sender, EventArgs e)
        {
            newId = int.Parse(((sender as SfButton).CommandParameter as ProductModel).id.ToString());
            int oldId = newId;
            newId = newId - 1;
            var product = cartItems.FirstOrDefault(item => item.id == oldId);
            if (product != null) { product.id = newId; }
            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].id == oldId)
                    cartItems[i] = product;
            }
            DisplayAlert(newId.ToString(), cartItems[0].id.ToString(), "ok", "cancel");
        }

        private void itemTaped(object sender, ItemTappedEventArgs e)
        {

        }

        private void show(object sender, EventArgs e)
        {
            DisplayAlert("HGSGG", "", "Ok");
        }

        private void remove(object sender, EventArgs e)
        {
            DisplayAlert("Remove", "", "ok");
        }

        private void addProduct(object sender, EventArgs e)
        {
           // Console.WriteLine(((sender as SfButton).CommandParameter as Items).id);
            newId= int.Parse(((sender as SfButton).CommandParameter as ProductModel).id.ToString());
            int oldId = newId;
            newId = newId + 1;
            var product = cartItems.FirstOrDefault(item => item.id == newId);
            if (product != null) { product.id = newId; }
            for(int i=0; i<cartItems.Count; i++)
            {
                if (cartItems[i].id == oldId)
                    cartItems[i] = product;
            }
            DisplayAlert(newId.ToString(), cartItems[0].id.ToString(),"ok", "cancel");
            //DisplayAlert("saaaaaaaaaaaaad", "ok", "cancel");
        }

        private void itemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if(e.ItemData == null)
            {
                return;
            }
            else
            {
                var product = e.ItemData as ProductModel;
                DisplayAlert("", product.name, "ok", "cancel");
            }
        }
    }
}