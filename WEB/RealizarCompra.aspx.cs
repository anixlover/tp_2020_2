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
    public partial class RealizarCompra : System.Web.UI.Page
    {
        DtoDatoFactura objDtoDatoFactura = new DtoDatoFactura();
        CtrDatoFactura objCtrDatoFactura = new CtrDatoFactura();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoPago objDtoPago = new DtoPago();
        CtrPago objCtrPago = new CtrPago();
        DtoMolduraXUsuario objDtoMolduraXUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraXUsuario = new CtrMolduraXUsuario();
        Dto_Voucher objDtoVoucher = new Dto_Voucher();
        Ctr_Voucher objCtrVoucher = new Ctr_Voucher();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMolduras();
                CargarRUCS();
                txtNuevoRUC.Visible = false;
                ddlRUC.Visible = false;
                chbNuevoRUC.Visible = false;
                lblTitulo1.Visible = false;
            }
        }

        protected void rbBoleta_CheckedChanged(object sender, EventArgs e)
        {
            ddlRUC.Visible = false;
            chbNuevoRUC.Visible = false;
            chbNuevoRUC.Checked = false;
            lblTitulo1.Visible = false;
        }

        protected void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            ddlRUC.Visible = true;
            lblTitulo1.Visible = true;
            chbNuevoRUC.Visible = true;
        }
        public void cargarEvento()
        {
            if (chbNuevoRUC.Checked == true)
            {
                txtNuevoRUC.Visible = true;
                ddlRUC.Visible = false;
            }
            else
            {
                txtNuevoRUC.Visible = false;
                ddlRUC.Visible = true;
            }
        }
        protected void chbNuevoRUC_CheckedChanged(object sender, EventArgs e)
        {
            cargarEvento();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            double costo = double.Parse(lblcosto.Text);
            objDtoDatoFactura.FK_VU_Dni = Session["DNIUsuario"].ToString();
            objDtoSolicitud.PK_IS_Cod = int.Parse(Session["idSolicitudPago"].ToString());
            if (hftxtimg.Value.ToString() == "vacio")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Suba Imagen del VOUCHER!!'})", true);
                return;
            }
            else if (txtNumOP.Text==""| txtImporte.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            else if(rbBoleta.Checked == false && rbFactura.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Seleccione BOLETA o FACTURA!!'})", true);
                return;
            }
            else if(chbNuevoRUC.Checked == true & rbFactura.Checked == true & txtNuevoRUC.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            else if(chbNuevoRUC.Checked == false & rbFactura.Checked == true & ddlRUC.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'No hay RUC'S!!'})", true);
                return;
            }
            objDtoVoucher.PK_VV_NumVoucher = txtNumOP.Text;
            objDtoVoucher.VV_Comentario = "";
            string cadena = hftxtimg.Value.ToString();
            List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
            byte[] bimagen = imagen.ToArray();
            objDtoVoucher.VBV_Foto = bimagen;
            if (rbBoleta.Checked == true)
            {
                objDtoPago.VP_RUC = "";
                objDtoPago.IP_TipoCertificado = 1;
            }
            if (chbNuevoRUC.Checked == false & rbFactura.Checked == true)
            {
                objDtoPago.VP_RUC = ddlRUC.Text;
                objDtoPago.IP_TipoCertificado = 2;
            }
            if (chbNuevoRUC.Checked == true)
            {
                objDtoDatoFactura.VDF_Ruc = txtNuevoRUC.Text;
                objCtrDatoFactura.RegistrarDatoFatcura(objDtoDatoFactura);
                objDtoPago.VP_RUC = txtNuevoRUC.Text;
                objDtoPago.IP_TipoCertificado = 2;
            }
            objDtoPago.DP_ImportePagado = double.Parse(txtImporte.Text);
            objDtoVoucher.DV_ImporteDepositado= double.Parse(txtImporte.Text);
            objDtoPago.DP_ImporteRestante = costo - Convert.ToDouble(txtImporte.Text);
            if (Convert.ToDouble(txtImporte.Text) == (costo / 2))
            {
                objDtoPago.IP_TipoPago = 1;
            }
            if (Convert.ToDouble(txtImporte.Text) > (costo / 2) | Convert.ToDouble(txtImporte.Text) == costo)
            {
                objDtoPago.IP_TipoPago = 2;
            }
            objDtoPago.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            objCtrPago.RegistrarPago(objDtoPago);
            objCtrPago.ExistenciaPago(objDtoPago);
            objDtoVoucher.FK_VP_Cod = objDtoPago.PK_VP_Cod;            
            objCtrVoucher.RegistrarVoucher(objDtoVoucher);
            objCtrSolicitud.Actualizar_a_EstadoRevisiónPago(objDtoSolicitud);
        }
        public void CargarMolduras()
        {
            objDtoMolduraXUsuario.FK_IS_Cod = int.Parse(Session["idSolicitudPago"].ToString());
            objDtoSolicitud.PK_IS_Cod= int.Parse(Session["idSolicitudPago"].ToString());
            if (objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud))
            {
                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    gvPersonalizado.Visible = false;
                    gvDetalles.Visible = true;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    lblcosto.Text = objDtoSolicitud.DS_ImporteTotal.ToString();
                    gvDetalles.DataSource = objCtrMolduraXUsuario.ListarMoldurasXUsuario(objDtoMolduraXUsuario);
                    gvDetalles.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvPersonalizado.Visible = true;
                    gvDetalles.Visible = false;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    lblcosto.Text = objDtoSolicitud.DS_PrecioAprox.ToString();
                    gvPersonalizado.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado.DataBind();
                }
            }
        }
        public void CargarRUCS()
        {
            objDtoDatoFactura.FK_VU_Dni= Session["DNIUsuario"].ToString();
            ddlRUC.DataSource=objCtrDatoFactura.ListarRucs(objDtoDatoFactura);
            ddlRUC.DataBind();
        }
    }
}