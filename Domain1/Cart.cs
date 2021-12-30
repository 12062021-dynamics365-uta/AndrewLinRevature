using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domain1
{
    public class CartItems
    {
        [Key]
        public int CartItemID { get; set; }

        public int LineID { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemTotal { get; set; }

        public int pID { get; set; }
        public string ProductName { get; set; }
        public decimal price { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }

        public List<Products> cartItems { get; set; }

        public CartItems()
        {
            cartItems = new List<Products>();
        }


    }

}
