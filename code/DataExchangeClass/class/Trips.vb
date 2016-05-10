Public Class Trips
    Dim _route_id As String
    Public Property route_id() As String
        Get
            Return Me._route_id
        End Get
        Set(ByVal value As String)
            Me._route_id = value
        End Set
    End Property

    Dim _service_id As String
    Public Property service_id() As String
        Get
            Return Me._service_id
        End Get
        Set(ByVal value As String)
            Me._service_id = value
        End Set
    End Property

    Dim _trip_id As String
    Public Property trip_id() As String
        Get
            Return Me._trip_id
        End Get
        Set(ByVal value As String)
            Me._trip_id = value
        End Set
    End Property

    Dim _trip_headsign As String
    Public Property trip_headsign() As String
        Get
            Return Me._trip_headsign
        End Get
        Set(ByVal value As String)
            Me._trip_headsign = value
        End Set
    End Property

    Dim _trip_short_name As String
    Public Property trip_short_name() As String
        Get
            Return Me._trip_short_name
        End Get
        Set(ByVal value As String)
            Me._trip_short_name = value
        End Set
    End Property

    Dim _direction_id As String
    Public Property direction_id() As String
        Get
            Return Me._direction_id
        End Get
        Set(ByVal value As String)
            Me._direction_id = value
        End Set
    End Property

    Dim _shape_id As String
    Public Property shape_id() As String
        Get
            Return Me._shape_id
        End Get
        Set(ByVal value As String)
            Me._shape_id = value
        End Set
    End Property

    Dim _trip_desc As String
    Public Property trip_desc() As String
        Get
            Return Me._trip_desc
        End Get
        Set(ByVal value As String)
            Me._trip_desc = value
        End Set
    End Property
End Class
