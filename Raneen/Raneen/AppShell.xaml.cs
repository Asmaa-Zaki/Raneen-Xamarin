using Raneen.Services;
using Raneen.ViewModels;
using Raneen.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Raneen
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //initApi();

        }

        //public async void initApi()
        //{
        //    Requests httpClient = new Requests(); ;
        //    var categoriesList = await httpClient.GetProducts();
        //}

    }
}
