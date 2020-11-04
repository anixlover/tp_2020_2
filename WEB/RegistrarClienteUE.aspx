<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCliente.Master" AutoEventWireup="true" CodeBehind="RegistrarClienteUE.aspx.cs" Inherits="WEB.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
  <%--<div style="background-position: center center; background-image: url('https://localhost:44363/assets/images/small/Portada2.png'); background-repeat: no-repeat; background-attachment: fixed;background-size:cover">--%>
     <p class="text-dark" style="text-align: center"><strong>REGISTRARSE</strong></p>
      <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-white">               
                <div class="card-body p-4">
                    <div class="row">
                        <div class="col-md-6" runat="server">
                            DNI
                            <asp:TextBox ID="txtDNI" name="texto" runat="server" class="form-control" type="text" placeholder="DNI" MinLength="8" MaxLength="8" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Nombres
                            <asp:TextBox ID="txtNombres" name="texto" runat="server" class="form-control" type="text" placeholder="Nombres" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Apellidos
                            <asp:TextBox ID="txtApellidos" name="texto" runat="server" class="form-control" type="text" placeholder="Apellidos" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            Fecha de nacimiento
                            <asp:TextBox ID="txtFechNac" name="texto" runat="server" class="form-control" type="date" placeholder="mm/dd/yyyy" BackColor="White" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        Celular
                    <asp:TextBox ID="txtCelular" name="texto" runat="server" class="form-control" type="text" placeholder="Celular" pattern="[0-9]+" MinLength="9" BackColor="White" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        Correo Electrónico
                    <asp:TextBox ID="txtCorreo" name="texto" runat="server" class="form-control" type="mail" placeholder="Correo electronico" BackColor="White" Width="100%"></asp:TextBox>
                    </div>
                    Contraseña   
                    <div class="input-group input-group-merge">                                            
                        <asp:TextBox ID="txtContraseña" name="texto" runat="server" class="form-control" type="password" placeholder="Contraseña" BackColor="White" ></asp:TextBox>
                        <div class="input-group-append" data-password="false">
                            <div class="input-group-text">
                                <span class="password-eye font-12"></span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div style="text-align:center">                        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btnRegistrar" class="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancelar" class="btn btn-secondary" runat="server" Text="Cancelar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--</div>--%>
</asp:Content>
