Public Class Response
    Dim _security_key As String
    Public Property security_key() As String
        Get
            Return Me._security_key
        End Get
        Set(ByVal value As String)
            Me._security_key = value
        End Set
    End Property

    Dim _transaction_id As Int64
    Public Property transaction_id() As Int64
        Get
            Return Me._transaction_id
        End Get
        Set(ByVal value As Int64)
            Me._transaction_id = value
        End Set
    End Property

    Dim _status As Integer
    Public Property status() As Integer
        Get
            Return Me._status
        End Get
        Set(ByVal value As Integer)
            Me._status = value
        End Set
    End Property

    Dim _timestamp As Date
    Public Property timestamp() As Date
        Get
            Return Me._timestamp
        End Get
        Set(ByVal value As Date)
            Me._timestamp = value
        End Set
    End Property
End Class
