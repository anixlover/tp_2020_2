using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class ConexiónBD
    {
        public static string CadenaConexión
        {
            get 
            {
                return "Data Source=(Local);Initial Catalog=BD_SWCPEDR;Integrated Security=True";
            }
        }
    }
}
