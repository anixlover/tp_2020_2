﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data.SqlClient;
using System.Data;

namespace WEB
{
    public partial class GestionarMolde : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        DtoMolde objDtoMolde = new DtoMolde();
        CtrMolde objCtrMolde = new CtrMolde();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UpdatePanel1.Update();
                gvMolduras.DataSource = objCtrMoldura.ListarMolduras();
                gvMolduras.DataBind();
                OpcionesTipoMoldura();
                gvMoldes.DataSource = objCtrMolde.ListarMoldes();
                gvMoldes.DataBind();
            }
        }
        protected Boolean ValidacionExistencia(int cod)
        {
            objDtoMolde.FK_IM_Cod = cod;
            return !objCtrMolde.ExistenciaMolde(objDtoMolde);
        }
        public void OpcionesTipoMoldura()
        {
            DataSet ds;
            ds = objCtrTipoMoldura.SelectTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Todos", "0"));
        }
        protected void txtcodigo_TextChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoMoldura.SelectedItem.Text;
            if (txtcodigo.Text.Length == 0)
            {
                if (tipo == "Todos")
                {
                    gvMolduras.DataSource = objCtrMoldura.ListarMolduras();
                    gvMolduras.DataBind();
                }
                else
                {
                    objDtoTipoMoldura.VTM_Nombre = ddlTipoMoldura.SelectedItem.Text;
                    gvMolduras.DataSource = objCtrTipoMoldura.ListarMoldurasxTipo(objDtoTipoMoldura);
                    gvMolduras.DataBind();
                }
            }
            else
            {
                objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                if (tipo == "Todos")
                {
                    gvMolduras.DataSource = objCtrMoldura.DataMolduraxCodMoldura(objDtoMoldura);
                    gvMolduras.DataBind();
                }
                else
                {
                    gvMolduras.DataSource = objCtrMoldura.DataMolduraxCodMoldura_y_Tipo(objDtoMoldura);
                    gvMolduras.DataBind();
                }              
            }
        }

        protected void ddlTipoMoldura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddlTipoMoldura.SelectedItem.Text;
            if (txtcodigo.Text.Length == 0)
            {
                if (tipo == "Todos")
                {
                    gvMolduras.DataSource = objCtrMoldura.ListarMolduras();
                    gvMolduras.DataBind();
                }
                else
                {
                    objDtoTipoMoldura.VTM_Nombre = ddlTipoMoldura.SelectedItem.Text;
                    gvMolduras.DataSource = objCtrTipoMoldura.ListarMoldurasxTipo(objDtoTipoMoldura);
                    gvMolduras.DataBind();
                }
            }
        }

        protected void gvMolduras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvMolduras.DataKeys[index].Values;
                GridViewRow row = gvMolduras.Rows[index];
                string id = colsNoVisible[0].ToString();
                lblId.Text =id;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            objDtoMolde.IML_Cantidad = int.Parse(txtCantidad.Text);
            objDtoMolde.FK_IM_Cod = int.Parse(lblId.Text);
            if (int.Parse(txtCantidad.Text) <= 0 | txtCantidad.Text.Contains("e") | txtCantidad.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte un cantidad VALIDA!!'})", true);
                return;
            }            
            objCtrMolde.RegistrarMolde(objDtoMolde);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Molde registrado!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='GestionarMolde.aspx'})", true);
        }

        protected void txtCodigoMoldura_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoMoldura.Text.Length == 0 | txtCodigoMoldura.Text.Contains(" "))
            {
                gvMoldes.DataSource = objCtrMolde.ListarMoldes();
                gvMoldes.DataBind();
            }
            else
            { 
                objDtoMolde.FK_IM_Cod = int.Parse(txtCodigoMoldura.Text);
                gvMoldes.DataSource = objCtrMolde.ListarMoldesxCodigoMoldura(objDtoMolde);
                gvMoldes.DataBind();
            }
        }
    }
}