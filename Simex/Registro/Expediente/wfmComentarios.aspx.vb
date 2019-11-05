﻿Imports prjDatos
Public Class wfmComentarios
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Dim Ok As Boolean
    Dim iId As String
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Private sNombreNuevoComentario As String = "pDetalleExpediente_Edit"
    Private sNombreMantenimiento As String = "Comentarios de Expediente"
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        sMensaje = Session("Mensaje")
        Master.Master.m_titulo = sNombreMantenimiento
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
        'If Not IsPostBack Then
        '    llenarGrid()
        'End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar0.Click
        bModificar()
        llenarGrid()
    End Sub
    Protected Sub btnAgregarComentario_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarComentario.Click
        mpeAgregarComentario.Show()
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Master.idExpediente <> "" Then
            llenarGrid()
        End If
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub
#End Region
#Region "Metodos"
    Private Sub llenarGrid()
        GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
        GridView1.DataBind()
    End Sub
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreNuevoComentario, dtParametrosComentario, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idExpediente", Master.idExpediente)
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosComentario() As DataTable
        Try
            dtParametrosComentario = cFunciones.dtDatos.Clone
            dtParametrosComentario.Rows.Add("idExpediente", Master.idExpediente)
            'dtParametrosComentario.Rows.Add("Comentario", txtComentarios.Text)
            dtParametrosComentario.Rows.Add("Comentario", txtComentarios2.Text)
            dtParametrosComentario.Rows.Add("idusuario", Master.Master.Usuario)
        Catch ex As Exception
            'Throw (ex)
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