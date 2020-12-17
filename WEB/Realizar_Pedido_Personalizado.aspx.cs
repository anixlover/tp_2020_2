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
using DAO;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;

namespace WEB
{
    public partial class Realizar_Pedido_Personalizado : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        CtrTipoMoldura objctrtipomoldura = new CtrTipoMoldura();
        //CtrMolduraxUsuario objCtrMXU = new CtrMolduraxUsuario();
        //DtoMolduraxUsuario objDtoMXU = new DtoMolduraxUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        //Ctr_Solicitud objCtrSolicitud = new Ctr_Solicitud();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_BuscarProducto_Click(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {

        }

        protected void btnCalcularP_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarP_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresarP_Click(object sender, EventArgs e)
        {

        }

    }
}