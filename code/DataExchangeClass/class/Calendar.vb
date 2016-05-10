Public Class Calendar
    Dim _service_id As String
    Public Property service_id() As String
        Get
            Return Me._service_id
        End Get
        Set(ByVal value As String)
            Me._service_id = value
        End Set
    End Property

    Dim _Monday As String
    Public Property Monday() As String
        Get
            Return Me._Monday
        End Get
        Set(ByVal value As String)
            Me._Monday = value
        End Set
    End Property

    Dim _Tuesday As String
    Public Property Tuesday() As String
        Get
            Return Me._Tuesday
        End Get
        Set(ByVal value As String)
            Me._Tuesday = value
        End Set
    End Property

    Dim _Wednesday As String
    Public Property Wednesday() As String
        Get
            Return Me._Wednesday
        End Get
        Set(ByVal value As String)
            Me._Wednesday = value
        End Set
    End Property

    Dim _Thursday As String
    Public Property Thursday() As String
        Get
            Return Me._Thursday
        End Get
        Set(ByVal value As String)
            Me._Thursday = value
        End Set
    End Property

    Dim _Friday As String
    Public Property Friday() As String
        Get
            Return Me._Friday
        End Get
        Set(ByVal value As String)
            Me._Friday = value
        End Set
    End Property

    Dim _Saturday As String
    Public Property Saturday() As String
        Get
            Return Me._Saturday
        End Get
        Set(ByVal value As String)
            Me._Saturday = value
        End Set
    End Property

    Dim _Sunday As String
    Public Property Sunday() As String
        Get
            Return Me._Sunday
        End Get
        Set(ByVal value As String)
            Me._Sunday = value
        End Set
    End Property

    Dim _start_date As String
    Public Property start_date() As String
        Get
            Return Me._start_date
        End Get
        Set(ByVal value As String)
            Me._start_date = value
        End Set
    End Property

    Dim _end_date As String
    Public Property end_date() As String
        Get
            Return Me._end_date
        End Get
        Set(ByVal value As String)
            Me._end_date = value
        End Set
    End Property
End Class
