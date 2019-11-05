Imports prjDatos
Imports System.IO
Imports System.Drawing.Imaging
Public Class wfmAsociacionesCiviles_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pUR_Registro_List"
    Private sNombreBorrado As String = "pUR_Registro_Delete"
    Private sNombreCargaTrabajo As String = "pUR_CargaTrabajo_List"
    Private sNombreMantenimiento = "Registro de Asociaciones Civiles"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        sMensaje = Session("Mensaje")
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If


    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            LimpiarFiltros()
            CargaTrabajo()
            If Session("preBusqueda") <> "" Then
                txtNumRegistro.Text = Session("NumRegistro")
                Session("NumRegistro") = ""
                Session("preBusqueda") = ""
            End If
            llenarGrid()
        End If
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.AllowPaging = False
        llenarGrid()
        Master.Exportar(GridView1, dtParametrosExportar, "Registro de Asociaciones Civiles")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("EnviadoSinRecibir") = ""
        Session("SinRecibir") = ""
        Session("SinEnviar") = ""
        Session("Empleado") = ""
        Session("Servicio") = ""
        llenarGrid()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.Cells(15).Text = "A" Then
                    e.Row.BackColor = Drawing.Color.White
                Else
                    e.Row.BackColor = Drawing.Color.Gray
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(3).Text
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
        Session("idRegistro") = GridView1.Rows(e.NewEditIndex).Cells(3).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
    Protected Sub SeguimientoExpediente(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Codigo = GridView1.Rows(GridView1.SelectedIndex).Cells(3).Text
        Session("idRegistro") = Codigo
        Response.Redirect(linkSeguimiento.NavigateUrl)
    End Sub
    Private Sub cboTipo(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAsoc.ComboChangedItem
        cboSubtipo.LLenarCombo(sender)
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
            dtParametrosExportar.Rows.Add(txtNumRegistro.FieldName, txtNumRegistro.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub llenarGrid()
        Dim tbl As DataTable = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
        GridView1.DataSource = tbl
        GridView1.DataBind()
        lblTotal.Text = "Total de Expedientes Encontrados: " & tbl.Rows.Count
        GridView1.DataBind()
    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone

            tbxExpediente.Text = Replace(tbxExpediente.Text, "'", "-")
            dtParametros = cFunciones.dtDatos.Clone

            If tbxExpediente.Text = "" Then
                dtParametros.Rows.Add("NumExpediente", tbxExpediente.Text)
            Else
                dtParametros.Rows.Add("NumExpediente", "%" & tbxExpediente.Text & "%")
            End If
            dtParametros.Rows.Add(txtNumRegistro.FieldName, txtNumRegistro.Text)
            dtParametros.Rows.Add(txtEncargado.FieldName, txtEncargado.Text)
            dtParametros.Rows.Add(txtNombreAsoc.FieldName, txtNombreAsoc.Text)
            dtParametros.Rows.Add(txtSiglas.FieldName, txtSiglas.Text)
            dtParametros.Rows.Add(txtNumResolucion.FieldName, txtNumResolucion.Text)
            If cboSubtipo.Value = Nothing Then
                dtParametros.Rows.Add(cboTipoAsoc.FieldName, cboTipoAsoc.Value)
            End If
            dtParametros.Rows.Add(cboSubtipo.FieldName, cboSubtipo.Value)
            dtParametros.Rows.Add(cboDepartamento.FieldName, cboDepartamento.Value)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(dtcFechaDesde.FieldName, dtcFechaDesde.Value)
            dtParametros.Rows.Add(dtcFechaHasta.FieldName, dtcFechaHasta.Value)

            If txtNumRegistro.Text = "" Then
                dtParametros.Rows.Add("SinRecibir", Session("SinRecibir"))
                dtParametros.Rows.Add("SinEnviar", Session("SinEnviar"))
                dtParametros.Rows.Add("idUsuario", Session("Empleado"))
                dtParametros.Rows.Add("EnviadoSinRecibir", Session("EnviadoSinRecibir"))
            End If
            If cboRubro.SelectedIndex > 0 Then
                dtParametros.Rows.Add(cboRubro.FieldName, cboRubro.Value)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametros(ByVal NumRegistro As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("NumRegistro", NumRegistro)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region

#Region "Arbol"
    Protected Sub tvData_SelectedNodeChanged(sender As Object, e As EventArgs) Handles tvData.SelectedNodeChanged
        LimpiarFiltros()
        If tvData.SelectedNode.Value.ToString <> "0" Then           
            Select Case tvData.SelectedNode.Value
                Case 1
                    Session("SinRecibir") = 1
                Case 2
                    Session("SinEnviar") = 1
                Case 3
                    Session("EnviadoSinRecibir") = 1
            End Select
        End If
        Session("Empleado") = Master.Master.Usuario
        llenarGrid()
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
            Dim dtParams As DataTable
            dtParams = cFunciones.dtDatos.Clone
            Dim i As Integer
            Dim sPath As String = sObtenerFotoEmp()

            sPath = Me.GenerateThumbnail(sPath)

            tvData.Nodes.Clear()

            Dim MasterNode As New TreeNode(Master.Master.Usuario, "0", sPath)
            tvData.Nodes.Add(MasterNode)

            Dim tCargaTrabajo As DataTable = cFunciones.Filldatatable(sNombreCargaTrabajo, dtParametrosCargaTrabajo, sMensaje)

            Dim cNode1 As New TreeNode("Sin Recibir", "1", "~/Imagenes/SinRecibir.png")
            cNode1.Text += "<font color='red'> <B>(" & tCargaTrabajo.Rows(i).Item("totalSinRecibir").ToString & ")</B></font>"
            MasterNode.ChildNodes.Add(cNode1)
            Dim cNode2 As New TreeNode("Sin Enviar", "2", "~/Imagenes/SinEnviar.png")
            cNode2.Text += "<font color='red'> <B>(" & tCargaTrabajo.Rows(i).Item("totalSinEnviar").ToString & ")</B></font>"
            MasterNode.ChildNodes.Add(cNode2)
            Dim cNode3 As New TreeNode("Enviado Sin Recibir", "3", "~/Imagenes/EnviadoSinRecibir.png")
            cNode3.Text += "<font color='red'> <B>(" & tCargaTrabajo.Rows(i).Item("totalEnviadoSinRecibir").ToString & ")</B></font>"
            MasterNode.ChildNodes.Add(cNode3)

            tvData.ExpandAll()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function dtParametrosCargaTrabajo() As DataTable
        Try
            dtParametrosCargaTrabajo = cFunciones.dtDatos.Clone
            dtParametrosCargaTrabajo.Rows.Add("idUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Sub LimpiarFiltros()
        Session("EnviadoSinRecibir") = ""
        Session("SinRecibir") = ""
        Session("SinEnviar") = ""
        Session("Empleado") = ""
        Session("Servicio") = ""
        tbxExpediente.Text = ""

        txtEncargado.Text = ""
        txtNumResolucion.Text = ""
        
        cboDepartamento.SelectedIndex = -1
        cboMunicipio.SelectedIndex = -1
        dtcFechaDesde.Value = ""
        dtcFechaHasta.Value = ""

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
#End Region
End Class