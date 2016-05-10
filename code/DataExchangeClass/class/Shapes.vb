Public Class Shapes
    Dim _shape_id As String
    Public Property shape_id() As String
        Get
            Return Me._shape_id
        End Get
        Set(ByVal value As String)
            Me._shape_id = value
        End Set
    End Property

    Dim _shape_pt_lat As String
    Public Property shape_pt_lat() As String
        Get
            Return Me._shape_pt_lat
        End Get
        Set(ByVal value As String)
            Me._shape_pt_lat = value
        End Set
    End Property

    Dim _shape_pt_lon As String
    Public Property shape_pt_lon() As String
        Get
            Return Me._shape_pt_lon
        End Get
        Set(ByVal value As String)
            Me._shape_pt_lon = value
        End Set
    End Property

    Dim _shape_pt_sequence As String
    Public Property shape_pt_sequence() As String
        Get
            Return Me._shape_pt_sequence
        End Get
        Set(ByVal value As String)
            Me._shape_pt_sequence = value
        End Set
    End Property

    Dim _shape_dist_traveled As String
    Public Property shape_dist_traveled() As String
        Get
            Return Me._shape_dist_traveled
        End Get
        Set(ByVal value As String)
            Me._shape_dist_traveled = value
        End Set
    End Property
End Class
