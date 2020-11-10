﻿using System;
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
            string update = "UPDATE T_Usuario SET VU_Contrasenia = '" + Usuario.VU_Contrasenia + "' WHERE VU_Correo = '" + Usuario.VU_Correo + "'";
            SqlCommand command = new SqlCommand(update, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void EnviarCorreoaUsuario(DtoUsuario objuser)
        {
            string Select = "SELECT VU_Correo, VU_Contrasenia, VU_Nombre from T_Usuario where VU_Correo ='"
                + objuser.VU_Correo + "'";

            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();

            if (reader.Read())
            {
                string senderr = "decormoldurassac@gmail.com";
                string senderrPass = "decormolduras";
                string displayName = "DECORMOLDURAS & ROSETONES SAC";

                var recipient = reader["VU_Correo"].ToString();
                var pass = reader["VU_Contrasenia"].ToString();
                var nombre = reader["VU_Nombre"].ToString();

                string body =
                    "<body>" +
                        "<h1>DECORMOLDURAS & ROSETONES SAC</h1>" +
                        "<h4>Bienvenid@ " + nombre + "</h4>" +
                        "<span>No comparta esto con nadie." +
                        "<br></br><span>Su contraseña actual es: " + pass + "</span>" +
                        //"<br></br><span>link de confirmación: "+ "https://localhost:44363/CambiarContraseña.aspx?act=" + recipient +
                        "<br></br><span> Saludos cordiales.<span>" +
                    "</body>";

                MailMessage mail = new MailMessage();
                mail.Subject = "Bienvenido";
                mail.From = new MailAddress(senderr.Trim(), displayName);
                mail.Body = body;
                mail.To.Add(recipient.Trim());
                mail.IsBodyHtml = true;
                //mail.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 44363;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
                NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
                smtp.Credentials = nc;

                smtp.Send(mail);
            }
        }
    }
}
