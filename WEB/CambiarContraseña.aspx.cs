using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace WEB
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //txtContraseña.Visible = false;
                //txtContraseña2.Visible = false;
                //if (Request.Params["act"] != null)
                //{
                //    txtContraseña.Visible = true;
                //    txtContraseña2.Visible = true;
                //}
            }
        }

        protected void btnContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "" | txtContraseña2.Text == "" | txtCorreo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!!',text: 'Espacios en BLANCO!!'});", true);
                return;
            }
            objUsuario.VU_Correo = txtCorreo.Text;
            if (objCtrUsuario.existenciaCorreo(objUsuario)==true)
            {                
                objUsuario.VU_Contrasenia = txtContraseña.Text;
                if (txtContraseña.Text != txtContraseña2.Text) 
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'las contraseñas deben coincidir!!'});", true);
                    return;
                }
                objCtrUsuario.CambiarContraseña(objUsuario);
                //objCtrUsuario.EnviarCorreo(objUsuario);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Revisa tu correo!',text: 'Contraseña actualizada y enviada!!'});", true);
                return;
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'Correo no existente!',text: 'Porfavor ingresar su correo!!'});", true);
        }
    }
}