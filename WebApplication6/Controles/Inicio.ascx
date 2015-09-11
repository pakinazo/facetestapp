<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Inicio.ascx.vb" Inherits="WebApplication6.Inicio1" %>



    <div id="ver">

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

    </div>
    <%--<script src="https://connect.facebook.net/es_MX/all.js"></script>--%>

    <script src="https://connect.facebook.net/es_MX/all.js"></script>
          <script>

        
                  FB.init({
                      appId: '779337262082870', // Set YOUR APP ID
                      status: true, // check login status
                      version: 'v2.3',
                      xfbml: false  // parse XFBML
                  });
                
  
                  window.onload = function () {
                      var offsetHeight = document.getElementById('ver').offsetHeight;
                      FB.Canvas.setSize({ height: offsetHeight + 40 });
                      alert(offsetHeight);
                  };
      </script>

      