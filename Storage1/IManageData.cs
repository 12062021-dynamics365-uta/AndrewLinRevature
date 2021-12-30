
using Domain1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Storage1
{
    interface IManageData
    {

        public void getCustomer(string FirstName, string LastName);
        int addCart(int StoreID, int CustomerID);
        List<CartItems> addItemToCart(int CartItemID,int CartID, int ProductID, int ItemQuantity);
        public void getOrder(int CartID, int StoreNum, int CustomerID, decimal OrderTotal);



    }
}