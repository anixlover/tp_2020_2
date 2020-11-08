<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Gestionar_Catalogo.aspx.cs" Inherits="WEB.Gestionar_Catalogo" %>

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
                <h4 class="page-title">GESTIONAR CATALOGO</h4>
            </div>
            <div class="card-box">

                <%--TABLA--%>
                <%--HeaderStyle-CssClass="table-borderless"--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div>
                            <asp:GridView ID="gvCatalogo" runat="server" CssClass="table-borderless table table-bordered table-hover"
                                DataKeyNames="Codigo,T. de Moldura" AutoGenerateColumns="False"
                                EmptyDataText="No existen registros, agreguen molduras a su carrito" ShowHeaderWhenEmpty="True" OnRowDataBound="gvCatalogo_RowDataBound" OnRowCommand="gvCatalogo_RowCommand">
                               <Columns>
                                    <%--<asp:TemplateField HeaderText="Agregar al carrito de compras">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" CssClass="checkbox" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                                   <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                   <asp:BoundField DataField="Precio V." HeaderText="Precio V." />
                                   <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <%--<asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("PK_IM_Cod") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioItems" runat="server" Text='<%# Eval("DMU_Precio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:ButtonField ButtonType="button" HeaderText="Detalles">
                                        <%--<ControlStyle CssClass="action-icon"/> <i class="mdi mdi-eye"></i>--%>
                                    </asp:ButtonField>

                                </Columns>
                            </asp:GridView>
                        </div>
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

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>


</asp:Content>
