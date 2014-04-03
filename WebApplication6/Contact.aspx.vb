Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim _amigos As Dictionary(Of String, FacebookFriend) = Session("amigosConResultados")
        For Each a In _amigos
            amigos.Text &= a.Value.uid & " " & a.Value.first_name & a.Value.last_name & " - "
        Next

    End Sub
End Class