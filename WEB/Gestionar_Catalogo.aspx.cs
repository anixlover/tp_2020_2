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