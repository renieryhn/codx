﻿Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class cMetodos
    Protected _Conexion As New SqlConnection
    Private dtAdapter As SqlDataAdapter
    Private objCommand As New SqlCommand
    Public Const g_FORMATO_FECHA_HORA As String = "dd/MM/yyyy HH:mm"
    Public Const sNombreSistema As String = "Sistema Integrado de Seguimiento de Expedientes"
    Dim iCont As Integer
#Region "Conectar\Desconectar"
    Private Function Conectar() As Boolean
        Try
            'prueba
            If _Conexion.State <> ConnectionState.Open Then
                _Conexion.ConnectionString = My.Settings.ConnectionString
                _Conexion.Open()
            End If
            Conectar = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function Conectar(ByRef objTrans As SqlTransaction) As Boolean
        Try
            If _Conexion.State <> ConnectionState.Open Then
                _Conexion.ConnectionString = My.Settings.ConnectionString
                _Conexion.Open()
            End If
            If objTrans Is Nothing Then
                objTrans = _Conexion.BeginTransaction
            End If
            Conectar = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub Desconectar()
        Try
            If _Conexion.State <> ConnectionState.Closed Then
                _Conexion.Close()
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
#End Region
#Region "Ejecutar Command"
    Public Function Ejecutar(ByVal spNombre As String, ByVal objCommand As SqlCommand, Optional ByRef sMensaje As String = "") As Boolean
        Try
            Ejecutar = False
            Dim s As New SqlParameter
            Dim i As Integer
            'Dim d As String
            If Not objCommand Is Nothing Then
                If Conectar() Then
                    objCommand.CommandText = spNombre
                    objCommand.Connection = _Conexion
                    objCommand.CommandType = CommandType.StoredProcedure
                    i = objCommand.ExecuteNonQuery()
                    If i > 0 Then
                        'sMensaje = "La operación se realizó satisfactoriamente"
                        sMensaje = ""
                    End If
                End If
                Ejecutar = True
                If i = 0 Then
                    sMensaje = "La operación no se pudo realizar"
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = "547" Then
                sMensaje = "No se puede actualizar o eliminar el registro, debido a que este tiene registros relacionados"
            ElseIf ex.Number = 8114 Then
                sMensaje = "Error en el tipo de dato introducido"
            Else
                sMensaje = ex.Message
            End If
            Return False
        End Try

    End Function

    Public Function Ejecutar(ByVal spNombre As String, ByVal dtParams As DataTable, Optional ByRef sMensaje As String = "") As Boolean
        Try
            Ejecutar = False
            Dim s As New SqlParameter
            Dim i As Integer
            'Dim d As String
            If Not dtParams Is Nothing Then
                If Conectar() Then
                    objCommand = New SqlCommand(spNombre, _Conexion)
                    objCommand.CommandType = CommandType.StoredProcedure
                    For Each dr As DataRow In dtParams.Rows
                        If dr.Item("Valor").ToString <> "" Then
                            objCommand.Parameters.AddWithValue("@" & dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                        End If
                    Next
                    i = objCommand.ExecuteNonQuery()
                    If i > 0 Then
                        'sMensaje = "La operación se realizó satisfactoriamente"
                        sMensaje = ""
                    End If
                End If

                Ejecutar = True
                If i = 0 Then
                    sMensaje = "La operación no se pudo realizar"
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = "547" Then
                sMensaje = "No se puede actualizar o eliminar el registro, debido a que este tiene registros relacionados"
            ElseIf ex.Number = 8114 Then
                sMensaje = "Error en el tipo de dato introducido"
            Else
                sMensaje = ex.Message
            End If
            Return False
        End Try

    End Function
    Public Function Ejecutar(ByVal spNombre As String, ByVal dtParams As DataTable, ByVal nombreParametro As String, ByRef ValorParametro As String, Optional ByRef sMensaje As String = "") As Boolean
        Try
            Ejecutar = False
            Dim s As New SqlParameter
            Dim i As Integer
            'Dim d As String
            If Not dtParams Is Nothing Then
                If Conectar() Then
                    objCommand = New SqlCommand(spNombre, _Conexion)
                    objCommand.CommandType = CommandType.StoredProcedure
                    For Each dr As DataRow In dtParams.Rows
                        If dr.Item("Valor").ToString <> "" Then
                            objCommand.Parameters.AddWithValue("@" & dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                        End If
                    Next
                    ' ValorParametro = (objCommand.Parameters("@" & nombreParametro).Direction = ParameterDirection.Output)
                    Dim paramResultado As SqlParameter = New SqlParameter("@" & nombreParametro, SqlDbType.NVarChar, 17)
                    paramResultado.Direction = ParameterDirection.Output
                    objCommand.Parameters.Add(paramResultado)
                    i = objCommand.ExecuteNonQuery()
                    ValorParametro = paramResultado.Value
                    If i > 0 Then
                        'sMensaje = "La operación se realizó satisfactoriamente"
                        sMensaje = ""
                    End If
                End If
                Ejecutar = True
                If i = 0 Then
                    sMensaje = "No se ha actualizado el registro"
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = "547" Then
                sMensaje = "No se puede eliminar el registro"
            ElseIf ex.Number = 8114 Then
                sMensaje = "Error en el tipo de dato introducido"
            Else
                sMensaje = ex.Message
            End If
            Return False
        End Try

    End Function
    Public Function Ejecutar(ByVal spNombre As String, ByVal dtParams As DataTable, ByRef objTrans As SqlTransaction, Optional ByRef sMensaje As String = "") As Boolean
        Try
            Dim i As Integer
            objCommand = New SqlCommand(spNombre, _Conexion, objTrans)
            objCommand.CommandType = CommandType.StoredProcedure
            If Not dtParams Is Nothing Then
                If Conectar(objTrans) Then
                    For Each dr As DataRow In dtParams.Rows
                        If dr.Item("Valor").ToString <> "" Then
                            objCommand.Parameters.AddWithValue("@" & dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                        End If
                    Next
                End If
                objCommand.Transaction = objTrans
                i = objCommand.ExecuteNonQuery()
                If i > 0 Then
                    'sMensaje = "La operación se realizó satisfactoriamente"
                    sMensaje = ""
                End If
                Ejecutar = True
                If i = 0 Then
                    sMensaje = "No se ha actualizado el registro"
                    Return False
                End If

            Else
                Return False
            End If
        Catch ex As SqlClient.SqlException
            If ex.Number = "547" Then
                sMensaje = "No se puede eliminar el registro"

            ElseIf ex.Number = 8114 Then
                sMensaje = "Error en el tipo de dato introducido"
            Else
                sMensaje = ex.Message
            End If
            Return False
        End Try
    End Function
#End Region
#Region "FillDataTable"
    Public Function Filldatatable(ByVal spNombre As String, ByVal dtParams As DataTable, ByVal nombreParametro As String, ByRef ValorParametro As String, Optional ByRef sMensaje As String = "") As DataTable
        Try
            Dim s As String
            Filldatatable = New DataTable
            If Conectar() Then
                objCommand = New SqlCommand(spNombre, _Conexion)
                If Not dtParams Is Nothing Then
                    For Each dr As DataRow In dtParams.Rows
                        s = dr.Item("Valor").ToString()
                        If dr.Item("Valor").ToString <> "" Then
                            objCommand.Parameters.AddWithValue(dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                        End If
                    Next
                End If
                Dim paramResultado As SqlParameter = New SqlParameter("@" & nombreParametro, SqlDbType.NVarChar, 17)
                paramResultado.Direction = ParameterDirection.Output
                objCommand.Parameters.Add(paramResultado)
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.StoredProcedure
                dtAdapter.Fill(Filldatatable)
                ValorParametro = paramResultado.Value
            End If
        Catch ex As SqlException
            If ex.ErrorCode = "-2146232060" Then
                sMensaje = "Error al conectarse a la base de datos, favor comunicarse con el administrador"
            End If
            If Not dtAdapter Is Nothing Then
                dtAdapter.Dispose()
                _Conexion.Dispose()
            End If
            Return Nothing
        End Try
    End Function
    Public Function Filldatatable(ByVal spNombre As String, ByVal objCommand As SqlCommand, Optional ByRef sMensaje As String = "") As DataTable
        Try
            Filldatatable = New DataTable
            If Conectar() Then
                objCommand.CommandType = CommandType.StoredProcedure
                objCommand.CommandText = spNombre
                objCommand.Connection = _Conexion
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.StoredProcedure
                dtAdapter.Fill(Filldatatable)
            End If
        Catch ex As SqlException
            If ex.ErrorCode = "-2146232060" Then
                sMensaje = "Error al conectarse a la base de datos, favor comunicarse con el administrador"
            End If
            If Not dtAdapter Is Nothing Then
                dtAdapter.Dispose()
                _Conexion.Dispose()
            End If
            Return Nothing
        End Try
    End Function

    Public Function Filldatatable(ByVal spNombre As String, ByVal dtParams As DataTable, Optional ByRef sMensaje As String = "") As DataTable
        Try
            Dim s As String
            Filldatatable = New DataTable
            If Conectar() Then
                objCommand = New SqlCommand(spNombre, _Conexion)
                If Not dtParams Is Nothing Then
                    For Each dr As DataRow In dtParams.Rows
                        s = dr.Item("Valor").ToString()
                        If dr.Item("Valor").ToString <> "" Then
                            objCommand.Parameters.AddWithValue(dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                        End If
                    Next
                End If
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.StoredProcedure
                dtAdapter.Fill(Filldatatable)
                sMensaje = ""
            End If
        Catch ex As SqlException
            If ex.ErrorCode = "-2146232060" Then
                sMensaje = "Error al conectarse a la base de datos, favor comunicarse con el administrador"
            End If
            If Not dtAdapter Is Nothing Then
                dtAdapter.Dispose()
                _Conexion.Dispose()
            End If
            Return Nothing
        End Try
    End Function

    Public Function Filldatatable(ByVal spNombre As String) As DataTable
        Try
            Filldatatable = New DataTable

            If Conectar() Then
                objCommand = New SqlCommand(spNombre, _Conexion)
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.StoredProcedure
                dtAdapter.Fill(Filldatatable)

            End If

        Catch ex As Exception
            dtAdapter.Dispose()
            _Conexion.Dispose()
            Return Nothing
        End Try
    End Function
    Public Function FillQuery(ByVal sQuery As String) As DataTable
        Try
            FillQuery = New DataTable
            If Conectar() Then
                objCommand = New SqlCommand(sQuery, _Conexion)
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.Text
                dtAdapter.Fill(FillQuery)

            End If
        Catch ex As Exception
            dtAdapter.Dispose()
            _Conexion.Dispose()
            Return Nothing
        End Try
    End Function
    Public Function Filldatatable(ByVal spNombre As String, ByVal dtParams As DataTable, ByRef objTrans As SqlTransaction) As DataTable
        Try
            If Conectar() Then
                Filldatatable = New DataTable
                objCommand = New SqlCommand(spNombre, _Conexion, objTrans)
                For Each dr As DataRow In dtParams.Rows
                    If dr.Item("DataType") = "4" Then
                        dr.Item("Valor") = Format(CDate(dr.Item("Valor").ToString), g_FORMATO_FECHA_HORA)
                    End If
                    objCommand.Parameters.AddWithValue(dr.Item("Nombre").ToString, dr.Item("Valor").ToString)
                Next
                dtAdapter = New SqlDataAdapter(objCommand)
                objCommand.CommandType = CommandType.StoredProcedure
                dtAdapter.Fill(Filldatatable)

            Else
                Return Nothing
            End If
            Return Filldatatable
        Catch ex As Exception
            dtAdapter.Dispose()
            _Conexion.Dispose()
            Return Nothing
        End Try
    End Function
#End Region
End Class
