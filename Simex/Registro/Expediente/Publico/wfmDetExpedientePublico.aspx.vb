﻿Imports prjDatos
Public Class wfmDetExpedientePublico
    Inherits System.Web.UI.Page

    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Private sNombreBusqueda As String = "pExpediente_List"

    Private Sub wfmDetExpedientePublico_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If

    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If txtNumExpediente.Valido Then
            Session("id") = txtNumExpediente.Text
            Response.Redirect("~/Registro/Expediente/Publico/wfmPropiedadesExpedientePublico.aspx")
        End If

    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Master.setNuevoVisible = False
        Master.setExportarVisible = False
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