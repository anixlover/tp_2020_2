﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="WEB.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap Tables css -->
    <link href="../assets/libs/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" type="text/css" />
    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card">
            <div class="card-header">
                Reporte de Ventas
            </div>
            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                Fecha Inicio:
                                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col">
                                Fecha Fin:
                                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <br />
                            <asp:Button ID="btnBuscar" runat="server" Text="🔎" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>
                            <br />
                        </div>
                        <br />
                        <div class="row">
                            <asp:GridView ID="gvVentas" runat="server" CssClass="table-borderless table table-bordered table-hover" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros!" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    <asp:BoundField DataField="PK_IS_Cod" HeaderText="Codigo" />
                                    <asp:BoundField DataField="VS_TipoSolicitud" HeaderText="Tipo" />
                                    <asp:BoundField DataField="DS_ImporteTotal" HeaderText="Importe" />
                                    <asp:BoundField DataField="DTS_FechaRecojo" HeaderText="Fecha" />
                                    <asp:BoundField DataField="FK_VU_Dni" HeaderText="DNI cliente" />
                                    <asp:BoundField DataField="IP_TipoCerficado" HeaderText="Certificado" />
                                </Columns>
                            </asp:GridView>
                            <br />                           
                        </div>
                        <div class="row"  style="color: #008000; font-weight: bold; font-style: inherit;">
                             Total: S/. <asp:Label ID="lbltotal" runat="server" Text="0.00"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</asp:Content>
