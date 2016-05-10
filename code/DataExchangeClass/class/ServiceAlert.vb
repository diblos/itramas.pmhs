Public Class ServiceAlert
    Dim _security_key As String
    Public Property security_key() As String
        Get
            Return Me._security_key
        End Get
        Set(ByVal value As String)
            Me._security_key = value
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

    Dim _start_time As Date
    Public Property start_time() As Date
        Get
            Return Me._start_time
        End Get
        Set(ByVal value As Date)
            Me._start_time = value
        End Set
    End Property

    Dim _end_time As Date
    Public Property end_time() As Date
        Get
            Return Me._end_time
        End Get
        Set(ByVal value As Date)
            Me._end_time = value
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

    Dim _cause As String
    Public Property cause() As String
        Get
            Return Me._cause
        End Get
        Set(ByVal value As String)
            Me._cause = value
        End Set
    End Property

    Dim _effect
    Public Property effect() As String
        Get
            Return Me._effect
        End Get
        Set(ByVal value As String)
            Me._effect = value
        End Set
    End Property

End Class
