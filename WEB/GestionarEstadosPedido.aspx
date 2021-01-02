<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarEstadosPedido.aspx.cs" Inherits="WEB.GestionarEstadosPedido" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="card">
        <div class="card-header">
            Gestionar Estados de Pedidos
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%" OnRowCommand="gvPedidos_RowCommand">
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
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Ver Detalles" ItemStyle-HorizontalAlign="Center" data-toggle="modal" data-target="#modalDetalle"
                                        CommandName="Ver detalles" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
     <div class="modal fade bd-example-modal-xl" id="modalDetalle" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-xl" role="dialog">
            <div class="modal-content">                
                <asp:UpdatePanel runat="server" ID="upPanelModal" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="modal-header">
                            <p class="modal-title" id="tituloModal" runat="server" style="color: #000000; font-weight: bold">
                                Detalles de la solicitud 
                        <asp:Label ID="lblid" runat="server" Text="0"></asp:Label>
                            </p>
                        </div>
                        <asp:GridView ID="gvPersonalizado" runat="server" DataKeyNames="PK_IMU_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" CssClass="table-borderless table table-bordered table-hover" Width="100%" OnRowDataBound="gvPersonalizado_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtenerImegenPersonalizada_2.ashx?id=<%# Eval("PK_IS_Cod")%>' height="60px" width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IMU_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código" />
                                <asp:BoundField DataField="PK_IS_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código de solicitud" />
                                <asp:BoundField DataField="DS_Largo" ItemStyle-HorizontalAlign="Center" HeaderText="Largo" />
                                <asp:BoundField DataField="DS_Ancho" ItemStyle-HorizontalAlign="Center" HeaderText="Ancho" />
                                <asp:BoundField DataField="VS_Comentario" ItemStyle-HorizontalAlign="Center" HeaderText="Comentario" />
                                <asp:BoundField DataField="IS_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DS_PrecioAprox" ItemStyle-HorizontalAlign="Center" HeaderText="Precio Aprox(S/.)" />
                                <asp:BoundField DataField="DS_ImporteTotal" ItemStyle-HorizontalAlign="Center" HeaderText="Importe total(S/.)" />
                                <asp:BoundField DataField="FK_IMXUE_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Cambiar Estado">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlEstados2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados2_SelectedIndexChanged"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvDetalles" runat="server" DataKeyNames="PK_IMU_Cod" AutoGenerateColumns="False"
                            EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" Width="100%" CssClass="table-borderless table table-bordered table-hover" OnRowDataBound="gvDetalles_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Imagen">
                                    <ItemTemplate>
                                        <img src='ObtieneImagen.ashx?id=<%# Eval("PK_IM_Cod")%>' height="80px" width="80px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PK_IMU_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código" />
                                <asp:BoundField DataField="PK_IM_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Código de Moldura" />
                                <asp:BoundField DataField="VM_Descripcion" ItemStyle-HorizontalAlign="Center" HeaderText="Descripción de Moldura" />
                                <asp:BoundField DataField="VTM_Nombre" ItemStyle-HorizontalAlign="Center" HeaderText="Tipo de Moldura" />
                                <asp:BoundField DataField="IMU_Cantidad" ItemStyle-HorizontalAlign="Center" HeaderText="Cantidad" />
                                <asp:BoundField DataField="DMU_Precio" ItemStyle-HorizontalAlign="Center" HeaderText="Precio" />
                                <asp:BoundField DataField="FK_IMXUE_Cod" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Cambiar Estado">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cph_Js" runat="server">
</asp:Content>--%>
