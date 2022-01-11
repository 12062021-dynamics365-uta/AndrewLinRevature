using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Business.GettersAndSetters;

namespace Business
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                flavorID = dr.GetInt32(0),
                flavorName = dr.GetString(1)
            };
        }

        public Person EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                personID = dr.GetInt32(0),
                fName = dr.GetString(1),
                lName = dr.GetString(2)
            };
        }

        public List<Flavor> EntityToFlavorList(SqlDataReader dr)
        {
            List<Flavor> flavorList = new List<Flavor>();

            while (dr.Read()){
                Flavor flavor = new Flavor()
                {
                    flavorID = dr.GetInt32(0),
                    flavorName = dr.GetString(1)
                };
                flavorList.Add(flavor);
            }

            return flavorList;
        }
        public Person EntityToPersonAndFlavor(SqlDataReader dr)
        {
            Person person = new Person()
            {
                personID = dr.GetInt32(0),
                fName = dr.GetString(1),
                lName = dr.GetString(2),
                Flavors = new List<Flavor>()
            };

            return person;
        }
    }
}
