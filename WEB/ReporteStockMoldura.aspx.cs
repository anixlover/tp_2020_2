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
    public partial class ReporteStockMoldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvMolduras.DataSource= objCtrMoldura.ListarMolduras();
                gvMolduras.DataBind();
            }
        }
    }
}