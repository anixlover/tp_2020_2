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
    public class DaoMoldura
    {
        SqlConnection conexion;
        public DaoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras=null;
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
            SqlCommand command = new SqlCommand("SP_RegistrarImagen_Moldura", conexion);
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
        public void InsertMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            //command.Parameters.AddWithValue("@imagen", DBNull.Value);
            var binary1 = command.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
            binary1.Value = DBNull.Value;
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@largo", objmoldura.DM_Largo);
            command.Parameters.AddWithValue("@ancho", objmoldura.DM_Ancho);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objmoldura.PK_IM_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        
        public DataTable ListarTodoMolduras(DtoMoldura objmoldura)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Todo_Moldura", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
    }
}
