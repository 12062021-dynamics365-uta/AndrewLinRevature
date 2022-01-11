using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccess;
using System.Data.SqlClient;
using static Business.GettersAndSetters;
namespace Business
{
   public class BusinessClass : IBusinessClass
    {
        private readonly ISweetnSaltyDataBaseAccess _dbaClass;
        private readonly IMapper _mapper;

        public BusinessClass(ISweetnSaltyDataBaseAccess Dbaccess, IMapper mapper)
        {
            this._dbaClass = Dbaccess;
            this._mapper = mapper;
        }

        public async Task<Flavor> PrintFlavor(string flavor)
        {
            SqlDataReader dr = await _dbaClass.PrintFlavor(flavor);

            if (dr.Read())
                return _mapper.EntityToFlavor(dr);
            else
                return null;
        }

        public async Task<Person> PrintPerson(string fName, string lName)
        {
            SqlDataReader dr = await _dbaClass.PrintPerson(fName, lName);

            if (dr.Read())
                return _mapper.EntityToPerson(dr);
            else
                return null;
        }

        public async Task<Person> GetPerson(string fName, string lName)
        {
            SqlDataReader dr = await _dbaClass.GetPerson(fName, lName);

            if (dr.Read())
                return _mapper.EntityToPerson(dr);
            else
                return null;
        }

       

        public async Task<List<Flavor>> GetFlavors()
        {
            SqlDataReader dr = await _dbaClass.GetFlavors();
            if (dr.Read())
                return _mapper.EntityToFlavorList(dr);
            else
                return null;
        }
        public async Task<List<Flavor>> FindPersonFlavor(int personId)
        {
            SqlDataReader dr = await this._dbaClass.FindPersonFlavor(personId);
            List<Flavor> flavors = new List<Flavor>();
            while (dr.Read())
            {
                Flavor f = this._mapper.EntityToFlavor(dr);
                flavors.Add(f);
            }
            return flavors;
        }
    }

}

