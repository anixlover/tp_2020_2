<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EvaluarPago.aspx.cs" Inherits="WEB.EvaluarPago" %>

<%--dev alvaro--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-12">
        <div class="page-title-box">
            <h2 style="text-align: center;" class="page-title">ADMINISTRAR PEDIDO</h2>
        </div>
        <div class="card-box">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
            <div class="body table-responsive">
                <%--<div class="header">
                    <h2>Administrar Pedidos
                                <small></small>
                    </h2>
                    <ul class="header-dropdown m-r--5">
                    </ul>
                </div>--%>
                <%--<input type="hidden" runat="server" id="valorObtenido" clientidmode="Static" />--%>
                <div class="card">
                    <div class="body">
                        <%--Imagen del producto--%>
                        <div class="tab-content pt-0">
                            <div class="tab-pane active show" id="product-1-item">
                                <asp:Image ID="Image1" Height="500px" Width="480px" runat="server" class="rounded" ImageAlign="Middle" />
                            </div>
                        </div>
                        <!-- end col -->

                        <%--Numero de operacion--%>
                        <h1>No. Operacion: #<asp:Label ID="txtNumOperacion" runat="server"></asp:Label></h1>
                        <%--end numero de operacion--%>

                        <%--Monto--%>
                        <h1>Monto: S/.<asp:Label ID="txtmonto" runat="server"></asp:Label></h1>
                        <%--end monto--%>

                        <%--ddl decision--%>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updPanelddl" ClientIDMode="Static">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddl_decision" ClientIDMode="Static" CssClass="form-control" Width="30%" OnSelectedIndexChanged="ddl_TipoComprobante_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Seleccionar" Selected="True" />
                                    <asp:ListItem Value="1" Text="Aprobar" />
                                    <asp:ListItem Value="2" Text="Reportar" />
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--end ddl decision--%>
                        <br>
                        <br>
                        <br>
                        <%--boton confirmar--%>
                        <asp:LinkButton ID="btnConfirmar" runat="server" type="button" class="btn btn-success waves-effect waves-light" OnClick="btnConfirmar_Click">
                                                    <span class="btn-label"></span>Confirmar
                        </asp:LinkButton>
                        <%--end boto confirmar--%>

                        <%--boton regresar--%>
                        <button type="button" onclick="" class="btn btn-danger waves-effect">
                            <a href="javascript:history.back()" style="color: white"><span class="btn-label"><i class="mdi dripicons-return"></i></span>Volver Atrás</a>
                        </button>
                        <%--end boton regresar--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function showSuccessMessage1() {
            swal({
                title: "ERROR!",
                text: "UPS! No se pudo completar la accion, vuelva a recargar la pagina!    ",
                type: "error"
            });
        }
        function showSuccessMessage2() {
            swal({
                title: "Actualizado Correctamente!",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "Administrar_Pedido.aspx"
                }
            });
        }
        function showSuccessMessage3() {
            swal({
                title: "Se le reporto al usuario correctamente!",
                text: "Pulsa el botón y se te redirigirá",
                type: "success"
            }, function (redirect) {
                if (redirect) {
                    window.location.href = "Administrar_Pedido.aspx"
                }
            });
        }
        function showSuccessMessage4() {
            swal({
                title: "SELECCIONAR OPCION!",
                text: "UPS! No selecciono ninguna opcion!",
                type: "error"
            });
        }
        
    </script>
    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Bootstrap Tables js -->
    <script src="../assets/libs/bootstrap-table/bootstrap-table.min.js"></script>

    <!-- Init js -->
    <script src="../assets/js/pages/bootstrap-tables.init.js"></script>
</asp:Content>
