Imports prjDatos
Imports System.Drawing
Imports System.Net.Mail
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class wfmSeguimientoExpediente
    Inherits System.Web.UI.Page
    Private dDataSeguimiento As DataTable
#Region "Declaraciones"
    Dim cFunciones As New funciones
    Private sAgregarEstado As String = "pDetalleExpediente_AgregarEstado"
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Private sNombreBorrado As String = "pDetalleExpediente_Delete"
    Private sNombreRecepcionExpediente As String = "pDetalleExpediente_Recibir"
    Private sNombreMantenimiento As String = "Seguimiento de Expediente"
    Dim ComentariosModificacion As String

    Dim sMensaje As String = ""
    Private Codigo As String = ""
    Dim dtDatos, dtCargaTrabajo As DataTable
    Dim ok As Boolean
    Public Event ComboChangedItem(ByVal sender As Object, ByVal e As EventArgs)
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AddHandler Master.PreRender, AddressOf Page_PreRender

            sMensaje = Session("Mensaje")
            Master.Master.m_titulo = sNombreMantenimiento
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            llenarGrid()
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Protected Sub btnRecibir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRecibir.Click
        ok = cFunciones.Ejecutar(sNombreRecepcionExpediente, dtParametrosRecepcion(), sMensaje)
        Mensaje(sMensaje)
        If ok Then
            llenarGrid()
            btnRecibir.Enabled = False
            NotificarApoderado(Session("idEstado").ToString)
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub

    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(2).Text
        Dim bEliminacionEspecial As Boolean = CBool(hActivarEliminacionEspecial.Value)

        If bEliminacionEspecial Then
            ok = cFunciones.Ejecutar("pDetalleExpediente_DeleteEspecial", dtParametros(Codigo), sMensaje)
            hActivarEliminacionEspecial.Value = False
        Else
            ok = cFunciones.Ejecutar(sNombreBorrado, dtParametros(Codigo), sMensaje)
        End If
        Mensaje(sMensaje)
        If ok Then
            llenarGrid()
            btnRecibir.Enabled = False
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkNuevo.NavigateUrl)
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Master.Master.e(GridView1, dtParametrosExportar, "Mantenimiento de Usuarios")
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Master.idExpediente <> "" And Not IsPostBack Then
            llenarGrid()
        End If
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim sDetalle As String = GridView1.Rows(e.NewEditIndex).Cells.Item(2).Text
        Dim sFecha As String = GridView1.Rows(e.NewEditIndex).Cells.Item(6).Text
        sFecha = Replace(sFecha, "&nbsp;", "")
        Session("idDetalleExpediente") = sDetalle
        Session("fechaConfirmacionAsignacion") = sFecha
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
#End Region

#Region "Metodos"
    Private Function bObtenerFechaRecepcion() As DataTable
        bObtenerFechaRecepcion = cFunciones.Filldatatable(sNombreBusqueda, dtParametrosFechaRecepcion, sMensaje)
        Session("Mensaje") = sMensaje
    End Function

    Private Sub llenarGrid()
        Try
            If Master.idExpediente <> "" Then
                dDataSeguimiento = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
                GridView1.DataSource = dDataSeguimiento
                GridView1.DataBind()
                dtDatos = bObtenerFechaRecepcion()

                If dtDatos.Rows(0).Item("FechaRecepcion").ToString = "" And dtDatos.Rows(0).Item("UsuarioRecibido").ToString.ToLower = Master.Master.Usuario.ToLower Then
                    btnRecibir.Enabled = True
                    Session("idDetalle") = dtDatos.Rows(0).Item("id").ToString
                    Session("idEstado") = dtDatos.Rows(0).Item("idEstado").ToString
                End If
                If Session("UsuarioRol") > 1 Then
                    If dtDatos.Rows(0).Item("FechaRecepcion").ToString = "" And dtDatos.Rows(0).Item("UsuarioRecibido").ToString.ToLower <> Master.Master.Usuario.ToLower Then
                        GridView1.Rows(0).Visible = False
                    End If
                End If
                Dim tblData As DataTable = cFunciones.Filldatatable("pEstado_List", dtParametroComboEstadoEnviar)
                With cboNuevoEstado
                    .DataFieldID = "Id"
                    .DataFieldParentID = ""
                    .DataValueField = "Id"
                    .DataTextField = "Nombre"
                    .DataSource = tblData
                    .DataBind()
                End With
                cboNuevoEmpleado.Enabled = True
                cboNuevoEmpleado.DataBind()

                Dim sRecibidoPor As String = GridView1.Rows(0).Cells.Item(9).Text
                Dim sFecha As String = GridView1.Rows(0).Cells.Item(4).Text


                If Master.Master.Alta And sFecha <> "&nbsp;" Then
                    btnAceptar.Enabled = True
                End If
                If sRecibidoPor.ToLower = Master.Master.Usuario.ToLower And sFecha <> "&nbsp;" Then
                    btnAceptar.Enabled = True
                Else
                    btnAceptar.Enabled = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idExpediente", Master.idExpediente)

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosFechaRecepcion() As DataTable
        Try
            dtParametrosFechaRecepcion = cFunciones.dtDatos.Clone
            dtParametrosFechaRecepcion.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosFechaRecepcion.Rows.Add("UltimoEstado", 1)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("ID", id)
            dtParametros.Rows.Add("idExpediente", Master.idExpediente)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosRecepcion() As DataTable
        Try
            dtParametrosRecepcion = cFunciones.dtDatos.Clone
            dtParametrosRecepcion.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosRecepcion.Rows.Add("idEstado", Session("idEstado").ToString)
            dtParametrosRecepcion.Rows.Add("idDetalle", Session("idDetalle").ToString)
            dtParametrosRecepcion.Rows.Add("idUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
        Catch ex As Exception
            Throw (ex)
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

#Region "Cambio de Estado de Expedientes"

    Public Function dtParametroComboEstadoEnviar() As DataTable
        Try
            dtParametroComboEstadoEnviar = cFunciones.dtDatos.Clone
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
    Private Function dtParametrosEmpleadoEstado() As DataTable
        Try
            dtParametrosEmpleadoEstado = cFunciones.dtDatos.Clone
            dtParametrosEmpleadoEstado.Rows.Add("idEstado", cboNuevoEstado.SelectedValue)
            dtParametrosEmpleadoEstado.Rows.Add("Recibir", "1")
            dtParametrosEmpleadoEstado.Rows.Add("Activo", "0")
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If cboNuevoEstado.SelectedValue.ToString() <> "" And cboNuevoEmpleado.SelectedValue.ToString() <> "" Then
            If bModificar() Then
                Response.Redirect("~/Registro/Expediente/wfmSeguimientoExpediente.aspx")
            End If
        Else
            Mensaje("Por favor seleccione el Estado y el Empleado")
        End If
    End Sub
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sAgregarEstado, dtParametrosAgregarEstado, sMensaje)
        'Mensaje(sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function dtParametrosAgregarEstado() As DataTable
        Try
            ComentariosModificacion = "Expediente:" & Master.idExpediente & Session("Modificacion") & " DATOS NUEVOS: ESTADO:" & cboNuevoEstado.SelectedText
            ComentariosModificacion = ComentariosModificacion & " USUARIO RECIBE:" & cboNuevoEmpleado.SelectedText
            dtParametrosAgregarEstado = cFunciones.dtDatos.Clone
            dtParametrosAgregarEstado.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosAgregarEstado.Rows.Add("idEstadoAsignado", cboNuevoEstado.SelectedValue)
            dtParametrosAgregarEstado.Rows.Add("idEmpleado", cboNuevoEmpleado.SelectedValue)
            dtParametrosAgregarEstado.Rows.Add("Modificacion", ComentariosModificacion)
            dtParametrosAgregarEstado.Rows.Add("idusuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function


    Protected Sub cboNuevoEstado2_EntryAdded(sender As Object, e As Telerik.Web.UI.DropDownTreeEntryEventArgs) Handles cboNuevoEstado.EntryAdded
        CambioEstado()
    End Sub

    Sub CambioEstado()
        Try
            If cboNuevoEstado.SelectedValue <> "-1" And cboNuevoEstado.SelectedValue <> Nothing Then
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

#End Region

#Region "Calculo de Retardo"
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            Dim sToolTip As String = ""
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim i As Integer = GridView1.PageSize * GridView1.PageIndex
                e.Row.BackColor = Retardos(e.Row.RowIndex + i, sToolTip)
                e.Row.ToolTip = sToolTip
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function Retardos(iRow As Integer, ByRef sToolTip As String) As System.Drawing.Color
        Try
            If IsNothing(dDataSeguimiento) Then
                Return Color.White
            End If
            If dDataSeguimiento.Rows.Count <= 0 Then
                Return Color.White
            End If
            sToolTip = 0
            Dim rColor As System.Drawing.Color = Drawing.Color.White
            Dim iDiasRetrazo As Integer = 0
            Dim iProm As Integer = 5
            Dim iMax As Integer = 10
            Dim idTipoEstado As Integer = 0
            Dim dAsignacion As Date = Now
            Dim dRecepcion As Date = Now

            If dDataSeguimiento.Rows(iRow).Item("FechaAsignacion").ToString <> "" Then
                dAsignacion = CDate(dDataSeguimiento.Rows(iRow).Item("FechaAsignacion"))
            End If
            If dDataSeguimiento.Rows(iRow).Item("FechaRecepcion").ToString <> "" Then
                dRecepcion = CDate(dDataSeguimiento.Rows(iRow).Item("FechaRecepcion"))
            End If

            idTipoEstado = dDataSeguimiento.Rows(iRow).Item("idTipoEstado")
            iDiasRetrazo = CalcularDiasHabiles(dAsignacion, dRecepcion)

            If Not IsNothing(dDataSeguimiento.Rows(iRow).Item("TiempoProm")) Then
                iProm = dDataSeguimiento.Rows(iRow).Item("TiempoProm")
            End If

            If Not IsNothing(dDataSeguimiento.Rows(iRow).Item("TiempoMax")) Then
                iMax = dDataSeguimiento.Rows(iRow).Item("TiempoMax")
            End If
            Select Case iDiasRetrazo
                Case Is <= iProm
                    rColor = Drawing.Color.White
                    sToolTip = "Trabajado en " & iDiasRetrazo.ToString & " días."
                Case Is <= iMax
                    rColor = Drawing.Color.Orange
                    sToolTip = "Trabajado por " & iDiasRetrazo.ToString & " días. Tiempo máximo permitido: " & iMax.ToString & " días."
                Case Else
                    rColor = Drawing.Color.Tomato
                    sToolTip = "Trabajado por " & iDiasRetrazo.ToString & " días. Tiempo máximo permitido: " & iMax.ToString & " días."
            End Select
            If idTipoEstado = 3 Then
                rColor = Drawing.Color.LightGray
                sToolTip = "Finalizado en " & iDiasRetrazo.ToString & " días."
            End If

            Return rColor
        Catch ex As Exception
            Return Drawing.Color.White
        End Try
    End Function

    Function CalcularDiasHabiles(dFechaAsignacion As Date, dFechaRecepcecion As Date) As Integer
        Try
            Dim Dias As Long = 0
            Dim iRes As Integer = 0

            Dias += DateDiff(DateInterval.Day, dFechaRecepcecion, dFechaAsignacion)
            If Dias = 0 And dFechaRecepcecion.ToShortDateString <> dFechaAsignacion.ToShortDateString Then
                Dias = 1
            End If
            iRes = (Dias / 7) * 2

            If dFechaAsignacion.DayOfWeek = DayOfWeek.Saturday Then
                iRes -= 2 ' Si el dia de la fecha de inicio es sabado, se restan sabado y domingo 
            ElseIf dFechaAsignacion.DayOfWeek = DayOfWeek.Sunday Then
                iRes -= 1 ' Si el dia de la fecha de inicio es domingo, se resata el domingo 
            End If

            If dFechaRecepcecion.DayOfWeek = DayOfWeek.Sunday Then
                iRes -= 2 ' Si el dia de la fecha de fin es domingo, se resta sabado y domingo 
            ElseIf dFechaRecepcecion.DayOfWeek = DayOfWeek.Saturday Then
                iRes -= 1 ' Si el dia de la fecha de fin es sabado, se resta el sabado 
            End If

            Return Dias + iRes
        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region

    Function NotificarApoderado(idEstado As String) As Boolean
        Try
            Dim dtParamEst As DataTable
            dtParamEst = cFunciones.dtDatos.Clone
            dtParamEst.Rows.Add("Id", idEstado)
            Dim tblDataEstado As DataTable = cFunciones.Filldatatable("pEstado_List", dtParamEst)
            If tblDataEstado.Rows.Count > 0 Then
                If tblDataEstado.Rows(0).Item("Notificar") = True Then
                    If Master.idTipoResponsable = "Apoderado" Then
                        Dim IdApodertado As Integer = Master.idResponsable
                        Dim sEmail As String = ""
                        Dim dtParam As DataTable = cFunciones.dtDatos.Clone
                        dtParam.Rows.Add("Id", IdApodertado)
                        Dim tblData As DataTable = cFunciones.Filldatatable("pApoderados_HasEmail", dtParam)
                        If tblData.Rows.Count > 0 Then
                            sEmail = tblData.Rows(0).Item("Email1").ToString
                            If sEmail <> "" Then
                                bEnviarEmail(sEmail)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ' Mensaje(ex.Message)
        End Try
    End Function

    Sub bEnviarEmail(sEmail As String)
        Try
            Dim iPos As Integer = GridView1.Columns.Count - 5
 
            Dim sRecibidoPor As String = GridView1.Rows(0).Cells.Item(iPos - 1).Text
            Dim sFecha As String = GridView1.Rows(0).Cells.Item(iPos - 2).Text
            Dim sEstado As String = GridView1.Rows(0).Cells.Item(iPos - 3).Text

            Dim sMsg As String = ""

            sMsg = "<html><head></head><body><b>"
            sMsg += "<h2><span style=""color:#337FE5;"">" & My.Settings.NombreLargoSistema & "</span></h2>"
            sMsg += " <p><hr /></p><p>Se le notifica que su expediente ha pasado al estado: " & sEstado
            sMsg += " <p><table style=""width:60%;"" cellpadding=""2"" cellspacing=""0"" border=""1"" bordercolor=""#000000"">"
            sMsg += " <tbody>"
            sMsg += " <tr>"
            sMsg += " <td>"
            sMsg += " <strong>Fecha:</strong>"
            sMsg += " </td>"
            sMsg += " <td>"
            sMsg += "" & sFecha
            sMsg += " </td>"
            sMsg += " </tr>"
            sMsg += " <tr>"
            sMsg += " <td>"
            sMsg += " <strong>Encargado Actual:</strong>"
            sMsg += " </td>"
            sMsg += " <td>"
            sMsg += "" & sRecibidoPor
            sMsg += " </td>"
            sMsg += " </tr>"
            sMsg += " </tbody>"
            sMsg += " </table>"
            sMsg += " <br />"
            sMsg += " <p>"
            sMsg += " <hr /></p><p>Puede Ingresar al sitema de trámites en línea aqui: https://ursac.sdhjgd.gob.hn &nbsp;</p><p>"
            sMsg += " <hr /></p><p>Cualquier Sugerencia o Comentario, puede escribirnos a: </p>" & My.Settings.EmailSoporte & " &nbsp;</p><p>"
            sMsg += " </p><p><span style=""line-height:1.5;"">Administrador <strong>CODEX</strong></span>"
            sMsg += " </p><p>" & My.Settings.NombreLargoSistema & "</p><p>"
            sMsg += "" & My.Settings.NombreSecretaria & "</p><p></p>"
            sMsg += " </p><p><br /></p>"
            sMsg += "</b></body>"

            mEmail.EnviarEmail(sEmail, "NOTIFICACIÓN DE ESTADO DE EXPEDIENTE: " & Master.idExpediente, sMsg)
        Catch ex As SmtpException
            Throw (ex)
        End Try
    End Sub
End Class