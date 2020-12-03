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
    public class Dao_Voucher
    {
        SqlConnection conexion;
        public Dao_Voucher()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarVoucher(Dto_Voucher objDtoVoucher)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarVoucher", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPago", objDtoVoucher.FK_VP_Cod);
            cmd.Parameters.AddWithValue("@numvoucher", objDtoVoucher.PK_VV_NumVoucher);
            cmd.Parameters.AddWithValue("@imagen", objDtoVoucher.VBV_Foto);
            cmd.Parameters.AddWithValue("@importe", objDtoVoucher.DV_ImporteDepositado);
            cmd.Parameters.AddWithValue("@comentario", objDtoVoucher.VV_Comentario);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
