Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports prjDatos
Imports Spire.Barcode

Public Class wfrmRepConstancias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("id") <> "" And Session("TipoReporte") <> "" Then
                LoadReport(Session("id"), Session("TipoReporte"))
            End If
        End If
    End Sub

    Sub LoadReport(idRecibo As String, sTipoReporte As String)
        Try
            ' Fill the datasource from DB
            Dim ta As New Simex_DesDataSetTableAdapters.pConstancia_ReportTableAdapter()
            Dim dt As New Simex_DesDataSet.pConstancia_ReportDataTable

            ta.Fill(dt, idRecibo)


            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.pConstancia_ReportRow

            For Each row In dt.Rows
                bc2.Data = My.Settings.URLConstMobilQ & row.IdConstancia.ToString()
                bc2.Data2D = My.Settings.URLConstMobilQ & row.IdConstancia.ToString()
                Dim generator2 As New BarCodeGenerator(bc2)
                Dim barcode2 As Image = generator2.GenerateImage()
                row.BaCodeQR = ImageToBytes(barcode2)
            Next

            dt.AcceptChanges()
            'Create Report Data Source
            Dim rptDataSource As New ReportDataSource()
            rptDataSource.Name = "DataSet1"
            rptDataSource.Value = dt
            Select Case sTipoReporte
                Case "E"
                    Me.rp.LocalReport.ReportPath = Server.MapPath("rptConstanciaE.rdlc")
                Case "PJ"
                    Me.rp.LocalReport.ReportPath = Server.MapPath("rptConstanciaE.rdlc")
                Case "V"
                    Me.rp.LocalReport.ReportPath = Server.MapPath("rptConstanciaE.rdlc")
            End Select
            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Function ImageToBytes(ByVal Image As Image) As Byte()
        Dim memImage As New System.IO.MemoryStream
        Dim bytImage() As Byte

        Image.Save(memImage, System.Drawing.Imaging.ImageFormat.Png)
        bytImage = memImage.GetBuffer()

        Return bytImage
    End Function

    Private Function BytesToImage(ByVal ImageBytes() As Byte) As Image
        Dim imgNew As Image
        Dim memImage As New System.IO.MemoryStream(ImageBytes)
        imgNew = Image.FromStream(memImage)
        Return imgNew
    End Function
End Class