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
        public DataTable SelectSolicitudesxDNI(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_SolicitudesxDNI", conexion);
            command.Parameters.AddWithValue("@dni", objDtoMolduraXUsuario.FK_VU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesxDNI_y_Estado(DtoMolduraXUsuario objDtoMolduraXUsuario, int estado)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_SolicitudesxDNI_y_Estado", conexion);
            command.Parameters.AddWithValue("@dni", objDtoMolduraXUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idSolEst",estado);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
    }
}
