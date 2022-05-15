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
    public partial class accountPage : ContentPage
    {
        public accountPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("Fname") == false)
            {
                account.IsVisible = true;
                profile.IsVisible = false;
                acountPage.BackgroundImageSource = "skybg";
            }
            else
            {
                account.IsVisible = false;
                profile.IsVisible = true;

                var fname = Application.Current.Properties["Fname"];
                var lname = Application.Current.Properties["Lname"];

                if (fname != null)
                {
                    fullName.Text = fname + " " + lname;
                    email.Text = Application.Current.Properties["Email"].ToString();
                }
            }
        }

        private void logIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimpleLoginPage());

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private void signUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimpleSignUpPage());
        }

        private void AccountInf(object sender, EventArgs e)
        {
            DisplayAlert("hi", "", "ok", "cancel");
        }

        private void LogOut(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            account.IsVisible = true;
            profile.IsVisible = false;
        }

        private void Account(object sender, EventArgs e)
        {

        }

        private void MyAddresses(object sender, EventArgs e)
        {

        }

        private void MyOrders(object sender, EventArgs e)
        {

        }

        private void WishList(object sender, EventArgs e)
        {

        }
    }
}