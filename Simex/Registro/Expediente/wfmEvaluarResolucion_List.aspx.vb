﻿Imports prjDatos
Public Class wfmEvaluarResolucion_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pResoluciones_List"
    Private sNombreEdicion As String = "pResoluciones_Edit"
    Private sNombreEdicionExpediente As String = "pExpediente_AnularResolucion"
    Private sNombreMantenimiento As String = "Listado de Resoluciones"
#Region "Eventos"
    Private Sub btnAgregarComentario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarComentario.Click
        bModificar()
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        'AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        'AddHandler Master.PreRender, AddressOf Page_PreRender
        'AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
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
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub
    'Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Departamentos")
    'End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub


    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(1).Text
        ' Response.Redirect(linkModificar.NavigateUrl)
    End Sub
#End Region

#Region "Metodos"
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreEdicion, dtParametrosDictamen, sMensaje)

        Session("Mensaje") = sMensaje
        Return Ok
    End Function
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
            ' dtParametrosExportar.Rows.Add("Nombre", txtNombre.Text)
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
            ' dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosDictamen() As DataTable
        Try
            dtParametrosDictamen = cFunciones.dtDatos.Clone
            dtParametrosDictamen.Rows.Add("id", Session("ID"))
            dtParametrosDictamen.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosDictamen.Rows.Add("Justificacion", txtComentarios.Text)
            dtParametrosDictamen.Rows.Add("idusuario", Master.Master.Usuario)
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
#End Region

   
End Class