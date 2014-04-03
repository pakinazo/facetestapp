Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim _amigos As Dictionary(Of String, FacebookFriend) = Session("amigosConResultados")
            For Each a In _amigos
                amigos.Text &= a.Value.uid & " " & a.Value.first_name & a.Value.last_name & " - "
            Next

        Catch ex As Exception
            LBerror.Text = ex.ToString
        End Try
    End Sub
End Class