Imports prjDatos
Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports Spire.Barcode
Imports System.IO
Imports System.Data
Imports System.Text

Class URSACReportes
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = "pUR_RegistroRubro_List"
    Dim m_sAgregarRegistro = "pUR_RegistroRubro_Add"
    Dim m_sEliminarRegistro = "pUR_RegistroRubro_Delete"
    Private sNombreMantenimiento As String = "Informes y Contancias"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sMensaje = Session("Mensaje")
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
        End If
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

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
        ' Fill the datasource from DB
        Dim dFDesde As Date = Now
        Dim dFHasta As Date = Now
        Dim ta As Object
        Dim dt As DataTable = Nothing
        Dim sReportName As String = ""
        rp.Visible = True
        rpTel.Visible = False

        Me.rp.LocalReport.ReportPath = ""
        Me.rp.LocalReport.DataSources.Clear()
        Me.rp.LocalReport.Refresh()

        Dim iTipoReporte As String = Session("URTipoRep").ToString

        If Not (IsNothing(dFechaDesde.SelectedDate)) Then
            dFDesde = dFechaDesde.SelectedDate
        End If
        If Not IsNothing(dFechaHasta.SelectedDate) Then
            dFHasta = dFechaHasta.SelectedDate
        End If

        If iTipoReporte = "1" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_ReporteEstadoFinancieroTableAdapter
            dt = New Simex_DesDataSet.pUR_ReporteEstadoFinancieroDataTable
            ta.Fill(dt, Nothing, dFDesde, dFHasta)
            sReportName = "rptUR_ReporteFIN.rdlc"
        ElseIf iTipoReporte = "2" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_ReporteJuntaDirectivaTableAdapter
            dt = New Simex_DesDataSet.pUR_ReporteJuntaDirectivaDataTable
            ta.Fill(dt, Nothing, dFDesde, dFHasta)
            sReportName = "rptUR_ReporteJD.rdlc"
        ElseIf iTipoReporte = "3" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_RegistroSinJD_ListTableAdapter
            dt = New Simex_DesDataSet.pUR_RegistroSinJD_ListDataTable
            ta.Fill(dt)
            sReportName = "rptUR_RegistrosSinJD.rdlc"
        ElseIf iTipoReporte = "4" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_RegistroSinEstFin_ListTableAdapter
            dt = New Simex_DesDataSet.pUR_RegistroSinEstFin_ListDataTable
            ta.Fill(dt)
            sReportName = "rptUR_RegistrosSinEstFin.rdlc"
        ElseIf iTipoReporte = "5" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_JuntaDirectivaVigente_ListTableAdapter
            dt = New Simex_DesDataSet.pUR_JuntaDirectivaVigente_ListDataTable
            ta.Fill(dt, dFechaDesde.SelectedDate.Value.Year)
            sReportName = "rptUR_RegistrosJDVigenteA.rdlc"
        ElseIf iTipoReporte = "6" Then
            ta = New Simex_DesDataSetTableAdapters.pUR_EstadoFinancieroVigente_ListTableAdapter
            dt = New Simex_DesDataSet.pUR_EstadoFinancieroVigente_ListDataTable
            ta.Fill(dt, dFechaDesde.SelectedDate.Value.Year)
            sReportName = "rptUR_RegistrosEstFinVigente.rdlc"
        End If

        'Create Report Data Source
        Dim rptDataSource As New ReportDataSource()
        rptDataSource.Name = "DataSet1"
        rptDataSource.Value = dt

        Me.rp.LocalReport.ReportPath = Server.MapPath("~/Reportes/") & sReportName
        Me.rp.LocalReport.DataSources.Add(rptDataSource)

        If iTipoReporte < 3 Or 5 Or 6 Then
            dFDesde = dFechaDesde.SelectedDate
            If Not IsNothing(dFechaHasta.SelectedDate) Then
                dFHasta = dFechaHasta.SelectedDate
            End If
            Dim parametros As ReportParameter() = New ReportParameter(1) {}
            parametros(0) = New ReportParameter("FechaDesde", dFDesde.ToString)
            parametros(1) = New ReportParameter("FechaHasta", dFHasta.ToString)
            Me.rp.LocalReport.SetParameters(parametros)
        End If

        Me.rp.LocalReport.Refresh()
        Me.rp.ShowPrintButton = True

    End Sub

    Private Sub btnAddParam_Click(sender As Object, e As EventArgs) Handles btnAddParam.Click
        Try
            If isValidParam() Then
                ShowReport()
            Else
                Me.Mensaje(sMensaje)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    Private Function isValidParam() As Boolean
        Dim iTipoReporte As String = Session("URTipoRep").ToString
        If iTipoReporte < 3 Or 5 Or 6 Then
            If dFechaDesde.SelectedDate Is Nothing Then
                sMensaje = "La fecha inicial es requerida."
                Return False
            End If
            If dFechaHasta.Visible Then
                If dFechaHasta.SelectedDate Is Nothing Then
                    sMensaje = "La fecha final es requerida."
                    Return False
                End If
                If dFechaDesde.SelectedDate > dFechaHasta.SelectedDate Then
                    sMensaje = "La fecha final debe ser mayor que la fecha inicial."
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Sub ShowTelerikReport(report As Object)
        rpTel.Visible = True
        rp.Visible = False
        Dim reportSource As New Telerik.Reporting.InstanceReportSource()
        reportSource.ReportDocument = report
        rpTel.ReportSource = reportSource
        rpTel.RefreshReport()
    End Sub

    Protected Sub btnMostrarReporte_Click(sender As Object, e As EventArgs) Handles btnMostrarReporte.Click
        Try
            'CargarReporte()
            Select Case lstReportes.SelectedItem.Value
                Case 0 'Estados Financieros registrados por período
                    Session("URTipoRep") = 1
                    dlgFiltrosFin.Show()
                Case 1 'Juntas Directivas registradas por período
                    Session("URTipoRep") = 2
                    dlgFiltrosFin.Show()
                Case 2 'AC por Tipo de Asociación
                    Dim report As New AsociacionesCiviles
                    ShowTelerikReport(report)
                Case 3 'AC Total por Departamento
                    Dim report As New rACPorDepartamento
                    ShowTelerikReport(report)
                Case 4 'AC que no tienen Junta Directiva Registrada
                    Session("URTipoRep") = 3
                    ShowReport()
                Case 5 'AC que tienen est fin vencidas su plazo
                    Session("URTipoRep") = 4
                    ShowReport()
                Case 6 '
                    Session("URTipoRep") = 5
                    dFechaDesde.Label = "Año a Mostrar:   "
                    dFechaDesde.DateFormat = "yyyy"
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
                Case 7 'AC 
                    Session("URTipoRep") = 6
                    dFechaDesde.Label = "Año a Mostrar:   "
                    dFechaDesde.DateFormat = "yyyy"
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
            End Select
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub

    Sub CargarReporte()
        Try
            Select Case lstReportes.SelectedItem.Value
                Case 0 'Estados Financieros registrados por período
                    Session("URTipoRep") = 1
                    dFechaDesde.Label = "Fecha Desde:   "
                    dFechaDesde.DateFormat = "dd/mm/yyyy"
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
                Case 1 'Juntas Directivas registradas por período
                    Session("URTipoRep") = 2
                    dFechaDesde.DateFormat = "dd/mm/yyyy"
                    dFechaDesde.Label = "Fecha Desde:   "
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
                Case 2 'AC por Tipo de Asociación
                    Dim report As New AsociacionesCiviles
                    ShowTelerikReport(report)
                Case 3 'AC Total por Departamento
                    Dim report As New rACPorDepartamento
                    ShowTelerikReport(report)
                Case 4 'AC que no tienen Junta Directiva Registrada
                    Session("URTipoRep") = 3
                    ShowReport()
                Case 5 'AC que tienen est fin vencidas su plazo
                    Session("URTipoRep") = 4
                    ShowReport()
                Case 6 '
                    Session("URTipoRep") = 5
                    dFechaDesde.Label = "Año a Mostrar:   "
                    dFechaDesde.DateFormat = "yyyy"
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
                Case 7 'AC 
                    Session("URTipoRep") = 6
                    dFechaDesde.Label = "Año a Mostrar:   "
                    dFechaDesde.DateFormat = "yyyy"
                    dFechaHasta.Visible = False
                    dlgFiltrosFin.Show()
            End Select
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
End Class
