using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : ContentPage
    {
        public AddressPage()
        {
            this.InitializeComponent();
        }

        private void showCity(object sender, System.EventArgs e)
        {
            City.IsVisible= true;
        }
    }
}