Imports prjDatos
Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Text
Imports Telerik.Reporting

Public Class rHistoricoJD
    Inherits System.Web.UI.Page
    Private sNombreMantenimiento As String = "Reporte Histórico de Juntas Directivas"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sMensaje = Session("Mensaje")
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            ShowReport()
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

    Sub ShowReport()
        Dim ta As Object
        Dim dt As DataTable = Nothing
     

        Dim iTipoReporte As String = Session("URTipoRep").ToString

        If iTipoReporte = "1" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_ReporteJuntaDirectivaHistTableAdapter
            dt = New Simex_DesDataSet.pUR_ReporteJuntaDirectivaHistDataTable
            ta.Fill(dt, Session("ID"), Nothing)

        ElseIf iTipoReporte = "2" Then

        End If

        Dim report As New Report1
        Dim objectDataSource As New Telerik.Reporting.ObjectDataSource()
        objectDataSource.DataSource = dt
        report.DataSource = objectDataSource

        Dim reportSource As New Telerik.Reporting.InstanceReportSource()
        reportSource.ReportDocument = report
        rp.ReportSource = reportSource

        rp.RefreshReport()

    End Sub


    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("~/URSAC/wfmRegistroJuntaDirectiva.aspx")
    End Sub
End Class