using Raneen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detailes : ContentPage
    {
        public detailes(Items obj)
        {
            InitializeComponent();
            Rotator.ItemsSource = obj.images;
            ProductName.Text = obj.name;
            ProductDiscription.Text = obj.description;

            ProductPrice.Text = obj.price.ToString();
            ProductActualPrice.Text = obj.old_price.ToString();
            var rating = 3.5;
            var DiscountPercent = obj.discount;

            ProductRating.Value = rating;
            //Text = "{'5.5', StringFormat='{}{0} Ratings'}"
            //Text = "{Binding DiscountPercent, StringFormat=' ({0}% OFF)'}"

        }
    }
}