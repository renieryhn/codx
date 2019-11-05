﻿Imports prjDatos
Public Class wfmArchivar
    Inherits System.Web.UI.Page
    Dim szExpedienteList = "pExpediente_List"
    Dim szBitacoraArchivoList = "pBitacoraArchivo_list"
    Dim szBitacoraAdd = "pBitacoraArchivo_Edit"
    Private sNombreMantenimiento As String = "Archivar Expediente"
    Private szMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Master.idExpediente <> "" Then
            Dim prams = cFunciones.dtDatos.Clone
            Dim pramsb = cFunciones.dtDatos.Clone
            prams.Rows.Add("id", Master.idExpediente.ToString)
            pramsb.Rows.Add("idExpediente", Master.idExpediente.ToString)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable(szExpedienteList, prams, szMensaje)
            If dtDatos.Rows.Count > 0 Then
                lblCajaAntrerior.Text = dtDatos.Rows(0).Item("idCaja").ToString()
            Else
                lblCajaAntrerior.Text = ""
            End If
            dtDatos = cFunciones.Filldatatable(szBitacoraArchivoList, pramsb, szMensaje)
            GVMovimiento.DataSource = dtDatos
            GVMovimiento.DataBind()
        End If
    End Sub

    Protected Sub btnIdCaja_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIdCaja.Click
        If tbIdCaja.Text <> "" Then
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("idExpediente", Master.idExpediente.ToString)
            prams.Rows.Add("idCaja", tbIdCaja.Text)
            If Not lblCajaAntrerior.Text = "" Then
                prams.Rows.Add("CajaAnterior", lblCajaAntrerior.Text)
                If lblCajaAntrerior.Text = tbIdCaja.Text Then
                    Return
                End If
            End If
            prams.Rows.Add("idUsuario", Master.Master.Usuario.ToString())
            cFunciones.ejecutar(szBitacoraAdd, prams, szMensaje)
            Mensaje(szMensaje)
        End If
    End Sub
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
        Session("Mensaje") = ""
    End Sub
End Class