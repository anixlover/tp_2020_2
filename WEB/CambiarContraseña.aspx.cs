using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Windows.Forms;

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
            objUsuario.PK_VU_Dni = txtDNI.Text;
            objUsuario.VU_Correo = txtCorreo.Text;
            objUsuario.IU_Celular = int.Parse(txtnumber.Text);
            if(!objCtrUsuario.ValidarUsuarioxDni_Correo_Celular(objUsuario))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Datos NO VALIDOS!!'});", true);
                return;
            }

            else
            {
                if(txtContraseña.Text == txtContraseña2.Text)
                {
                    objUsuario.VU_Contrasenia = txtContraseña.Text;
                    objCtrUsuario.CambiarContraseña(objUsuario);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: '',text: 'Contraseña cambiada con éxito!!'});", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Las contraseñas no coinciden!!'});", true);
                }
            }
        }
    }
}