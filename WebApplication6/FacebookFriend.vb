﻿Public Class FacebookFriend

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
End Class