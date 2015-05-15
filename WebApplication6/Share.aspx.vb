Public Class Share
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Dim Etiqueta As String = "https://www.facebook.com/dialog/share?" & _
                    "app_id=145634995501895" & _
                    "&display=popup" & _
                    "&href=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2F" & _
                    "&redirect_uri=https%3A%2F%2Fdevelopers.facebook.com%2Ftools%2Fexplorer"
        ResponseHelper.Redirect(Etiqueta, "_blank", "")
    End Sub

End Class