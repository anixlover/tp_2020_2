﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarMolde.aspx.cs" Inherits="WEB.GestionarMolde" %>
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
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <h4 class="page-title">GESTIONAR MOLDE</h4>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="card-box">
                <h4 class="page-title">MOLDURAS</h4>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col">
                                <asp:DropDownList ID="ddlTipoMoldura" runat="server" placeholder="Código de Moldura" CssClass="form-control" OnSelectedIndexChanged="ddlTipoMoldura_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtcodigo" runat="server" placeholder="codigo de moldura" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtcodigo_TextChanged" pattern="[0-9]+" TextMode="Number" step="1" min="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="overflow-y: scroll; overflow-x: hidden; height: 200px; width: 100%;">
                            <asp:GridView ID="gvMolduras" runat="server" CssClass="table-borderless table table-bordered table-hover"
                                DataKeyNames="Codigo,T. de Moldura" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros, agreguen molduras a su catálogo" ShowHeaderWhenEmpty="True" OnRowCommand="gvMolduras_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Imagen">
                                        <ItemTemplate>
                                            <img src='ObtieneImagen.ashx?id=<%# Eval("Codigo")%>' height="80px" width="80px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                    <asp:BoundField DataField="T. de Moldura" HeaderText="T. de Moldura" />
                                    <asp:BoundField DataField="Largo" HeaderText="Largo" />
                                    <asp:BoundField DataField="Ancho" HeaderText="Ancho" />
                                    <asp:BoundField DataField="U. Metrica" HeaderText="U. Metrica" />
                                    <asp:TemplateField HeaderText="Accion" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Agregar Molde" ItemStyle-HorizontalAlign="Center" data-toggle="modal" data-target="#modalDetalle"
                                                Visible='<%# ValidacionExistencia(int.Parse(Eval("Codigo").ToString())) %>' CommandName="Agregar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>                           
                        </div>
                        <br />
                        <h4 class="page-title">MOLDES</h4>
                        <div class="row">
                            <asp:TextBox ID="txtCodigoMoldura" placeholder="codigo de moldura" runat="server" CssClass="form-control" OnTextChanged="txtCodigoMoldura_TextChanged" pattern="[0-9]+" TextMode="Number" step="1" min="0" AutoPostBack="true" Width="25%"></asp:TextBox>
                            <br />
                        </div>
                        <div class="row">
                            <asp:GridView ID="gvMoldes" runat="server" CssClass="table-borderless table table-bordered table-hover" AutoGenerateColumns="False"
                                DataKeyNames="PK_IML_Cod" EmptyDataText="No existen registros, agreguen moldes a su catálogo" ShowHeaderWhenEmpty="True" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="PK_IML_Cod" HeaderText="Codigo" />
                                    <asp:BoundField DataField="VML_Disponibilidad" HeaderText="Disponibilidad" />
                                    <asp:BoundField DataField="IML_Cantidad" HeaderText="Cantidad" />
                                    <asp:BoundField DataField="FK_IM_Cod" HeaderText="Codigo de Moldura" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="dialog">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="upPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header">
                            <p class="modal-title" id="tituloModal" runat="server" style="color: #000000; font-weight: bold">
                                Moldura N° <asp:Label ID="lblId" runat="server" Text="..."></asp:Label>
                            </p>
                        </div>
                        <div class="row-sm">
                            <div class="col-sm">
                                <asp:TextBox ID="txtCantidad" runat="server" placeholder="Cantidad" CssClass="form-control" pattern="[0-9]+" TextMode="Number" step="1" min="0" Width="50%"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                <br />
                            </div>
                            <br />
                            <br />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
