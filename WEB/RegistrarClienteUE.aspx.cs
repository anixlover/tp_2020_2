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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DtoUsuario objUsuario= new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtContraseña.Text == "" | txtFechNac.Text == "")//<----Control de espacion vacios o Nulos
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Complete espacios en BLANCO!!'});", true);
                return;
            }
            objUsuario.PK_VU_Dni = txtDNI.Text;
            objUsuario.VU_Nombre = txtNombres.Text;
            objUsuario.VU_Apellidos = txtApellidos.Text;
            objUsuario.IU_Celular = Convert.ToInt32(txtCelular.Text);
            objUsuario.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
            objUsuario.VU_Correo = txtCorreo.Text;
            objUsuario.VU_Contrasenia = txtContraseña.Text;
            RegistrarUE(objUsuario);
        }        
        public void RegistrarUE(DtoUsuario objUsuario)//<----Metodo de Registro
        {
            if (objCtrUsuario.formatoDni(objUsuario) == false) //Probar si el Dni introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Dni INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoNombre(objUsuario) == false)//Probar si el Nombre introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoApellido(objUsuario) == false)//Probar si el Apellido introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoCorreo(objUsuario) == false)//Probar si el correo introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaDni(objUsuario))//probar si el DNI introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Dni DUPLICADO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCelular(objUsuario))//probar si el Número de celular introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Número de celular DUPLICADO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCorreo(objUsuario))//probar si el Correo introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Correo DUPLICADO!!'});", true);
                return;
            }
            objCtrUsuario.RegistrarClienteUsuarioExterno(objUsuario);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'});", true);
            return;

        }
    }
}