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
    public partial class ReporteVentas : System.Web.UI.Page
    {
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoSolicitud objDtoSOlicitud = new DtoSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                gvVentas.DataSource = objCtrSolicitud.SolicitudesTerminadas();
                gvVentas.DataBind();
                lbltotal.Text = objCtrSolicitud.ImporteTotal().ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string fechaInicio=txtFechaInicio.Text;
            string fechaFin=txtFechaFin.Text;
            if (fechaInicio != "" && fechaFin != "")
            {
                DateTime inicio = Convert.ToDateTime(fechaInicio), fin = Convert.ToDateTime(fechaFin);

                if ( inicio <= fin)
                {
                    gvVentas.DataSource = objCtrSolicitud.SolicitudesTerminadasEntreFechas(fechaInicio, fechaFin);
                    gvVentas.DataBind();
                    lbltotal.Text = (objCtrSolicitud.ImporteTotalEntreFechas(fechaInicio, fechaFin)).ToString();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Espacios VACIOS o intervalo incorrecto!!'})", true);
                return;
            }
        }
    }
}