using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.GettersAndSetters;

namespace Business
{
    public interface IBusinessClass
    {

        Task<Flavor> PrintFlavor(string flavor);
        Task<Person> PrintPerson(string fName, string lName);
        Task<Person> GetPerson(string fName, string lName);
        Task<List<Flavor>> GetFlavors();
        Task<List<Flavor>> FindPersonFlavor(int personId);
    }
}
