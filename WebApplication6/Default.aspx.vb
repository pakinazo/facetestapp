Imports System.Net

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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

        Dim fb As New Facebook.FacebookClient
        Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = "779337262082870", .client_secret = "0e4c136ef9121b45a272c8d43e77509b", .grant_type = "client_credentials"})

        Dim fbclient As New Facebook.FacebookClient(result.access_token)

        Dim usrRest = fbclient.Get("me")
        LBNombre.Text = usrRest.first_name & "!"
    End Sub
End Class