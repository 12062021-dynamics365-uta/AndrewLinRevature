using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain1
{
    public class Customer
    {
        public List<Customer> customers; //All new customers

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public Customer returningCustomer;


        public Customer(string first, string last)
        {
            first = FirstName;
            last = LastName;
        }

        internal bool Login()
        {
            throw new NotImplementedException();
        }

 
        public void Login(string first, string last)
        {
            Customer c1 = customers.Where(c1 => c1.FirstName == first && c1.LastName == last).FirstOrDefault();
            if (c1 == null)
            {
                Customer c = new Customer(first, last);
                this.returningCustomer = c;
                customers.Add(c);

            }
            else
            {
                this.returningCustomer = c1;
            }

        }

    }
}