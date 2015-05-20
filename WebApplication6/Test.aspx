<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WebApplication6.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml">
<head id="Head1" runat="server">
<title>Facebook JavaScript SDK Basic Example in ASP.NET 3.5</title>
</head>
<body>
<form id="form1" runat="server">
<div>
This is the simplest ASP.NET Facebook application that is using C#.<br />
Try logging in first to your Facebook account by clicking the login button.<br />
And then the Facebook cookies will be set.<br />
<br />
<fb:login-button autologoutlink="true"></fb:login-button>
<br /><br />
Login and Facebook cookie remarks:<br /><br />
<asp:Label runat="server" ID="cookie_detector"></asp:Label>

</div>
<div id="fb-root"></div>
<script src="https://connect.facebook.net/en_US/all.js"></script>
<script>
    FB.init({ appId: '779337262082870', status: true, cookie: true, xfbml: true});
    FB.Event.subscribe('auth.login', function(response) {
        window.location.reload();
    });
</script>
</form>
</body>
</html>