Public Class Share
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Dim Etiqueta As String = "https://www.facebook.com/dialog/share?" & _
                    "app_id=546495888778745" & _
                    "&display=popup" & _
                    "&href=http://pakinazocanvas.apphb.com/Contact.aspx" & _
                    "&redirect_uri=http://pakinazocanvas.apphb.com/Contact.aspx"
        ResponseHelper.Redirect(Etiqueta, "_blank", "")
    End Sub

End Class