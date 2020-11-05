using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAO;
using DTO;

namespace DAO
{
    public class DaoMoldura
    {
        SqlConnection conexion;
        public DaoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Detalles_Moldura_by_TipoMoldura", conexion);
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public void RegistrarImgMoldura(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Img_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            //SqlParameter retValue = new SqlParameter("@NewId", SqlDbType.Int);
            //retValue.Direction = ParameterDirection.ReturnValue;
            //command.Parameters.Add(retValue);
            //using (SqlDataReader dr = command.ExecuteReader())
            //{
            //    objmoldura.PK_IM_Cod = Convert.ToInt32(retValue.Value);
            //}
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
