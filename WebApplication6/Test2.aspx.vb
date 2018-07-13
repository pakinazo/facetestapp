Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Dynamic

Public Class Test2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try

                If Not Request("accessToken") Is Nothing Or Not Session("accessToken") Is Nothing Then
                    If Session("accessToken") Is Nothing Then
                        Session("accessToken") = Request("accessToken")
                    End If

                    Iniciar(Session("accessToken"))
                Else
                    Response.Redirect("Test.aspx")
                End If
            Catch ex As Exception
                LError.Text = "error1 " & ex.Message.ToString
            End Try
        End If
    End Sub

    Private Sub Iniciar(ByVal access_token As String)

        Try

    
        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")

        Dim sURL As String
        sURL = String.Format("https://graph.facebook.com/?id={0}", usrRest.id)
        Session("FBID") = usrRest.id
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
        Catch ex As Exception
            LError.Text = "error2 " & ex.Message.ToString
        End Try
    End Sub

    Protected Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        LBDatosPrincipalesFacebook.Text &= " *** Permitido ***"
        Dim xlogo As String = String.Empty
        Dim tempLogo As String = "images/mmclubhuilango2015.jpg"
        Dim XARRIMG As String() = tempLogo.Split("/")

        Select Case XARRIMG.Count
            Case 0
                xlogo = tempLogo
            Case 2
                xlogo = tempLogo.Split("/")(2)
            Case Is > 2
                xlogo = String.Empty
                For i = 2 To (XARRIMG.Count - 1) Step 1
                    xlogo = xlogo & "/" & XARRIMG(i)
                Next i
        End Select
        Dim xrutaImagen As String = System.Configuration.ConfigurationManager.AppSettings.Item("RutaImagenes")
        Dim _logoFinal As String = xrutaImagen & xlogo

        sendFacebook(Session("FBID"), "", "", "https://apps.facebook.com/primercanvazazo", "", "Logré realizar el tiempo estimado en el evento: Maratón de la Ciudad de México, con el número 11", "http://registro.tiempooficial.com/images/eventos/mmclubhuilango2015.jpg")
    End Sub

    Protected Sub BNotifica_Click(sender As Object, e As EventArgs) Handles BNotifica.Click
        EnviarNotificacion()
    End Sub

    Private Sub EnviarNotificacion()
        Try

            Dim fb As New Facebook.FacebookClient

            Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = ConfigurationManager.AppSettings("FB_Client_ID"), .client_secret = ConfigurationManager.AppSettings("FB_Client_secret"), .grant_type = "client_credentials"})

            Dim fbclient As New Facebook.FacebookClient(result.access_token)

            'Enviar Notificacion ejemplo:
            'POST /{recipient_userid}/notifications?
            'access_token= … & 
            'href= … & 
            'template=You have people waiting to play with you, play now!
            Dim UrlNotificar As String = "https://apps.facebook.com/primercanvazazo"
            Dim txtNotificación As String = "Buen día @[100002078392441] debido a cambios en facebook debes confirmar tu número de competidor en tu Tiempo Digital, aceptando publicar en tu muro"
            Dim idNotificar As String = "100002078392441"
    

            Dim msg As String = String.Format("/{0}/notifications", idNotificar)

            Dim args As New Dictionary(Of String, Object)
            args("access_token") = result.access_token
            args("href") = ""
            args("template") = txtNotificación
            Dim req As Object = fbclient.Post(msg, args)

            Try
                LBDatosPrincipalesFacebook.Text &= "respuesta: " & req.success
            Catch ex As Exception
                LBDatosPrincipalesFacebook.Text &= ",e1: " & ex.Message.ToString
            End Try
        Catch ex As Exception
            LBDatosPrincipalesFacebook.Text &= ",e2: " & ex.Message.ToString
        End Try

    End Sub


    Public Function sendFacebook(ByVal Usuario As String, ByVal Accion As String, ByVal Carrera As String, ByVal CarreraURL As String, ByVal Categoria As String, ByVal Mensaje As String, ByVal urlImagen As String) As Boolean
        Dim fb As New Facebook.FacebookClient

        Dim _app_id As String = System.Configuration.ConfigurationManager.AppSettings.Item("FB_Client_ID")
        Dim _secret As String = System.Configuration.ConfigurationManager.AppSettings.Item("FB_Client_secret")

        Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = _app_id, .client_secret = _secret, .grant_type = "client_credentials"})

        Dim fbclient As New Facebook.FacebookClient(result.access_token)

        Dim vars As New Dictionary(Of String, Object)

        vars("message") = Accion
        vars("name") = Carrera
        vars("caption") = Categoria
        vars("description") = Mensaje
        vars("picture") = urlImagen
        vars("link") = CarreraURL
        vars("actions") = New With {.name = "A Tiempo", .link = "https://apps.facebook.com/primercanvazazo"}

        Try
            Dim msg As String = String.Format("/{0}/feed", Usuario)
            Dim kk As Object = fbclient.Post(msg, vars)
            Return True
        Catch EX As Exception
            LBDatosPrincipalesFacebook.Text = "EX: " & EX.Message.ToString
            Return False
        End Try
    End Function
End Class