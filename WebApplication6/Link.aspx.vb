Public Class Link
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _idevento As Integer = Integer.Parse(Request.QueryString("IdEvento"))
        LQUERY.Text = _idevento
    End Sub

End Class