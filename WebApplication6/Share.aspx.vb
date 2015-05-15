Public Class Share
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Dim Etiqueta As String = "https://www.facebook.com/dialog/share?" & _
                    "app_id=546495888778745" & _
                    "&display=popup" & _
                    "&href=http://www.lanacion.com.ar/edicion-impresa/suplementos/revista" & _
                    "&redirect_uri=http://www.lanacion.com.ar/edicion-impresa/suplementos/revista"
        ResponseHelper.Redirect(Etiqueta, "_blank", "")
    End Sub

End Class