<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="Administrar_Perfil.aspx.cs" Inherits="WEB.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/bootstrap-saas.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app-saas.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />
    <link href="../assets/css/bootstrap-saas-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-saas-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card-box" style="background-color: #FFFFFF">
            <div class="row">
                <div class="col">
                    <asp:Image ID="Image1" runat="server" ImageUrl="https://www.expreso.com.pe/wp-content/uploads/2020/07/abimael-guzman1.jpg" Height="100%" Width="100%" ImageAlign="Middle" />
                </div>
                <div class="col">
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Apellidos:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control"  BackColor="White" Width="100%" TextMode="Date"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Correo:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label ID="Label5" runat="server" Text="RUCs:"></asp:Label>
                    <br />
                    <asp:ListBox ID="LRucs" runat="server" CssClass="form-comtrol" Height="100%" Width="100%" OnSelectedIndexChanged="LRucs_SelectedIndexChanged"></asp:ListBox>
                </div>
                <div class="col">
                    <asp:Label ID="Label6" runat="server" Text="Eliminar:"></asp:Label>
                    <br />
                    <asp:ListBox ID="LEliminar" runat="server" CssClass="form-comtrol" Height="100%" Width="100%" OnSelectedIndexChanged="LRucs_SelectedIndexChanged"></asp:ListBox>

                </div>

            </div>
            <br />
            <div class="row">
                <div class="col" style="text-align:center">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-success" Width="50%" OnClick="btnModificar_Click" />
                </div>
                <div class="col" style="text-align:center">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" Width="50%" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
