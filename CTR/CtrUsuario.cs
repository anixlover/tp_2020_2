using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DAO;
using DTO;

namespace CTR
{
    public class CtrUsuario
    {
        DaoUsuario objDaoUsuario;
        public CtrUsuario()
        {
            objDaoUsuario = new DaoUsuario();
        }
        public void RegistrarClienteUsuarioExterno(DtoUsuario objUsuario)
        {
            bool correcto = true;
            string usuarioNom = "";
            string usuarioApe = "";
            string usuarioCor = "";
            string usuarioDni = "";
            string Expression = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            int usuarioCel = 0;
            //DNI solo tiene números
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                for (int i = 0; i < usuarioDni.Trim().Length; i++)
                {
                    correcto = char.IsDigit(usuarioNom.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 1;
                return;
            }
            //Nombre solo tiene letras
            try
            {
                usuarioNom = objUsuario.VU_Nombre;
                for (int i = 0; i < usuarioNom.Trim().Length; i++)
                {
                    correcto = char.IsLetter(usuarioNom.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 2;
                return;
            }
            //Apellido solo tiene letras
            try
            {
                usuarioApe = objUsuario.VU_Apellidos;
                for (int i = 0; i < usuarioApe.Trim().Length; i++)
                {
                    correcto = char.IsLetter(usuarioApe.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 3;
                return;
            }
            //Correo escrito correctamente
            usuarioCor = objUsuario.VU_Correo;
            correcto = Regex.IsMatch(usuarioCor,Expression);
            if (!correcto) 
            {
                objUsuario.IU_Estado = 4;
                return;
            }
            //Dni duplicado
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                correcto = !objDaoUsuario.SelectUsuarioxDni(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 5;
                return;
            }
            //Celular Duplicado
            try
            {
                usuarioCel = objUsuario.IU_Celular;
                correcto = !objDaoUsuario.SelectUsuarioxCelular(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 6; 
                return; 
            }
            //Correo duplicado
            try
            {
                usuarioCor = objUsuario.VU_Correo;
                correcto = !objDaoUsuario.SelectUsuarioxCorreo(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto) 
            {
                objUsuario.IU_Estado = 7; 
                return; 
            }
            //Registro exitoso!
            objUsuario.IU_Estado = 77;
            objDaoUsuario.InsertUsuarioCliente(objUsuario);
        }
        public string GenerarContraseña(DtoUsuario objUsuario) 
        {
            DateTime fecha = new DateTime();
            string contraseña = fecha.Year.ToString() + objUsuario.PK_VU_Dni.Trim()[0]+ objUsuario.PK_VU_Dni.Trim()[7] + fecha.Month.ToString();
            return contraseña;
        }
        public void RegistrarClienteVendedor(DtoUsuario objUsuario)
        {
            bool correcto = true;
            string usuarioNom = "";
            string usuarioApe = "";
            string usuarioCor = "";
            string usuarioDni = "";
            string Expression = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            int usuarioCel = 0;
            //DNI solo tiene números
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                for (int i = 0; i < usuarioDni.Trim().Length; i++)
                {
                    correcto = char.IsDigit(usuarioNom.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 1;
                return;
            }
            //Nombre solo tiene letras
            try
            {
                usuarioNom = objUsuario.VU_Nombre;
                for (int i = 0; i < usuarioNom.Trim().Length; i++)
                {
                    correcto = char.IsLetter(usuarioNom.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 2;
                return;
            }
            //Apellido solo tiene letras
            try
            {
                usuarioApe = objUsuario.VU_Apellidos;
                for (int i = 0; i < usuarioApe.Trim().Length; i++)
                {
                    correcto = char.IsLetter(usuarioApe.Trim()[i]);
                }
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 3;
                return;
            }
            //Correo escrito correctamente
            usuarioCor = objUsuario.VU_Correo;
            correcto = Regex.IsMatch(usuarioCor, Expression);
            if (!correcto)
            {
                objUsuario.IU_Estado = 4;
                return;
            }
            //Dni duplicado
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                correcto = !objDaoUsuario.SelectUsuarioxDni(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 5;
                return;
            }
            //Celular Duplicado
            try
            {
                usuarioCel = objUsuario.IU_Celular;
                correcto = !objDaoUsuario.SelectUsuarioxCelular(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 6;
                return;
            }
            //Correo duplicado
            try
            {
                usuarioCor = objUsuario.VU_Correo;
                correcto = !objDaoUsuario.SelectUsuarioxCorreo(objUsuario);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objUsuario.IU_Estado = 7;
                return;
            }
            //Registro exitoso!
            objUsuario.VU_Contrasenia = GenerarContraseña(objUsuario);
            objUsuario.IU_Estado = 77;
            objDaoUsuario.InsertUsuarioCliente(objUsuario);
        }
        public bool ValidarInicioSesion(DtoUsuario objUsuario)
        {
            return objDaoUsuario.SelectUsuarioxDni_Contraseña(objUsuario);
        }
    }
}
