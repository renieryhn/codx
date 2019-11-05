Imports prjDatos
Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports Spire.Barcode
Imports System.IO
Imports System.Data
Imports System.Text

Public Class wfmRegistroInformesConstLibro
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = ""
    Dim m_sAgregarRegistro = ""
    Dim m_sEliminarRegistro = ""
    Private sNombreMantenimiento As String = "Informes y Contancias"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            sMensaje = Session("Mensaje")
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            Spire.Barcode.BarcodeSettings.ApplyKey("8LXF1-2G6GL-TBJZP-HL7CT-SANVP")
            If Not IsNothing(Session("CodigoRegistroJD")) Then
                CargarConstanciaJD()
            Else
                CargarCaratula("rptUR_Portada.rdlc")
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

    Protected Sub btnCaratural_Click(sender As Object, e As EventArgs) Handles btnCaratural.Click
        CargarCaratula("rptUR_Portada.rdlc")
    End Sub

    Sub CargarComprobante()
        Try
            CargarCaratula("rptUR_ComprobanteSimple.rdlc")
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub CargarConstancia()
        Try

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub CargarCaratula(sNombreReporte As String)
        Try
            ' Fill the datasource from DB
            Dim nExp As String = Session("idRegistro")
            Dim ta As New Simex_DesDataSetTableAdapters.pUR_Registro_ListTableAdapter()
            Dim dt As New Simex_DesDataSet.pUR_Registro_ListDataTable
            ta.ClearBeforeFill = True
            ta.Fill(dt, nExp, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            ' Create and setup an instance of Bytescout Barcode SDK
            Dim bc As New BarCodeControl()
            bc.Type = Spire.Barcode.BarCodeType.Code39
            bc.ShowText = False

            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.pUR_Registro_ListRow

            For Each row In dt.Rows
                ' Set the value to encode
                bc.Data = row.id.ToString()
                bc.Data2D = row.id.ToString()
                bc2.Data = My.Settings.URLMobilQ & row.id.ToString()
                bc2.Data2D = My.Settings.URLMobilQ & row.id.ToString()

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

            Me.rp.LocalReport.ReportPath = Server.MapPath("~/Reportes/") & sNombreReporte
            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
        Catch ex As Exception

        End Try
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

    Protected Sub btnConsJD_Click(sender As Object, e As EventArgs) Handles btnConsJD.Click
        Try
            CargarConstanciaJD()
        Catch ex As Exception

        End Try
    End Sub

    Sub CargarConstanciaJD()
        Try
            ' Fill the datasource from DB
            Dim nExp As String = Session("idRegistro")
            Dim nIdJD As String = Session("CodigoRegistroJD")
            Dim ta As New Simex_DesDataSetTableAdapters.pLibroRegistro_ListTableAdapter
            Dim dt As New Simex_DesDataSet.pLibroRegistro_ListDataTable
            ta.Fill(dt, nExp, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            'Create Report Data Source
            Dim rptDataSource As New ReportDataSource()
            rptDataSource.Name = "DataSet1"
            rptDataSource.Value = dt

            Dim ta2 As New Simex_DesDataSetTableAdapters.pUR_RegistroJunta_ListTableAdapter
            Dim dt2 As New Simex_DesDataSet.pUR_RegistroJunta_ListDataTable
            If nIdJD = "" Then
                ta2.Fill(dt2, nExp, Nothing, Nothing)
            Else
                ta2.Fill(dt2, nExp, nIdJD, Nothing)
            End If
            'Create Report Data Source
            Dim rptDataSource2 As New ReportDataSource()
            rptDataSource2.Name = "DataSet2"
            rptDataSource2.Value = dt2

            Dim ta3 As New Simex_DesDataSetTableAdapters.pUR_RegistroJuntaDet_ListTableAdapter
            Dim dt3 As New Simex_DesDataSet.pUR_RegistroJuntaDet_ListDataTable
            If dt2.Rows.Count > 0 Then
                Dim idJunta As Integer = dt2.Rows(0).Item("id")
                ta3.Fill(dt3, idJunta, Nothing)
            End If
            'Create Report Data Source
            Dim rptDataSource3 As New ReportDataSource()
            rptDataSource3.Name = "DataSet3"
            rptDataSource3.Value = dt3

            Me.rp.LocalReport.ReportPath = "rptConstanciaJD.rdlc"
            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.DataSources.Add(rptDataSource2)
            Me.rp.LocalReport.DataSources.Add(rptDataSource3)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
            Session("CodigoRegistroJD") = Nothing
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Protected Sub btnConsReg_Click(sender As Object, e As EventArgs) Handles btnConsReg.Click
        Try
            ' Fill the datasource from DB
            Dim nExp As String = Session("idRegistro")

            Dim ta As New Simex_DesDataSetTableAdapters.pLibroRegistro_ListTableAdapter
            Dim dt As New Simex_DesDataSet.pLibroRegistro_ListDataTable
            ta.Fill(dt, nExp, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            'Create Report Data Source
            Dim rptDataSource As New ReportDataSource()
            rptDataSource.Name = "DataSet1"
            rptDataSource.Value = dt


            Me.rp.LocalReport.ReportPath = "rptConstanciaREG.rdlc"
            Me.rp.LocalReport.DataSources.Add(rptDataSource)

            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

End Class