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
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{ID}---{Email}----{ProductId}---{Count}";
        }

    }
}
