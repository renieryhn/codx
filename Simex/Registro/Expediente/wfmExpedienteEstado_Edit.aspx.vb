Imports prjDatos
Public Class wfmSeguimientoExpediente_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pDetalleExpediente_CambioEstado"
    Private Const spListNombre As String = "pDetalleExpediente_List"
    Dim ComentariosModificacion As String
    Dim fechaConfirmacionAsignacion As String
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender

    End Sub
    Protected Sub btnAceptar_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        If bModificar() Then
            Redirect()
        Else
            Mensaje(sMensaje)
        End If
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Master.idExpediente <> "" And Not IsPostBack Then
            CargarValores()
        End If
    End Sub
    Private Sub cboNuevoEstado_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNuevoEstado.ComboChangedItem
        If cboNuevoEstado.Value <> "-1" And cboNuevoEstado.Value <> Nothing Then
            cboNuevoEmpleado.LLenarCombo(dtParametroComboEmpleado)
        End If

    End Sub
#End Region
#Region "Metodos"
    Private Sub CargarValores()
        Try
            If Master.idExpediente <> "" Then
                cboEstadoActual.LLenarCombo(dtParametroComboEstado)
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                cboEstadoActual.Value = dtDatos.Rows(0).Item("idEstado")
                cboNuevoEstado.LLenarCombo(dtParametroComboEstadoEnviar)
                dtcFechaRecepcion.Value = dtDatos.Rows(0).Item(dtcFechaRecepcion.FieldName)
                dtcFechaAsignacion.Value = dtDatos.Rows(0).Item(dtcFechaAsignacion.FieldName).ToString
                txtAsignadoA.Text = dtDatos.Rows(0).Item(txtAsignadoA.FieldName).ToString
                txtRecibidoPor.Text = dtDatos.Rows(0).Item(txtRecibidoPor.FieldName).ToString
                'txtComentarioActual.Text = dtDatos.Rows(0).Item(txtComentarioActual.FieldName).ToString()
                Session("Modificacion") = dtDatos.Rows(0).Item("Modificacion").ToString()
                Session("Modificacion") = Session("Modificacion") & " FECHA MODIFICACION:" & Date.Now & " USUARIO MODIFICACION:" & Master.Master.Usuario
                Session("Modificacion") = Session("Modificacion") & " MODIFICACIONES: DATOS ANTIGUOS: ESTADO:" & dtDatos.Rows(0).Item("Estado").ToString()
                Session("Modificacion") = Session("Modificacion") & " USUARIO RECIBE:" & dtDatos.Rows(0).Item("RecibidoPor").ToString()
                Session("fechaConfirmacionAsignacion") = DirectCast(dtDatos.Rows(0).Item("FechaConfirmacionAsignacion"), DateTime)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Private Sub Redirect()
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            'dtParametrosBusqueda.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosBusqueda.Rows.Add("id", Session("idDetalleExpediente"))

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Public Function dtParametroComboEstado() As DataTable
        Try
            dtParametroComboEstado = Funciones.dtDatos.Clone
            'dtParametrosBusqueda.Rows.Add("idExpediente", Master.idExpediente)
            dtParametroComboEstado.Rows.Add("idUsuario", Master.Master.Usuario)

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function dtParametroComboEstadoEnviar() As DataTable
        Try
            dtParametroComboEstadoEnviar = Funciones.dtDatos.Clone
            'dtParametrosBusqueda.Rows.Add("idExpediente", Master.idExpediente)
            dtParametroComboEstadoEnviar.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametroComboEstadoEnviar.Rows.Add("Enviar", 1)
            If Not Master.Master.Alta Then
                dtParametroComboEstadoEnviar.Rows.Add("idEstadoActual", cboEstadoActual.Value)
                dtParametroComboEstadoEnviar.Rows.Add("idServicio", Master.idExpediente.ToString.Substring(0, 2))
                dtParametroComboEstadoEnviar.Rows.Add("idExpediente", Master.idExpediente)
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function dtParametroComboEmpleado() As DataTable
        Try
            dtParametroComboEmpleado = Funciones.dtDatos.Clone
            'dtParametrosBusqueda.Rows.Add("idExpediente", Master.idExpediente)
            dtParametroComboEmpleado.Rows.Add("idEstado", cboNuevoEstado.Value)
            dtParametroComboEmpleado.Rows.Add("Recibir", "1")
            dtParametroComboEmpleado.Rows.Add("Activo", "0")

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try

            dtParametros = Funciones.dtDatos.Clone
            ComentariosModificacion = Session("Modificacion") & " DATOS NUEVOS: ESTADO:" & cboNuevoEstado.Text
            ComentariosModificacion = ComentariosModificacion & " USUARIO RECIBE:" & cboNuevoEmpleado.Text
            dtParametros.Rows.Add("idDetalleExpediente", Session("idDetalleExpediente"))
            dtParametros.Rows.Add("idExpediente", Master.idExpediente)
            dtParametros.Rows.Add(cboNuevoEmpleado.FieldName, cboNuevoEmpleado.Value)
            dtParametros.Rows.Add(cboNuevoEstado.FieldName, cboNuevoEstado.Value)
            dtParametros.Rows.Add("Modificacion", ComentariosModificacion)
            'dtParametros.Rows.Add("FechaConfirmacionAsignacion", Format(Session("fechaConfirmacionAsignacion"), "dd/MM/yyyy HH:mm"))
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)

            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
        Session("Mensaje") = ""
    End Sub
#End Region

End Class