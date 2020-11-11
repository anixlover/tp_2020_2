using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.Net.Mail;
using System.Net;
namespace DAO
{
    public class DaoUsuario
    {
        SqlConnection conexion;
        //constructor
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertUsuarioCliente(DtoUsuario Usuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Usuario_Insert";
            command.Connection = conexion;
            command.Parameters.AddWithValue("@DNI", Usuario.PK_VU_Dni);
            command.Parameters.AddWithValue("@Nom", Usuario.VU_Nombre);
            command.Parameters.AddWithValue("@Ape", Usuario.VU_Apellidos);
            command.Parameters.AddWithValue("@Cel", Usuario.IU_Celular);
            command.Parameters.AddWithValue("@FechaNac", Usuario.DTU_FechaNac);
            command.Parameters.AddWithValue("@Cor", Usuario.VU_Correo);
            command.Parameters.AddWithValue("@Con", Usuario.VU_Contrasenia);
            command.Parameters.AddWithValue("@Tipo", Usuario.FK_ITU_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectUsuarioxDni(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE PK_VU_Dni = '" + Usuario.PK_VU_Dni + "'";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
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
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
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
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
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
        public bool SelectUsuarioxDni_Contraseña(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE PK_VU_Dni = '" + Usuario.PK_VU_Dni + "' and VU_Contrasenia = '" + Usuario.VU_Contrasenia + "'";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                Usuario.VU_Nombre = (string)reader[1];
                Usuario.VU_Apellidos = (string)reader[2];
                Usuario.IU_Celular = (int)reader[3];
                Usuario.VU_Correo = (string)reader[5];
                Usuario.FK_ITU_Cod = (int)reader[7];
            }
            conexion.Close();
            return hayRegistros;
        }

        public bool SelectUsuarioxDni_Correo_Celular(DtoUsuario Usuario)
        {
            string select = "SELECT * FROM T_Usuario WHERE PK_VU_Dni = '" + Usuario.PK_VU_Dni + "' and VU_Correo = '" + Usuario.VU_Correo + "' and IU_Celular = '" + Usuario.IU_Celular + "'";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                Usuario.VU_Nombre = (string)reader[1];
                Usuario.VU_Apellidos = (string)reader[2];
                Usuario.IU_Celular = (int)reader[3];
                Usuario.VU_Correo = (string)reader[5];
                Usuario.FK_ITU_Cod = (int)reader[7];
            }
            conexion.Close();
            return hayRegistros;
        }

        public void UpdateContraseña(DtoUsuario Usuario)
        {
            string update = "UPDATE T_Usuario SET VU_Contrasenia = '" + Usuario.VU_Contrasenia + "' WHERE PK_VU_Dni = '" + Usuario.PK_VU_Dni + "'";
            SqlCommand command = new SqlCommand(update, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
