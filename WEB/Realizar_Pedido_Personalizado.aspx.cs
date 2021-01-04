using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DTO;
using CTR;
using DAO;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;

namespace WEB
{
    public partial class Realizar_Pedido_Personalizado : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        CtrTipoMoldura objctrtipomoldura = new CtrTipoMoldura();
        CtrMolduraXUsuario objCtrMXU = new CtrMolduraXUsuario();
        DtoMolduraXUsuario objDtoMXU = new DtoMolduraXUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();

        Log _log = new Log();

        SqlConnection conexion = new SqlConnection(@"data source=(local); initial catalog=BD_SCPEDR; integrated security=SSPI;");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                OpcionesTipoMoldura();
                ddlTipoMoldura.SelectedValue = "1";
                _log.CustomWriteOnLog("registrar pedido personalizado", "carga datos por catalogo");


                //try
                //{
                //    if (Session["DNIUsuario"] != null)
                //    {
                //        objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                        
                //    }
                //    else
                //    {
                //        Response.Redirect("~/IniciarSesion.aspx");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
                //}
            }
        }

        public void OpcionesTipoMoldura()
        {
            //DataSet ds = new DataSet();
            //ds = objCtrTipoMoldura.SelectTipoMoldura();
            //ddlTipoMoldura.DataSource = ds;
            //ddlTipoMoldura.DataTextField = "VTM_Nombre";
            //ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ////ddlTipoMoldura.DataBind();
            //ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            //_log.CustomWriteOnLog("registrar pedido personalizado", "Termino de llenar el ddl");


            DataSet ds = new DataSet();
            ds = objctrtipomoldura.SelectTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            _log.CustomWriteOnLog("RegistrarMoldura", "Termino de llenar el ddl");
        }



        public void ObtenerMoldura()
        {
            objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_BuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcodigo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese codigo de moldura!!', type: 'error'});", true);
                    return;
                }
                _log.CustomWriteOnLog("registrar pedido personalizado", "entro a busqueda");
                objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMoldura.PK_IM_Cod : " + objDtoMoldura.PK_IM_Cod);
                //if (!objCtrMoldura.MolduraExiste(objDtoMoldura))
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!', type: 'error'});", true);
                    
                //    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!'})</script>");
                //    return;
                //}

                //Obtener moldura y unidad metrica

                objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
                txtDescripcion.Text = objDtoMoldura.VM_Descripcion.ToString();
                txtLargo.Text = objDtoMoldura.DM_Largo.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
                txtAncho.Text = objDtoMoldura.DM_Ancho.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();

                txtunidadmetrica.Value = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
                //_log.CustomWriteOnLog("registrar pedido personalizado", " devolvio objDtoMoldura.DM_Medida y objDtoTipoMoldura.VTM_UnidadMetrica : " + objDtoMoldura.DM_Medida + " " + objDtoTipoMoldura.VTM_UnidadMetrica);
                txtPrecio.Text = objDtoMoldura.DM_Precio.ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "devolvio objDtoMoldura.DM_Precio : " + objDtoMoldura.DM_Precio);
                Buscar.Update();

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {

        }

        protected void btnCalcularP_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarP_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresarP_Click(object sender, EventArgs e)
        {

        }

    }
}