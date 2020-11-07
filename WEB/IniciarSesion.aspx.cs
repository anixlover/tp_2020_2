using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace WEB
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            objUsuario.PK_VU_Dni = txtDNI.Text;
            objUsuario.VU_Contrasenia = txtContraseña.Text;
            if (!objCtrUsuario.ValidarInicioSesion(objUsuario))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Usuario o contraseña INCORRECTOS!!'});", true);
                return;
            }
            int tipoUsuario = objUsuario.FK_ITU_Cod;
            switch (tipoUsuario)
            {
                case 1: Response.Redirect("Home.aspx"); break;
            }
        }
    }
}