Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim _amigos As List(Of FacebookFriend) = Session("amigosConResultados")
            For Each a In _amigos
                amigos.Text &= a.uid & " " & a.username & " - "
            Next

        Catch ex As Exception
            LBerror.Text = ex.ToString

        End Try
    End Sub
End Class