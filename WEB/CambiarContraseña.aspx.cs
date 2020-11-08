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
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContraseña_Click(object sender, EventArgs e)
        {
            if(!objCtrUsuario.ValidarUsuarioxDni_Correo_Celular(objUsuario))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Usuario o contraseña INCORRECTOS!!'});", true);
                return;
            }

            else
            {
                
            }
        }
    }
}