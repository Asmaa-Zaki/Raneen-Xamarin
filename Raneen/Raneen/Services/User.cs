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
    internal class User
    {
        static SQLiteAsyncConnection database;

        public static async Task<IEnumerable<UserModel>> getAllUsers()
        {
            database = await Database.Init(database);
            var allUsers = await database.Table<UserModel>().ToListAsync();
            return allUsers;
        }

        public static async Task<UserModel> getUser(int id)
        {
            database = await Database.Init(database);
            var user = await database.FindAsync<UserModel>(id);
            return user;
        }

        public static async Task AddUser(string _FirstName, string _LastName, string _Email, string _Phone, string _Password)
        {
            database = await Database.Init(database);
            UserModel user = new UserModel()
            {
                FirstName = _FirstName,
                LastName = _LastName,
                Email = _Email,
                Phone = _Phone,
                Password = _Password
            };
            await database.InsertAsync(user);
        }

        public static async Task UpdateUser(UserModel user)
        {
            database = await Database.Init(database);
            await database.UpdateAsync(user);
        }

        public static async Task RemoveUser(int id)
        {
            database = await Database.Init(database);
            await database.DeleteAsync<UserModel>(id);
        }
    }
}
