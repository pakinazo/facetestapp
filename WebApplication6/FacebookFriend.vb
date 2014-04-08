Public Class FacebookFriend

    Public Property uid() As String
        Get
            Return m_uid
        End Get
        Set(value As String)
            m_uid = value
        End Set
    End Property
    Private m_uid As String

    Public Property username() As String
        Get
            Return m_username
        End Get
        Set(value As String)
            m_username = value
        End Set
    End Property
    Private m_username As String

    Public Property first_name() As String
        Get
            Return m_first_name
        End Get
        Set(value As String)
            m_first_name = value
        End Set
    End Property
    Private m_first_name As String

    Public Property last_name() As String
        Get
            Return m_last_name
        End Get
        Set(value As String)
            m_last_name = value
        End Set
    End Property
    Private m_last_name As String

    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(value As String)
            m_email = value
        End Set
    End Property
    Private m_email As String

End Class