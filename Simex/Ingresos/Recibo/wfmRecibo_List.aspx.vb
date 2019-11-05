﻿Imports prjDatos
Public Class wfmRecibo_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pRecibo_List"
    Private sNombreBorrado As String = "pRecibo_Delete"


#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click

        sMensaje = Session("Mensaje")
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
        If Not IsPostBack Then
            Bitacora()
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
            llenarGrid()
        End If
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.AllowPaging = False
        llenarGrid()
        Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Recibos")
    End Sub
    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/Reportes/wfmReporteador.aspx")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(2).Text
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
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(2).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
    Private Sub cboServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
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
            dtParametrosExportar.Rows.Add("Nombre", txtUsuario.Text)
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
            dtParametrosBitacora.Rows.Add("Comentario", "Ingreso al Modulo de Ingresos")
            dtParametrosBitacora.Rows.Add("Justificacion", "No Necesaria")
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub llenarGrid()
        If GridView1.DataSource Is Nothing Then
            cFunciones.Ejecutar("pBitacora_Add", dtParametrosBitacora)
            GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
            GridView1.DataBind()
        End If
    End Sub
    Private Sub Bitacora()

    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtUsuario.FieldName, txtUsuario.Text)
            dtParametros.Rows.Add(lblNumReciboFinanzas.Text, txtNumReciboFinanzas.Text)
            dtParametros.Rows.Add(txtId.FieldName, txtId.Text)
            dtParametros.Rows.Add(txtSolicitante.FieldName, txtSolicitante.Text)
            dtParametros.Rows.Add(txtValorDolares.FieldName, txtValorDolares.Text)
            dtParametros.Rows.Add(txtUsuario.FieldName, txtUsuario.Text)
            dtParametros.Rows.Add(cboOficina.FieldName, cboOficina.Value)
            dtParametros.Rows.Add(cboServicio.FieldName, cboServicio.Value)
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
            dtParametros.Rows.Add(dtcFechaEmisionDesde.FieldName, dtcFechaEmisionDesde.Value)
            dtParametros.Rows.Add(dtcFechaEmisionHasta.FieldName, dtcFechaEmisionHasta.Value)
            dtParametros.Rows.Add(dtcFechaPagoDesde.FieldName, dtcFechaPagoDesde.Value)
            dtParametros.Rows.Add(dtcFechaPagoHasta.FieldName, dtcFechaPagoHasta.Value)
            dtParametros.Rows.Add(cboPagado.FieldName, cboPagado.Value)
        Catch ex As Exception
            Throw (ex)
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
#End Region

End Class