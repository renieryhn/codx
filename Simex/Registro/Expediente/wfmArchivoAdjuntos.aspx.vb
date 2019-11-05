﻿Imports prjDatos
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Public Class wfmArchivoAdjuntos
    Inherits System.Web.UI.Page
    Private cFunciones = New prjDatos.funciones()
    Private szListView = "pArchivoAdjunto_List"
    Private szSubirArchivo = "pArchivoAdjunto_Add"
    Private szBorrarArchivo = "pArchivoAdjunto_Delete"
    Private sNombreMantenimiento As String = "Adjuntar archivo"
    Private szMensaje = ""

    Protected Sub gvArchivosAdjuntos_SelectedIndexChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles gvArchivosAdjuntos.SelectedIndexChanged
        Dim objCommand = New SqlCommand()
        objCommand.Parameters.Add(New SqlParameter("id", gvArchivosAdjuntos.Rows(gvArchivosAdjuntos.SelectedIndex).Cells(2).Text))
        objCommand.Parameters.Add(New SqlParameter("MostrarAdjunto", "true"))
        Dim dtDatos = cFunciones.Filldatatable(szListView, objCommand)
        Dim bArr = dtDatos.Rows(0).item("Archivo")
        Dim path = System.IO.Path.GetTempPath().ToString() & dtDatos.Rows(0).item("Nombre")
        Dim output As New FileStream(path, FileMode.Create, FileAccess.Write)
        output.Write(bArr, 0, bArr.length)
        output.Close()
        Response.AddHeader("Content-Disposition", "attachment; filename=" & dtDatos.Rows(0).item("Nombre"))
        Response.WriteFile(path)
    End Sub

    Protected Sub Borrar(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvArchivosAdjuntos.RowDeleting
        Dim objCommand = New SqlCommand()
        objCommand.Parameters.Add(New SqlParameter("id", gvArchivosAdjuntos.Rows(e.RowIndex).Cells(2).Text))
        cFunciones.Ejecutar(szBorrarArchivo, objCommand, szMensaje)
        Session("Mensaje") = szMensaje
        Mensaje(szMensaje)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Master.idExpediente <> "" Then
            llenarGridView()
        End If
    End Sub

    Private Sub llenarGridView()
        Dim szMensaje = ""
        Dim dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("idExpediente", Master.idExpediente.ToString)
        Dim dtDatos = cFunciones.Filldatatable(szListView, dtParametros)
        gvArchivosAdjuntos.DataSource = dtDatos
        gvArchivosAdjuntos.DataBind()
        gvArchivosAdjuntos.Visible = True
    End Sub

    Protected Sub btnAdjuntar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdjuntar.Click
        If Not Insert() Then
            Mensaje(szMensaje)
        End If
    End Sub

    Public Function Insert() As Boolean
        Dim Ok = True
        Dim dTamaño As Double
        If fuAdjuntarArchivo.HasFile Then
            Dim objCommand = New SqlCommand()
            Dim param = New SqlParameter("idExpediente", Master.idExpediente.ToString)
            objCommand.Parameters.Add(param)
            Dim pathSplit = fuAdjuntarArchivo.FileName.Split("\")
            param = New SqlParameter("NombreArchivo", pathSplit(pathSplit.Count - 1))
            objCommand.Parameters.Add(param)
            param = New SqlParameter("Archivo", fuAdjuntarArchivo.FileBytes)


            objCommand.Parameters.Add(param)
            param = New SqlParameter("idUsuario", Master.Master.Usuario.ToString)
            objCommand.Parameters.Add(param)
            dTamaño = fuAdjuntarArchivo.FileBytes.Length / 1000000
            param = New SqlParameter("Tamaño", dTamaño)
            objCommand.Parameters.Add(param)

            Ok = cFunciones.Ejecutar(szSubirArchivo, objCommand, szMensaje)
            Session("Mensaje") = szMensaje
        End If
        Return Ok
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

#Region "Metodos"

#End Region


End Class