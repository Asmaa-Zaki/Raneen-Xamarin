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
        }

        public async void InitProductsInDB()
        {
            Random r = new Random();            
            var dbProduct = await Product.getAllProducts();
            if (dbProduct.ToList().Count == 0)
            {
                    Requests requests = new Requests();
                    var categories =await requests.GetCategories();
                    foreach (var category in categories.data.data)
                    {
                        var products = await requests.GetProducts(category.id.ToString());
                        foreach (var product in products.data.data)
                        {
                            await Product.AddProduct(product.id, r.Next(3, 8));
                        }
                    }
            }

        }

    }
}
