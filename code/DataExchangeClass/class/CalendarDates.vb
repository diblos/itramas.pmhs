Public Class CalendarDates
    Dim _service_id As String
    Public Property service_id() As String
        Get
            Return Me._service_id
        End Get
        Set(ByVal value As String)
            Me._service_id = value
        End Set
    End Property

    Dim _date As String
    Public Property [date]() As String
        Get
            Return Me._date
        End Get
        Set(ByVal value As String)
            Me._date = value
        End Set
    End Property

    Dim _exception_type As String
    Public Property exception_type() As String
        Get
            Return Me._exception_type
        End Get
        Set(ByVal value As String)
            Me._exception_type = value
        End Set
    End Property
End Class
