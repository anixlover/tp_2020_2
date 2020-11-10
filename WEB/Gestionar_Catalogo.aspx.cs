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
                Response.Redirect("~/Registrar_Moldura.aspx?ID=" + id);
            }
            else if (e.CommandName == "Ver")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    string Nombre = colsNoVisible[1].ToString();
                    objDtoMoldura.PK_IM_Cod = int.Parse(id);



                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);
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
    }
}