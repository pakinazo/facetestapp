<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Inicio.ascx.vb" Inherits="WebApplication6.Inicio1" %>



<%--    <div id="ver">

        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
       ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
       ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
       ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        ads
<br />
        <img src="http://www.planwallpaper.com/static/images/Nature-Beach-Scenery-Wallpaper-HD.jpg" />
        <img src="http://www.planwallpaper.com/static/images/black-apple-wallpaper-hd-hd-wallpapers-landscape-animals-photo-wallpaper-hd.jpg" />
        <img src="http://www.planwallpaper.com/static/images/1641179.jpg" />
        <img src="http://www.hdwallpapers.in/walls/limited_edition_batman_arkham_knight-wide.jpg" />
        <img src="http://www.hdwallpapers.in/walls/katy_perry_as_elizabeth_taylor-wide.jpg" />
    </div>--%>
    <%--<script src="https://connect.facebook.net/es_MX/all.js"></script>--%>

   <%-- <script src="https://connect.facebook.net/es_MX/all.js"></script>--%>
   <%--       <script>

              window.fbAsyncInit = function () {
                  FB.init({
                      appId: '779337262082870', // Set YOUR APP ID
                      status: true, // check login status
                      version: 'v2.3',
                      xfbml: false  // parse XFBML
                  });
              };
     
                  window.onload = function () {
                      var offsetHeight = document.getElementById('ver').offsetHeight;
                      FB.Canvas.setSize({ height: offsetHeight + 40 });
                    
                  };
      </script>--%>

      

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>TiempoOficial.com Live Timing</title>
	<link rel="stylesheet" href="Content/site.css?v1.13">
</head>
<body>
    <div id="alto">
<div id="ver" runat ="server" visible="false">
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
        <br /><br />
        <asp:HyperLink NavigateUrl="~/ProximosEventos.aspx" ID="proxE" runat="server" CssClass="HistorialLink">Próximos Eventos</asp:HyperLink>
        <asp:Literal ID="espacioResAmigos" runat="server" Text="<br /><br />" Visible="false"></asp:Literal>
        <asp:HyperLink NavigateUrl="~/ResultadosAmigos.aspx" ID="resAmigos" runat="server" CssClass="HistorialLink" Visible ="false">Resultados de mis amigos</asp:HyperLink>
        <br /><br />
        <asp:HyperLink NavigateUrl="~/TiempoDigital.aspx" ID="resDigital" runat="server" CssClass="HistorialLink" Visible ="true">Tu tiempo digital</asp:HyperLink>
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

             <script src="https://connect.facebook.net/es_MX/all.js"></script>
          <script>
              window.fbAsyncInit = function () {
                  FB.init({
                      appId: '779337262082870', // Set YOUR APP ID
                      status: true, // check login status
                      version: 'v2.3',
                      xfbml: false  // parse XFBML
                  });
              };

              window.onload = function () {
                  var offsetHeight = document.getElementById('alto').offsetHeight;
                  FB.Canvas.setSize({ height: offsetHeight + 40 });

              };
      </script>

	</body>
</html>