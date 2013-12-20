Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim access_token = "f24caa53a309a170aa35609011176b6b"
        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")
        LBNombre.Text = usrRest.first_name & "!"
    End Sub
End Class