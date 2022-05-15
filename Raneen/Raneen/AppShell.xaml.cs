using Raneen.Services;
using Raneen.ViewModels;
using Raneen.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Raneen
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitProductsInDB();

            //initApi();
        }

        public async void InitProductsInDB()
        {
            var product= await Product.getAllProducts();
            if (product.ToList().Count == 0)
            {
                foreach (var item in product)
                {
                    Requests requests = new Requests();
                    var categories =await requests.GetCategories();
                    var cat =categories.data.data;
                    foreach (var category in cat)
                    {
                        Console.WriteLine(category.id);
                    }
                }
            }
                
        }

    }
}
