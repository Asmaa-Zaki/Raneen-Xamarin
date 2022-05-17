using Raneen.Models;
using Raneen.Services;
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
        ObservableCollection<ProductModel> cartItems;

        protected async override void OnAppearing()
        {

            if (Application.Current.Properties.ContainsKey("Email"))
            {
                Requests request = new Requests();
                var productsInCart = await UserCart.getProductsByUserId(Application.Current.Properties["Email"].ToString());
                var allProducts = (await request.GetAllProducts()).data.data;
                cartItems = new ObservableCollection<ProductModel>();
                foreach (var product in productsInCart)
                {
                    ProductModel p = allProducts.FirstOrDefault(x => x.id == product.ProductId);
                    p.count = product.Count;
                    cartItems.Add(p);
                }

                if (cartItems.ToList().Count() > 0)
                {
                    emptyCart = false;
                    listView.ItemsSource = cartItems;
                    TotalCost.Text = cartItems.Sum(item => item.price * item.count).ToString();
                }
                else
                {
                    emptyCart = true;
                }
            }
            emptyCard.IsVisible = emptyCart;
            notEmptyCard.IsVisible = !emptyCart;
        }

       

        private async void removeProduct(object sender, EventArgs e)
        {
            var productModel = (sender as SfButton).CommandParameter as ProductModel;
            await UserCart.UpdateProduct(Application.Current.Properties["Email"].ToString(), productModel.id, "-");
            //await Product.UpdateProduct(productModel, "+");
            var product = cartItems.FirstOrDefault(x => x.id == productModel.id);
            if (product.count > 1)
                product.count--;
            //newId = int.Parse(((sender as SfButton).CommandParameter as ProductModel).id.ToString());
            //int oldId = newId;
            //newId = newId - 1;
            //var product = cartItems.FirstOrDefault(item => item.id == oldId);
            //if (product != null) { product.id = newId; }
            //for (int i = 0; i < cartItems.Count; i++)
            //{
            //    if (cartItems[i].id == oldId)
            //        cartItems[i] = product;
            //}
            //DisplayAlert(newId.ToString(), cartItems[0].id.ToString(), "ok", "cancel");
        }

        private void itemTaped(object sender, ItemTappedEventArgs e)
        {

        }

        private void show(object sender, EventArgs e)
        {
            DisplayAlert("HGSGG", "", "Ok");
        }

        private async void remove(object sender, EventArgs e)
        {
            DisplayAlert("Remove", "Are you Sure", "OK");
        }

        private async void addProduct(object sender, EventArgs e)
        {
            var productModel = (sender as SfButton).CommandParameter as ProductModel;
            await UserCart.UpdateProduct(Application.Current.Properties["Email"].ToString(), productModel.id, "+");
            var product = cartItems.FirstOrDefault(x => x.id == productModel.id);
                product.count++;
            //// Console.WriteLine(((sender as SfButton).CommandParameter as Items).id);
            // newId= int.Parse(((sender as SfButton).CommandParameter as ProductModel).id.ToString());
            // int oldId = newId;
            // newId = newId + 1;
            // var product = cartItems.FirstOrDefault(item => item.id == newId);
            // if (product != null) { product.id = newId; }
            // for(int i=0; i<cartItems.Count; i++)
            // {
            //     if (cartItems[i].id == oldId)
            //         cartItems[i] = product;
            // }
            // DisplayAlert(newId.ToString(), cartItems[0].id.ToString(),"ok", "cancel");
            // //DisplayAlert("saaaaaaaaaaaaad", "ok", "cancel");
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