<%@ Page Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="DescripcionMoldura.aspx.cs" Inherits="WEB.DescripcionMoldura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/bootstrap-saas.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app-saas.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-saas-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-saas-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="../assets/images/favicon.ico">

    <!-- Lightbox css -->
    <link href="../assets/libs/magnific-popup/magnific-popup.css" rel="stylesheet" type="text/css" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css"/>

    <link href="assets/css/StyleSheet1.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <section class="seccion contenedor clearfix">
        <h2>Descripcion</h2>
        <div class="descripcion-moldura">
            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Image ID="Image1" Height="370px" Width="450px" runat="server" class="rounded" />

                    <p>Medida:<asp:Label ID="txtmedida" runat="server"></asp:Label></p>
                    <p>
                     <%--   <asp:Label ID="txtmetrica" runat="server"></asp:Label>--%>
                    </p>
                    <p>Precio: S./<asp:Label ID="txtprecio" runat="server" ClientIDMode="Static"></asp:Label></p>
                    <p>Descripción:<asp:Label ID="txtdescripcion" runat="server"></asp:Label></p>
                    <asp:Button runat="server" ID="Button1" CssClass="button" Text="Regresar" OnClick="Button1_Click" />

                    <a href="#" class="button" onclick="btn_regresar()"><i class="far fa-star"></i></a>

                    <%--<asp:Button runat="server" ID="btnModal" CssClass="button" Text="Agregar a carrito de compra" data-target="#defaultmodal" data-toggle="modal" />--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>

