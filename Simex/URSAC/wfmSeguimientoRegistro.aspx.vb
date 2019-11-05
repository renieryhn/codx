Imports prjDatos
Public Class wfmSeguimientoRegistro
    Inherits System.Web.UI.Page

#Region "Declaraciones"
    Dim cFunciones As New funciones
    Private sAgregarEstado As String = "pUR_DetalleRegistro_AgregarEstado"
    Private sNombreBusqueda As String = "pUR_DetalleRegistro_List"
    Private sNombreBorrado As String = "pUR_DetalleRegistro_Delete"
    Private sNombreRecepcionExpediente As String = "pUR_DetalleRegistro_Recibir"
    Private sNombreMantenimiento As String = "Seguimiento de Asociaciones Civiles"
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
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub
    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(2).Text
        Dim bEliminacionEspecial As Boolean = CBool(hActivarEliminacionEspecial.Value)

        If bEliminacionEspecial Then
            ok = cFunciones.Ejecutar("pUR_DetalleRegistro_DeleteEspecial", dtParametros(Codigo), sMensaje)
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
        If Master.NumRegistro <> "" And Not IsPostBack Then
            llenarGrid()
        End If
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim sDetalle As String = GridView1.Rows(e.NewEditIndex).Cells.Item(2).Text
        Dim sFecha As String = GridView1.Rows(e.NewEditIndex).Cells.Item(6).Text
        sFecha = Replace(sFecha, "&nbsp;", "")
        Session("idDetalleRegistro") = sDetalle
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
            If Master.NumRegistro <> "" Then
                GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
                GridView1.DataBind()
                dtDatos = bObtenerFechaRecepcion()

                If dtDatos.Rows(0).Item("FechaRecepcion").ToString = "" And dtDatos.Rows(0).Item("UsuarioRecibido").ToString.ToLower = Master.Master.Usuario.ToLower Then
                    btnRecibir.Enabled = True
                    Session("idDetalle") = dtDatos.Rows(0).Item("id").ToString
                    Session("idEstado") = dtDatos.Rows(0).Item("idEstado").ToString
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
            dtParametros.Rows.Add("NumRegistro", Master.NumRegistro)

        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosFechaRecepcion() As DataTable
        Try
            dtParametrosFechaRecepcion = cFunciones.dtDatos.Clone
            dtParametrosFechaRecepcion.Rows.Add("NumRegistro", Master.NumRegistro)
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
            dtParametros.Rows.Add("NumRegistro", Master.NumRegistro)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosRecepcion() As DataTable
        Try
            dtParametrosRecepcion = cFunciones.dtDatos.Clone
            dtParametrosRecepcion.Rows.Add("NumRegistro", Master.NumRegistro)
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
            'dtParametrosExportar.Rows.Add("Nombre", txtNombre.Text)
            'dtParametrosExportar.Rows.Add("Rol", cbRol.Text)
            'dtParametrosExportar.Rows.Add("Ubicación", cbUbicacion.Text)
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
                'dtParametroComboEstadoEnviar.Rows.Add("idServicio", Master.NumRegistro.ToString.Substring(0, 2))
                dtParametroComboEstadoEnviar.Rows.Add("NumRegistro", Master.NumRegistro)
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
                Response.Redirect("~/URSAC/wfmSeguimientoRegistro.aspx")
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
            ComentariosModificacion = "Registro:" & Master.NumRegistro & Session("Modificacion") & " DATOS NUEVOS: ESTADO:" & cboNuevoEstado.SelectedText
            ComentariosModificacion = ComentariosModificacion & " USUARIO RECIBE:" & cboNuevoEmpleado.SelectedText
            dtParametrosAgregarEstado = cFunciones.dtDatos.Clone
            dtParametrosAgregarEstado.Rows.Add("NumRegistro", Master.NumRegistro)
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


End Class