<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Share.aspx.vb" Inherits="WebApplication6.Share" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v2.3";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
    <form id="form1" runat="server">
    <div>
    <div class="fb-like" data-href="http://pakinazocanvas.apphb.com/Contact.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    </div>
    </form>
</body>
</html>
