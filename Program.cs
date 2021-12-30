using System;
using System.Data.SqlClient;
using Domain1;
using Storage1;
using System.Collections.Generic;

namespace Project0
{
    class Program
    { 

       
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Mapper mapper = new Mapper();
            connectDataBase db = new connectDataBase();
            DataManager dm = new DataManager(db);
            Console.WriteLine("Hello, Welcome to Bored Games. We sell board games.\n");
            bool currentCustomer = false;
            bool login = false;
            int CustomerID = 1;
            do
            {
                do
                {
                 
                    Console.WriteLine("Are you a new user or a returning user? Enter 1 if you are a returning user to log in and enter 2 if you are a new user to create a new login\n");
                    string logInput = Console.ReadLine();
                    

                    if (logInput == "1")
                    {

                        Console.WriteLine("Enter first name: \n");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Enter your login name: \n");
                        string loginName = Console.ReadLine();
                       
                        Customer loginCheck = new Customer(FirstName, LastName);
                        connectDataBase isCustomer = new connectDataBase();
                        CustomerID = isCustomer.getCustomerID(FirstName, LastName);
                        Console.WriteLine(CustomerID);
                      

                        if (CustomerID == 0)
                        {
                            Console.WriteLine("This name does not exist, please create a new account. \n");
                            currentCustomer = false;
                        }
                        else
                        {
                            login = true;
                            Console.WriteLine("Welcome. Would you like to add a new Store location, Add a new Product, or continue to shopping? \n" +
                                              "(Enter 1: Add Store location)\n" +
                                              "(Enter 2: Add Product)\n" +
                                              "(Enter 3: Add Both)\n" +
                                              "(Enter Anything Else: Continue\n");
                            int adminInput = Convert.ToInt32(Console.ReadLine());
                            if(adminInput == 1)
                            {
                                Console.WriteLine("What will the Store Number be? \n");
                                int storeInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Where will the Location be?\n");
                                string locationInput = Console.ReadLine();
                                connectDataBase newStore = new connectDataBase();
                                newStore.addLocation(storeInput, locationInput);
                                Console.WriteLine("Successfully Added!");
                            }
                            if(adminInput == 2)
                            {
                                Console.WriteLine("What will the Product ID be?");
                                int productIDInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("What is the Product Name?");
                                string productNameInput = Console.ReadLine();
                                Console.WriteLine("What is the Price of the Product?");
                                decimal productPriceInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("What is the description of the product?");
                                string prodDescriptionInput = Console.ReadLine();
                                connectDataBase newProduct = new connectDataBase();
                                newProduct.addProduct(productIDInput, productNameInput, productPriceInput, prodDescriptionInput);
                                connectDataBase storeLocation = new connectDataBase();
                                storeLocation.findStores();
                                Console.WriteLine("Which Location would you like to stock this product?");
                                int productLocationInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("How many of this product will be at this location?");
                                int productQuantityInput = Convert.ToInt32(Console.ReadLine());
                                storeLocation.addProductToStore(productLocationInput, productIDInput, productQuantityInput);
                                Console.WriteLine("Successfully Added!");

                            }
                            if (adminInput == 3)
                            {
                                Console.WriteLine("What will the Store Number be? \n");
                                int storeInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Where will the Location be?\n");
                                string locationInput = Console.ReadLine();
                                connectDataBase newStore = new connectDataBase();
                                newStore.addLocation(storeInput, locationInput);
                                Console.WriteLine("Successfully Added!");
                                Console.WriteLine("What will the Product ID be?");
                                int productIDInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("What is the Product Name?");
                                string productNameInput = Console.ReadLine();
                                Console.WriteLine("What is the Price of the Product?");
                                decimal productPriceInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("What is the description of the product?");
                                string prodDescriptionInput = Console.ReadLine();
                                connectDataBase newProduct = new connectDataBase();
                                newProduct.addProduct(productIDInput, productNameInput, productPriceInput, prodDescriptionInput);
                                connectDataBase storeLocation = new connectDataBase();
                                storeLocation.findStores();
                                Console.WriteLine("Which Location would you like to stock this product?");
                                int productLocationInput = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("How many of this product will be at this location?");
                                int productQuantityInput = Convert.ToInt32(Console.ReadLine());
                                storeLocation.addProductToStore(productLocationInput, productIDInput, productQuantityInput);
                                Console.WriteLine("Successfully Added!");
                            }
                                
                            else
                            {
                                Console.WriteLine("We will continue to shopping then");
                            }
                        }
                    }
                    else if (logInput == "2")
                    {
                        Console.WriteLine("Enter first name: \n");
                        string newFirstName = Console.ReadLine();
                        Console.WriteLine("Enter last name: \n");
                        string newLastName = Console.ReadLine();
                        Console.WriteLine("Enter a login name: \n");
                        string newLoginName = Console.ReadLine();
                        connectDataBase newCustID = new connectDataBase();
                        CustomerID = newCustID.getNextCustomerID();
                        connectDataBase newLogin = new connectDataBase();
                        newLogin.addCustomer(CustomerID, newFirstName, newLastName, newLoginName);

                        login = true;

                    }
                    else
                    {
                        Console.WriteLine("Please type a valid response");
                        login = false;
                    }

                } while (!login);
            } while (currentCustomer);



            bool ifStore = false;
            int isStore = 0;
            do
            {
                Console.WriteLine("We have multiple locations, which are you going to be shopping from? (Enter the number above the location to choose a location) \n");
                connectDataBase storeLocation = new connectDataBase();
                storeLocation.findStores();
                string storeSelect = Console.ReadLine();
                int convertNumber = -1;
                bool convertBool = false;
                convertBool = Int32.TryParse(storeSelect, out convertNumber);
                isStore = Convert.ToInt32(storeSelect);
                if (convertNumber > 0)
                {
                    connectDataBase displayProducts1 = new connectDataBase();
                    dm.currentStore.StoreNum = convertNumber;
                    Console.WriteLine("Here are all the products at this location!\n");
 
                    dm.LoadProducts();
                    foreach (Products p in dm.currentStore.products)
                    {
                       
                        Console.WriteLine($"ProductID:{p.ProductID}\n  ProductName:{p.ProductName}\n ${p.price}\n Quantity:{p.ProductQuantity}\n");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input. Try again!");
                }
            } while (ifStore);

            int CartID = dm.addCart(isStore, CustomerID);
            decimal totalPrice = 0;
            int CartItemID = rnd.Next(1,3000);
            bool addCart = false;
            do
            {
                
                int itemCount = 0;
                Console.Write("Which item do you want to buy? Please enter the number above the game name: \n");
                int productIDSelect = Convert.ToInt32(Console.ReadLine());
                decimal priceOfProduct = db.GetProductPrice(productIDSelect);
                Console.Write("Quantity that you would like to order: ");
                int itemQuantity = Convert.ToInt32(Console.ReadLine());
                string productName = db.GetProductName(productIDSelect);
                totalPrice = totalPrice + (priceOfProduct * itemQuantity);
                foreach (Products p in dm.currentStore.products)
                {
                    CartItemID++;
                   
                  
                    if (productIDSelect == p.ProductID)
                    {
                       
                        if (itemQuantity <= p.ProductQuantity)
                        {
                            List<CartItems> cartItems = dm.addItemToCart(CartItemID,CartID, productIDSelect, itemQuantity);
                            itemCount++;
                        }
                    }
                }

                if (itemCount == 0)
                {
                    Console.WriteLine("Invalid input.");
                }

                connectDataBase order = new connectDataBase();
                order.insertOrderHistory(CustomerID, productName, itemQuantity, priceOfProduct);
                bool menu = true;
                do
                {
                    
                    Console.WriteLine("Would you like to do anything else? \n " +
                                       "(1: Add an item to your Cart) \n " +
                                       "(2: View your cart) \n " +
                                       "(3: Checkout) \n " +
                                       "(4: View Order History) \n " +
                                       "(5: Delete an item)\n" +
                                       "(6: Cancel Order) \n" +
                                       "(7: EXIT)\n"
                                       );
                    string userInput = (Console.ReadLine().ToString());

                    if (userInput == "1")
                    {
                        addCart = false;
                        menu = false;

                    }
                    else if (userInput == "2")
                    {

                        Console.WriteLine("(From top to bottom)\n Your Order Number,\n Name Of Board Game,\n Quantity in your cart,\n and the price of these items in US dollars\n ");
                        connectDataBase viewItems = new connectDataBase();
                        viewItems.viewCart(CartID);

                    }
                    else if (userInput == "3")
                    {
                        connectDataBase checkout = new connectDataBase();
                        Console.WriteLine("Your Total is $" + totalPrice);
                        Console.WriteLine("Thanks for shopping!");
                        checkout.deleteCartItems(CartID);
                        totalPrice = 0;
                      


                    }
                    else if (userInput == "4")
                    {
                        Console.WriteLine("(From top to bottom)\n The Game Number,\n Name Of Board Game,\n Quantity,\n and the price of these items in US dollars\n ");
                        connectDataBase orderHistory = new connectDataBase();
                        orderHistory.checkOrderHistory(CustomerID);
                    }
                    else if (userInput == "5")
                    {
                        Console.WriteLine("Which item would you like to delete? (Enter the cooresponding productID number):");
                        int ProductID = Convert.ToInt32(Console.ReadLine());
                        connectDataBase deleteItems = new connectDataBase();
                        deleteItems.deleteFromCart(CartID, ProductID);
                    }
                   else if(userInput == "6")
                    {
                        connectDataBase deleteCart = new connectDataBase();
                        deleteCart.deleteCartItems(CartID);
                        Console.WriteLine("Order Canceled!");
                    }
                    else if (userInput == "7")
                    {
                        Console.WriteLine("Thanks for shopping!");
                        menu = false;
                        addCart = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again");

                    }
                }
                while (menu);

            } while (!addCart);



        }

    }

}
