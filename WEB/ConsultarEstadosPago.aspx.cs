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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DNIUsuario"] == null)
                {
                    Response.Redirect("~/IniciarSesion.aspx");
                }
                else
                {
                    UpdatePanel.Update();
                    CargarDDL();
                    CargarSolicitudes();
                }                
            }
        }
        DtoMolduraXUsuario objDtoMolduraxUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraxUsuario = new CtrMolduraXUsuario();
        CtrSolicitudEstado objCtrSolicitudEstados = new CtrSolicitudEstado();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        protected Boolean ValidacionEstado1(string estado)
        {
            return estado == "Pendiente de pago";
        }
        protected Boolean ValidacionEstado2(string estado)
        {
            return estado == "Observada";
        }
        protected Boolean ValidacionEstado3(string estado)
        {
            return estado == "Aprobada";
        }
        protected Boolean ValidacionEstado4(string estado)
        {
            return estado == "Personalizado por diseño propio";
        }
        protected Boolean ValidacionEstado5(string estado)
        {
            return estado == "En proceso";
        }
        protected Boolean ValidacionEstado6(string estado)
        {
            return estado == "Con retraso";
        }
        public void CargarSolicitudes() 
        {
            objDtoMolduraxUsuario.FK_VU_Dni = Session["DNIUsuario"].ToString();
            gvPedidos.DataSource = objCtrMolduraxUsuario.ListarSolicitudesxDNI(objDtoMolduraxUsuario);
            gvPedidos.DataBind();
        }
        public void CargarDDL()
        {
            ddlEstadoSolicitud.DataSource = objCtrSolicitudEstados.ListarEstados();
            ddlEstadoSolicitud.DataTextField = "VSE_Nombre";
            ddlEstadoSolicitud.DataValueField = "PK_ISE_Cod";
            ddlEstadoSolicitud.DataBind();
            ddlEstadoSolicitud.Items.Insert(0, new ListItem("Todos", "Todos"));
        }
        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver detalles")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;                
                CargarMolduras(id);
                lblid.Text = id;
            }
            if (e.CommandName == "Pago")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/RealizarCompra.aspx?sol="+id);
            }
        }
        public void CargarMolduras(string id)
        {
            objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(id);
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            if (objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud))
            {

                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    gvPersonalizado.Visible = false;
                    gvDetalles.Visible = true;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    gvDetalles.DataSource = objCtrMolduraxUsuario.ListarMoldurasXUsuario(objDtoMolduraxUsuario);
                    gvDetalles.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvPersonalizado.Visible = true;
                    gvDetalles.Visible = false;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    gvPersonalizado.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado.DataBind();
                }
            }
        }

        protected void ddlEstadoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDtoMolduraxUsuario.FK_VU_Dni = Session["DNIUsuario"].ToString();
            if (ddlEstadoSolicitud.SelectedValue.ToString()=="Todos")
            {
                gvPedidos.DataSource = objCtrMolduraxUsuario.ListarSolicitudesxDNI(objDtoMolduraxUsuario);
                gvPedidos.DataBind();
            }
            else
            {
                int estado = Convert.ToInt32(ddlEstadoSolicitud.SelectedValue);
                gvPedidos.DataSource = objCtrMolduraxUsuario.ListarMoldurasxDNI_y_Estado(objDtoMolduraxUsuario, estado);
                gvPedidos.DataBind();
            }            
        }
    }
}