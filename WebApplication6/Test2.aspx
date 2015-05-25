<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test2.aspx.vb" Inherits="WebApplication6.Test2" %>

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
            status: true, // check login status
            version: 'v2.3',
            xfbml: false  // parse XFBMLs
        });
        Permitir();
    };

    function Permitir() {

        FB.login(function (response) {
            if (response.authResponse) {
                 } else {
                 console.log('User cancelled login or did not fully authorize.');
            }
        }, { scope: 'publish_actions', auth_type: 'rerequest' });

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
    </div>

            <asp:Label ID="LBDatosPrincipalesFacebook" runat="server"></asp:Label>
        <br />
        <asp:Button ID="BAceptar" runat="server" text="Permitir" />
        <a href="Link.aspx?idEvento=302">Ir al link</a>

        <br />
        <asp:Button ID="BNotifica" runat="server" Text="Enviar Notificación" />
    </form>
</body>
</html>
