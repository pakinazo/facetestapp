Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim _amigos As System.Linq.IQueryable(Of FacebookFriend) = Session("amigosConResultados")
            For Each a In _amigos
                amigos.Text &= a.uid & " " & a.first_name & a.last_name & " - "
            Next

        Catch ex As Exception
            LBerror.Text = ex.ToString

        End Try
    End Sub
End Class