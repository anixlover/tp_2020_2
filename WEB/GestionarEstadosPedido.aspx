<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarEstadosPedido.aspx.cs" Inherits="WEB.GestionarEstadosPedido" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card">
        <div class="card-header">
            Gestionar Estados de Pedidos
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo de solicitud" />
                            <asp:BoundField DataField="VS_TipoSolicitud" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo" />
                            <asp:BoundField DataField="DTS_FechaRegistro" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha de Registro" />
                            <asp:BoundField DataField="DTS_FechaRecojo" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha de Recojo" />                            
                            <asp:BoundField DataField="DS_ImporteTotal" ItemStyle-HorizontalAlign="Center" HeaderText="Importe" />
                            <asp:BoundField DataField="FK_VU_Dni" ItemStyle-HorizontalAlign="Center" HeaderText="Dni del cliente" />
                            <asp:BoundField DataField="Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre y apellido" />
                            <asp:BoundField DataField="VSE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                            <asp:TemplateField HeaderText="Accion" ItemStyle-HorizontalAlign="Center">                            
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cph_Js" runat="server">
</asp:Content>--%>
