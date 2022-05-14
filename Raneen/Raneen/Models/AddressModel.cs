using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    internal class AddressModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public override string ToString()
        {
            return $"{ID}- \t{State}\t\t{City}\t\t{FirstName}";
        }
    }
}
