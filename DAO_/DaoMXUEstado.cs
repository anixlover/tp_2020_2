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
    public class DaoMXUEstado
    {
        SqlConnection conexion;
        public DaoMXUEstado()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataSet SelectMXUEstado()
        {
            SqlDataAdapter Estado = new SqlDataAdapter("SELECT*FROM T_MXU_ESTADO", conexion);
            DataSet DS = new DataSet();
            Estado.Fill(DS);
            return DS;
        }
    }
}
