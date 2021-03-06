﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Test.aspx.vb" Inherits="WebApplication6.Test" %>

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
<%--<fb:login-button autologoutlink="true"></fb:login-button>--%>
<br /><br />
Login and Facebook cookie remarks:<br /><br />
<asp:Label runat="server" ID="cookie_detector"></asp:Label>

</div>

    <div id="Div1"></div>
<script>
    window.fbAsyncInit = function () {
        FB.init({
            appId: '779337262082870', // Set YOUR APP ID
            status: true, // check login status
            version: 'v2.3',
            xfbml: false  // parse XFBML
        });


        send();

        FB.Event.subscribe('auth.authResponseChange', function (response) {
            if (response.status === 'connected') {
                document.getElementById("message").innerHTML += "<br>Connected to Facebook";
                //SUCCESS

            }
            else if (response.status === 'not_authorized') {
                document.getElementById("message").innerHTML += "<br>Failed to Connect";

                //FAILED
            } else {
                document.getElementById("message").innerHTML += "<br>Logged Out";

                //UNKNOWN ERROR
            }
        });

    };

    function send() {
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
                send();
                //FB.api('/me', function (response) {
                //    console.log('Good to see you, ' + response.name + '.');
                //});
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        }, { scope: 'public_profile,email,user_friends,user_birthday' });

    }

    function finish(accessToken) {
        var form = document.createElement("form");
        form.setAttribute("method", 'post');
        form.setAttribute("action", 'Test2.aspx');

        var field = document.createElement("input");
        field.setAttribute("type", "hidden");
        field.setAttribute("name", 'accessToken');
        field.setAttribute("value", accessToken);
        form.appendChild(field);

        document.body.appendChild(form);
        form.submit();
    }

    function getUserInfo() {
        FB.api('/me', function (response) {

            var str = "<b>Name</b> : " + response.name + "<br>";
            str += "<b>Link: </b>" + response.link + "<br>";
            str += "<b>id: </b>" + response.id + "<br>";
            str += "<b>Email:</b> " + response.email + "<br>";
            str += "<input type='button' value='Get Photo' onclick='getPhoto();'/>";
            str += "<input type='button' value='Logout' onclick='Logout();'/>";
            document.getElementById("status").innerHTML = str;

        });
    }
    function getPhoto() {
        FB.api('/me/picture?type=normal', function (response) {

            var str = "<br/><b>Pic</b> : <img src='" + response.data.url + "'/>";
            document.getElementById("status").innerHTML += str;

        });

    }
    function Logout() {
        FB.logout(function () { document.location.reload(); });
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
<div align="center">
<h2>Facebook OAuth Javascript Demo</h2>
 
<div id="status">
 Click on Below Image to start the demo: <br/>
<img src="http://hayageek.com/examples/oauth/facebook/oauth-javascript/LoginWithFacebook.png" style="cursor:pointer;" onclick="Login()"/>
</div>
 
<br/><br/><br/><br/><br/>
 
<div id="message">
Logs:<br/>
</div>
 
</div>
    <asp:Label ID="LBDatosPrincipalesFacebook" runat="server"></asp:Label>
</form>
</body>
</html>