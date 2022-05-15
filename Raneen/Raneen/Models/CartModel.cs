using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Models
{
    internal class CartModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        public int count { get; set; }

    }
}
