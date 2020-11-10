using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB
{
    public partial class Gestionar_Catalogo : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    OpcionesTipoMoldura();
                    UpdatePanel.Update();
                    gvCatalogo.DataSource = objCtrMoldura.ListarMolduras();
                    gvCatalogo.DataBind();
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                    throw;
                }
            }
        }
        public void OpcionesTipoMoldura()
        {

        }
        //Opciones de botones
        protected void gvCatalogo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                Response.Redirect("~/Registrar_Moldura.aspx?ID=" + id+"&act=1");
            }
            else if (e.CommandName == "getMoldura")
            {
                try
                {
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                    //string id = colsNoVisible[0].ToString();
                    //string Nombre = colsNoVisible[1].ToString();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvCatalogo.Rows[index];
                    Button b = (Button)row.FindControl("btnGetMoldura");
                    string id = row.Cells[1].Text;
                    lblId.Text = id;
                    objDtoMoldura.PK_IM_Cod = int.Parse(id);
                    objCtrMoldura.ObtenerMoldura(objDtoMoldura,objDtoTipoMoldura);
                    lblId.Text = id;
                    Img1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(objDtoMoldura.VBM_Imagen);
                    txtTipo.Text = objDtoTipoMoldura.VTM_Nombre;
                    txtmetrica.Text = objDtoTipoMoldura.VTM_UnidadMetrica;
                    txtprecio.Text = objDtoMoldura.DM_Precio.ToString();
                    txtdescripcion.Text = objDtoMoldura.VM_Descripcion;
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }
        
        protected void gvCatalogo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[5];
                if (statusCell.Text == "1")
                {
                    statusCell.Text = "Habilitado";
                }
                if (statusCell.Text == "0")
                {
                    statusCell.Text = "Desabilitado";
                }
            }
        }

        protected void btnAgregarMoldura_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar_Moldura.aspx");
        }
    }
}