using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GettersAndSetters
    {
        public class Person
        {
            public int personID { get; set; }
            public string fName { get; set; }
            public string lName { get; set; }
            public List<Flavor> Flavors
            {
                get; set;
            }

        }
       
        public class Flavor
        {
            public int flavorID { get; set; }
            public string flavorName { get; set; }
        
        }

       
    }
}
