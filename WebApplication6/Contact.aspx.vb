Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim _amigos As List(Of FacebookFriend) = Session("amigosConResultados")
            For Each a In _amigos
                'amigos.Text &= a.uid & " " & a.username & " - <br/>"
                'Consulta para obtener el idResultado de cada uno
                'amigos.Text &= String.Format("<img src=""https://graph.facebook.com/{0}/picture?type=square"">   {1} <br/>", a.uid, a.username)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)
                amigos.Text &= String.Format("<tr><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}""><img src=""https://graph.facebook.com/{0}/picture?type=square""></a></td><td><a href=""HistorialDeCarreras.aspx?IdResultado={1}"">{2} {3} </a></td></tr>", a.uid, a.email, a.first_name, a.last_name)

                
            Next
        Catch ex As Exception
            LBerror.Text = ex.ToString

        End Try
    End Sub
End Class