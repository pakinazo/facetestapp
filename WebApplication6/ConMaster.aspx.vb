Public Class ConMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CambiarEncabezadoOGFacebook()
    End Sub

    Private Sub CambiarEncabezadoOGFacebook()
        Try
            Dim builder As UriBuilder = New UriBuilder(Request.Url.AbsoluteUri)
            builder.Port = -1
            Dim newUri As Uri = builder.Uri

            Dim imageTag As String = "<meta property=""og:image"" content=""http://pakinazocanvas.apphb.com/Images/mapa.png""/>"
            Dim descriptionTag As String = "<meta property=""og:description"" content=""Comparación Side By Side durante la competencia""/>"
            Dim urlTag As String = String.Format("<meta property=""og:url"" content=""{0}""/>", newUri)
            Dim typeTag As String = "<meta property=""og:type"" content=""article"" />"
            Dim app_idTag As String = String.Format("<meta property=""fb:app_id"" content=""{0}""/>", ConfigurationManager.AppSettings("FB_Client_ID"))
            Dim titleTag As String = "<meta property=""og:title"" content=""PERIDOCAZAZO"" />"

            Dim facebookTags = imageTag & descriptionTag & urlTag & typeTag & app_idTag & titleTag
            DirectCast(Me.Page.Master.FindControl("OGFacebookMetaTags"), Literal).Text = facebookTags
        Catch ex As Exception

        End Try
    End Sub
End Class