using Raneen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Raneen.Services
{
    internal class Database
    {
        public static async Task<SQLiteAsyncConnection> Init(SQLiteAsyncConnection database)
        {
            if (database != null)
            {
                return database;
            }
            else
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "RaneenDB");
                database = new SQLiteAsyncConnection(path);
                await database.CreateTableAsync<UserModel>();
                await database.CreateTableAsync<ProductModel>();
                await database.CreateTableAsync<AddressModel>();
                await database.CreateTableAsync<CartModel>();
                return database;
            }
        }
    }
}
