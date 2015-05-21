Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class Test2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request("accessToken") Is Nothing Or Not Session("accessToken") Is Nothing Then
                If Session("accessToken") Is Nothing Then
                    Session("accessToken") = Request("accessToken")
                End If

                Iniciar(Session("accessToken"))
            Else
                Response.Redirect("Test.aspx")
            End If

        End If
    End Sub

    Private Sub Iniciar(ByVal access_token As String)


        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")

        Dim sURL As String
        sURL = String.Format("https://graph.facebook.com/?id={0}", usrRest.id)

        Dim wrGETURL As WebRequest
        wrGETURL = WebRequest.Create(sURL)
        Dim objStream As Stream
        objStream = wrGETURL.GetResponse.GetResponseStream()

        Dim objReader As New StreamReader(objStream)
        Dim strResponse As String = objReader.ReadToEnd()
        objReader.Close()
        LBDatosPrincipalesFacebook.Text += "respuesta2: " & strResponse & "!"

        'Dim item As Object = New JavaScriptSerializer().Deserialize(Of Object)(strResponse)
        'LBDatosPrincipalesFacebook.Text += String.Format("id: {0}, fistname: {1}, lastname {2}, gender {3}, locale {4}, link {5}, username {6} ", item.id, item.first_name, item.last_name, item.gender, item.locale, item.link, item.username)

        Dim itemzazo As FacebookData = New JavaScriptSerializer().Deserialize(Of FacebookData)(strResponse)
        LBDatosPrincipalesFacebook.Text += String.Format("id: {0}, fistname: {1}, lastname {2}", itemzazo.id, itemzazo.first_name, itemzazo.last_name)

    End Sub

    Protected Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        LBDatosPrincipalesFacebook.Text &= " *** Permitido ***"
    End Sub

    Protected Sub BNotifica_Click(sender As Object, e As EventArgs) Handles BNotifica.Click
        EnviarNotificacion()
    End Sub

    Private Sub EnviarNotificacion()
        Try

            Dim fb As New Facebook.FacebookClient
            
            Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = ConfigurationManager.AppSettings("FB_Client_ID"), .client_secret = ConfigurationManager.AppSettings("FB_Client_secret"), .grant_type = "client_credentials"})

            Dim fbclient As New Facebook.FacebookClient(result.access_token)

            Dim act As New Dictionary(Of String, Object)

            'Enviar Notificacion ejemplo:
            'POST /{recipient_userid}/notifications?
            'access_token= … & 
            'href= … & 
            'template=You have people waiting to play with you, play now!
            Dim UrlNotificar As String = ""
            Dim txtNotificación As String = "Buen día @[100002078392441] debido a cambios en facebook debes confirmar tu número de competidor en tu Tiempo Digital, disculpa las molestias"
            Dim idNotificar As String = "100002078392441"
            Dim msg As String = String.Format("/{0}/notifications?access_token={1}&href={2}&template={3}", idNotificar, result.access_token, UrlNotificar, txtNotificación)
            Dim kk As Object = fbclient.Post(msg)
            Try
                LBDatosPrincipalesFacebook.Text &= "respuesta: " & kk.success
            Catch ex As Exception

            End Try
        Catch

        End Try

    End Sub
End Class