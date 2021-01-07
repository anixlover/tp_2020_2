﻿using System;
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
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string fechaInicio=txtFechaInicio.Text;
            string fechaFin=txtFechaFin.Text;
            DateTime inicio = Convert.ToDateTime(fechaInicio), fin= Convert.ToDateTime(fechaFin);
            if (fechaInicio!=""&&fechaFin!=""&&inicio<=fin)
            {
                gvVentas.DataSource =objCtrSolicitud.SolicitudesTerminadasEntreFechas(fechaInicio,fechaFin);
                gvVentas.DataBind();
            }
        }
    }
}