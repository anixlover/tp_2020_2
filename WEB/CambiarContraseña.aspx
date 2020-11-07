<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="WEB.CambiarContraseña" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>Forgot Password | UBold - Responsive Admin Dashboard Template</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
        <meta content="Coderthemes" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <!-- App favicon -->
        <link rel="shortcut icon" href="../assets/images/favicon.ico">

		<!-- App css -->
		<link href="../assets/css/bootstrap-creative.min.css" rel="stylesheet" type="text/css" id="bs-default-stylesheet" />
		<link href="../assets/css/app-creative.min.css" rel="stylesheet" type="text/css" id="app-default-stylesheet" />


		<link href="../assets/css/bootstrap-creative-dark.min.css" rel="stylesheet" type="text/css" id="bs-dark-stylesheet" />
		<link href="../assets/css/app-creative-dark.min.css" rel="stylesheet" type="text/css" id="app-dark-stylesheet" />

		<!-- icons -->
		<link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />

    </head>

    <body class="loading auth-fluid-pages pb-0">

        <div class="auth-fluid">
            <!--Auth fluid left content -->
            <div class="auth-fluid-form-box">
                <div class="align-items-center d-flex h-100">
                    <div class="card-body">

                        <!-- Logo -->
                        <div class="auth-brand text-center text-lg-left">
                            <div class="auth-logo">
                                <a href="index.html" class="logo logo-dark text-center">
                                    <span class="logo-lg">
                                        <img src="../assets/images/logo-dark.png" alt="" height="22">
                                    </span>
                                </a>

                                <a href="index.html" class="logo logo-light text-center">
                                    <span class="logo-lg">
                                        <img src="../assets/images/logo-light.png" alt="" height="22">
                                    </span>
                                </a>
                            </div>
                        </div>

                        <!-- title-->
                        <h4 class="mt-0">Recover Password</h4>
                        <p class="text-muted mb-4">Enter your email address and we'll send you an email with instructions to reset your password.</p>

                        <!-- form -->
                        <form action="#">

                            <div class="form-group mb-3">
                                <label for="emailaddress">Email address</label>
                                <input class="form-control" type="email" id="emailaddress" required="" placeholder="Enter your email">
                            </div>

                             <div class="form-group mb-3">
                                <input class="form-control" type="password" id="contraseña" required="" placeholder="Nueva contraseña">
                            </div>

                            <div class="form-group mb-3">
                                <input class="form-control" type="password" id="contraseña2" required="" placeholder="Confirmar contraseña">
                            </div>

                            
                            <div class="form-group mb-0 text-center">
                                <button class="btn btn-primary waves-effect waves-light btn-block" type="submit"> Reset Password </button>
                            </div>

                        </form>
                    <!-- end form-->
                    <!-- Footer-->
                    <footer class="footer footer-alt">
                        <p class="text-muted">Back to <a href="auth-login-2.html" class="text-muted ml-1"><b>Log in</b></a></p>
                    </footer>

                </div> <!-- end .card-body -->
                </div> <!-- end .align-items-center.d-flex.h-100-->
            </div>
            <!-- end auth-fluid-form-box-->

            <!-- Auth fluid right content -->
            <div class="auth-fluid-right text-center">
                <div class="auth-user-testimonial">
                    <h2 class="mb-3 text-white">I love the color!</h2>
                    <p class="lead"><i class="mdi mdi-format-quote-open"></i> I've been using your theme from the previous developer for our web app, once I knew new version is out, I immediately bought with no hesitation. Great themes, good documentation with lots of customization available and sample app that really fit our need. <i class="mdi mdi-format-quote-close"></i>
                    </p>
                    <h5 class="text-white">
                        - Fadlisaad (Ubold Admin User)
                    </h5>
                </div> <!-- end auth-user-testimonial-->
            </div>
            <!-- end Auth fluid right content -->
        </div>
        <!-- end auth-fluid-->

        <!-- Vendor js -->
        <script src="../assets/js/vendor.min.js"></script>

        <!-- App js -->
        <script src="../assets/js/app.min.js"></script>
        
    </body>
</html>

 <!--  <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
            
        
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
        
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
        <link rel="stylesheet" type="text/css" href="css/forget-password.css"/>
        
    
    
        <div class="d-flex align-items-center light-blue-gradient" style="height: 100vh;">
            <div class="container" >
                <div class="d-flex justify-content-center">
                    <div class="col-md-7">
                        <div class="card rounded-0 shadow">
                            <div class="card-body">
                                <h3>Olvido su contraseña</h3>
                                
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Ingrese lo solicitado:</label>
                                        <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Ingrese email"/>
                                        <div class="input-group input-group-merge">                                            
                        <asp:TextBox ID="txtContraseña" name="texto" runat="server" class="form-control" type="password" placeholder="Nueva contraseña" BackColor="White" ></asp:TextBox>
                        <div class="input-group-append" data-password="false">
                            <div class="input-group-text">
                                <span class="password-eye font-12"></span>
                            </div>
                        </div>
                    </div>
                                        <div class="input-group input-group-merge">                                            
                        <asp:TextBox ID="TextBox1" name="texto" runat="server" class="form-control" type="password" placeholder="Confirmar Contraseña" BackColor="White" ></asp:TextBox>
                        <div class="input-group-append" data-password="false">
                            <div class="input-group-text">
                                <span class="password-eye font-12"></span>
                            </div>
                        </div>
                    </div>
                                       
                                    </div>
                                    <button type="submit" class="btn btn-primary">Registrar</button>
                                
                            </div>
                        </div>
                    </div>
                </div>

                
                <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
                <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
                <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
            </div>
    
        </div>
    </form>
</body>
</html>
-->