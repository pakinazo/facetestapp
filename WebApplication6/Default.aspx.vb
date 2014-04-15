'Option Strict Off
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization


Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' hazalgo()
        If Not Page.IsPostBack Then
            primero()
        End If

    End Sub


    Private Sub primero()
        Dim code As String = Request("code")
        Dim state As String = Request("state")

        Try


            Session("myurl") = Request.Url.ToString
            If code <> "" And state = Session.SessionID Then
                getUserData(code)
            Else
                Session("myurl") = Request.Url.ToString
                'Session("inscripcionURLRegreso") = Request.Url.AbsoluteUri

                'Dim myURL As String = Session("myurl")
                Dim FbURL As String = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope=user_birthday,email,user_hometown,publish_actions", "779337262082870", "https://apps.facebook.com/primercanvazazo", Session.SessionID)

                Response.Write("<script language='javascript'>top.location.href='" & FbURL & "'</script>")


            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub getUserData(ByVal code As String)
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", "779337262082870", "https://apps.facebook.com/primercanvazazo", "0e4c136ef9121b45a272c8d43e77509b", code)

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")


        LBNombre.Text = usrRest.first_name & " mail: " & usrRest.email
        LBNombre.Text += "access token=" & access_token
        LBpicture.Text = "<img src=""https://graph.facebook.com/" & usrRest.username & "/picture?type=large""/>"
        Dim code2 As String = Request("code")
        Dim state2 As String = Request("state")
        Inscribete.Text = "<a href=""http://registro.tiempooficial.com/default.aspx?evento=26&facebook=on"" target=""_blank"">¡Inscríbete!</a>"
        'LBpicture.Text = "<img src=""" & usrRest.pic_big_with_logo & """/>"
        LabelDatosFace.Text = "Aquí van los datos: "
        Dim inputString As String = String.Format("{0},{1},{2},{3},{4}", usrRest.username, usrRest.name, usrRest.id, usrRest.email, usrRest.birthday)
        LabelDatosFace.Text += "--" & inputString & "--"

        'Dim fql_multiquery_url = "https://graph.facebook.com/fql?q=SELECT%20uid2%20FROM%20friend%20WHERE%20uid1=me()&access_token=" & access_token

        ''Dim fql_multiquery_url = "https://graph.facebook.com/fql?q={""all+friends"":""SELECT+uid2+FROM+friend+WHERE+uid1=me()"",my+name"":""SELECT+name+FROM+user+WHERE+uid=me()""}&" + access_token
        'Dim fql_multiquery_result = file_get_contents(fql_multiquery_url)
        'Dim fql_multiquery_obj = Newtonsoft.Json.JsonConvert.SerializeObject(fql_multiquery_result, Newtonsoft.Json.Formatting.Indented)
        'LabelDatosFace.Text += fql_multiquery_url
        'LabelDatosFace.Text += "(" & fql_multiquery_obj & ")"

        Try
            Dim resultado As Object = fbClient.Get("fql",
            New With {.q = "SELECT uid, username, first_name, last_name FROM user " & _
                         "WHERE is_app_user = 1 AND uid IN (SELECT uid2 FROM friend WHERE uid1 = me())"})
            'New With {.q = "SELECT uid, username, first_name, last_name FROM user " & _
            '              "WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = me())"})


            Dim datos As String = Newtonsoft.Json.JsonConvert.SerializeObject(resultado)
            LabelDatosFace.Text += datos
            Dim facebookFriends As Friends = New JavaScriptSerializer().Deserialize(Of Friends)(datos)
            For Each item In facebookFriends.data
                LabelDatosFace.Text += String.Format("id: {0}, name: {1}", item.uid, item.username, item.first_name, item.last_name)
                Console.WriteLine("id: {0}, name: {1}", item.uid, item.username)
            Next



            Dim amigos =
                From p In facebookFriends.data
                Where p.uid = "1534584407"
                Select p.uid, p.username

            Dim friendsWithResults =
                From p In facebookFriends.data
                Where (From o In facebookFriends.data
                        Select o.uid).Contains(p.uid)
                Select p.uid, p.username, p.first_name, p.last_name, p.email

            Dim fList As New List(Of FacebookFriend)

            For Each a In friendsWithResults
                Dim ffriend As New FacebookFriend
                ffriend.uid = a.uid
                ffriend.username = a.username
                ffriend.first_name = a.first_name
                ffriend.last_name = a.last_name
                ffriend.email = a.email
                fList.Add(ffriend)
            Next


            Session("amigosConResultados") = fList



            For Each d In amigos
                LabelDatosFace.Text += "***" & d.uid & "-" & d.username & "***"
            Next

            For Each d In friendsWithResults
                LabelDatosFace.Text += "**TODOS:" & d.uid & "-" & d.username & ":TODOS**"
            Next

            ''Dim ressult = Newtonsoft.Json.JsonConvert.DeserializeObject(datos)
            ''LabelDatosFace.Text += datos
            'Dim datosjson = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of obJson))(datos)
            LabelDatosFace.Text += "algo"
            'For Each a As KeyValuePair(Of String, Object) In ressult.data
            '    Dim id = a.Key
            '    LabelDatosFace.Text += "id :" & id & "."
            '    Dim uid = a.Value.uid.ToString
            '    LabelDatosFace.Text += "uid :" & uid & "."
            'Next

            '' Dim resulta As List(Of obJson) = Newtonsoft.Json.JsonConvert.DeserializeObject(datos)
            ''LabelDatosFace.Text += "count :" & resulta.Count & "."
            'For Each a In resulta.data
            '    Dim x = a.uid
            '    LabelDatosFace.Text += "count :" & x & "."
            'Next

            ''LabelDatosFace.Text += "text :" & datos & "."
            'For Each res In datos
            '    LabelDatosFace.Text += "*" & res.uid & "*"
            'Next
        Catch ex As Exception
            LabelDatosFace.Text += ex.Message.ToString
        End Try



        Try
            Dim wrtr As StreamWriter = New StreamWriter(Server.MapPath("~/users.txt"), True)
            inputString = String.Format("{0},{1},{2},{3},{4}", usrRest.username, usrRest.name, usrRest.id, usrRest.email, usrRest.birthday)
            wrtr.WriteLine(inputString)
            wrtr.Close()
            LabelDatosFace.Text += " escrito."
        Catch ex As Exception

        End Try
    End Sub
    Protected Function file_get_contents(ByVal fileName As String) As String

        Dim sContents As String = String.Empty
        Dim mee As String = String.Empty

        Try

            If (fileName.ToLower().IndexOf("http:") > -1) Then
                ' URL 
                Dim wc As System.Net.WebClient = New System.Net.WebClient()
                Dim response As Byte() = wc.DownloadData(fileName)
                sContents = System.Text.Encoding.ASCII.GetString(response)


            Else
                ' Regular Filename 
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(fileName)
                sContents = sr.ReadToEnd()
                sr.Close()
            End If
        Catch ex As Exception
            sContents = "unable to connect to server "
        End Try


        Return sContents
    End Function

    Private Sub hazalgo()
        'Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={2}&code={3}", "294444543985836", MyURL, "0757f6a496872d0d3c02087c183d0c2f", code)

        ' Dim fbWeb As New WebClient
        ' Dim result As String = fbWeb.DownloadString(fbURL)

        '  Dim access_token As String = String.Empty
        ' Dim expires As Double

        ' For Each s As String In result.Split("&")
        'If s.Contains("access_token") Then
        'access_token = s.Replace("access_token=", "")
        ' Else
        ' expires = s.Replace("expires=", "")
        'End If
        'Next

        'Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim code As String = Request("code")
        Dim state As String = Request("state")
        If code <> "" And state = Session.SessionID Then
            getUserData(code)
        Else
            Session("myurl") = Request.Url.ToString
            Dim myURL As String = Session("myurl")
            Dim FbURL As String = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope=user_birthday,email,user_hometown,publish_actions", "294444543985836", myURL, Session.SessionID)
            Response.Redirect(FbURL)
        End If




        '   Dim fb As New Facebook.FacebookClient
        '   Dim result As Object = fb.Get("oauth/access_token", New With {.client_id = "779337262082870", .client_secret = "0e4c136ef9121b45a272c8d43e77509b", .grant_type = "client_credentials"})

        '    Dim fbclient As New Facebook.FacebookClient(result.access_token)

        '   Dim usrRest = fbclient.Get("me")
        '   LBNombre.Text = usrRest.first_name & "!"
    End Sub

    Private Sub inicia()
        Dim fb = New Facebook.FacebookClient("access_token")
        Dim result = DirectCast(fb.[Get]("/me"), IDictionary(Of String, Object))
        Dim fbname = DirectCast(result("name"), String)
    End Sub

    Private Sub getUserDatax(ByVal code As String)
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", "779337262082870", MyURL, "0e4c136ef9121b45a272c8d43e77509b", code)

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")


    End Sub

    Private Sub getUserData2()
        Dim MyURL As String = Session("myurl")
        Dim fbURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials", "779337262082870", "0e4c136ef9121b45a272c8d43e77509b")

        Dim fbWeb As New WebClient
        Dim result As String = fbWeb.DownloadString(fbURL)

        Dim access_token As String = String.Empty
        Dim expires As Double

        For Each s As String In result.Split("&")
            If s.Contains("access_token") Then
                access_token = s.Replace("access_token=", "")
            Else
                expires = s.Replace("expires=", "")
            End If
        Next

        Dim fbClient As New Facebook.FacebookClient(access_token)
        Dim usrRest = fbClient.Get("me")
    End Sub
End Class

Class obJson
    Public Property data As List(Of valores)
    'public IDictionary(Of string, valores)  
End Class

Class valores
    Public Property uid As String
    'public long pageid { get; set; }
    'public string title { get; set; }
End Class

