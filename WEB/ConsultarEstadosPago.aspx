﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="ConsultarEstadosPago.aspx.cs" Inherits="WEB.ConsultarEstadosPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <!-- Plugins css -->
    <link href="../assets/libs/dropzone/min/dropzone.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/libs/dropify/css/dropify.min.css" rel="stylesheet" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cph_Js" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlEstadoSolicitud" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoSolicitud_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                            <br />
                            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPedidos_RowCommand" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Codigo de solicitud" />
                                    <asp:BoundField DataField="DTS_FechaEmicion" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha de emision del pago" />
                                    <asp:BoundField DataField="VS_TipoSolicitud" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo" />
                                    <asp:BoundField DataField="DS_ImporteTotal" ItemStyle-HorizontalAlign="Center" HeaderText="Importe" />
                                    <asp:BoundField DataField="VSE_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Accion" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button runat="server" DataKeyNames="PK_IS_Cod,VSE_Nombre" Text="Pago 💵" ItemStyle-HorizontalAlign="Center"
                                                Visible='<%# ValidacionEstado1(Eval("VSE_Nombre").ToString()) %>'
                                                CommandName="Pago" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-soft-blue" />
                                            <asp:Button runat="server" Text="Actualizar" ItemStyle-HorizontalAlign="Center"
                                                Visible='<%# ValidacionEstado2(Eval("VSE_Nombre").ToString()) %>'
                                                CommandName="Actualizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                            <asp:Button runat="server" Text="Ver" ItemStyle-HorizontalAlign="Center"
                                                Visible='<%# ValidacionEstado3(Eval("VSE_Nombre").ToString()) %>'
                                                CommandName="Ver detalle" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                            <asp:Button runat="server" Text="Ver Detalles" ItemStyle-HorizontalAlign="Center" data-toggle="modal" data-target="#modalDetalle"
                                                CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                            <asp:Button runat="server" Text="Ver proceso" ItemStyle-HorizontalAlign="Center"
                                                Visible='<%# ValidacionEstado5(Eval("VSE_Nombre").ToString()) %>'
                                                CommandName="Ver proceso" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                            <asp:Button runat="server" Text="Ver incidencias" ItemStyle-HorizontalAlign="Center"
                                                Visible='<%# ValidacionEstado6(Eval("VSE_Nombre").ToString()) %>'
                                                CommandName="Ver incidencias" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
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
                                Detalles de la solicitud 
                        <asp:Label ID="lblid" runat="server" Text="0"></asp:Label>
                            </p>
                        </div>
                        <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IS_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtenerImagenPersonalizada.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="DS_Largo" ItemStyle-HorizontalAlign="Center" HeaderText="Largo" />
                                <asp:BoundField DataField="DS_Ancho" ItemStyle-HorizontalAlign="Center" HeaderText="Ancho" />
                                <asp:BoundField DataField="VS_Comentario" ItemStyle-HorizontalAlign="Center" HeaderText="Cometario" />
                                <asp:BoundField DataField="IS_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DS_PrecioAprox" ItemStyle-HorizontalAlign="Center" HeaderText="Precio Aprox(S/.)" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvDetalles" runat="server" DataKeyNames="PK_IM_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="100%" CssClass="table-borderless table table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IM_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código de Moldura" />
                                <asp:BoundField DataField="VM_Descripcion" ItemStyle-HorizontalAlign="Center" HeaderText="Descripción de Moldura" />
                                <asp:BoundField DataField="VTM_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo de Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Bootstrap Tables js -->
    <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

    <!-- Init js -->
    <script src="../assets/js/pages/bootstrap-tables.init.js"></script>
</asp:Content>
