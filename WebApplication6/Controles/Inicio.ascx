﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Inicio.ascx.vb" Inherits="WebApplication6.Inicio1" %>



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
        <img src="http://www.planwallpaper.com/static/images/a601cb579cc9a289bc51cd41d8bcf478_large.jpg" />

    </div>
    <%--<script src="https://connect.facebook.net/es_MX/all.js"></script>--%>

          <script>
              window.fbAsyncInit = function () {
                  FB.init({
                      appId: '779337262082870', // Set YOUR APP ID
                      status: true, // check login status
                      version: 'v2.3',
                      xfbml: false  // parse XFBML
                  });
                  var offsetHeight = document.getElementById('ver').offsetHeight;
                  FB.Canvas.setSize({ height: offsetHeight + 40 });
                  alert(offsetHeight);
              };

              // Load the SDK asynchronously
              (function (d, s, id) {
                  var js, fjs = d.getElementsByTagName(s)[0];
                  if (d.getElementById(id)) { return; }
                  js = d.createElement(s); js.id = id;
                  js.src = "//connect.facebook.net/es_LA/sdk.js";
                  fjs.parentNode.insertBefore(js, fjs);
              }(document, 'script', 'facebook-jssdk'));

      </script>

      