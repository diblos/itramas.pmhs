Public Class Routes
    Dim _route_id As String
    Public Property route_id() As String
        Get
            Return Me._route_id
        End Get
        Set(ByVal value As String)
            Me._route_id = value
        End Set
    End Property

    Dim _route_short_name As String
    Public Property route_short_name() As String
        Get
            Return Me._route_short_name
        End Get
        Set(ByVal value As String)
            Me._route_short_name = value
        End Set
    End Property

    Dim _route_long_name As String
    Public Property route_long_name() As String
        Get
            Return Me._route_long_name
        End Get
        Set(ByVal value As String)
            Me._route_long_name = value
        End Set
    End Property

    Dim _route_desc As String
    Public Property route_desc() As String
        Get
            Return Me._route_desc
        End Get
        Set(ByVal value As String)
            Me._route_desc = value
        End Set
    End Property

    Dim _route_type As String
    Public Property route_type() As String
        Get
            Return Me._route_type
        End Get
        Set(ByVal value As String)
            Me._route_type = value
        End Set
    End Property
End Class
