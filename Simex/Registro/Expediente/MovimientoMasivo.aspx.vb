Imports System.Web.DynamicData
Imports prjDatos
Imports Telerik.Web.UI

Class MovimientoMasivo
    Inherits Page
    Dim cFunciones As New funciones
    Private sNombreMantenimiento As String = "Seguimiento de Expediente"
    Dim ComentariosModificacion As String
    Private sAgregarEstado As String = "pDetalleExpediente_AgregarEstado"
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Dim sMensaje As String = ""
    Dim tblExp As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            cboNuevoEstado.LLenarCombo(dtParametroComboEstadoEnviar)
            Session("tblExp") = Nothing
            tblExp = New DataTable
            tblExp.Columns.Add("Expediente")
            tblExp.Columns.Add("EsValido")
            Session("tblExp") = tblExp
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
                tblExp = Session("tblExp")
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
                row = tblExp.NewRow
                row(0) = sExpediente
                row(1) = bExpValido(sExpediente)
                tblExp.Rows.Add(row)
                gExp.DataSource = tblExp
                gExp.DataBind()
                Session("tblExp") = tblExp
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function bExpValido(sExpediente As String) As Boolean
        Try
            If sExpediente <> "" Then
                Dim tbl As DataTable = cFunciones.Filldatatable(sNombreBusqueda, dtParametros(sExpediente))

                Dim sRecibidoPor As String = tbl.Rows(0).Item("UsuarioRecibido").ToString
                Dim sFecha As String = tbl.Rows(0).Item("FechaRecepcion").ToString

                If sRecibidoPor.ToLower = Session("Usuario").ToString.ToLower And sFecha <> "" Then
                    Return True
                Else
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

#Region "Cambio de Estado de Expedientes"
    Public Function dtParametroComboEstadoEnviar() As DataTable
        Try
            dtParametroComboEstadoEnviar = cFunciones.dtDatos.Clone
            dtParametroComboEstadoEnviar.Rows.Add("idUsuario", Session("Usuario"))
            dtParametroComboEstadoEnviar.Rows.Add("Enviar", 1)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosEmpleadoEstado() As DataTable
        Try
            dtParametrosEmpleadoEstado = cFunciones.dtDatos.Clone
            dtParametrosEmpleadoEstado.Rows.Add("idEstado", cboNuevoEstado.Value)
            dtParametrosEmpleadoEstado.Rows.Add("Recibir", "1")
            dtParametrosEmpleadoEstado.Rows.Add("Activo", "0")
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim sMsg As String = "Se han enviado los siguientes expedientes:" & vbCrLf
        For i = 0 To gExp.Rows.Count - 1
            If gExp.Rows(i).Cells(2).Text = "True" Then
                If bModificar(gExp.Rows(i).Cells(1).Text) Then
                    sMsg += (i + 1).ToString & " - " & gExp.Rows(i).Cells(1).Text & vbCrLf
                End If
            End If
        Next
        Mensaje(sMsg)
        Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
    End Sub
    Private Function bModificar(sExpediente As String) As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sAgregarEstado, dtParametrosAgregarEstado(sExpediente), sMensaje)
        'Mensaje(sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function dtParametrosAgregarEstado(sExpediente As String) As DataTable
        Try
            ComentariosModificacion = "Expediente:" & sExpediente & Session("Modificacion") & " DATOS NUEVOS: ESTADO:" & cboNuevoEstado.Text
            ComentariosModificacion = ComentariosModificacion & " USUARIO RECIBE:" & cboNuevoEmpleado.SelectedText
            dtParametrosAgregarEstado = cFunciones.dtDatos.Clone
            dtParametrosAgregarEstado.Rows.Add("idExpediente", sExpediente)
            dtParametrosAgregarEstado.Rows.Add("idEstadoAsignado", cboNuevoEstado.Value)
            dtParametrosAgregarEstado.Rows.Add("idEmpleado", cboNuevoEmpleado.SelectedValue)
            dtParametrosAgregarEstado.Rows.Add("Modificacion", ComentariosModificacion)
            dtParametrosAgregarEstado.Rows.Add("idusuario", Session("Usuario"))
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub cboNuevoEstado_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNuevoEstado.ComboChangedItem
        Try
            If cboNuevoEstado.Value <> "-1" And cboNuevoEstado.Value <> Nothing Then
                Dim tblData As DataTable = cFunciones.Filldatatable("pPersonaEstadoRol_List2", dtParametrosEmpleadoEstado)
                With cboNuevoEmpleado
                    .DataFieldID = "IdEmpleado"
                    .DataFieldParentID = "IdRol"
                    .DataValueField = "IdEmpleado"
                    .DataTextField = "NombreCompleto"
                    .DataSource = tblData
                    .DataBind()
                End With
                cboNuevoEmpleado.Enabled = True
                cboNuevoEmpleado.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

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

    Protected Sub gExp_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gExp.RowDeleting
        Try
            tblExp = Session("tblExp")
            tblExp.Rows(e.RowIndex).Delete()
            Session("tblExp") = tblExp
            gExp.DataSource = tblExp
            gExp.DataBind()
            e.Cancel = True
        Catch ex As Exception

        End Try
    End Sub
End Class
