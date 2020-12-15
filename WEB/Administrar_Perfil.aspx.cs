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
        DtoDatoFactura objDatoFactura = new DtoDatoFactura();
        CtrDatoFactura objCtrDatoFactura = new CtrDatoFactura();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNombre.Text = (string)Session["NombreUsuario"];
                txtApellidos.Text = (string)Session["ApellidosUsuario"];
                txtCorreo.Text = (string)Session["CorreoUsuario"];
                DateTime FechaNac = (DateTime)Session["FechaNacUsuario"];
                txtFechaNac.Text = FechaNac.ToString("yyyy-MM-dd");
                CargarRUCS();
                //LRucs.Items.Add(objCtrDatoFactura.ListarRucs(objDatoFactura));                
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == ""|txtApellidos.Text==""|txtCorreo.Text==""|txtFechaNac.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Correo = txtCorreo.Text;
            DateTime FechaNac = DateTime.Parse(txtFechaNac.Text);

            objUsuario.VU_Nombre = Nombre;
            objUsuario.VU_Apellidos = Apellidos;
            objUsuario.VU_Correo = Correo;
            objUsuario.DTU_FechaNac = FechaNac;
            objDatoFactura.FK_VU_Dni = Session["DNIUsuario"].ToString();
            
            
        }

        public void EliminarRUCS()
        {
            if (LEliminar.Items.Count != 0)
            {
                for (int i = 0; i < LEliminar.Items.Count; i++)
                {
                    objDatoFactura.VDF_Ruc = LEliminar.Items[i].Text;
                    objCtrDatoFactura.EliminarRUC(objDatoFactura);
                }
            }
        }
        public void CargarRUCS()
        {
            objDatoFactura.FK_VU_Dni= Session["DNIUsuario"].ToString();
            LRucs.DataSource = objCtrDatoFactura.ListarRucs(objDatoFactura);
            LRucs.DataValueField = "VDF_Ruc";
            LRucs.DataTextField = "VDF_Ruc";
            LRucs.DataBind();
        }
        public void ModificarDatos(DtoUsuario objUsuario)//<----Metodo de Registro
        {
            if (objCtrUsuario.formatoNombre(objUsuario) == false)//Probar si el Nombre introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoApellido(objUsuario) == false)//Probar si el Apellido introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoCorreo(objUsuario) == false)//Probar si el correo introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCelular(objUsuario))//probar si el Número de celular introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Número de celular DUPLICADO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCorreo(objUsuario))//probar si el Correo introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Correo DUPLICADO!!'});", true);
                return;
            }
            if (DateTime.Now.Year - objUsuario.DTU_FechaNac.Year < 18)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Debe ser mayor de edad!!'});", true);
                return;
            }
            //Modifica los datos del usuario tipo cliente
            if (LEliminar.Items.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Modificación Exitosa!',text: 'Datos MODIFICADOS y RUC(s) ELIMINADOS!!'})", true);
                objCtrUsuario.ActualizarDatos(objUsuario);
                EliminarRUCS();
                LEliminar.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Modificación Exitosa!',text: 'Datos MODIFICADOS!!'})", true);
                objCtrUsuario.ActualizarDatos(objUsuario);
            }
            
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inspeccionar_Catalogo.aspx");
        }

        protected void btnMoverDerecha_Click(object sender, EventArgs e)
        {
            LEliminar.Items.Add(LRucs.SelectedValue);
            int i = 0;
            i = LRucs.SelectedIndex;
            LRucs.Items.RemoveAt(i);
        }

        protected void btnMoverIzquierda_Click(object sender, EventArgs e)
        {
            LRucs.Items.Add(LEliminar.SelectedValue);
            int i = 0;
            i = LEliminar.SelectedIndex;
            LEliminar.Items.RemoveAt(i);
        }

        protected void btnMoverTodoDerecha_Click(object sender, EventArgs e)
        {
            while (LRucs.Items.Count != 0)
            {
                for (int i = 0; i < LRucs.Items.Count; i++)
                {
                    LEliminar.Items.Add(LRucs.Items[i]);
                    LRucs.Items.Remove(LRucs.Items[i]);
                }
            }
        }

        protected void btnMoverTTodoIzquierda_Click(object sender, EventArgs e)
        {
            while (LEliminar.Items.Count != 0)
            {
                for (int i = 0; i < LEliminar.Items.Count; i++)
                {
                    LRucs.Items.Add(LEliminar.Items[i]);
                    LEliminar.Items.Remove(LEliminar.Items[i]);
                }
            }
        }
    }
}