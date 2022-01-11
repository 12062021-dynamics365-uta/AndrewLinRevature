using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBaseAccess
{
    public interface ISweetnSaltyDataBaseAccess
    {
        Task<SqlDataReader> GetFlavors();
        Task<SqlDataReader> PrintPerson(string fName, string lName);
        Task<SqlDataReader> PrintFlavor(string flavor);
        Task<SqlDataReader> GetPerson(string fName, string lName);
        Task<SqlDataReader> FindPersonFlavor(int PersonID);
       
    }
}
