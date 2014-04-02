Public Class Friends

    Public Property data() As List(Of FacebookFriend)
        Get
            Return m_data
        End Get
        Set(value As List(Of FacebookFriend))
            m_data = value
        End Set
    End Property
    Private m_data As List(Of FacebookFriend)
End Class

