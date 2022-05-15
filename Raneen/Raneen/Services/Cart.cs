using Raneen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raneen.Services
{
    internal class Cart
    {
        static SQLiteAsyncConnection database;

        public static async Task<IEnumerable<CartModel>> getAllProducts()
        {
            database = await Database.Init(database);
            var allProducts = await database.Table<CartModel>().ToListAsync();
            return allProducts;
        }

        public static async Task<CartModel> getProduct(int id)
        {
            await Database.Init(database);
            var product = await database.FindAsync<CartModel>(id);
            return product;
        }

        public static async Task<List<CartModel>> getProductsByUserId(string _email)
        {
            await Database.Init(database);

            var products = await database.QueryAsync<CartModel>($"select * from CartModel where Email = ?", _email);
            return products;
        }
        public static async Task<List<CartModel>> getProductsByUserIdAndProductId(string _email, int _productId)
        {
            await Database.Init(database);
            var products = await database.QueryAsync<CartModel>($"select * from CartModel where Email = ? " +
                $"And _productId = ?", _email,_productId);
            return products;
        }
        public static async Task AddProductToCart(string _email, int _ProductId)
        {
           var result = await getProductsByUserIdAndProductId(_email, _ProductId);
            if(result.Count == 0 || result == null)
            {
                CartModel product = new CartModel()
                {
                    ProductId = _ProductId,
                    Email = _email,
                    count = 1
                };
                await database.InsertAsync(product);
            }
            else
            {
                await UpdateProduct(_email, _ProductId, "+");
            }
            
        }

        public static async Task UpdateProduct(string _email, int _ProductId, string operation)
        {
            var result = await getProductsByUserIdAndProductId(_email, _ProductId);
            if (operation == "+")
                result[0].count++;
            else if (operation == "-")
            {
                if (result[0].count == 1)
                    return;
                else
                result[0].count--;
            }
            await database.UpdateAsync(result[0]);
        }

        public static async Task RemoveProduct(int id)
        {
            database = await Database.Init(database);
            await database.DeleteAsync<CartModel>(id);
        }
    }
}
