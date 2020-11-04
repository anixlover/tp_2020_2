using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;

namespace WEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CtrUsuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new CtrUsuario();
        }

        public void ValidarInicioSesion(DtoUsuario objUsuario)
        {
            bool correcto = true;
            string usuarioDni = "";
            string usuarioContraseña = "";
            //Campos de usuario vacios
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                correcto = !usuarioDni.Equals("");
            }

            catch
            {
                correcto = false;
            }

            if (!correcto)
            {
                return;
            }
            //Campos de contraseña vacios
            try
            {
                usuarioContraseña = objUsuario.VU_Contrasenia;
                correcto = !usuarioContraseña.Equals("");
            }

            catch
            {
                correcto = false;
            }

            if (!correcto)
            {
                return;
            }
            //Usuario incorrecto
            try
            {
                usuarioDni = objUsuario.PK_VU_Dni;
                correcto = usuario.ValidarInicioSesion(objUsuario);
            }

            catch
            {
                correcto = false;
            }

            if (!correcto)
            {
                return;
            }
            
        }

        
    }
}