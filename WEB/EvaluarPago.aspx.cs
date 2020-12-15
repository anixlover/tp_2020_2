using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB
{
    public partial class EvaluarPago : System.Web.UI.Page
    {
        Log _log = new Log();
        DtoPago dtopago = new DtoPago();
        DtoSolicitud dtosol = new DtoSolicitud();
        Dto_Voucher dtovoucher = new Dto_Voucher();
        CtrSolicitud ctrsol = new CtrSolicitud();
        Ctr_Voucher ctrvoucher = new Ctr_Voucher();
        CtrPago ctrpago = new CtrPago();
        int solicitud = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    solicitud = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    obtenerVoucher();
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("EvaluarPago", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }
        }

        protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void obtenerVoucher()
        {
            dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            dtopago.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            dtovoucher.PK_VV_NumVoucher = ctrsol.HayPago(dtosol);
            ctrsol.LeerSolicitudTipo(dtosol);
            if (ctrvoucher.hayVoucher(dtovoucher))
            {
                //string image = Convert.ToBase64String(dtovoucher.VBV_Foto);
                //Image1.ImageUrl = "data:Image/png;base64," + image;
                ctrpago.HayRUC(dtopago);
                txtNumOperacion.Text = dtovoucher.PK_VV_NumVoucher.ToString();
                txtmonto.Text = dtovoucher.DV_ImporteDepositado.ToString();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_decision.SelectedValue == "0")
                {

                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //muestra aviso que no se selecciono ninguna opcion
                    Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage4()");
                }
                if (ddl_decision.SelectedValue == "1")
                {

                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //actualiza correctamente a aprobado
                    Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage2()");
                }
                if (ddl_decision.SelectedValue == "2")
                {

                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //reporta la solicitud
                    Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage3()");
                }
            }

            catch (Exception ex)
            {
                Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage1()");
                _log.CustomWriteOnLog("EvaluarPago", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }

        }
    }
}