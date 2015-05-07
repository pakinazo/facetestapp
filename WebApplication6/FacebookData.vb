Public Class FacebookData
    Public Property id As String
    Public Property first_name As String
    Public Property last_name As String
    Public Property gender As String
    Public Property link As String
    Public Property locale As String
    Public Property name As String
    Public Property username As String
End Class


Public Class FacebookDataList

    Public Property data() As List(Of FacebookData)
        Get
            Return m_data
        End Get
        Set(value As List(Of FacebookData))
            m_data = value
        End Set
    End Property
    Private m_data As List(Of FacebookData)
End Class
