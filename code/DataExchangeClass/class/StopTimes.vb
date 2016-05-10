Public Class StopTimes
    Dim _trip_id As String
    Public Property trip_id() As String
        Get
            Return Me._trip_id
        End Get
        Set(ByVal value As String)
            Me._trip_id = value
        End Set
    End Property

    Dim _arrival_time As String
    Public Property arrival_time() As String
        Get
            Return Me._arrival_time
        End Get
        Set(ByVal value As String)
            Me._arrival_time = value
        End Set
    End Property

    Dim _departure_time As String
    Public Property departure_time() As String
        Get
            Return Me._departure_time
        End Get
        Set(ByVal value As String)
            Me._departure_time = value
        End Set
    End Property

    Dim _stop_id As String
    Public Property stop_id() As String
        Get
            Return Me._stop_id
        End Get
        Set(ByVal value As String)
            Me._stop_id = value
        End Set
    End Property

    Dim _stop_sequence As String
    Public Property stop_sequence() As String
        Get
            Return Me._stop_sequence
        End Get
        Set(ByVal value As String)
            Me._stop_sequence = value
        End Set
    End Property

    Dim _stop_headsign As String
    Public Property stop_headsign() As String
        Get
            Return Me._stop_headsign
        End Get
        Set(ByVal value As String)
            Me._stop_headsign = value
        End Set
    End Property
End Class
