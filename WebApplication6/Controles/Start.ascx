<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Start.ascx.vb" Inherits="WebApplication6.Start1" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>TiempoOficial.com Live Timing</title>
	<link rel="stylesheet" href="Content/site.css?v1.13">
</head>
<body>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({
                appId: '779337262082870', // Set YOUR APP ID
                status: true, // check login status
                version: 'v2.3',
                xfbml: false  // parse XFBML
            });
            CheckLogin();
            var offsetHeight = document.getElementById('alto').offsetHeight;
            FB.Canvas.setSize({ height: offsetHeight + 40 });
        };

        function CheckLogin() {
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    // the user is logged in and has authenticated your
                    // app, and response.authResponse supplies
                    // the user's ID, a valid access token, a signed
                    // request, and the time the access token 
                    // and signed request each expire
                    //var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;
                    finish(accessToken);
                } else if (response.status === 'not_authorized') {
                    // the user is logged in to Facebook, s
                    // but has not authenticated your app
                    Login();
                } else {
                    Login();
                    // the user isn't logged in to Facebook.
                }
            });
        }

        function Login() {

            FB.login(function (response) {
                if (response.authResponse) {
                    CheckLogin();
                } else {
                    document.getElementById("divIniciar").style.display = "block";
                    //console.log('User cancelled login or did not fully authorize.');
                }
            }, { scope: 'public_profile,email,user_friends' });

        }

        function finish(accessToken) {
            var form = document.createElement("form");
            form.setAttribute("method", 'post');
            form.setAttribute("action", 'Inicio.aspx');

            var field = document.createElement("input");
            field.setAttribute("type", "hidden");
            field.setAttribute("name", 'accessToken');
            field.setAttribute("value", accessToken);
            form.appendChild(field);

            document.body.appendChild(form);
            form.submit();
        }

        // Load the SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/es_LA/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

    </script>
    <div id="alto">
<div id="ver" runat ="server">
<div id="wrapper">
        <header id="topHeader">
                                    <h1>
                           </h1>
            <h1>
                           </h1>
                        <h1>
                           </h1>
            <h1>
                           </h1>
            <h1>
                           </h1>
                        <h1>
                           </h1>
            <h1>
                           </h1>

            <h2>Bienvenido</h2>
            <span id="arrow"></span>
            <h3>Esta aplicación te permitirá acceder a los resultados de tus competencias con el sistema de cronometraje de TiempoOficial.com</h3>
        </header>
        

<article class="intro">
    <span id="profilePicture">
        <asp:Literal id="LProfileImg" runat="server"></asp:Literal>
    </span>
    <h3>Bienvenido: <asp:Literal id="LName" runat="server"></asp:Literal></h3>
</article>

<article id="content">
    <div class="left">
        <label>
            A través de esta aplicación podrás inscribirte a tus eventos deportivos así como obtener tus tiempos parciales, totales y estadísticas de competencia.
        </label>
            </div>
    <div class="right">
        <label>
            A continuación se muestran tus estadísticas de competencia. Sólo se muestran las estadísticas de los eventos que utilizan la tecnología de cronometraje electrónico de TiempoOficial.com.
        </label>
        <br /><br />
        <asp:Literal id="historial" runat="server"></asp:Literal>
        <div id="divIniciar" style="display:none;">
        Click para iniciar: <br/>
        <img src="Imagenes/LoginWithFacebook.png" style="cursor:pointer;" onclick="CheckLogin();"/>
        </div>
        <br /><br />
        <br />
    </div>
</article>
        <footer>
            <p>Todos los Derechos Reservados</p>
            <p>Copyright © 2014-2015 <a href="http://tiempooficial.com" target="_blank">TiempoOficial.com®</a></p>
        </footer>
    </div>
</div>
</div> 
	</body>
</html>