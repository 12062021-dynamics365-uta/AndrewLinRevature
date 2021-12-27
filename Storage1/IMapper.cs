using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain1;


namespace Storage1
{

    public interface IMapper
    {
        public int EntitytoisCustomer(SqlDataReader dr);
        List<CartItems> EntityToCartItem(SqlDataReader dr);
        List<ShoppingCart> EntityToCart(SqlDataReader dr);
        List<Products> EntityToProducts(SqlDataReader dr);
    }
}
