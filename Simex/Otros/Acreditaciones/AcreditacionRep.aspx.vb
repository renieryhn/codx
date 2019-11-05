Imports prjDatos
Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports Spire.Barcode
Imports System.IO
Imports System.Data
Imports System.Text

Class AcreditacionRep
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = "pUR_Acreditaciones_List"
    Dim m_sAgregarRegistro = "pUR_Acreditaciones_Add"
    Dim m_sEliminarRegistro = "pUR_Acreditaciones_Delete"
    Private sNombreMantenimiento As String = "Acreditaciones"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sMensaje = Session("Mensaje")
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            Spire.Barcode.BarcodeSettings.ApplyKey("8LXF1-2G6GL-TBJZP-HL7CT-SANVP")
            ShowTelerikReport()
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

    Sub ShowTelerikReport(Optional bAllYear As Boolean = False)
        Try
            Me.rp.LocalReport.ReportPath = ""
            Me.rp.LocalReport.DataSources.Clear()
            Me.rp.LocalReport.Refresh()

            Dim sAcre As String = Session("IdAcre")
            If sAcre = "" Then
                Exit Sub
            End If
            Dim ta As New Simex_DesDataSetTableAdapters.AcreditacionesTableAdapter
            Dim dt As New Simex_DesDataSet.AcreditacionesDataTable

            If Not bAllYear Then
                ta.FillByCodigo(dt, sAcre)
            Else
                ta.FillByYear(dt, txtYear.Text)
            End If
            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.AcreditacionesRow

            ' Create and setup an instance of Bytescout Barcode SDK
            Dim bc As New BarCodeControl()
            bc.Type = Spire.Barcode.BarCodeType.Code39
            bc.ShowText = False

            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            For Each row In dt.Rows
                ' Set the value to encode
                bc.Data = row.ID.ToString()
                bc.Data2D = row.ID.ToString()
                bc2.Data = My.Settings.URLAcreQR & row.ID.ToString()
                bc2.Data2D = My.Settings.URLAcreQR & row.ID.ToString()

                Dim generator As New BarCodeGenerator(bc)
                Dim barcode As Image = generator.GenerateImage()
                Dim generator2 As New BarCodeGenerator(bc2)
                Dim barcode2 As Image = generator2.GenerateImage()

                row.BarCode = ImageToBytes(barcode)
                row.BaCodeQR = ImageToBytes(barcode2)
            Next
            dt.AcceptChanges()
            Dim rptDataSource As New ReportDataSource()
            rptDataSource.Name = "DataSet1"
            rptDataSource.Value = dt
            Me.rp.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptAcreditacion.rdlc")
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

    Protected Sub btnPrintALl_Click(sender As Object, e As EventArgs) Handles btnPrintALl.Click
        If txtYear.Text = "" Then
            Session("Mensaje") = "Por favor escriba un año a imprimir."
            txtYear.Focus()
            Exit Sub
        ElseIf Not IsNumeric(txtYear.Text) Then
            Session("Mensaje") = "El formato de año es incorrecto."
            txtYear.Focus()
            Exit Sub
        Else
            ShowTelerikReport(True)
        End If
    End Sub
End Class
