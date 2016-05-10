Public Class TripUpdates
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

    Dim _stop_sequence As Integer
    Public Property stop_sequence() As Integer
        Get
            Return Me._stop_sequence
        End Get
        Set(ByVal value As Integer)
            Me._stop_sequence = value
        End Set
    End Property

    Dim _arrival As Date
    Public Property arrival() As Date
        Get
            Return Me._arrival
        End Get
        Set(ByVal value As Date)
            Me._arrival = value
        End Set
    End Property

    Dim _vehicle_reg_no As String
    Public Property vehicle_reg_no() As String
        Get
            Return Me._vehicle_reg_no
        End Get
        Set(ByVal value As String)
            Me._vehicle_reg_no = value
        End Set
    End Property

    Dim _exact_timestamp As Date
    Public Property exact_timestamp() As Date
        Get
            Return Me._exact_timestamp
        End Get
        Set(ByVal value As Date)
            Me._exact_timestamp = value
        End Set
    End Property
End Class
