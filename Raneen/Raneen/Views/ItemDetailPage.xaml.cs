using Raneen.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Raneen.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}