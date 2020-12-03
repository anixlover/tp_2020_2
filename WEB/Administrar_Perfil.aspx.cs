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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNombre.Text = (string)Session["NombreUsuario"];
                txtApellidos.Text = (string)Session["ApellidosUsuario"];
                txtCorreo.Text = (string)Session["CorreoUsuario"];
                DateTime FechaNac = (DateTime)Session["FechaNacUsuario"];
                txtFechaNac.Text = FechaNac.ToString("yyyy-MM-dd");
                LRucs.Items.Add("0");
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Correo = txtCorreo.Text;
            DateTime FechaNac = DateTime.Parse(txtFechaNac.Text);

            objUsuario.VU_Nombre = Nombre;
            objUsuario.VU_Apellidos = Apellidos;
            objUsuario.VU_Correo = Correo;
            objUsuario.DTU_FechaNac = FechaNac;
            objCtrUsuario.ActualizarDatos(objUsuario);
        }

        protected void LRucs_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("dd");
        }
    }
}