using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    internal class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{ID}- \t{FirstName}\t\t{LastName}\t\t{Email}";
        }
    }
}
