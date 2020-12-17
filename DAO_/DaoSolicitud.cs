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
    public class DaoSolicitud
    {
        SqlConnection conexion;
        public DaoSolicitud()
        {
            conexion= new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool SelectSolicitudTipo(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.PK_IS_Cod = (int)reader[0];
                objsol.VS_TipoSolicitud = (string)reader[1];
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectSolicitudImporte(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.PK_IS_Cod = (int)reader[0];
                objsol.DS_ImporteTotal = Convert.ToDouble(reader[8].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectSolicitudDiseñoPersonalizado(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.VS_TipoSolicitud = (string)reader[1];
                objsol.DS_PrecioAprox = Convert.ToDouble(reader[6].ToString());
                //objsol.VBS_Imagen = (byte[])reader[2];
                //objsol.VS_Comentario = (string)reader[9];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataTable SelectSolicitudDiseñoPropioIMG(DtoSolicitud objsol)
        {
            DataTable dtsolicitudes = null;
            string select = "SELECT VBS_Imagen from T_Solicitud where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand command = new SqlCommand(select, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudDiseñoPropio(DtoSolicitud objsol)
        {
            DataTable dtsolicitudes = null;
            string select = "SELECT PK_IS_Cod,DS_Largo,DS_Ancho,VS_Comentario,IS_Cantidad,DS_PrecioAprox,DTS_FechaRecojo,DS_ImporteTotal from T_Solicitud where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand command = new SqlCommand(select, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public void UpdateEstadoSolicitud_RevisióPago(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 6, DTS_FechaEmicion= GETDATE()  Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Rechazado(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 4 Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Observacion(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 7, VS_Comentario='"+objsolicitud.VS_Comentario+"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
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
        public DataTable SelectSolicitudesDiseñoPropio_Clientes()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Solicitudes_DiseñoPropio", conexion);
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
        public string SelectSolicitudPago(DtoSolicitud objsol)
        {
            string v = "";
            SqlCommand unComando = new SqlCommand("SP_SelectPagos", conexion);
            conexion.Open();
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@sol", objsol.PK_IS_Cod);
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                v = (string)reader[0];
            }
            conexion.Close();
            return v;
        }
        public bool SelectSolicitud(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.VS_TipoSolicitud = (string)reader[1];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataTable ListaMoldurasSolicitud(DtoSolicitud objSol)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud", conexion);
            command.Parameters.AddWithValue("@sol", objSol.PK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable ListaMoldurasSolicitudXDiseñoPropio(DtoSolicitud objSol)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud_Diseño_Propio", conexion);
            command.Parameters.AddWithValue("@sol", objSol.PK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public void Actualizar_Estado_SolicitudX1(DtoSolicitud objsol)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 8 where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand unComando = new SqlCommand(update, conexion);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void UpdateSolicitudFecha_RevisionFecha(DtoSolicitud objsol)
        {
            string update = "UPDATE T_Solicitud SET DTS_FechaRecojo=CAST(DATEADD(day," + objsol.IS_Ndias + ",GETDATE()) AS DATE),FK_ISE_Cod=3, DS_ImporteTotal="+objsol.DS_ImporteTotal+", IS_Ndias="+objsol.IS_Ndias+" where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
