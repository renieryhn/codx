Imports prjDatos
Imports System.IO
Imports System.Drawing.Imaging
Public Class wfmTramites_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pTramites_List"
    Private sNombreBorrado As String = "pTramites_Delete"
    Private sNombreMantenimiento = "Libro de Registro de Asociaciones Comunitarias"

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
        GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
        GridView1.DataBind()
    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone

            tbxExpediente.Text = Replace(tbxExpediente.Text, "'", "-")
            dtParametros = cFunciones.dtDatos.Clone

            If txtNumRegistro.Text = "" Then
                dtParametros.Rows.Add("NumRegistro", txtNumRegistro.Text)
            Else
                dtParametros.Rows.Add("NumRegistro", "%" & txtNumRegistro.Text & "%")
            End If

            'dtParametros.Rows.Add(txtNumRegistro.FieldName, txtNumRegistro.Text)
            dtParametros.Rows.Add(txtEncargado.FieldName, txtEncargado.Text)
            dtParametros.Rows.Add(txtNombreAsoc.FieldName, txtNombreAsoc.Text)

            dtParametros.Rows.Add(txtFolio.FieldName, txtFolio.Text)
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


    Sub LimpiarFiltros()
        tbxExpediente.Text = ""
        txtEncargado.Text = ""
        txtFolio.Text = ""
        cboDepartamento.SelectedIndex = -1
        cboMunicipio.SelectedIndex = -1
        dtcFechaDesde.Value = ""
        dtcFechaHasta.Value = ""
    End Sub

End Class