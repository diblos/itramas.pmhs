Public Class Frequency
    Dim _trip_id As String
    Public Property trip_id() As String
        Get
            Return Me._trip_id
        End Get
        Set(ByVal value As String)
            Me._trip_id = value
        End Set
    End Property

    Dim _start_time As String
    Public Property start_time() As String
        Get
            Return Me._start_time
        End Get
        Set(ByVal value As String)
            Me._start_time = value
        End Set
    End Property

    Dim _end_time As String
    Public Property end_time() As String
        Get
            Return Me._end_time
        End Get
        Set(ByVal value As String)
            Me._end_time = value
        End Set
    End Property

    Dim _headway_secs As String
    Public Property headway_secs() As String
        Get
            Return Me._headway_secs
        End Get
        Set(ByVal value As String)
            Me._headway_secs = value
        End Set
    End Property
End Class
