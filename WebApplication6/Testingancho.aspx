<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Testingancho.aspx.vb" Inherits="WebApplication6.Testingancho" %>

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
    </div>
    </form>
     </div>
    <script>
        var offsetHeight = document.getElementById('alto').offsetHeight;
        FB.Canvas.setSize({ height: offsetHeight });
    </script>
</body>
</html>
