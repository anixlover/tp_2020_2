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
        public DataTable ListaMoldurasSolicitud(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud", conexion);
            command.Parameters.AddWithValue("@sol", objDtoMolduraXUsuario.FK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
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
        public DataTable ListarMXU(DtoMolduraXUsuario objmxu)
        {
            DataTable dtmxu = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_MXU_C", conexion);
            command.Parameters.AddWithValue("@idU", objmxu.FK_VU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmxu = new DataTable();
            daAdaptador.Fill(dtmxu);
            conexion.Close();
            return dtmxu;
        }
        public void eliminarMXU(DtoMolduraXUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_Eliminar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.FK_IM_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
