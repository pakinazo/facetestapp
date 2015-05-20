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
        LBDatosPrincipalesFacebook.Text += String.Format("id: {0}, fistname: {1}, lastname {2}, gender {3}, locale {4}, link {5}, username {6} ", itemzazo.id, itemzazo.first_name, itemzazo.last_name, itemzazo.gender, itemzazo.locale, itemzazo.link, itemzazo.username)

    End Sub
End Class