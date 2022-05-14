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
        }
    }
}