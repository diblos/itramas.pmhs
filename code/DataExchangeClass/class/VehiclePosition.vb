Public Class VehiclePosition
    Dim _security_key As String
    Public Property security_key() As String
        Get
            Return Me._security_key
        End Get
        Set(ByVal value As String)
            Me._security_key = value
        End Set
    End Property

    Dim _count As Integer
    Public Property count() As Integer
        Get
            Return Me._count
        End Get
        Set(ByVal value As Integer)
            Me._count = value
        End Set
    End Property

    Dim _vehicle_position_data As VehiclePositionData()
    Public Property vehicle_position_data() As VehiclePositionData()
        Get
            Return Me._vehicle_position_data
        End Get
        Set(ByVal value As VehiclePositionData())
            Me._vehicle_position_data = value
        End Set
    End Property
End Class