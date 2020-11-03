<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Administrar_Solicitud_Pedido.aspx.cs" Inherits="WEB.Administrar_Solicitud_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="header-title">CARRITO DE COMPRAS</h4>

                <p></p>

                <div class="bootstrap-table bootstrap4">

                    <div class="fixed-table-toolbar">
                        <div class="bs-bars float-left">
                            <button id="demo-delete-row" class="btn btn-danger btn-sm" disabled><i class="mdi mdi-trash-can mr-1"></i>Delete</button>

                        </div>

                        <div class="colums columns-right btn-group float-right">
                            <button class="btn btn-secondary" type="button" name="paginationSwitch" arial-label="Pagination Switch" title="Hide/Show pagination">
                                <i class="fa fa-caret-square-down"></i>
                            </button>
                        </div>


                        <div class="float-right search btn-group">
                            <input class="form-control search-input" type="text" name="name" value="" placeholder="Search" autocomplete="off" />
                        </div>

                    </div>

                    <%--TABLA--%>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:GridView ID="gvCarrito"  runat="server" DataKeyNames="PK_IMU"></asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>









            </div>

        </div>
    </div>
</asp:Content>
