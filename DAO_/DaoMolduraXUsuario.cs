using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoMolduraXUsuario
    {
        SqlConnection conexion;
        public DaoMolduraXUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarMolduraxUsuario(DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
