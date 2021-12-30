using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain1;

namespace Storage1
{
    public class Mapper
    {

        public int EntitytoisCustomer(SqlDataReader dr)
        {
            string first = " ";
            string last = " ";
            int CustomerID = 0;

            while (dr.Read())
            {
                Customer isCustomer = new Customer(first, last)
                {
                    CustomerID = Convert.ToInt32(dr[0].ToString()),

                };
            }
            return CustomerID;
        }



        public List<Products> EntityToProducts(SqlDataReader dr)
        {
            List<Products> products = new List<Products>();
            while (dr.Read())
            {

                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(dr[0].ToString()),
                    ProductName = dr[1].ToString(),
                    price = Convert.ToDecimal(dr[2].ToString()),
                    ProductDescription = dr[3].ToString(),
                    ProductQuantity = Convert.ToInt32(dr[4].ToString())

                };
                products.Add(product);

            }
            return products;
        }

        public List<ShoppingCart> EntityToCart(SqlDataReader dr)
        {

            List<ShoppingCart> addCart = new List<ShoppingCart>();
            while (dr.Read())
            {

                ShoppingCart cart = new ShoppingCart()
                {
                    CartID = Convert.ToInt32(dr[0].ToString()),
                    StoreID = Convert.ToInt32(dr[0].ToString()),
                    CustomerID = Convert.ToInt32(dr[1].ToString()),
                    CartTotal = Convert.ToDecimal(dr[2].ToString()),

                };
                addCart.Add(cart);

            }
            return addCart;


        }
        public List<CartItems> EntityToCartItem(SqlDataReader dr)
        {

            List<CartItems> cartItems = new List<CartItems>();
            while (dr.Read())
            {

                CartItems item = new CartItems()
                {
                    CartItemID = Convert.ToInt32(dr[0].ToString()),
                    LineID = Convert.ToInt32(dr[1].ToString()),
                    CartID = Convert.ToInt32(dr[2].ToString()),
                    pID = Convert.ToInt32(dr[3].ToString()),
                    ItemQuantity = Convert.ToInt32(dr[4].ToString()),
                    ItemTotal = Convert.ToInt32(dr[5].ToString()),
                };
                cartItems.Add(item);

            }
            return cartItems;


        }






    }





}
