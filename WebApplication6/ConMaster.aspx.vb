﻿Public Class ConMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CambiarEncabezadoOGFacebook()
    End Sub

    Private Sub CambiarEncabezadoOGFacebook()
        Try
            Dim builder As UriBuilder = New UriBuilder(Request.Url.AbsoluteUri)
            builder.Port = -1
            Dim newUri As Uri = builder.Uri
            Dim q As String = "nada"
            If Request.QueryString("idRes") = 1 Then
                q = "uno"
            ElseIf Request.QueryString("idRes") = 2 Then
                q = "dos"
            ElseIf Request.QueryString("idRes") = 3 Then
                q = "tres"
            ElseIf Request.QueryString("idRes") = 4 Then
                q = "cuatro"

            End If


            Dim imageTag As String = "<meta property=""og:image"" content=""http://pakinazocanvas.apphb.com/Images/sidebyside_fyf.png""/>"
            Dim descriptionTag As String = String.Format("<meta property=""og:description"" content=""Comparación Side By Side durante la competencia:{0}""/>", q)
            Dim urlTag As String = String.Format("<meta property=""og:url"" content=""{0}""/>", newUri)
            Dim typeTag As String = "<meta property=""og:type"" content=""article"" />"
            Dim app_idTag As String = String.Format("<meta property=""fb:app_id"" content=""{0}""/>", ConfigurationManager.AppSettings("FB_Client_ID"))
            Dim titleTag As String = "<meta property=""og:title"" content=""PERIDOCAZAZO 2"" />"

            Dim facebookTags = imageTag & descriptionTag & urlTag & typeTag & app_idTag & titleTag
            LFacebookInfo.Text = facebookTags
            'DirectCast(Me.Page.Master.FindControl("OGFacebookMetaTags"), Literal).Text = 
        Catch ex As Exception

        End Try
    End Sub
End Class