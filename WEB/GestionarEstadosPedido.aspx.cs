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
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        DtoMolduraXUsuario objDtoMolduraxUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraxUsuario = new CtrMolduraXUsuario();
        CtrMXUEstado objCtrMXUEstado = new CtrMXUEstado();
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
                    UpdatePanel1.Update();
                    gvPedidos.DataSource= objCtrSolicitud.ListarSolicitudesTrabajdor();
                    gvPedidos.DataBind();
                    
                }
            }
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
                    gvDetalles.DataSource = objCtrMolduraxUsuario.ListarMoldurasXsolicitud(objDtoMolduraxUsuario);
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
        public int obtenerEstado(string codigo)
        {
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(codigo);
            objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
            return objDtoMolduraxUsuario.FK_IMXUE_Cod;
        }
        protected void gvDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMXUEstados = (e.Row.FindControl("ddlEstados") as DropDownList);
                ddlMXUEstados.DataSource = objCtrMXUEstado.ListarEstados();
                ddlMXUEstados.DataTextField = "VMXUE_Nombre";
                ddlMXUEstados.DataValueField = "PK_IMXUE_Cod";
                ddlMXUEstados.DataBind();
                int idE = Convert.ToInt32(e.Row.Cells[1].Text);
                objDtoMolduraxUsuario.PK_IMU_Cod = idE;
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
                ddlMXUEstados.SelectedValue = (objDtoMolduraxUsuario.FK_IMXUE_Cod).ToString();
                e.Row.Cells[1].Visible = false;
                gvDetalles.HeaderRow.Cells[1].Visible = false;
            }
        }

        protected void gvPersonalizado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMXUEstados = (e.Row.FindControl("ddlEstados") as DropDownList);
                ddlMXUEstados.DataSource = objCtrMXUEstado.ListarEstados();
                ddlMXUEstados.DataTextField = "VMXUE_Nombre";
                ddlMXUEstados.DataValueField = "PK_IMXUE_Cod";
                ddlMXUEstados.DataBind();
                int idE = Convert.ToInt32(e.Row.Cells[1].Text);
                objDtoMolduraxUsuario.PK_IMU_Cod = idE;
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
                ddlMXUEstados.SelectedValue = (objDtoMolduraxUsuario.FK_IMXUE_Cod).ToString();
                e.Row.Cells[1].Visible = false;
                gvPersonalizado.HeaderRow.Cells[1].Visible = false;
            }
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlEstados = (DropDownList)sender;
            string rowNumber = gvDetalles.DataKeys[gvr.RowIndex].Value.ToString();
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(rowNumber);
            objDtoMolduraxUsuario.FK_IMXUE_Cod = int.Parse(ddlEstados.SelectedValue);
            objCtrMolduraxUsuario.actualizarMXUxCod(objDtoMolduraxUsuario);
            string sol = lblid.Text;
            CargarMolduras(sol);
        }

        protected void ddlEstados2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlEstados2 = (DropDownList)sender;
            string rowNumber = gvPersonalizado.DataKeys[gvr.RowIndex].Value.ToString();
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(rowNumber);
            objDtoMolduraxUsuario.FK_IMXUE_Cod = int.Parse(ddlEstados2.SelectedValue);
            objCtrMolduraxUsuario.actualizarMXUxCod(objDtoMolduraxUsuario);
            string sol = lblid.Text;
            CargarMolduras(sol);
        }
    }
}