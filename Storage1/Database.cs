
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain1;
using System.Linq;
using System.Text;
namespace Storage1

{


    public class connectDataBase : IDataBase
    {
        
        string getDataBase = "Data Source = LAPTOP-PITFN5NH\\SQLEXPRESS; initial Catalog = Project_Zero; integrated security = true";
        public SqlConnection SqlConnect;
        public  Mapper mapper;
        Random rnd = new Random();

        public void ConnectDataBase()
        {
            this.SqlConnect = new SqlConnection(this.getDataBase);
            SqlConnect.Open();
            this.mapper = new Mapper();

        }

        public void addLocation(int StoreNum, string storeLoc)
        {
            string query = $"INSERT INTO Stores (StoreNum, StoreLocation) VALUES ('{StoreNum}' , '{storeLoc}');";
            ConnectDataBase();
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();
           
            
            dr.Close();
        }

        public void insertOrderHistory(int CustomerID, string ProductOrdered, int QuantityOrdered, decimal price)
        {
            string query = $"INSERT INTO PastOrders3 (CustomerID, ProductOrdered, QuantityOrdered, Price) VALUES ('{CustomerID}' , '{ProductOrdered}' , '{QuantityOrdered}' , '{price}');";
            ConnectDataBase();
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();


            dr.Close();
        }


        public void checkOrderHistory(int CustomerID)
        {
            string query = $"SELECT DISTINCT CustomerID, ProductOrdered, QuantityOrdered, Price FROM PastOrders3 WHERE CustomerID = {CustomerID};";
            List<CartItems> itemsInCart = new List<CartItems>();

            ConnectDataBase();
            SqlCommand command = new SqlCommand(query, this.SqlConnect);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }
        }

          public string GetProductName(int productID)
        {
            string productName = "";
            string query = $"SELECT ProductName FROM Products WHERE ProductID = {productID};";
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                productName = dr[0].ToString();
            }
            dr.Close();
            return productName;
        }

    
    public void addProduct(int ProductID, string ProductName, decimal price, string prodDescription)
        {
            string query = $"INSERT INTO Products (ProductID, ProductName, Price, ProductDescription) VALUES ('{ProductID}' , '{ProductName}' , '{price}' , '{prodDescription}');";
            ConnectDataBase();
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Close();
        }

        public void addProductToStore(int StoreNum, int ProductID, int ProductQuantity)
        {
            string query = $"INSERT INTO Inventory (StoreNum, ProductID, ProductQuantity) VALUES ('{StoreNum}' , '{ProductID}' , '{ProductQuantity}');";
            ConnectDataBase();
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Close();
        }
        public int GetProductPrice(int productID)
        {
            int cost = 0;
            string query = $"SELECT Price FROM Products WHERE ProductID = '{productID}';";
            SqlCommand cmd = new SqlCommand(query, SqlConnect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cost += Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            int cartCost = cost;
            return cartCost;
        }

        public void getCustomers()
        {
            string query = "SELECT LoginName FROM Customers;";

            using (SqlConnect)
            {            
                using (SqlCommand command = new SqlCommand(query, SqlConnect))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                Console.WriteLine(dataRead.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }
        }

        public int getCustomerID(string FirstName, string LastName)
        {
            int CustomerID = 0;
            string query = $"SELECT CustomerID FROM Customers WHERE FirstName = '{FirstName}' AND LastName = '{LastName}';";
            ConnectDataBase();
            using (SqlCommand command = new SqlCommand(query, this.SqlConnect))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        CustomerID = Convert.ToInt32(dr[0].ToString());

                    };
                }

                dr.Close();
            }
            return CustomerID;


        }


        public int getNextCustomerID()
        {
            int CustomerID = -1;
           
            string query = "SELECT MAX(CustomerID) + 1 as MaxID FROM Customers;";
         
            ConnectDataBase();
            using (SqlConnect)
            {
                using (SqlCommand command = new SqlCommand(query, SqlConnect))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                CustomerID = int.Parse(dataRead["MaxID"].ToString());
                            }
                        }
                        dataRead.Close();
                    }
                }
            }
            return CustomerID;
        }






        public void addCustomer(int CustomerID, string FirstName, string LastName, string LoginName)
        {
            SqlCommand command;
            ConnectDataBase();
            command = SqlConnect.CreateCommand();
       
            if (CustomerID > 0)
            {

                string query = "INSERT INTO Customers(CustomerID, FirstName, LastName, LoginName) values('" + CustomerID + "', '" + FirstName + "', '" + LastName + "', '" + LoginName + "');";

                using (SqlConnect)
                {
                    using (command = new SqlCommand(query, SqlConnect))
                    {
                        using (SqlDataReader dataRead = command.ExecuteReader())
                        {
                            while (dataRead.Read())
                            {
                                for (int i = 0; i < dataRead.FieldCount; i++)
                                {
                                    Console.WriteLine(dataRead.GetValue(i));

                                }
                                Console.WriteLine();
                            }
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("Error creating new customer.");
            }



        }


        public void findStores()
        {
            string query = "SELECT StoreNum, StoreLocation FROM Stores;";
            ConnectDataBase();
            using (SqlConnect)
            {
                using (SqlCommand command = new SqlCommand(query, SqlConnect))
                {
                    using (SqlDataReader dataRead = command.ExecuteReader())
                    {
                        while (dataRead.Read())
                        {
                            for (int i = 0; i < dataRead.FieldCount; i++)
                            {
                                Console.WriteLine(dataRead.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }

        }

        public List<Products> displayProducts1(int StoreNum)
        {

            string query = "SELECT p.ProductID, ProductName, Price, ProductDescription, ProductQuantity " +
                           "FROM Inventory " +
                           "LEFT OUTER JOIN Stores " +
                           "ON Stores.StoreNum = Inventory.StoreNum " +
                           "LEFT OUTER JOIN Products p " +
                           "ON p.ProductID = Inventory.ProductID " +
                           "WHERE Inventory.StoreNum = " + StoreNum + " ;";

            List<Products> products = new List<Products>();
            ConnectDataBase();
            using (SqlCommand command = new SqlCommand(query, this.SqlConnect))
            {
                SqlDataReader dr = command.ExecuteReader();
                products = this.mapper.EntityToProducts(dr);
                dr.Close();
            }
            return products;

        }

        public int newCart(int StoreNum, int CustomerID, decimal CartTotal)
        {
            int CartID = rnd.Next(1, 3000);
            string query = "INSERT INTO ShoppingCart(CartID, StoreID, CustomerID, CartTotal) values('" + CartID + "', '" + StoreNum + "', '" + CustomerID + "', '" + CartTotal + "')";
            List<ShoppingCart> cart = new List<ShoppingCart>();
            ConnectDataBase();
            using (SqlCommand command = new SqlCommand(query, this.SqlConnect))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr.GetValue(i));

                    };
                }
                dr.Close();
            }




            string query2 = "SELECT CartID FROM ShoppingCart;";
            using (SqlCommand command = new SqlCommand(query2, this.SqlConnect))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    CartID = (Convert.ToInt32(dr[0].ToString()));
                }
                dr.Close();
            }
            return CartID;


        }
        public void addItemToCart(int CartItemID, int LineID, int CartID, int ProductID, int ItemQuantity, decimal ItemTotal)
        {
            
            string query = $"INSERT INTO ShoppingCartItems(CartItemID, LineID, CartID, ProductID, ItemQuantity, ItemTotal) values('{CartItemID} ',' {LineID} ',' {CartID} ', ' {ProductID} ', ' {ItemQuantity} ', ' {ItemTotal} ');";
            List<CartItems> cartItems = new List<CartItems>();
            ConnectDataBase();
            SqlCommand command = new SqlCommand(query, SqlConnect);
            //{
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }
            cartItems = this.mapper.EntityToCartItem(dr);
            
            dr.Close();
            
            //}
        }





        public decimal getOrder(int OrderID, int StoreID, int CustomerID, decimal OrderTotal)
        {
            string query = $"INSERT INTO Orders (OrderID, StoreID, CustomerID, OrderTotal) values('{OrderID}','{StoreID}', '{CustomerID}', '{OrderTotal}');";
            List<Orders> order = new List<Orders>();
            ConnectDataBase();
            SqlCommand command = new SqlCommand(query, this.SqlConnect);
            //{
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }

            return OrderTotal;
        }


        public decimal getOrderItems(int CartID, int StoreID, int CustomerID, decimal CartTotal)
        {
            string query1 = "SELECT CartTotal FROM ShoppingCart WHERE CartID = " + CartID + ";";
            List<Orders> order = new List<Orders>();
            ConnectDataBase();
            SqlCommand command = new SqlCommand(query1, this.SqlConnect);
            SqlDataReader dr = command.ExecuteReader();
            using (command = new SqlCommand(query1, this.SqlConnect))
            {
                dr.Close();
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.WriteLine(dr.GetValue(i));
                    };

                }


            }
            return CartTotal;
        }



        public void deleteFromCart(int CartID, int ProductID)
        {

            string query = $"DELETE FROM ShoppingCartItems WHERE ProductID = " + ProductID + " AND " + "CartID = " + CartID + " ;";
            List<CartItems> cartItems = new List<CartItems>();
            ConnectDataBase();
            SqlCommand command = new SqlCommand(query, SqlConnect);
            //{
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }
            cartItems = this.mapper.EntityToCartItem(dr);

            dr.Close();
        }
        public void deleteCartItems(int CartID)
        {
            string query = "DELETE ShoppingCartItems WHERE CartID = " + CartID + " ;";
            ConnectDataBase();
            using (SqlCommand command = new SqlCommand(query, this.SqlConnect))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                dataReader.Close();
            }
        }
        public void viewCart(int CartID)
        {
            string query = "SELECT LineID, ProductName, ItemQuantity, ItemTotal " +
                           "FROM ShoppingCartItems " +
                           "LEFT OUTER JOIN Products " +
                           "ON Products.ProductID = ShoppingCartItems.ProductID " +
                           "WHERE CartID = " + CartID +
                           "ORDER BY LineID ;";
            List<CartItems> itemsInCart = new List<CartItems>();

            ConnectDataBase(); 
            SqlCommand command = new SqlCommand(query, this.SqlConnect);
           
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetValue(i));
                };

            }
        }


    }
}