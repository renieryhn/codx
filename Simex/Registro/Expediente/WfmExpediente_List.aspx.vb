Imports prjDatos
Imports System.IO
Imports System.Drawing.Imaging

Public Class WfmExpedientes_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pExpediente_List"
    Private sServicio As String = "pServicios_List"
    Private sNombreBorrado As String = "pExpediente_Delete"
    Private sNombreCargaTrabajo As String = "pCargaTrabajoTree_List"
    Private sNombreMantenimiento As String = "Mantenimiento de Expedientes"
    Private dtCargaTrabajo As DataTable

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        sMensaje = Session("Mensaje")
        Master.Master.m_titulo = sNombreMantenimiento

        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If

        If Session("preBusqueda") <> "" Then
            tbxExpediente.Text = Session("id")
            Session("id") = ""
            Session("preBusqueda") = ""
            llenarGrid()
        End If
        If Not IsPostBack Then
            CargarValores()
            CargaTrabajo()
        End If
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub
    Protected Sub SeguimientoExpediente(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Codigo = GridView1.Rows(GridView1.SelectedIndex).Cells(3).Text
        Session("id") = Codigo
        Response.Redirect(linkSeguimiento.NavigateUrl)
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Session("Empleado") = "" Then
            GridView1.Columns(0).Visible = Master.Master.Modificacion
        Else
            GridView1.Columns(0).Visible = 1
        End If
        GridView1.Columns(1).Visible = Master.Master.Modificacion
        GridView1.Columns(2).Visible = Master.Master.Borrado
    End Sub
    Private Sub CargarValores()
        Try
            Dim tblData As DataTable = cFunciones.Filldatatable("pUsuario_List", dtParametrosEmpleado)
            With cboEmpleado
                .DataFieldID = "IdEmpleado"
                .DataValueField = "IdEmpleado"
                .DataTextField = "NombreEmpleado"
                .DataSource = tblData
                .DataBind()
            End With
            cboEmpleado.DataBind()
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub
    Public Function dtParametrosEmpleado() As DataTable
        Try
            dtParametrosEmpleado = cFunciones.dtDatos.Clone
            dtParametrosEmpleado.Rows.Add("Usuario", 0)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.AllowPaging = False
        llenarGrid()
        Master.Exportar(GridView1, dtParametrosExportar, "Consulta de Expedientes")
    End Sub
    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/Reportes/wfmReporteador.aspx")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tbxExpediente.Text = "" Then
            Session("SinRecibir") = ""
            Session("SinEnviar") = ""
            Session("EnviadoSinRecibir") = ""
            Session("Empleado") = ""
        End If
        llenarGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(3).Text
        Dim s As String = GridView1.Rows(e.RowIndex).ID
        Ok = cFunciones.Ejecutar(sNombreBorrado, dtParametros(Codigo), sMensaje)
        Mensaje(sMensaje)
        If Ok Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkNuevo.NavigateUrl)
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(3).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
    Private Sub cboServicioFiltro_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicioFiltro.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub
    Private Sub cboDepartamento_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.ComboChangedItem
        cboMunicipio.LLenarCombo(sender)
    End Sub
#End Region

#Region "Metodos"
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametrosBitacora(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBitacora = cFunciones.dtDatos.Clone
            dtParametrosBitacora.Rows.Add("NombreUsuario", Master.Master.Usuario)
            dtParametrosBitacora.Rows.Add("idModificacion", 2)
            dtParametrosBitacora.Rows.Add("idAccion", 1)
            dtParametrosBitacora.Rows.Add("Comentario", "Ingreso al Modulo de Expedientes")
            dtParametrosBitacora.Rows.Add("Justificacion", "No Necesaria")
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub llenarGrid()
        Try
            If GridView1.DataSource Is Nothing Then
                Dim tbl As DataTable = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
                GridView1.DataSource = tbl
                GridView1.DataBind()
                lblTotal.Text = "Total de Expedientes Encontrados: " & tbl.Rows.Count
            End If
            Page.SetFocus(tbxExpediente)
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub
    Sub CargaTrabajo()
        Try
            If Not LoadTree() Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Function LoadTree() As Boolean
        Try
            Dim dtServicio As DataTable
            Dim dtParams As DataTable
            dtParams = cFunciones.dtDatos.Clone
            dtParams.Rows.Add("IdModulo", 1)
            Dim i As Integer
            dtServicio = cFunciones.Filldatatable(sServicio, dtParams, sMensaje)
            tvData.Nodes.Clear()
            Dim sPath As String = sObtenerFotoEmp()

            sPath = Me.GenerateThumbnail(sPath)

            Dim MasterNode As New TreeNode(Session("Usuario"), "0", sPath)
            tvData.Nodes.Add(MasterNode)

            Dim tCargaTrabajo As DataTable = cFunciones.Filldatatable(sNombreCargaTrabajo, dtParametrosCargaTrabajo, sMensaje)


            Dim cNode1 As New TreeNode("Sin Recibir", "1", "~/Imagenes/SinRecibir.png")
            cNode1.Text += GetSumTreeValues(1, tCargaTrabajo)
            MasterNode.ChildNodes.Add(cNode1)
            Dim cNode2 As New TreeNode("Sin Enviar", "2", "~/Imagenes/SinEnviar.png")
            cNode2.Text += GetSumTreeValues(2, tCargaTrabajo)
            MasterNode.ChildNodes.Add(cNode2)
            Dim cNode3 As New TreeNode("Enviado Sin Recibir", "3", "~/Imagenes/EnviadoSinRecibir.png")
            cNode3.Text += GetSumTreeValues(3, tCargaTrabajo)
            MasterNode.ChildNodes.Add(cNode3)

            Dim sNombre As String = ""
            For i = 0 To dtServicio.Rows.Count - 1
                Dim sNombreServ As String = dtServicio.Rows(i).Item("Nombre").ToString
                If Len(sNombreServ) > 20 Then
                    sNombreServ = Left(sNombreServ, 20) + "..."
                End If
                Dim cDetNote As New TreeNode(sNombreServ, dtServicio.Rows(i).Item("Id").ToString, "~/Imagenes/Folder.png")
                Dim cDetNote2 As New TreeNode(sNombreServ, dtServicio.Rows(i).Item("Id").ToString, "~/Imagenes/Folder.png")
                Dim cDetNote3 As New TreeNode(sNombreServ, dtServicio.Rows(i).Item("Id").ToString, "~/Imagenes/Folder.png")
                cDetNote.Text += GetTreeValues(1, dtServicio.Rows(i).Item("Id").ToString, tCargaTrabajo)
                cDetNote.ToolTip = dtServicio.Rows(i).Item("Nombre").ToString
                cNode1.ChildNodes.Add(cDetNote)
                cDetNote2.Text += GetTreeValues(2, dtServicio.Rows(i).Item("Id").ToString, tCargaTrabajo)
                cDetNote2.ToolTip = dtServicio.Rows(i).Item("Nombre").ToString
                cNode2.ChildNodes.Add(cDetNote2)
                cDetNote3.Text += GetTreeValues(3, dtServicio.Rows(i).Item("Id").ToString, tCargaTrabajo)
                cDetNote3.ToolTip = dtServicio.Rows(i).Item("Nombre").ToString
                cNode3.ChildNodes.Add(cDetNote3)
            Next
            tvData.ExpandAll()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetTreeValues(intVal As Integer, sServicio As String, tCargaTrabajo As DataTable) As String
        Try
            Dim i As Integer
            Dim sCampo As String = ""
            GetTreeValues = ""
            Select Case intVal
                Case 1
                    sCampo = "SinRecibir"
                Case 2
                    sCampo = "SinEnviar"
                Case 3
                    sCampo = "EnviadoSinRecibir"
            End Select
            For i = 0 To tCargaTrabajo.Rows.Count - 1
                If tCargaTrabajo.Rows(i).Item("Id") = sServicio And tCargaTrabajo.Rows(i).Item(sCampo) <> 0 Then
                    GetTreeValues = "<font color='red'> <B>(" & tCargaTrabajo.Rows(i).Item(sCampo).ToString & ")</B></font>"
                    Exit For
                End If
            Next
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Function GetSumTreeValues(intVal As Integer, tCargaTrabajo As DataTable) As String
        Dim i As Integer
        Dim dValor As Double = 0
        Dim sCampo As String = ""
        Select Case intVal
            Case 1
                sCampo = "SinRecibir"
            Case 2
                sCampo = "SinEnviar"
            Case 3
                sCampo = "EnviadoSinRecibir"
        End Select
        If Not tCargaTrabajo Is Nothing Then
            For i = 0 To tCargaTrabajo.Rows.Count - 1
                dValor += tCargaTrabajo.Rows(i).Item(sCampo)
            Next
        Else
            dValor = 0
        End If

        Return " (" & dValor.ToString & ")"
    End Function

    Private Function dtParametros() As DataTable
        Try
            tbxExpediente.Text = Replace(tbxExpediente.Text, "'", "-")
            dtParametros = cFunciones.dtDatos.Clone

            If tbxExpediente.Text = "" Then
                dtParametros.Rows.Add("Id", tbxExpediente.Text)
            Else
                dtParametros.Rows.Add("Id", "%" & tbxExpediente.Text & "%")
            End If

            dtParametros.Rows.Add(txtEncargado.FieldName, txtEncargado.Text)
            dtParametros.Rows.Add(txtSolicitante.FieldName, txtSolicitante.Text)
            dtParametros.Rows.Add(txtNumDictamen.FieldName, txtNumDictamen.Text)
            dtParametros.Rows.Add(txtNumResolucion.FieldName, txtNumResolucion.Text)
            If cboSubServicio.Value = Nothing Then
                dtParametros.Rows.Add(cboServicioFiltro.FieldName, cboServicioFiltro.Value)
            End If
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
            dtParametros.Rows.Add(cboDepartamento.FieldName, cboDepartamento.Value)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(dtcFechaDesde.FieldName, dtcFechaDesde.Value)
            dtParametros.Rows.Add(dtcFechaHasta.FieldName, dtcFechaHasta.Value)
            dtParametros.Rows.Add(txtCodigoApo.FieldName, Me.txtCodigoApo.Text)
            If tbxExpediente.Text = "" Then
                dtParametros.Rows.Add("SinRecibir", Session("SinRecibir"))
                dtParametros.Rows.Add("SinEnviar", Session("SinEnviar"))
                dtParametros.Rows.Add("idUsuario", Session("Empleado"))
                dtParametros.Rows.Add("EnviadoSinRecibir", Session("EnviadoSinRecibir"))
                dtParametros.Rows.Add(cboServicioFiltro.FieldName, Session("Servicio"))
            End If
            dtParametros.Rows.Add("TipoFecha", rbtnList.SelectedIndex + 1)
            dtParametros.Rows.Add("idEmpleado", cboEmpleado.SelectedValue)
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function
    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("ID", id)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametrosCargaTrabajo() As DataTable
        Try
            dtParametrosCargaTrabajo = cFunciones.dtDatos.Clone
            'dtParametrosCargaTrabajo.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametrosCargaTrabajo.Rows.Add("idUsuario", Session("Usuario"))
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Print" Then
            Dim rowIndex As Integer = e.CommandArgument
            Session("ID") = GridView1.Rows(rowIndex).Cells(3).Text
            Response.Redirect("~/Reportes/ExReporter.aspx")
        End If
    End Sub

    Sub LimpiarFiltros()
        Session("EnviadoSinRecibir") = ""
        Session("SinRecibir") = ""
        Session("SinEnviar") = ""
        Session("Empleado") = ""
        Session("Servicio") = ""
        tbxExpediente.Text = ""
        txtCodigoApo.Text = ""
        txtNumDictamen.Text = ""
        txtSolicitante.Text = ""
        txtEncargado.Text = ""
        txtNumResolucion.Text = ""
        cboServicioFiltro.SelectedIndex = -1
        cboSubServicio.SelectedIndex = -1
        cboDepartamento.SelectedIndex = -1
        cboMunicipio.SelectedIndex = -1
        dtcFechaDesde.Value = ""
        dtcFechaHasta.Value = ""
        rbtnList.SelectedIndex = 0
    End Sub

    Protected Sub tvData_SelectedNodeChanged(sender As Object, e As EventArgs) Handles tvData.SelectedNodeChanged
        LimpiarFiltros()
        If tvData.SelectedNode.Value.ToString <> "0" Then
            Select Case tvData.SelectedNode.Parent.Value
                Case 0
                    Select Case tvData.SelectedNode.Value
                        Case 1
                            Session("SinRecibir") = 1
                        Case 2
                            Session("SinEnviar") = 1
                        Case 3
                            Session("EnviadoSinRecibir") = 1
                    End Select
                Case 1
                    Session("SinRecibir") = 1
                    Session("Servicio") = tvData.SelectedNode.Value
                Case 2
                    Session("SinEnviar") = 1
                    Session("Servicio") = tvData.SelectedNode.Value
                Case 3
                    Session("EnviadoSinRecibir") = 1
                    Session("Servicio") = tvData.SelectedNode.Value
            End Select
        End If
        Session("Empleado") = Master.Master.Usuario
        llenarGrid()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.BackColor = Retardos(e.Row.Cells(3).Text, CDate(e.Row.Cells(17).Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function sObtenerFotoEmp() As String
        Try
            Dim dtParametros As DataTable
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("Nombre", Session("Usuario"))
            dtParametros.Rows.Add("Usuario", 0)
            Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_List", dtParametros)
            sObtenerFotoEmp = ""
            If tbl.Rows.Count > 0 Then
                If tbl.Rows(0).Item("FotoURL").ToString <> "" Then
                    sObtenerFotoEmp = tbl.Rows(0).Item("FotoURL").ToString
                    If Not File.Exists(Server.MapPath(sObtenerFotoEmp)) Then
                        sObtenerFotoEmp = ""
                    End If
                End If
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Function GenerateThumbnail(sPath As String) As String
        Dim sThumbnail As String = "~/Imagenes/user.png"
        If sPath <> "" Then
            Dim path As String = Server.MapPath(sPath)
            Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(path)
            Using thumbnail As System.Drawing.Image = image.GetThumbnailImage(50, 50, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback), IntPtr.Zero)
                Using memoryStream As New MemoryStream()
                    thumbnail.Save(memoryStream, ImageFormat.Png)
                    Dim bytes As [Byte]() = New [Byte](memoryStream.Length - 1) {}
                    memoryStream.Position = 0
                    memoryStream.Read(bytes, 0, CInt(bytes.Length))
                    Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                    sThumbnail = "data:image/png;base64," & base64String
                End Using
            End Using
        End If
        Return sThumbnail
    End Function
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Function Retardos(idExpediente As String, dFechaUltimoEstado As Date) As System.Drawing.Color
        Try
            Dim dtParametros As DataTable
            Dim rColor As System.Drawing.Color = Drawing.Color.White
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("Expediente", idExpediente)
            Dim tbl As DataTable = cFunciones.Filldatatable("pAlertas_List", dtParametros)

            Dim dAsignacion As Date = dFechaUltimoEstado
            Dim iDiasRetrazo As Integer = 0
            Dim iProm As Integer = 30
            Dim iMax As Integer = 60
            Dim idTipoEstado As Integer = 0
            If Not IsNothing(tbl) Then
                If tbl.Rows.Count > 0 Then
                    idTipoEstado = tbl.Rows(0).Item("idTipoEstado")
                    iDiasRetrazo = CalcularDiasHabiles(tbl.Rows(0).Item("Fecha"))
                    If Not IsNothing(tbl.Rows(0).Item("TiempoProm")) Then
                        iProm = tbl.Rows(0).Item("TiempoProm")
                    End If
                    If Not IsNothing(tbl.Rows(0).Item("TiempoMax")) Then
                        iMax = tbl.Rows(0).Item("TiempoMax")
                    End If
                    Select Case iDiasRetrazo
                        Case Is <= iProm
                            rColor = Drawing.Color.White
                        Case Is <= iMax
                            rColor = Drawing.Color.Orange
                        Case Else
                            rColor = Drawing.Color.Tomato
                    End Select
                    If idTipoEstado = 3 Then
                        rColor = Drawing.Color.LightGray
                    End If
                End If
            End If
            Return rColor
        Catch ex As Exception
            Return Drawing.Color.White
        End Try
    End Function

    Function CalcularDiasHabiles(dFechaAsig As Date) As Integer
        Try
            Dim Dias As Integer = 0

            Dias = DateDiff(DateInterval.Day, dFechaAsig, Now, )
            Dias = (Dias / 7) * 2

            If dFechaAsig.DayOfWeek = DayOfWeek.Saturday Then
                Dias -= 2 ' Si el dia de la fecha de inicio es sabado, se restan sabado y domingo 
            ElseIf dFechaAsig.DayOfWeek = DayOfWeek.Sunday Then
                Dias -= 1 ' Si el dia de la fecha de inicio es domingo, se resata el domingo 
            End If

            If Now.DayOfWeek = DayOfWeek.Sunday Then
                Dias -= 2 ' Si el dia de la fecha de fin es domingo, se resta sabado y domingo 
            ElseIf Now.DayOfWeek = DayOfWeek.Saturday Then
                Dias -= 1 ' Si el dia de la fecha de fin es sabado, se resta el sabado 
            End If

            Return Dias
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class