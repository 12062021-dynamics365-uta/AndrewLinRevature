using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataBaseAccess
{
    public class SweetnSaltyDataBaseAccess : ISweetnSaltyDataBaseAccess
    {
        private readonly string str = "Data Source = LAPTOP-PITFN5NH\\SQLEXPRESS; initial Catalog = SweetnSalty; integrated security = true";
        private SqlConnection sqlconnection;
        
        public void DBAccess()
        {
            this.sqlconnection = new SqlConnection(this.str);
            sqlconnection.Open();
        }




        public async Task<SqlDataReader> GetFlavors()
        {
            string query = "SELECT * FROM Flavor;";

            using (SqlCommand cmd = new SqlCommand(query, this.sqlconnection))
            {
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }

        public async Task<SqlDataReader> GetPerson(string fName, string lName)
        {
            string query = "SELECT * FROM Person WHERE firstName = @fName && fastName = @lName;";
            using (SqlCommand cmd = new SqlCommand(query, this.sqlconnection))
            {
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }

        public async Task<SqlDataReader> PrintFlavor(string flavor)
        {
            string query = "INSERT INTO Flavor VALUES (@flavor);";

            using (SqlCommand cmd = new SqlCommand(query, this.sqlconnection))
            {
                cmd.Parameters.AddWithValue("@flavor", flavor);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string query1 = "SELECT * FROM Flavor ORDER BY FlavorID DESC;";
                    using (SqlCommand cmd2 = new SqlCommand(query1, this.sqlconnection))
                    {
                        SqlDataReader dr = await cmd2.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine($"EXCEPTION IN PRINTFLAVOR {ex}");
                    return null;
                }
            }
        }

        public async Task<SqlDataReader> PrintPerson(string fName, string lName)
        {
            string query = "INSERT INTO Person VALUES (@fName, @lName);";

            using (SqlCommand cmd = new SqlCommand(query, this.sqlconnection))
            {
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string query1 = "SELECT * FROM Person ORDER BY PersonID DESC;";
                    using (SqlCommand cmd2 = new SqlCommand(query1, this.sqlconnection))
                    {
                        SqlDataReader dr = await cmd2.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine($"EXCEPTION IN PRINTING PERSON {ex}");
                    return null;
                }
            }
        }

        public async Task<SqlDataReader> FindPersonFlavor(int PersonID)
        {
            string query = "SELECT person.PersonID, person.firstName, flavor.FlavorID, flavor.flavorName From Person LEFT JOIN PersonFlavorJunction WHERE person.PersonID = @PersonID;";
            using (SqlCommand cmd = new SqlCommand(query, this.sqlconnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }


    
    }
}
    

