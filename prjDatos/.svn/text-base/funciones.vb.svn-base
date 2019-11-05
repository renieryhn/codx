Public Class funciones
    Inherits cMetodos
    Public dt As DataTable
    Public _db As BindingSource


#Region "Datatable para filtros\Alta\Modificacion\Borrado"
    Public Function dtParamsFiltro(ByVal dtRows As DataTable) As DataTable
        Try
            dtParamsFiltro = New DataTable("Filtros")
            dtParamsFiltro.Columns.Add("Nombre", GetType(System.String))
            dtParamsFiltro.Columns.Add("Valor", GetType(System.String))
            If Not dtRows Is Nothing Then
                For Each DR As DataRow In dtRows.Rows
                    dtParamsFiltro.Rows.Add(DR.Item(0), DR.Item(1), DR.Item(2))
                Next
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtRowsComboEnumerado(ByVal dtRows As DataTable) As DataTable
        Try
            dtRowsComboEnumerado = New DataTable("Elementos")
            dtRowsComboEnumerado.Columns.Add("Codigo", GetType(System.String))
            dtRowsComboEnumerado.Columns.Add("Nombre", GetType(System.String))
            If Not dtRows Is Nothing Then
                For Each DR As DataRow In dtRows.Rows
                    dtRowsComboEnumerado.Rows.Add(DR.Item(0), DR.Item(1))
                Next
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region
    
#Region "Propiedades"
    Public Property db() As BindingSource
        Get
            Return _db
        End Get
        Set(ByVal value As BindingSource)
            _db = value
        End Set
    End Property
#End Region

#Region "NO MODIFICAR!!"
    Sub New()
        Try
            dt = New DataTable
            db = New BindingSource
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Public Function dtDatos() As DataTable
        Try
            dtDatos = dtParamsFiltro(Nothing)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Public Function dtDatosComboEnumerado() As DataTable
        Try
            dtDatosComboEnumerado = dtRowsComboEnumerado(Nothing)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region
End Class

