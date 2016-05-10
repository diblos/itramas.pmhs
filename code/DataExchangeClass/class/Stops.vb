Public Class Stops 'Bus Stop
    Dim _stop_id As String
    Public Property stop_id() As String
        Get
            Return Me._stop_id
        End Get
        Set(ByVal value As String)
            Me._stop_id = value
        End Set
    End Property

    Dim _stop_code As String
    Public Property stop_code() As String
        Get
            Return Me._stop_code
        End Get
        Set(ByVal value As String)
            Me._stop_code = value
        End Set
    End Property

    Dim _stop_name As String
    Public Property stop_name() As String
        Get
            Return Me._stop_name
        End Get
        Set(ByVal value As String)
            Me._stop_name = value
        End Set
    End Property

    Dim _stop_desc
    Public Property stop_desc() As String
        Get
            Return Me._stop_desc
        End Get
        Set(ByVal value As String)
            Me._stop_desc = value
        End Set
    End Property

    Dim _stop_lat As String
    Public Property stop_lat() As String
        Get
            Return Me._stop_lat
        End Get
        Set(ByVal value As String)
            Me._stop_lat = value
        End Set
    End Property

    Dim _stop_lon As String
    Public Property stop_lon() As String
        Get
            Return Me._stop_lon
        End Get
        Set(ByVal value As String)
            Me._stop_lon = value
        End Set
    End Property

    Dim _zone_id As String
    Public Property zone_id() As String
        Get
            Return Me._zone_id
        End Get
        Set(ByVal value As String)
            Me._zone_id = value
        End Set
    End Property
End Class
