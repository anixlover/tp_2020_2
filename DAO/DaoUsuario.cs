using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class DaoUsuario
    {
        SqlConnection conexion;
        //constructor
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexiónBD.CadenaConexión);
        }
        public void InsertUsuarioCliente(DtoUsuario Usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Usuario_Insert";
            cmd.Connection = conexion;
            cmd.Parameters.AddWithValue("@DNI", Usuario.PK_VU_Dni);
            cmd.Parameters.AddWithValue("@Nom", Usuario.VU_Nombre);
            cmd.Parameters.AddWithValue("@Ape", Usuario.VU_Apellidos);
            cmd.Parameters.AddWithValue("@Cel", Usuario.IU_Celular);            
            cmd.Parameters.AddWithValue("@FechaNac", Usuario.DTU_FechaNac);
            cmd.Parameters.AddWithValue("@Cor", Usuario.VU_Correo);
            cmd.Parameters.AddWithValue("@Con", Usuario.VU_Contraseña);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectUsuarioxDni(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE PK_VU_Dni = '" +Usuario.PK_VU_Dni+"'" ;
            SqlCommand Comando = new SqlCommand(select,conexion);
            conexion.Open();
            SqlDataReader reader = Comando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                Usuario.VU_Nombre = (string)reader[1];
                Usuario.VU_Apellidos = (string)reader[2];
                Usuario.IU_Celular = (int)reader[3];
                Usuario.VU_Correo = (string)reader[5];
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuarioxCorreo(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE VU_Correo = '" + Usuario.VU_Correo + "'";
            SqlCommand Comando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = Comando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                Usuario.PK_VU_Dni = (string)reader[0];
                Usuario.VU_Nombre = (string)reader[1];
                Usuario.VU_Apellidos = (string)reader[2];
                Usuario.IU_Celular = (int)reader[3];
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuarioxCelular(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE IU_Celular = '" + Usuario.IU_Celular + "'";
            SqlCommand Comando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = Comando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                Usuario.PK_VU_Dni = (string)reader[0];
                Usuario.VU_Nombre = (string)reader[1];
                Usuario.VU_Apellidos = (string)reader[2];
                Usuario.VU_Correo = (string)reader[5];
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
