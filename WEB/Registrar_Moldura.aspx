﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Registrar_Moldura.aspx.cs" Inherits="WEB.Registrar_Moldura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Plugins css -->
    <link href="../assets/libs/dropzone/min/dropzone.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/libs/dropify/css/dropify.min.css" rel="stylesheet" type="text/css" />

    <!-- App css -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />

    <link href="../assets/css/bootstrap-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

    <!-- icons -->
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />

    <!-- Libreria JQuery -->
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>
    <!--JS leerImagen-->
    <script type="text/javascript">
        function leerImagen(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#hfileupload').val("Lleno");
                    console.log(reader.result);
                    convertDataURIToBinary(reader.result);
                };
                var BASE64_MARKER = ';base64,';

                function convertDataURIToBinary(dataURI) {
                    var base64Index = dataURI.indexOf(BASE64_MARKER) + BASE64_MARKER.length;
                    var base64 = dataURI.substring(base64Index);
                    var raw = window.atob(base64);
                    var rawLength = raw.length;
                    var array = new Uint8Array(new ArrayBuffer(rawLength));

                    for (i = 0; i < rawLength; i++) {
                        array[i] = raw.charCodeAt(i);
                    }
                    $('#hftxtimg').val(array);
                    console.log(array);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <h4 class="page-title">REGISTRAR MOLDURA</h4>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="card-box">

                <label for="heard">Adjunte imagen: <span class="text-danger">*</span></label>
                

                <input type="file" id="FileUpload1" accept="image/*" onchange="leerImagen(this);" data-plugins="dropify" data-height="300"   />

                <div class="row">
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Tipo de moldura: <span class="text-danger">*</span></label>
                            <asp:DropDownList ID="ddlTipoMoldura" class="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Largo: <span class="text-danger">*</span></label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">cm</span>
                                </div>
                                <asp:TextBox ID="txtLargo" runat="server" class="form-control autonumber" data-v-max="250" data-v-min="0" placeholder="Centimetros"></asp:TextBox>
                                <%--<input type="text" class="form-control" id="validationCustomUsername" placeholder="Centimetros" aria-describedby="inputGroupPrepend"
                                    required>--%>
                                <%--<div class="invalid-feedback">
                                    Please choose a username.
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Ancho: <span class="text-danger">*</span></label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">cm</span>
                                </div>
                                <asp:TextBox ID="txtAncho" runat="server" class="form-control autonumber" data-v-max="250" data-v-min="0" placeholder="Centimetros"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Estado: <span class="text-danger">*</span></label>
                            <asp:DropDownList ID="ddlEstadoMoldura" class="form-control" runat="server" required>
                                <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Stock: <span class="text-danger">*</span></label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">u.</span>
                                </div>
                                <asp:TextBox ID="txtStock" class="form-control autonumber" data-parsley-type="digits" data-v-max="999" data-v-min="0" runat="server" required></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="mt-3">
                            <label for="heard">Precio: <span class="text-danger">*</span></label>
                            <div class="input-group">
                                <asp:TextBox ID="txtPrecio" class="form-control autonumber" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <label for="heard">Descripción: <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtDescripcion" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group text-right m-b-0">
                            <asp:UpdatePanel ID="upBotonRegistrar" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btnActualizar" Visible="true" class="btn btn-primary waves-effect waves-light" runat="server">
                                    Actualizar<span class="btn-label-right"><i class="mdi mdi-content-save-edit"></i></span>        
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnRegistrar" class="btn btn-success waves-effect waves-light" runat="server" OnClick="btnRegistrar_Click">
                                    Registrar<span class="btn-label-right"><i class="mdi mdi-check-all"></i></span>        
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCancelar" class="btn btn-light waves-effect" runat="server" OnClick="btnCancelar_Click">
                                    Regresar<span class="btn-label-right"><i class="mdi mdi-arrow-right-bold"></i></span>
                                    </asp:LinkButton>
                                    <input type="hidden" runat="server" id="hftxtimg" clientidmode="Static" value="vacio" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Right bar overlay-->
    <div class="rightbar-overlay"></div>

    <!-- Vendor js -->
    <script src="../assets/js/vendor.min.js"></script>

    <!-- Plugin js-->
    <script src="../assets/libs/dropzone/min/dropzone.min.js"></script>
    <script src="../assets/libs/dropify/js/dropify.min.js"></script>
    <script src="../assets/libs/parsleyjs/parsley.min.js"></script>
    <script src="../assets/libs/jquery-mask-plugin/jquery.mask.min.js"></script>
    <script src="../assets/libs/autonumeric/autoNumeric-min.js"></script>

    <!-- Validation init js-->
    <script src="../assets/js/pages/form-validation.init.js"></script>
    <script src="../assets/js/pages/form-fileuploads.init.js"></script>

    <!-- Init js-->
    <script src="../assets/js/pages/form-masks.init.js"></script>

    <!-- App js -->
    <script src="../assets/js/app.min.js"></script>
    <script src="assets/js/Aplicacion/UploadFile.js"></script>

    <script>

        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Enviado correctamente",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "ConsultarEstadoPago.aspx";
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
