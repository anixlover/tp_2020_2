using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CTR;
using DTO;

namespace WEB
{
    public partial class Administrar_Solicitud_Pedido : System.Web.UI.Page
    {
        CtrMolduraXUsuario objCtrMXU = new CtrMolduraXUsuario();
        DtoMolduraXUsuario objDtoMXU = new DtoMolduraXUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("Administrar Solicitud Pedido", "Carga de pagina");
                try
                {
                    if (Session["DNIUsuario"] != null)
                    {
                        objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                        UpdatePanel.Update();
                        gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                        gvCarrito.DataBind();

                        if (gvCarrito.Rows.Count == 0)
                        {
                            btncrear.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("Administrar Solicitud Pedido", ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvCarrito.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    objDtoMXU.FK_IM_Cod = int.Parse(id);

                    _log.CustomWriteOnLog("carrito de compra", "eliminar id:" + id);
                    _log.CustomWriteOnLog("carrito de compra", "dni:" + Session["DNIUsuario"].ToString());
                    objCtrMXU.eliminarMXU(objDtoMXU);
                    objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                    UpdatePanel.Update();
                    gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                    gvCarrito.DataBind();
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

                    throw;
                }
            }
        }

    }
}