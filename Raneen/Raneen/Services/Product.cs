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

        public static async Task AddProduct(int _id, int _count)
        {
            database = await Database.Init(database);
            ProductModel product = new ProductModel()
            {
                id = _id,
                count = _count
            };
            await database.InsertAsync(product);
        }

        public static async Task UpdateProduct(ProductModel product, string op)
        {
            if (op == "+")
                product.count++;
            else if (op == "-")
                product.count--;
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
