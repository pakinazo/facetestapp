﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test2.aspx.vb" Inherits="WebApplication6.Test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="fb-root"></div>
<script>
    window.fbAsyncInit = function () {
        FB.init({
            appId: '779337262082870', // Set YOUR APP ID
            channelUrl: 'http://hayageek.com/examples/oauth/facebook/oauth-javascript/channel.html', // Channel File
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });


        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                // the user is logged in and has authenticated your
                // app, and response.authResponse supplies
                // the user's ID, a valid access token, a signed
                // request, and the time the access token 
                // and signed request each expire
                var uid = response.authResponse.userID;
                var accessToken = response.authResponse.accessToken;
                //getUserInfo();
                finish(accessToken);
            } else if (response.status === 'not_authorized') {
                // the user is logged in to Facebook, s
                // but has not authenticated your app
              
            } else {
            
                // the user isn't logged in to Facebook.
            }
        });

    };

    function Permitir() {

        FB.login(function (response) {
            if (response.authResponse) {
                return true;
            } else {
                return false;
                console.log('User cancelled login or did not fully authorize.');
            }
        }, { scope: 'publish_actions' });

    }

    
    // Load the SDK asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));

</script>
    </div>

            <asp:Label ID="LBDatosPrincipalesFacebook" runat="server"></asp:Label>
        <br />
        <asp:Button ID="BAceptar" runat="server" OnClientClick="Permitir();" />
        <a href="Link.aspx">Ir al link</a>
    </form>
</body>
</html>
