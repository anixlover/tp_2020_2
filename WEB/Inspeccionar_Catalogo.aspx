﻿<%@ Page Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Inspeccionar_Catalogo.aspx.cs" Inherits="WEB.Inspeccionar_Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="seccion contenedor clearfix">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <h2>Catalogo</h2>
        <div class="contenedor-molduras">
            <div class="categorias" id="categorias">
                <asp:UpdatePanel runat="server" ID="updOpcionesMolduras">
                    <ContentTemplate>
                        <asp:LinkButton runat="server" ID="btnTodos" OnClick="btnTodos_Click">Todos</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnBaquetonClasico" OnClick="btnBaquetonClasico_Click">Baqueton Clasico</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnBaquetonDecorado" OnClick="btnBaquetonDecorado_Click">Baqueton Decorado</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnRosetonClasico" OnClick="btnRosetonClasico_Click">Roseton Clasico</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnRosetonDecorado" OnClick="btnRosetonDecorado_Click">Roseton Decorado</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnCornisaClasica" OnClick="btnCornisaClasica_Click">Cornisa Clasica</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnCornisaDecorada" OnClick="btnCornisaDecorada_Click">Cornisa Decorada</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnPlaca3D" OnClick="btnPlaca3D_Click">Placa 3D</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        
        <div class="lista-moldura-tipo">


            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                <ContentTemplate>
                    <ul class="lista-moldura-tipo clearfix" id="ListaMoldura" runat="server">
                    </ul>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">

    <script src="js/Aplicacion/UploadFile.js"></script>
    <script>
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = ".aspx";
                });
            }, 1000);
        }

        function getQueryStringParameter(paramToRetrieve) {
            if (document.URL.split("?")[1] != undefined) {
                var params = document.URL.split("?")[1].split("&");
                var strParams = "";
                for (var i = 0; i < params.length; i = i + 1) {
                    var singleParam = params[i].split("=");
                    if (singleParam[0] == paramToRetrieve)
                        return singleParam[1].replace("#", "");
                }
            }
        }
    </script>
</asp:Content>
