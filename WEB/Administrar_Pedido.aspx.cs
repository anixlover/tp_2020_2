using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;

namespace WEB
{
    public partial class Administrar_Pedidos : System.Web.UI.Page
    {
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoMolduraXUsuario dtomxu = new DtoMolduraXUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
                dtomxu.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudMXU"]);
                gvSolicitudes.DataBind();
                OpcionesSolicitudEstado();
            }
        }

        public void OpcionesSolicitudEstado()
        {
            DataSet ds = new DataSet();
            ds = objCtrSolicitud.OpcionesSolicitudEstado();
            ddltipo.DataSource = ds;
            ddltipo.DataTextField = "VSE_Nombre";
            ddltipo.DataValueField = "VSE_Nombre";
            ddltipo.DataBind();
            ddltipo.Items.Insert(0, new ListItem("Todos", "Todos"));

        }
        protected void gvSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var columna = gvSolicitudes.DataKeys[index].Values;
            int sol = Convert.ToInt32(columna[0].ToString());
            int solMXU = Convert.ToInt32(columna[3].ToString());
            string dni = columna[2].ToString();
            switch (e.CommandName)
            {
                case "Ver detalles":
                    Session["clienteDNI"] = dni;
                    Session["idSolicitudPago"] = sol;
                    Session["estado"] = "0";
                    Response.Redirect("Detalles_Solicitud.aspx");
                    break;
                case "Evaluar": 
                    Session["idSolicitudPago"] = sol;
                    Response.Redirect("EvaluarPago.aspx");
                    break;
                case "asignar fecha":
                    Session["idSolicitudPago"] = sol;
                    Session["clienteDNI"] = dni;
                    Session["estado"] = "2";
                    Response.Redirect("Detalles_Solicitud.aspx");
                    break;
            }
        }
        protected bool ValidacionEstado(string estado)
        {
            return estado == "Pendiente de pago";
        }
        protected bool ValidacionEstado2(string estado)
        {
            return estado == "Por asignar fecha";
        }

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddltipo.Text;
            if (tipo == "Todos")
            {
                gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
                gvSolicitudes.DataBind();
            }
            else
                gvSolicitudes.DataSource = objCtrSolicitud.Listar_Solicitud_tipo(tipo);
            gvSolicitudes.DataBind();
        }
    }
}
