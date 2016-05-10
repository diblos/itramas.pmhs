Public Class VehiclePositionData
    Dim _route_id As String
    Public Property route_id() As String
        Get
            Return Me._route_id
        End Get
        Set(ByVal value As String)
            Me._route_id = value
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

    Dim _vehicle_reg_no As String
    Public Property vehicle_reg_no() As String
        Get
            Return Me._vehicle_reg_no
        End Get
        Set(ByVal value As String)
            Me._vehicle_reg_no = value
        End Set
    End Property

    Dim _driver_name As String
    Public Property driver_name() As String
        Get
            Return Me._driver_name
        End Get
        Set(ByVal value As String)
            Me._driver_name = value
        End Set
    End Property

    Dim _latitude As Decimal
    Public Property latitude() As Decimal
        Get
            Return Me._latitude
        End Get
        Set(ByVal value As Decimal)
            Me._latitude = value
        End Set
    End Property

    Dim _longitude As Decimal
    Public Property longitude() As Decimal
        Get
            Return Me._longitude
        End Get
        Set(ByVal value As Decimal)
            Me._longitude = value
        End Set
    End Property

    Dim _altitude As Double
    Public Property altitude() As Double
        Get
            Return Me._altitude
        End Get
        Set(ByVal value As Double)
            Me._altitude = value
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

    Dim _speed As Single
    Public Property speed() As Single
        Get
            Return Me._speed
        End Get
        Set(ByVal value As Single)
            Me._speed = value
        End Set
    End Property

    Dim _bearing As Decimal
    Public Property bearing() As Decimal
        Get
            Return Me._bearing
        End Get
        Set(ByVal value As Decimal)
            Me._bearing = value
        End Set
    End Property

    Dim _odometer As Int64
    Public Property odometer() As Int64
        Get
            Return Me._odometer
        End Get
        Set(ByVal value As Int64)
            Me._odometer = value
        End Set
    End Property

    Dim _collection As Integer
    Public Property collection() As Integer
        Get
            Return Me._collection
        End Get
        Set(ByVal value As Integer)
            Me._collection = value
        End Set
    End Property

    Dim _ticket_count As Integer
    Public Property ticket_count() As Integer
        Get
            Return Me._ticket_count
        End Get
        Set(ByVal value As Integer)
            Me._ticket_count = value
        End Set
    End Property

    Dim _passenger_onboard As Integer
    Public Property passenger_onboard() As Integer
        Get
            Return Me._passenger_onboard
        End Get
        Set(ByVal value As Integer)
            Me._passenger_onboard = value
        End Set
    End Property

    Dim _activity_id As Integer
    Public Property activity_id() As Integer
        Get
            Return Me._activity_id
        End Get
        Set(ByVal value As Integer)
            Me._activity_id = value
        End Set
    End Property
End Class
