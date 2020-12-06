﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoDatoFactura
    {
        SqlConnection conexion;
        public DaoDatoFactura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertDatoFatcura(DtoDatoFactura objDtoDatoFactura)
        {
            string insert = "INSERT INTO T_DATO_FACTURA VALUES('" + objDtoDatoFactura.VDF_Ruc+"','"+objDtoDatoFactura.FK_VU_Dni+"')";
            SqlCommand command = new SqlCommand(insert, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void DeleteDatoFatcura(DtoDatoFactura objDtoDatoFactura)
        {
            string insert = "DELETE T_DATO_FACTURA WHERE VDF_Ruc='"+objDtoDatoFactura.VDF_Ruc+"'"+"and FK_VU_Dni='"+objDtoDatoFactura.FK_VU_Dni+"'";
            SqlCommand command = new SqlCommand(insert, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectDatoFacturaxRUC_Dni(DtoDatoFactura objDtoDatoFactura)
        {
            string Select = "SELECT * from T_DATO_FACTURA where FK_VU_Dni ='" + objDtoDatoFactura.FK_VU_Dni + "' and VDF_Ruc='" + objDtoDatoFactura.VDF_Ruc + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoDatoFactura.VDF_Ruc = (string)reader[1];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataSet SelectRUCxDNI(DtoDatoFactura objDtoDatoFactura)
        {
            SqlDataAdapter dsRUCS = new SqlDataAdapter("SELECT VDF_Ruc from T_DATO_FACTURA where FK_VU_Dni ='" + objDtoDatoFactura.FK_VU_Dni + "'", conexion);
            DataSet DS = new DataSet();
            dsRUCS.Fill(DS);
            return DS;
        }
    }
}
