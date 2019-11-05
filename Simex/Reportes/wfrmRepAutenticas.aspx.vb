Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports prjDatos
Imports Spire.Barcode

Public Class wfrmRepAutenticas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Spire.Barcode.BarcodeSettings.ApplyKey("8LXF1-2G6GL-TBJZP-HL7CT-SANVP")
                ' Fill the datasource from DB
                Dim sCodigoRegistro As String = Session("idAutentica").ToString
                Dim ta As New Simex_DesDataSetTableAdapters.pAutenticas_ListTableAdapter()
                Dim dt As New Simex_DesDataSet.pAutenticas_ListDataTable

                ta.Fill(dt, sCodigoRegistro, Nothing, Nothing, Nothing, Nothing)

                ' Create and setup an instance of Bytescout Barcode SDK
                Dim bc As New BarCodeControl()
                bc.Type = Spire.Barcode.BarCodeType.Code39
                bc.ShowText = False

                Dim bc2 As New BarCodeControl()
                bc2.Type = Spire.Barcode.BarCodeType.QRCode
                bc2.ShowText = False

                ' Update DataTable with barcode image
                Dim row As Simex_DesDataSet.pAutenticas_ListRow

                For Each row In dt.Rows
                    ' Set the value to encode
                    bc.Data = row.NumeroAutentica.ToString
                    bc.Data2D = row.NumeroAutentica.ToString()
                    bc2.Data = My.Settings.URLMobilQ & row.NumeroAutentica.ToString()
                    bc2.Data2D = My.Settings.URLMobilQ & row.NumeroAutentica.ToString()

                    Dim generator As New BarCodeGenerator(bc)
                    Dim barcode As Image = generator.GenerateImage()
                    Dim generator2 As New BarCodeGenerator(bc2)
                    Dim barcode2 As Image = generator2.GenerateImage()

                    row.BarCode = ImageToBytes(barcode)
                    row.BaCodeQR = ImageToBytes(barcode2)
                Next

                dt.AcceptChanges()
                'Create Report Data Source
                Dim rptDataSource As New ReportDataSource()
                rptDataSource.Name = "DataSet1"
                rptDataSource.Value = dt

                Me.rp.LocalReport.ReportPath = Server.MapPath("rptAutentica.rdlc")
                Me.rp.LocalReport.DataSources.Add(rptDataSource)
                Me.rp.LocalReport.Refresh()
                Me.rp.ShowPrintButton = True
            Catch ex As Exception
                Throw (ex)
            End Try
        End If
    End Sub

    Private Function ImageToBytes(ByVal Image As Image) As Byte()
        Dim memImage As New System.IO.MemoryStream
        Dim bytImage() As Byte

        Image.Save(memImage, System.Drawing.Imaging.ImageFormat.Png)
        bytImage = memImage.GetBuffer()

        Return bytImage
    End Function

    Private Function BarCodeControlToBytes(ByVal Image As BarCodeControl) As Byte()
        Dim memImage As New System.IO.MemoryStream
        Dim bytImage() As Byte

        Image.SaveToStream(memImage, System.Drawing.Imaging.ImageFormat.Png)
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