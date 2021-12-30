using Domain1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage1
{
  
   
    public class DataManager : IManageData
    {
        public Stores currentStore { get; set; }

        public Orders currentOrder { get; set; }


        List<ShoppingCart> cart;
        public CartItems ProductID { get; set; }


        List<CartItems> cartItems;
        private  IDataBase _connectDataBase;


        public DataManager(IDataBase dba)
        {
            ProductID = new CartItems();
            currentStore = new Stores();
            cart = new List<ShoppingCart>();
            cartItems = new List<CartItems>();
            currentOrder = new Orders();
            this._connectDataBase = dba;
        }


        public void getCustomer(string FirstName, string LastName)
        {
            int CustomerID = 0;
            CustomerID = this._connectDataBase.getCustomerID(FirstName, LastName);
        }



        public void LoadProducts()
        {

            currentStore.products = this._connectDataBase.displayProducts1(currentStore.StoreNum);



        }


        public int addCart(int StoreID, int CustomerID)
        {
            decimal CartTotal = 0;
            int CartID = this._connectDataBase.newCart(StoreID, CustomerID, CartTotal);
            return CartID;

        }
        public List<CartItems> addItemToCart(int CartItemID, int CartID, int ProductID, int ItemQuantity)
        {

            decimal ItemTotal = 0;
            int LineID = CartID;
            List<CartItems> cartItems = new List<CartItems>();
            Products p;
            foreach (Products prod in currentStore.products)
            {

                if (prod.ProductID == ProductID)
                {

                    p = prod;
                    ItemTotal = ItemQuantity * p.price;
                }
            }
            this._connectDataBase.addItemToCart(CartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal);
            return cartItems;
        }

        public void viewCart()
        {

        }

        public void getOrder(int CartID, int StoreNum, int CustomerID, decimal OrderTotal)
        {
            List<Orders> order = new List<Orders>();
            Orders o;
            int ItemQuantity = 0;
            ItemQuantity++;

            foreach (Orders orders in order)
            {
                o = orders;

            }

            this._connectDataBase.getOrder(CartID, StoreNum, CustomerID, OrderTotal);
        }







       

    }


}