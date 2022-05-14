using Raneen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raneen.Services
{
    internal class Product
    {
        static SQLiteAsyncConnection database;

        public static async Task<IEnumerable<ProductModel>> getAllProducts()
        {
            database = await Database.Init(database);
            var allProducts = await database.Table<ProductModel>().ToListAsync();
            return allProducts;
        }

        public static async Task<ProductModel> getProduct(int id)
        {
            await Database.Init(database);
            var product = await database.FindAsync<ProductModel>(id);
            return product;
        }

        public static async Task AddProduct(int _id, double _price, double _oldPrice,
                                         double _discount, string _image, string _name,
                                         string _description, List<string> _images,
                                         bool _inFavorites, bool _inCart)
        {
            database = await Database.Init(database);
            ProductModel product = new ProductModel()
            {
                id = _id,
                price = _price,
                old_price = _oldPrice,
                discount = _discount,
                image = _image,
                name = _name,   
                description = _description,
                images = _images,
                in_favorites = _inFavorites,
                in_cart = _inCart
            };
            await database.InsertAsync(product);
        }

        public static async Task UpdateProduct(ProductModel product)
        {
            database = await Database.Init(database);
            await database.UpdateAsync(product);
        }

        public static async Task RemoveProducts(int id)
        {
            database = await Database.Init(database);
            await database.DeleteAsync<ProductModel>(id);
        }
    }
}
