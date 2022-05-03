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
        }
        
        private void logIn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimpleLoginPage());

        }

        private void signUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SimpleSignUpPage());
        }
    }
}