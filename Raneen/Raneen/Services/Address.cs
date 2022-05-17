using Raneen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raneen.Services
{
    internal class Address
    {
        static SQLiteAsyncConnection database;

        public static async Task<IEnumerable<AddressModel>> getAllAdresses()
        {
            database = await Database.Init(database);
            var allAdresses = await database.Table<AddressModel>().ToListAsync();
            return allAdresses;
        }

        public static async Task<AddressModel> getAddress(int id)
        {
            database = await Database.Init(database);
            var address = await database.FindAsync<AddressModel>(id);
            return address;
        }

        public static async Task<List<AddressModel>> getAddressByUserId(int UserId)
        {
            database = await Database.Init(database);
            var address = await database.QueryAsync<AddressModel>($"select * from AddressModel where UserId = ?", UserId);
            return address;
        }

        public static async Task AddAddress(string _State, string _City, string _Street, int _UserId, string _Fname, string _Lname)
        {
            database = await Database.Init(database);
            AddressModel address = new AddressModel()
            {
                State = _State,
                City = _City,
                Street = _Street,
                UserId = _UserId,
                FirstName = _Fname,
                LastName = _Lname
            };
            await database.InsertAsync(address);
        }

        public static async Task UpdateAddress(AddressModel address)
        {
            database = await Database.Init(database);
            await database.UpdateAsync(address);
        }

        public static async Task RemoveAddress(int id)
        {
            database = await Database.Init(database);
            await database.DeleteAsync<AddressModel>(id);
        }
    }
}
