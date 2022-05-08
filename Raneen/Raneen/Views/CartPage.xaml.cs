using Raneen.Models;
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

        public CartPage()
        {
            InitializeComponent();
            
        }
        ObservableCollection<ProductModel> cartItems = new ObservableCollection<ProductModel>();

        protected override void OnAppearing()
        {
          /*  cartItems.Add(new Items() { Id=1, Name="f", Price=1, });
            cartItems.Add(new Items() { Id=2, Name="s", Price=1, });
            cartItems.Add(new Items() { Id=2, Name="s", Price=1, });
            cartItems.Add(new Items() { Id=2, Name="s", Price=1, });
*/
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
    }
}