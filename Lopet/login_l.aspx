<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_l.aspx.cs" Inherits="Lopet.login_l" EnableEventValidation="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Inicio Sesion</title>
    <link href="Content/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <link href="Content/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="Content/js/bootstrap.js"></script>
    <script type="text/javascript" src="Content/js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    </script>
		<!----webfonts---->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Oswald:400,300,700' rel='stylesheet' type='text/css'>
    <!----//webfonts---->
    <link href="Content/css/theme.css" rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="Content/js/jquery.min.js"></script>
    <!--start slider -->
    <link rel="stylesheet" href="Content/css/fwslider.css" media="all">
    <script src="Content/js/jquery-ui.min.js"></script>
    <script src="Content/js/css3-mediaqueries.js"></script>
    <script src="Content/js/fwslider.js"></script>
    <!--end slider -->
    <!--  jquery plguin -->
    <script src="Content/js/login.js"></script>
    <script src="Content/js/modernizr.custom.js"></script>


    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <script src="Content/js/validacion.js"></script>

    <link href="Content/login/css/style.css" rel="stylesheet" />

    <script type="text/javascript">
        //javscript Menu principal
        $(document).ready(function () {

            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear'
            };


            $().UItoTop({ easingType: 'easeOutQuart' });

        });
        /*********FACEBOOK CON JAVASCRIPT********/
        //// initialize and setup facebook js sdk
        //window.fbAsyncInit = function () {
        //    FB.init({
        //        appId: '460240781009362',
        //        xfbml: true,
        //        version: 'v2.10'
        //    });
        //    FB.getLoginStatus(function (response) {

        //        if (response.status === 'connected') {
        //            document.getElementById('status').innerHTML = 'We are connected.';
        //            document.getElementById('login').style.visibility = 'hidden';

        //        } else if (response.status === 'not_authorized') {
        //            document.getElementById('status').innerHTML = 'We are not logged in.'
        //        } else {
        //            document.getElementById('status').innerHTML = 'You are not logged into Facebook.';
        //        }
        //    });
        //};
        //(function (d, s, id) {
        //    var js, fjs = d.getElementsByTagName(s)[0];
        //    if (d.getElementById(id)) { return; }
        //    js = d.createElement(s); js.id = id;
        //    js.src = "//connect.facebook.net/en_US/sdk.js";
        //    fjs.parentNode.insertBefore(js, fjs);
        //}(document, 'script', 'facebook-jssdk'));

        //// login with facebook with extra permissions
        //function login() {
        //    FB.login(function (response) {
        //        if (response.status === 'connected') {
        //            document.getElementById('status').innerHTML = 'We are connected.';
        //            document.getElementById('login').style.visibility = 'hidden';
        //        } else if (response.status === 'not_authorized') {
        //            document.getElementById('status').innerHTML = 'We are not logged in.'
        //        } else {
        //            document.getElementById('status').innerHTML = 'You are not logged into Facebook.';
        //        }
        //    }, { scope: 'email' });
        //}

        //// getting basic user info
        //function getInfo() {
        //    FB.api('/me', 'GET', { fields: 'first_name,last_name,name,id' }, function (response) {
        //        document.getElementById('status').innerHTML = response.id;
        //    });
        //}
        /*********FACEBOOK CON JAVASCRIPT********/

        /*********FACEBOOK CON ASP.NET********/
        // Load the SDK Asynchronously
        (function (d) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all.js";
            ref.parentNode.insertBefore(js, ref);
        }(document));

        // Init the SDK upon load
        window.fbAsyncInit = function () {
            FB.init({
                appId: 'write your app id here', // App ID
                channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            // listen for and handle auth.statusChange events
            FB.Event.subscribe('auth.statusChange', function (response) {
                if (response.authResponse) {
                    // user has auth'd your app and is logged into Facebook
                    FB.api('/me', function (me) {
                        if (me.name) {
                            document.getElementById('auth-displayname').innerHTML = me.name;
                        }
                    })
                    document.getElementById('auth-loggedout').style.display = 'none';
                    document.getElementById('auth-loggedin').style.display = 'block';
                } else {
                    // user has not auth'd your app, or is not logged into Facebook
                    document.getElementById('auth-loggedout').style.display = 'block';
                    document.getElementById('auth-loggedin').style.display = 'none';
                }
            });
            $("#auth-logoutlink").click(function () { FB.logout(function () { window.location.reload(); }); });
        }
        /*********FACEBOOK CON ASP.NET********/
        function validacion_usuario() {
            alert('usuario no registrado');
        }
    </script>

</head>

<body>
    <form id="form1" runat="server">

        <div class="header-bg" id="home">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="logo">
                            <h1><a href="/inicio.aspx">LOPET</a></h1>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="h_right">
                            <div class="left">
                                <ul class="menu list-unstyled">
                                    <li class="active"><a href="/inicio.aspx" class="scroll">Inicio</a></li>
                                    <%--<li><a href="#features" class="scroll">Quienes Somos</a></li>--%>
                                    <li><a href="/buscarLopets.aspx" class="scroll">Buscar Lopets</a></li>
                                    <li><a href="/busqueda_sitios.aspx" class="scroll">Sitios de Interes</a></li>
                                    <li><a href="/Registrar.aspx" class="scroll">Registrarse</a></li>

                                </ul>
                            </div>


                            <!-- start smart_nav * -->
                            <nav class="nav">
                                <ul class="nav-list">
                                    <li class="nav-item"><a href="/inicio.aspx">Inicio</a></li>
                                    <li class="nav-item"><a href="/buscarLopets.aspx" class="scroll">Buscar Lopets</a></li>
                                    <li class="nav-item"><a href="/busqueda_sitios.aspx" class="scroll">Sitios de Interes</a></li>
                                    <li class="nav-item"><a href="/Registrar.aspx" class="scroll">Registrarse</a></li>

                                    <div class="clearfix"></div>
                                </ul>

                                <div class="nav-mobile"></div>
                            </nav>

                            <script type="text/javascript" src="Content/js/responsive.menu.js"></script>
                            <!-- end smart_nav * -->
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="logmod" style="position: relative; background: none;">
            <div class="logmod__wrapper">

                <div class="logmod__container">
                    <ul class="logmod__tabs">
                        <li data-tabtar="lgm-1"><a href="#">Ingresar</a></li>
                    </ul>
                    <div class="logmod__tab-wrapper">
                        <div class="logmod__tab lgm-1">
                            <div class="logmod__heading">
                                <span class="logmod__heading-subtitle">Ingresar sus datos personales <strong>para crearse una cuenta</strong></span>
                            </div>
                            <div class="logmod__form">
                                <form accept-charset="utf-8" action="#" class="simform">
                                    <div class="sminputs">

                                        <div class="sminputs">
                                            <div class="input full">
                                                <label class="string optional" for="user-name">Correo*</label>
                                                <asp:TextBox ID="txt_correo" class="string optional" placeholder="Correo" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="sminputs">
                                            <div class="input full">
                                                <label class="string optional" for="user-pw">Contraseña *</label>
                                                <asp:TextBox ID="txt_con" class="string optional" placeholder="Contraseña" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="simform__actions">
                                        <%--   <input class="sumbit" name="commit" type="sumbit" value="Crear Cuenta" />--%>
                                        <asp:Button ID="btn_ing" class="sumbit" runat="server" Text="Ingresar" OnClick="btn_ingresar_Click" />
                                        <span class="simform__actions-sidetext"><a class="special" role="link">Olvido su contraseña?<br>
                                            Click aqui</a></span>
                                    </div>
                                </form>
                            </div>
                            <div class="logmod__alter">
                                <div class="logmod__alter-container">
                                    <a href="#" class="connect facebook">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/images/ing_face.png" OnClick="ImageButton1_Click" />
                                    </a>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>


        <script src="Content/login/js/index.js"></script>
    </form>
</body>
</html>
