using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB
{
    public partial class GestionarEstadosPedido : System.Web.UI.Page
    {
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudes();
            gvPedidos.DataBind();
        }
    }
}