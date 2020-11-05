using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoTipoMoldura
    {
        SqlConnection conexion;
        public DaoTipoMoldura()
        {
            conexion = new SqlConnection(ConexiónBD.CadenaConexión);
        }
        public void ListarTipoMoldura(DtoTipoMoldura objTipo)
        {
            string select = "SELECT * FROM T_TIPOMOLDURA WHERE PK_ITM_Tipo" + objTipo.PK_ITM_Tipo;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objTipo.VTM_Nombre = (string)reader[1];
                objTipo.VTM_UnidadMetrica = (string)reader[2];
            }
            conexion.Close();
        }
        public DataSet ListarTipoMoldura()
        {
            SqlDataAdapter TipoMoldura = new SqlDataAdapter("SP_Listar_TipoMoldura", conexion);
            TipoMoldura.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            TipoMoldura.Fill(DS);
            return DS;
        }
    }
    
}
