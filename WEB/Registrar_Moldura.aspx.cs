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
using System.Security.Cryptography.X509Certificates;

namespace WEB
{
    public partial class Registrar_Moldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        //Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OpcionesTipoMoldura();
                ddlEstadoMoldura.SelectedValue = "1";
            }

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                //_log.CustomWriteOnLog("PropiedadMoldura", "La función es de creación");
                objDtoMoldura.DM_Precio = Double.Parse(txtPrecio.Text);
                objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                objDtoMoldura.DM_Largo = Double.Parse(txtLargo.Text);
                objDtoMoldura.DM_Ancho = Double.Parse(txtAncho.Text);
                objCtrMoldura.RegistrarMoldura(objDtoMoldura);
                int ValorDevuelto = objDtoMoldura.PK_IM_Cod;
                //_log.CustomWriteOnLog("PropiedadMoldura", "PK_IM_Cod valor retornado " + objDtoMoldura.PK_IM_Cod);
                Utils.AddScriptClientUpdatePanel(upBotonRegistrar, "uploadFileDocuments(" + objDtoMoldura.PK_IM_Cod + ");");
                //_log.CustomWriteOnLog("PropiedadMoldura", "Agregado");
                Utils.AddScriptClientUpdatePanel(upBotonRegistrar, "showSuccessMessage2()");
                //_log.CustomWriteOnLog("PropiedadMoldura", "Completado");

            }
            catch (Exception ex)
            {
                //_log.CustomWriteOnLog("PropiedadMoldura", "Error  = " + ex.Message + "posicion" + ex.StackTrace);

                throw;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Gestionar_Catalogo.aspx");
        }
        public void OpcionesTipoMoldura()
        {
            DataSet ds = new DataSet();
            ds = objCtrTipoMoldura.OpcionesTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            //_log.CustomWriteOnLog("PropiedadMoldura", "Termino de llenar el ddl");
        }
    }
}