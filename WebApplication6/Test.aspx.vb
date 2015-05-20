﻿Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

'System.Text namespace is required for String Builder to work

Imports System.Text

'System.Security.Cryptography namespace is also required for MD5 function to work

Imports System.Security.Cryptography
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request("accessToken") Is Nothing Then
                Iniciar(Request("accessToken"))
            End If

        End If
    End Sub

    Private Sub Iniciar(ByVal access_token As String)


        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")

        Dim sURL As String
        sURL = String.Format("https://graph.facebook.com/?id={0}", usrRest.id)

        Dim wrGETURL As WebRequest
        wrGETURL = WebRequest.Create(sURL)
        Dim objStream As Stream
        objStream = wrGETURL.GetResponse.GetResponseStream()

        Dim objReader As New StreamReader(objStream)
        Dim strResponse As String = objReader.ReadToEnd()
        objReader.Close()
        LBDatosPrincipalesFacebook.Text += "respuesta2: " & strResponse & "!"

        'Dim item As Object = New JavaScriptSerializer().Deserialize(Of Object)(strResponse)
        'LBDatosPrincipalesFacebook.Text += String.Format("id: {0}, fistname: {1}, lastname {2}, gender {3}, locale {4}, link {5}, username {6} ", item.id, item.first_name, item.last_name, item.gender, item.locale, item.link, item.username)

        Dim itemzazo As FacebookData = New JavaScriptSerializer().Deserialize(Of FacebookData)(strResponse)
        LBDatosPrincipalesFacebook.Text += String.Format("id: {0}, fistname: {1}, lastname {2}, gender {3}, locale {4}, link {5}, username {6} ", itemzazo.id, itemzazo.first_name, itemzazo.last_name, itemzazo.gender, itemzazo.locale, itemzazo.link, itemzazo.username)

    End Sub
    ''Below is a variation of original code written by jrummell here: 
    ''http://stackoverflow.com/questions/3340436/what-is-the-c-equivalent-of-this-php-cookie-parsing-snippet
    ''It is rewritten a bit to work on this example projec and is the C# equivalent code for this Facebook PHP Code on getting cookies:
    ''
    ''<?php
    ''define('FACEBOOK_APP_ID', 'YOUR FACEBOOK APPLICATION ID');
    ''define('FACEBOOK_SECRET', 'YOUR FACEBOOK SECRET');
    ''function get_facebook_cookie($app_id, $application_secret) {
    ''$args = array();
    ''parse_str(trim($_COOKIE['fbs_' . $app_id], '"'), $args);
    ''ksort($args);
    ''$payload = ";
    ''foreach ($args as $key => $value) {
    ''if ($key != 'sig') {
    ''$payload .= $key . '=' . $value;
    ''}
    ''}
    ''if (md5($payload . $application_secret) != $args['sig']) {
    ''return null;
    ''}
    ''return $args;
    ''}
    ''$cookie = get_facebook_cookie(FACEBOOK_APP_ID, FACEBOOK_SECRET);
    ''?> 


    '    Private Function GetMd5Hash(input As String) As String
    '        Dim cryptoServiceProvider As New MD5CryptoServiceProvider()
    '        Dim bytes As Byte() = Encoding.[Default].GetBytes(input)
    '        Dim hash As Byte() = cryptoServiceProvider.ComputeHash(bytes)
    '        Dim s As New StringBuilder()
    '        For Each b As Byte In hash
    '            s.Append(b.ToString("x2"))
    '        Next
    '        Return s.ToString()
    '    End Function
    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '        'During loading of the page, the code below will be executed
    '        'Define the Facebook application ID and the Facebook Secret Key

    '    Dim facebook_application_id = "779337262082870"
    '    Dim facebook_secret_key = "0e4c136ef9121b45a272c8d43e77509b"

    '        'Retrieve Facebook cookie for a given application ID

    '        Dim cookie As HttpCookie = Request.Cookies("fbs_" + facebook_application_id)
    '        If cookie IsNot Nothing Then

    '            'Facebook Cookie is set and not null


    '            Dim pairs = From pair In cookie.Value.Trim(""""c, "").Split("&"c)
    '                        Let indexOfEquals = pair.IndexOf("="c)
    '                        Order By pair
    '                    Select New With { _
    '             .Key = pair.Substring(0, indexOfEquals).Trim(), _
    '             .Value = pair.Substring(indexOfEquals + 1).Trim() _
    '        }

    '            Dim cookieValues As IDictionary(Of String, String) = pairs.ToDictionary(Function(pair) pair.Key, Function(pair) Server.UrlDecode(pair.Value))

    '            Dim payload As New StringBuilder()
    '            For Each pair As KeyValuePair(Of String, String) In cookieValues
    '                Response.Write(pair.Key + ": " + pair.Value + "<br/>n")
    '                If pair.Key <> "sig" Then
    '                    payload.Append(pair.Key + "=" + pair.Value)
    '                End If
    '            Next
    '            Dim sig As String = cookieValues("sig")
    '            Dim hash As String = GetMd5Hash(payload.ToString & facebook_secret_key)
    '            If sig = hash Then

    '                'Compare if the hash generated is equal to the signature. 
    '                'If equal, the authentication is successful, and the user will //be successfully logged-in to Facebook


    '                'Output text to the browser, indicating that the cookie has been //set and the user has been successfully authenticated.
    '            cookie_detector.Text = "<font color='blue'><b>You have successfully login to a Facebook account and the cookie is set.<b></font>"
    '            End If
    '        Else

    '            'The user is still not logged-on and the cookie is the not set.

    '            cookie_detector.Text = "<font color='red'><b>You still have NOT logged-in to a Facebook account and the cookie is null.</b></font>"
    '        End If
    '    End Sub

End Class