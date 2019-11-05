﻿Imports prjDatos
Public Class wfmRequisitosSubServicios_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private CodigoSubServicio As String = ""
    Private CodigoRequisito As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pRequisitosSubServicios_List"
    Private sNombreBorrado As String = "pRequisitosSubServicios_Delete"
    Private sNombreMantenimiento = "Mantenimiento de Requisitos Sub Servicios"
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
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.AllowPaging = False
        llenarGrid()
        Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Requsitos con SubServicios")
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub
    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        CodigoSubServicio = GridView1.Rows(e.RowIndex).Cells(2).Text
        CodigoRequisito = GridView1.Rows(e.RowIndex).Cells(4).Text
        Ok = cFunciones.Ejecutar(sNombreBorrado, dtParametros(CodigoSubServicio, CodigoRequisito), sMensaje)
        Mensaje(sMensaje)
        If Ok Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkNuevo.NavigateUrl)
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("IdSubServicio") = GridView1.Rows(e.NewEditIndex).Cells(2).Text
        Session("IdRequisito") = GridView1.Rows(e.NewEditIndex).Cells(4).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
#End Region

#Region "Metodos"
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
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametrosExportar.Rows.Add("Requisito", txtNombre.Text)
            dtParametrosExportar.Rows.Add("Subservicio", cboSubServicio.Text)
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
            dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
            dtParametros.Rows.Add(cboServicio.FieldName, cboServicio.Value)
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametros(ByVal idSubServicio As String, ByVal idRequisito As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idSubServicio", idSubServicio)
            dtParametros.Rows.Add("idRequisito", idRequisito)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region

    Private Sub cboServicio_ComboChangedItem(sender As Object, e As EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub
End Class