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
    public class Dao_Solicitud
    {
        SqlConnection conexion;
        public Dao_Solicitud()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable SelectSolicitudes()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Administrar_Solicitudes", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataSet desplegableSolicitudEstado()
        {
            SqlDataAdapter solest = new SqlDataAdapter("SP_Desplegable_Solicitud_Estado", conexion);
            solest.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            solest.Fill(DS);
            return DS;
        }
        public DataTable SelectSolicitudes(string tipo)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Administrar_Solicitudes_Filtro", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@tipo", tipo);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
    }
}
