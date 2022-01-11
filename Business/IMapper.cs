using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Business.GettersAndSetters;

namespace Business
{
    public interface IMapper
    {
        Flavor EntityToFlavor(SqlDataReader dr);
        Person EntityToPerson(SqlDataReader dr);
        List<Flavor> EntityToFlavorList(SqlDataReader dr);
        Person EntityToPersonAndFlavor(SqlDataReader dr);
    }
}

