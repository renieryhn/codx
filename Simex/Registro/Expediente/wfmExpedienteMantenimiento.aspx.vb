Imports prjDatos
Public Class wfmExpedienteMantenimiento
    Inherits System.Web.UI.Page
    Dim Funciones As New funciones
    Private sMensaje As String = ""
    Dim Ok As Boolean
    Dim iId As String
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Private sNombreNuevoComentario As String = "pComentarioDetalleExpediente_Add"
    Private sAgregarEstado As String = "pDetalleExpediente_AgregarEstado"
    Private Const spListNombre As String = "pDetalleExpediente_List"
    Private spResoluciones_List As String = "pResoluciones_List"
    Private spAnularResolucion As String = "pExpediente_AnularResolucion"
    Private spDictamenes_List As String = "pDictamenes_List"
    Private spAnularDictamen As String = "pExpediente_AnularDictamen"
    Private sNombreMantenimiento As String = "Mantenimiento de Expediente"
    Dim ComentariosModificacion As String
    Dim dtDatos As DataTable
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
        Mensaje(Session("Mensaje"))
    End Sub
    Protected Sub btnCambiarEncargadoExpediente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCambiarEncargadoExpediente.Click
        Response.Redirect("~/Registro/Expediente/wfmCambiarEncargadoExpediente_Prop.aspx")
    End Sub
    Protected Sub btnAnularNumeroDictamen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnularNumeroDictamen.Click
        ObtenerDictamenes()
        mpeAnularDictamen.Show()
    End Sub
    Protected Sub btnEvaluarResolucion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEvaluarResolucion.Click
        Response.Redirect("~/Registro/Expediente/wfmEvaluarResolucion_List.aspx")
    End Sub
    Protected Sub btnEvaluarDictamen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEvaluarDictamen.Click
        Response.Redirect("~/Registro/Expediente/wfmEvaluarDictamen_List.aspx")
    End Sub
    Protected Sub btnAgregarComentario_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarComentario.Click
        mpeAgregarComentario.Show()
    End Sub
   
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try
            If Master.idExpediente <> "" And Not IsPostBack Then
                CargarValores()
            End If
        Catch ex As Exception

        End Try
    End Sub
   
    Protected Sub btnAnularResolucion_Click(sender As Object, e As EventArgs) Handles btnAnularResolucion.Click
        If Not bAnularResolucion() Then
            mpeAnularResolucion.Show()
        Else
            Response.Redirect("~/Registro/Expediente/wfmExpedienteMantenimiento.aspx")
            
        End If
    End Sub
    Protected Sub btnAnularDictamen_Click(sender As Object, e As EventArgs) Handles btnAnularDictamen.Click
        If Not bAnularDictamen() Then
            mpeAnularDictamen.Show()
        Else
            Response.Redirect("~/Registro/Expediente/wfmExpedienteMantenimiento.aspx")
        End If
    End Sub
    Protected Sub btnInsertarComentario_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsertarComentario.Click
        bInsertarComentario()
    End Sub
    Protected Sub btnAnularNumeroResolucion_Click(sender As Object, e As EventArgs) Handles btnAnularNumeroResolucion.Click
        ObtenerResoluciones()
        mpeAnularResolucion.Show()
    End Sub
#End Region
#Region "Metodos"
    Private Function bObtenerFechaRecepcion() As DataTable
        bObtenerFechaRecepcion = Funciones.Filldatatable(sNombreBusqueda, dtParametrosFechaRecepcion, sMensaje)
        Session("Mensaje") = sMensaje
    End Function
    Private Sub CargarValores()
        
        Try
            If Master.idExpediente <> "" Then

                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosFechaRecepcion)
                txtEstadoActual.Text = dtDatos.Rows(0).Item(txtEstadoActual.FieldName)
                dtcFechaRecepcion.Value = dtDatos.Rows(0).Item(dtcFechaRecepcion.FieldName)
                dtcFechaAsignacion.Value = dtDatos.Rows(0).Item(dtcFechaAsignacion.FieldName).ToString
                txtAsignadoA.Text = dtDatos.Rows(0).Item(txtAsignadoA.FieldName).ToString
                txtRecibidoPor.Text = dtDatos.Rows(0).Item(txtRecibidoPor.FieldName).ToString
                txtNumDictamen.Text = dtDatos.Rows(0).Item(txtNumDictamen.FieldName).ToString
                txtNumeroResolucion.Text = dtDatos.Rows(0).Item(txtNumeroResolucion.FieldName).ToString
                dtcFechaResolucion.Value = dtDatos.Rows(0).Item(dtcFechaResolucion.FieldName).ToString
                dtcFechaDictamen.Value = dtDatos.Rows(0).Item(dtcFechaDictamen.FieldName).ToString
                btnCambiarEncargadoExpediente.Enabled = True

                If Master.Master.Alta And Not dtcFechaRecepcion.Value Is Nothing Then
                    btnAnularNumeroDictamen.Enabled = True
                    btnAnularNumeroResolucion.Enabled = True
                End If
                If txtRecibidoPor.Text.ToLower = Master.Master.Usuario.ToLower And Not dtcFechaRecepcion.Value Is Nothing Then
                    btnAgregarComentario.Enabled = True
                    btnCambiarEncargadoExpediente.Enabled = True
                    btnEvaluarDictamen.Enabled = True
                    btnEvaluarResolucion.Enabled = True
                End If
                If Session("UsuarioRol") = 1 Then
                    btnAnularNumeroDictamen.Enabled = True
                    btnAnularNumeroResolucion.Enabled = True
                    btnAgregarComentario.Enabled = True
                    btnCambiarEncargadoExpediente.Enabled = True
                    btnEvaluarDictamen.Enabled = True
                    btnEvaluarResolucion.Enabled = True
                End If

                Session("Modificacion") = dtDatos.Rows(0).Item("Modificacion") + " FECHA MODIFICACION:" & Date.Now & " USUARIO MODIFICACION:" & Master.Master.Usuario
                Session("Modificacion") = Session("Modificacion") & " MODIFICACIONES: DATOS ANTIGUOS: ESTADO:" & dtDatos.Rows(0).Item("Estado").ToString()
                Session("Modificacion") = Session("Modificacion") & " USUARIO RECIBE:" & dtDatos.Rows(0).Item("RecibidoPor").ToString()
                'Session("fechaConfirmacionAsignacion") = DirectCast(dtDatos.Rows(0).Item("FechaConfirmacionAsignacion"), DateTime)
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub
    Private Function bInsertarComentario() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(sNombreNuevoComentario, dtParametrosComentario, sMensaje)
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If

        ' Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function bAnularResolucion() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spAnularResolucion, dtParametrosAnularResolucion, sMensaje)
        If sMensaje <> "" Then
            Session("Mensaje") = sMensaje
        End If
        ' Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function bAnularDictamen() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spAnularDictamen, dtParametrosAnularDictamen, sMensaje)
        If Not sMensaje = "" Then
            Session("Mensaje") = sMensaje
        End If

        Return Ok
    End Function
    Private Function ObtenerDictamenes() As Boolean
        Dim Ok As Boolean
        ListadoDictamenRepeater.DataSource = Funciones.Filldatatable(spDictamenes_List, dtParametrosBuscarResolucion, sMensaje)
        ListadoDictamenRepeater.DataBind()
        If Not sMensaje = "" Then
            Mensaje(sMensaje)
        End If

        Return Ok
    End Function
    Private Function ObtenerResoluciones() As Boolean
        Dim Ok As Boolean
        ListadoResolucionesRepeater.DataSource = Funciones.Filldatatable(spResoluciones_List, dtParametrosBuscarResolucion, sMensaje)
        ListadoResolucionesRepeater.DataBind()
        If Not sMensaje = "" Then
            Mensaje(sMensaje)
        End If

        Return Ok
    End Function
   
    Private Function idResolucion() As Integer
        Dim iNumero As Integer = 0
        If ListadoResolucionesRepeater.Items.Count > 0 Then
            For Each Fila As RepeaterItem In ListadoResolucionesRepeater.Items
                Dim RequisitoIDlbl As Label
                Dim szRequisitoID As String
                RequisitoIDlbl = Fila.FindControl("id")
                szRequisitoID = RequisitoIDlbl.Text
                Dim ValorChkbx As CheckBox
                ValorChkbx = TryCast(Fila.FindControl("Anular"), CheckBox)
                If ValorChkbx.Checked Then
                    iNumero = iNumero + 1
                    idResolucion = szRequisitoID
                End If
            Next
            If iNumero > 1 Then
                Session("Mensaje") = "Error"
                Mensaje("Debe seleccionar solamente una resolución de la lista")
                mpeAnularResolucion.Show()
                Return Nothing
            End If
        Else
            Session("Mensaje") = "Error"
            Mensaje("Debe seleccionar una resolución de la lista")
        End If
    End Function
    Private Function idDictamen() As Integer
        Dim iNumero As Integer = 0
        If ListadoDictamenRepeater.Items.Count > 0 Then
            For Each Fila As RepeaterItem In ListadoDictamenRepeater.Items
                Dim RequisitoIDlbl As Label
                Dim szRequisitoID As String
                RequisitoIDlbl = Fila.FindControl("idDictamen")
                szRequisitoID = RequisitoIDlbl.Text
                Dim ValorChkbx As CheckBox
                ValorChkbx = TryCast(Fila.FindControl("AnularDictamen"), CheckBox)
                If ValorChkbx.Checked Then
                    iNumero = iNumero + 1
                    idDictamen = szRequisitoID
                End If
            Next
            If iNumero > 1 Then
                Session("Mensaje") = "Error"
                Mensaje("Debe seleccionar solamente un dictamen de la lista")
                mpeAnularResolucion.Show()
                Return Nothing
            End If
        Else
            Session("Mensaje") = "Error"
            Mensaje("Debe seleccionar un dictamen de la lista")
        End If
    End Function
    Private Function dtParametrosBuscarResolucion() As DataTable
        Try
            dtParametrosBuscarResolucion = Funciones.dtDatos.Clone
            dtParametrosBuscarResolucion.Rows.Add("idExpediente", Master.idExpediente)

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosAnularResolucion() As DataTable
        Try
            Session("Mensaje") = ""
            dtParametrosAnularResolucion = Funciones.dtDatos.Clone
            dtParametrosAnularResolucion.Rows.Add("idResolucion", idResolucion)
            dtParametrosAnularResolucion.Rows.Add("id", Master.idExpediente)
            dtParametrosAnularResolucion.Rows.Add("Comentario", txtJustificacion.Text)
            dtParametrosAnularResolucion.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosAnularDictamen() As DataTable
        Try
            Session("Mensaje") = ""
            dtParametrosAnularDictamen = Funciones.dtDatos.Clone
            dtParametrosAnularDictamen.Rows.Add("idDictamen", idDictamen)
            dtParametrosAnularDictamen.Rows.Add("id", Master.idExpediente)
            dtParametrosAnularDictamen.Rows.Add("Justificacion", txtJustificacionDictamen.Text)
            dtParametrosAnularDictamen.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
   
    End Function
    Private Function dtParametrosComentario() As DataTable
        Try
            dtParametrosComentario = Funciones.dtDatos.Clone
            dtParametrosComentario.Rows.Add("id", Master.idExpediente)
            dtParametrosComentario.Rows.Add("Comentario", txtComentarios.Text)
            dtParametrosComentario.Rows.Add("idusuario", Master.Master.Usuario)
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function

    Private Function dtParametrosFechaRecepcion() As DataTable
        Try
            dtParametrosFechaRecepcion = Funciones.dtDatos.Clone
            dtParametrosFechaRecepcion.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosFechaRecepcion.Rows.Add("UltimoEstado", 1)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add("id", Session("idDetalleExpediente"))

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function dtParametroComboTodos() As DataTable
        Try
            dtParametroComboTodos = Funciones.dtDatos.Clone
            dtParametroComboTodos.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametrosBusqueda.Rows.Add("Enviar", "1")
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function dtParametroComboEstadoEnviar() As DataTable
        Try
            dtParametroComboEstadoEnviar = Funciones.dtDatos.Clone
           dtParametroComboEstadoEnviar.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametroComboEstadoEnviar.Rows.Add("Enviar", 1)
            If Not Master.Master.Alta Then
                dtParametroComboEstadoEnviar.Rows.Add("idEstadoActual", 1)
                dtParametroComboEstadoEnviar.Rows.Add("idServicio", Master.idExpediente.ToString.Substring(0, 2))
                dtParametroComboEstadoEnviar.Rows.Add("idExpediente", Master.idExpediente)
            End If
            


        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        If sMensaje <> "" Then
            If sMensaje <> "Error" Then
                Dim strScript As String = "<script language=JavaScript>"
                strScript += "alert(""" & sMensaje & """);"
                strScript += "</script>"
                If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
                End If
                Session("Mensaje") = ""
            Else
                Session("Mensaje") = ""
            End If
        End If
    End Sub

#End Region


    'Private Sub cboNuevoEmpleado_NodeDataBound(sender As Object, e As Telerik.Web.UI.DropDownTreeNodeDataBoundEventArguments) Handles cboNuevoEmpleado.NodeDataBound
    '    If e.DropDownTreeNode.Level = 0 Then
    '        e.DropDownTreeNode.Checkable = False
    '    End If
    'End Sub
End Class