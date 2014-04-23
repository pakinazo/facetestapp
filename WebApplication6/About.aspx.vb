Imports System.Web.Script.Serialization

Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim fb As New Facebook.FacebookClient
            Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = "779337262082870", .client_secret = "0e4c136ef9121b45a272c8d43e77509b", .grant_type = "client_credentials"})

            Dim fbclient As New Facebook.FacebookClient(result.access_token)

            Dim act As New Dictionary(Of String, Object)

            act("access_token") = result.access_token

            act("article") = "http://rubyatika.wordpress.com/2014/04/03/nak-rangsang-anak-bercakap/"
            
            If Not Session("username") Is Nothing Then
                Dim msg As String = String.Format("/{0}/primerCanvazazo:Registrar", Session("username"))
                Dim kk As Object = fbclient.Post(msg, act)
                respuesta.Text = kk.id

                Dim jsonSerialized As String = Newtonsoft.Json.JsonConvert.SerializeObject(kk)
                'Dim datos = New JavaScriptSerializer().Deserialize(Of Object)(jsonSerialized)

                respuesta.Text &= " " & jsonSerialized

                'respuesta.Text &= " " & datos.from.name
            End If
            

        Catch ex As Exception
            respuesta.Text &= ex.Message.ToString
        End Try
    End Sub
End Class