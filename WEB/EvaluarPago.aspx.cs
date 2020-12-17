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
using System.Net.Mail;
using System.Net;
using DAO;

namespace WEB
{
    public partial class EvaluarPago : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
        Log _log = new Log();
        DtoPago dtopago = new DtoPago();
        DtoSolicitud dtosol = new DtoSolicitud();
        Dto_Voucher dtovoucher = new Dto_Voucher();
        CtrSolicitud ctrsol = new CtrSolicitud();
        DtoMolduraXUsuario dtomxu = new DtoMolduraXUsuario();
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
                    CargarMolduras2();
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("EvaluarPago", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }
        }

        public void CargarMolduras2()
        {
            dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);
            //pendiente de pago A aprobado
            if (ctrsol.leerSolicitudTipo(dtosol))
            {
                if (dtosol.VS_TipoSolicitud == "Personalizado por catalogo" || dtosol.VS_TipoSolicitud == "Catalogo")
                {
                    ctrsol.LeerSolicitud(dtosol);
                    gvDetalleSolicitud2.Visible = false;
                    gvDetalles.Visible = true;
                    
                    gvDetalles.DataSource = ctrsol.ListaMolduras(dtosol);
                    gvDetalles.DataBind();
                }
                if (dtosol.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    ctrsol.leerSolicitudDiseñoPersonal(dtosol);

                    gvDetalleSolicitud2.Visible = true;
                    gvDetalles.Visible = false;
                    gvDetalleSolicitud2.DataSource = ctrsol.ListaMoldurasxDiseñoPropio(dtosol);
                    gvDetalleSolicitud2.DataBind();
                    
                }
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
                    dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    ctrsol.Actualizar_Estado_Solicitud(dtosol);
                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //actualiza correctamente a aprobado
                    Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage2()");
                }
                if (ddl_decision.SelectedValue == "2")
                {

                    string Select = "";
                    //"SELECT VU_Correo, VU_Contrasenia, VU_Nombre from T_Usuario where PK_VU_Dni ='"
                    //+ dtomxu. + "'";

                    SqlCommand unComando = new SqlCommand(Select, conexion);
                    conexion.Open();
                    SqlDataReader reader = unComando.ExecuteReader();

                    if (reader.Read())
                    {
                        string senderr = "DecormoldurasRosetonesSAC@gmail.com";
                        string senderrPass = "decormolduras1";
                        string displayName = "SWCPEDR - DECORMOLDURAS & ROSETONES SAC";

                        var date = DateTime.Now.ToShortDateString();
                        var recipient = reader["VU_Correo"].ToString();
                        var nombre = reader["VU_Nombre"].ToString();
                        string body =
                            "<body>" +
                                "<h1>SWCPEDR - DECORMOLDURAS & ROSETONES SAC</h1>" +
                                "<h4>ERROR EN SU VOUCHER ADJUNTADO</h4>" +
                                "<span>Es probable que la imagen de su voucher este dañada o no distingible, favor de volver a realizar la operacion!" +
                                "<br></br><span>Gracias.</span>" +
                                "<br></br><span> Saludos cordiales.<span>" +
                            "</body>";

                        MailMessage mail = new MailMessage();
                        mail.Subject = "SWCPEDR - AVISO - PROBLEMA CON EL ADJUNTO DE VOUCHER";
                        mail.From = new MailAddress(senderr.Trim(), displayName);
                        mail.Body = body;
                        mail.To.Add(recipient.Trim());
                        mail.IsBodyHtml = true;
                        //mail.Priority = MailPriority.Normal;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
                        NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
                        smtp.Credentials = nc;

                        smtp.Send(mail);
                    }

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