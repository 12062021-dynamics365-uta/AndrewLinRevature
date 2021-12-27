using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain1;

namespace Storage1
{
    public interface IDataBase
    {
        //methods here
        public void getCustomers();
        public int getCustomerID(string FirstName, string LastName);
        public int getNextCustomerID();

        public void addCustomer(int CustomerID, string FirstName, string LastName, string LoginName);
        public void findStores();
        public List<Products> displayProducts1(int StoreNum);
        public int newCart(int StoreNum, int CustomerID, decimal CartTotal);
        public void addItemToCart(int CartItemID, int LineID, int CartID, int ProductID, int ItemQuantity, decimal ItemTotal);
        public void deleteFromCart(int CartID, int ProductID);
        public decimal getOrder(int OrderID, int StoreID, int CustomerID, decimal OrderTotal);

        public decimal getOrderItems(int CartID, int StoreID, int CustomerID, decimal CartTotal);

       
        public int GetProductPrice(int productID);
    }
}
