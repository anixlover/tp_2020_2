using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DTO;
using CTR;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace WEB
{
    public partial class Registrar_Moldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["Id"] != null)
                {
                    obtenerInformacionMoldura(Request.Params["Id"]);

                }
                OpcionesTipoMoldura();
                ddlEstadoMoldura.SelectedValue = "1";
            }

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("RegistrarMoldura", "-------------------------------------------------------------Evento Click-----------------------");
            _log.CustomWriteOnLog("RegistrarMoldura", "Entró a evento de Registro ");
            try
            {
                if (true)
                {
                    string cadena = hftxtimg.Value.ToString();
                    List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
                    byte[] bimagen = imagen.ToArray();

                    _log.CustomWriteOnLog("RegistrarMoldura", "La función es de creación");
                    objDtoMoldura.DM_Precio = double.Parse(txtPrecio.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Precio valor ingresado " + objDtoMoldura.DM_Precio);
                    objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("RegistrarMoldura", "IM_Estado valor ingresado " + objDtoMoldura.IM_Estado);
                    objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "IM_Stock valor ingresado " + objDtoMoldura.IM_Stock);
                    objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("RegistrarMoldura", "FK_ITM_Tipo valor ingresado " + objDtoMoldura.FK_ITM_Tipo);
                    objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                    _log.CustomWriteOnLog("RegistrarMoldura", "VM_Descripcion valor ingresado " + objDtoMoldura.VM_Descripcion);
                    objDtoMoldura.DM_Largo = Double.Parse(txtLargo.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Largo valor ingresado " + objDtoMoldura.DM_Largo);
                    objDtoMoldura.DM_Ancho = Double.Parse(txtAncho.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Ancho valor ingresado " + objDtoMoldura.DM_Ancho);
                    objCtrMoldura.InsertMoldura(objDtoMoldura);
                    int ValorDevuelto = objDtoMoldura.PK_IM_Cod;
                    _log.CustomWriteOnLog("RegistrarMoldura", "Registro exitoso de la moldura N° " + objDtoMoldura.PK_IM_Cod);

                    objCtrMoldura.registrarImgMoldura(bimagen, ValorDevuelto);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Moldura registrada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Gestionar_Catalogo.aspx'})", true);
                }
                



            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("RegistrarMoldura", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
                throw;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Gestionar_Catalogo.aspx");
        }
        public void OpcionesTipoMoldura()
        {
            DataSet ds = new DataSet();
            ds = objCtrTipoMoldura.SelectTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            _log.CustomWriteOnLog("RegistrarMoldura", "Termino de llenar el ddl");
        }
        public void obtenerInformacionMoldura(string id)
        {
            _log.CustomWriteOnLog("RegistrarMoldura", "-------------------------------------------------- Entro a actualización ----------------------------------------");
            objDtoMoldura.PK_IM_Cod = int.Parse(id);
        }
    }
}