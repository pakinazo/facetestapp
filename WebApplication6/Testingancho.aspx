﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Testingancho.aspx.vb" Inherits="WebApplication6.Testingancho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="alto">


    <form id="form1" runat="server">
    <div>
    adsadads
                <a href="OtroAlto.aspx">Otro alto</a>
        <a href="Default.aspx">Default</a>


        <img src="https://s.yimg.com/fz/api/res/1.2/BMY6py2YCJwqGLmenmI2BA--/YXBwaWQ9c3JjaGRkO2g9MTYwMDtxPTk1O3c9MjU2MA--/http://www.splendidwallpaper.com/wp-content/uploads/2012/11/high-resolution-wallpaper-nature-2560x1600.jpg" height="3000" width="300" />

    </div>
    </form>
     </div>
    <script>
        var offsetHeight = document.getElementById('alto').offsetHeight;
        FB.Canvas.setSize({ height: offsetHeight +40 });
    </script>
</body>
</html>
