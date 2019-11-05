Imports System.Web.DynamicData
Imports prjDatos
Imports Telerik.Web.UI

Class RecepcionMasiva
    Inherits Page
    Dim cFunciones As New funciones
    Private sNombreMantenimiento As String = "Seguimiento de Expediente"
    Dim ComentariosModificacion As String
    Private sNombreRecepcionExpediente As String = "pDetalleExpediente_Recibir"
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Dim sMensaje As String = ""
    Dim tblExp As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Session("tblExpR") = Nothing
            tblExp = New DataTable
            tblExp.Columns.Add("Expediente")
            tblExp.Columns.Add("EsValido")
            tblExp.Columns.Add("Detalle")
            tblExp.Columns.Add("Estado")
            Session("tblExpR") = tblExp
            txtExpediente.Focus()
        Else
            If txtExpediente.Text <> "" Then
                Dim sExpediente As String = Trim(Replace(UCase(txtExpediente.Text), "'", "-"))
                AgregarExpediente(sExpediente)
                txtExpediente.Text = ""
                txtExpediente.Focus()
            End If
        End If
    End Sub

    Protected Sub txtExpediente_TextChanged(sender As Object, e As EventArgs) Handles txtExpediente.TextChanged

    End Sub
    Sub AgregarExpediente(sExpediente As String)
        Try
            If tblExp Is Nothing Then
                tblExp = Session("tblExpR")
            End If
            Dim i As Integer
            Dim bExiste As Boolean = False
            For i = 0 To tblExp.Rows.Count - 1
                If sExpediente = tblExp.Rows(i).Item(0).ToString Then
                    bExiste = True
                    Exit For
                End If
            Next
            If Not bExiste Then
                Dim row As DataRow
                Dim iDetalle As String = ""
                Dim iEstado As String = ""
                row = tblExp.NewRow
                row(0) = sExpediente
                row(1) = bExpValido(sExpediente, iDetalle, iEstado)
                row(2) = iDetalle
                row(3) = iEstado
                tblExp.Rows.Add(row)
                gExp.DataSource = tblExp
                gExp.DataBind()
                Session("tblExpR") = tblExp
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function bExpValido(sExpediente As String, ByRef iDetalle As String, ByRef iEstado As String) As Boolean
        Try
            If sExpediente <> "" Then
                Dim dtDatos As DataTable = bObtenerFechaRecepcion(sExpediente)
                If dtDatos.Rows(0).Item("FechaRecepcion").ToString = "" And dtDatos.Rows(0).Item("UsuarioRecibido").ToString.ToLower = Session("Usuario").ToString.ToLower Then
                    iDetalle = dtDatos.Rows(0).Item("id").ToString
                    iEstado = dtDatos.Rows(0).Item("idEstado").ToString
                    Return True
                Else
                    iDetalle = ""
                    iEstado = ""
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function dtParametros(sExpediente As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idExpediente", sExpediente)

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub gExp_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gExp.RowDeleting
        Try
            tblExp = Session("tblExpR")
            tblExp.Rows(e.RowIndex).Delete()
            Session("tblExpR") = tblExp
            gExp.DataSource = tblExp
            gExp.DataBind()
            e.Cancel = True
        Catch ex As Exception

        End Try
    End Sub

#Region "Recibir Expedientes"
    Private Function bObtenerFechaRecepcion(sExpediente As String) As DataTable
        bObtenerFechaRecepcion = cFunciones.Filldatatable(sNombreBusqueda, dtParametrosFechaRecepcion(sExpediente), sMensaje)
        Session("Mensaje") = sMensaje
    End Function
    Private Function dtParametrosFechaRecepcion(sExpediente As String) As DataTable
        Try
            dtParametrosFechaRecepcion = cFunciones.dtDatos.Clone
            dtParametrosFechaRecepcion.Rows.Add("idExpediente", sExpediente)
            dtParametrosFechaRecepcion.Rows.Add("UltimoEstado", 1)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub btnRecibir_Click(sender As Object, e As EventArgs) Handles btnRecibir.Click
        Dim sMsg As String = "Se han enviado los siguientes expedientes:" & vbCrLf
        For i = 0 To gExp.Rows.Count - 1
            If gExp.Rows(i).Cells(2).Text = "True" Then
                Dim iDetalle As String = gExp.Rows(i).Cells(3).Text
                Dim iEstado As String = gExp.Rows(i).Cells(4).Text
                If cFunciones.Ejecutar(sNombreRecepcionExpediente, dtParametrosRecepcion(gExp.Rows(i).Cells(1).Text, iDetalle, iEstado), sMensaje) Then
                    sMsg += (i + 1).ToString & " - " & gExp.Rows(i).Cells(1).Text & vbCrLf
                End If
            End If
        Next
        Mensaje(sMsg)
        Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
    End Sub

    Private Function dtParametrosRecepcion(sExpediente As String, iDetalle As String, iEstado As String) As DataTable
        Try
            dtParametrosRecepcion = cFunciones.dtDatos.Clone
            dtParametrosRecepcion.Rows.Add("idExpediente", sExpediente)
            dtParametrosRecepcion.Rows.Add("idEstado", iEstado)
            dtParametrosRecepcion.Rows.Add("idDetalle", iDetalle)
            dtParametrosRecepcion.Rows.Add("idUsuario", Session("Usuario"))
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        If sMensaje <> "" Then
            Dim strScript As String = "<script language=JavaScript>"
            strScript += "alert(""" & sMensaje & """);"
            strScript += "</script>"
            If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
            End If
            Session("Mensaje") = ""
        End If

    End Sub
#End Region

End Class
