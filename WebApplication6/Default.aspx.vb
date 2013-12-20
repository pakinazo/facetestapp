Imports System.Net

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' hazalgo()
        If Not Page.IsPostBack Then
            primero()
        End If

    End Sub

    Private Sub primero()
        Dim code As String = Request("code")
        Dim state As String = Request("state")
        If code <> "" And state = Session.SessionID Then
            getUserData(code)
        Else
            If Not Request.Url.ToString.Contains("WebResource.axd") And Not Request.Url.ToString.Contains("ScriptResource.axd") Then
                Session("myurl") = Request.Url.ToString
                Session("inscripcionURLRegreso") = Request.Url.AbsoluteUri

                Dim myURL As String = Session("myurl")
                Dim FbURL As String = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope=user_birthday,email,user_hometown,publish_actions", "779337262082870", "https://pakinazocanvas.apphb.com/default.aspx", Session.SessionID)

                Response.Redirect(FbURL)
            End If
        End If


    End Sub
   
    Private Sub getUserData(ByVal code As String)
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", "779337262082870", "https://pakinazocanvas.apphb.com/default.aspx", "0e4c136ef9121b45a272c8d43e77509b", code)

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")


        LBNombre.Text = usrRest.first_name
        LBpicture.Text = "http://graph.facebook.com/" & usrRest.username & "/picture?width=180"
        'LBpicture.Text = "<img src=""" & usrRest.pic_big_with_logo & """/>"
    End Sub

    Private Sub hazalgo()
        'Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={2}&code={3}", "294444543985836", MyURL, "0757f6a496872d0d3c02087c183d0c2f", code)

        ' Dim fbWeb As New WebClient
        ' Dim result As String = fbWeb.DownloadString(fbURL)

        '  Dim access_token As String = String.Empty
        ' Dim expires As Double

        ' For Each s As String In result.Split("&")
        'If s.Contains("access_token") Then
        'access_token = s.Replace("access_token=", "")
        ' Else
        ' expires = s.Replace("expires=", "")
        'End If
        'Next

        'Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim code As String = Request("code")
        Dim state As String = Request("state")
        If code <> "" And state = Session.SessionID Then
            getUserData(code)
        Else
            Session("myurl") = Request.Url.ToString
            Dim myURL As String = Session("myurl")
            Dim FbURL As String = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope=user_birthday,email,user_hometown,publish_actions", "294444543985836", myURL, Session.SessionID)
            Response.Redirect(FbURL)
        End If




        '   Dim fb As New Facebook.FacebookClient
        '   Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = "779337262082870", .client_secret = "0e4c136ef9121b45a272c8d43e77509b", .grant_type = "client_credentials"})

        '    Dim fbclient As New Facebook.FacebookClient(result.access_token)

        '   Dim usrRest = fbclient.Get("me")
        '   LBNombre.Text = usrRest.first_name & "!"
    End Sub

    Private Sub inicia()
        Dim fb = New Facebook.FacebookClient("access_token")
        Dim result = DirectCast(fb.[Get]("/me"), IDictionary(Of String, Object))
        Dim fbname = DirectCast(result("name"), String)
    End Sub

    Private Sub getUserDatax(ByVal code As String)
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", "779337262082870", MyURL, "0e4c136ef9121b45a272c8d43e77509b", code)

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")
    End Sub

    Private Sub getUserData2()
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials", "779337262082870", "0e4c136ef9121b45a272c8d43e77509b")

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")
    End Sub
End Class