Imports prjDatos
Imports Spire.Barcode.WebUI
Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports Spire.Barcode
Imports System.IO
Imports System.Data
Imports System.Text

Public Class ExReporter
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreMantenimiento As String = "Reportes"
    Private dtCargaTrabajo As DataTable

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnImprimir_Click, AddressOf btnImprimir_Click
        If Not IsPostBack Then
            sMensaje = Session("Mensaje")
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            Spire.Barcode.BarcodeSettings.ApplyKey("8LXF1-2G6GL-TBJZP-HL7CT-SANVP")
            If bTieneDetalle() Then
                CargarPortada(2)
            Else
                CargarPortada(1)
            End If
        End If
    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Using cImprimir As New cImpresionDirecta(rp.LocalReport)
                cImprimir.Run()
            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Protected Sub btnPortada_Click(sender As Object, e As EventArgs) Handles btnPortada.Click
        If bTieneDetalle() Then
            CargarPortada(2)
        Else
            CargarPortada(1)
        End If
    End Sub

    Protected Sub btnComprobante_Click(sender As Object, e As EventArgs) Handles btnComprobante.Click
        If bTieneDetalle() Then
            CargarComprobanteVarios()
        Else
            CargarComprobante(1)
        End If
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Session("preBusqueda") = "1"
        Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
    End Sub
#End Region

#Region "Reportes"
    Sub CargarPortada(iTipo As Integer)
        Try
            ' Fill the datasource from DB
            Dim nExp As String = Session("ID")
            Dim ta As New Simex_DesDataSetTableAdapters.ExpedienteTableAdapter()
            Dim dt As New Simex_DesDataSet.ExpedienteDataTable
            Dim dtBenef As DataTable = Nothing

            ta.FillByExpediente(dt, nExp)


            If iTipo = 2 Then
                Dim taBenef As New Simex_DesDataSetTableAdapters.ExpedienteClienteTableAdapter
                dtBenef = New Simex_DesDataSet.ExpedienteClienteDataTable
                taBenef.FillCodigoExp(dtBenef, nExp)
            End If

            ' Create and setup an instance of Bytescout Barcode SDK
            Dim bc As New BarCodeControl()
            bc.Type = Spire.Barcode.BarCodeType.Code39
            bc.ShowText = False

            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.ExpedienteRow

            For Each row In dt.Rows
                ' Set the value to encode
                bc.Data = row.Id.ToString()
                bc.Data2D = row.Id.ToString()
                bc2.Data = My.Settings.URLMobilQ & row.Id.ToString()
                bc2.Data2D = My.Settings.URLMobilQ & row.Id.ToString()

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
            If iTipo = 2 Then
                Dim rptDataSource3 As New ReportDataSource()
                rptDataSource3.Name = "dsBeneficiarios"
                rptDataSource3.Value = dtBenef
                Me.rp.LocalReport.ReportPath = Server.MapPath("rptPortadaVarios.rdlc")
                Me.rp.LocalReport.DataSources.Add(rptDataSource3)
            Else
                Me.rp.LocalReport.ReportPath = Server.MapPath("rptPortada.rdlc")
            End If

            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
            'Me.rp.LocalReport.ShowDetailedSubreportMessages = "False"
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub CargarComprobante(iRep As Integer )
        Try
            ' Fill the datasource from DB
            Dim nExp As String = Session("ID")
            Dim ta As New Simex_DesDataSetTableAdapters.ExpedienteTableAdapter()
            Dim dt As New Simex_DesDataSet.ExpedienteDataTable
            ta.FillByExpediente(dt, nExp)

            Dim ta2 As New Simex_DesDataSetTableAdapters.ExpedienteRequisitosTableAdapter
            Dim dt2 As New Simex_DesDataSet.ExpedienteRequisitosDataTable
            'If iRep = 1 Then
            ta2.Fill(dt2, nExp)
            'Else
            '    ta2.FillByActivos(dt2, nExp)
            'End If

            ' Create and setup an instance of Bytescout Barcode SDK
            Dim bc As New BarCodeControl()
            bc.Type = Spire.Barcode.BarCodeType.Code39
            bc.ShowText = True

            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.ExpedienteRow

            For Each row In dt.Rows
                ' Set the value to encode
                bc.Data = row.Id.ToString()
                bc.Data2D = row.Id.ToString()
                bc2.Data = My.Settings.URLMobilQ & row.Id.ToString()
                bc2.Data2D = My.Settings.URLMobilQ & row.Id.ToString()

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

            'Create Report Data Source
            Dim rptDataSource2 As New ReportDataSource()
            rptDataSource2.Name = "DataSet2"
            rptDataSource2.Value = dt2
            If iRep = 1 Then
                If dt2.Rows.Count > 0 Then
                    Me.rp.LocalReport.ReportPath = Server.MapPath("rptComprobante.rdlc")
                Else
                    Me.rp.LocalReport.ReportPath = Server.MapPath("rptComprobanteSimple.rdlc")
                End If
            Else
                Me.rp.LocalReport.ReportPath = Server.MapPath("rptConstRecibo.rdlc")
            End If

            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.DataSources.Add(rptDataSource2)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub CargarComprobanteVarios()
        Try
            Dim nExp As String = Session("ID")
            Dim ta As New Simex_DesDataSetTableAdapters.ExpedienteTableAdapter()
            Dim dt As New Simex_DesDataSet.ExpedienteDataTable
            ta.FillByExpediente(dt, nExp)

            Dim ta2 As New Simex_DesDataSetTableAdapters.ExpedienteClienteTableAdapter
            Dim dt2 As New Simex_DesDataSet.ExpedienteClienteDataTable
            ta2.FillCodigoExp(dt2, nExp)

            Dim ta3 As New Simex_DesDataSetTableAdapters.ExpedienteRequisitosTableAdapter
            Dim dt3 As New Simex_DesDataSet.ExpedienteRequisitosDataTable
            ta3.Fill(dt3, nExp)

            ' Create and setup an instance of Bytescout Barcode SDK
            Dim bc As New BarCodeControl()
            bc.Type = Spire.Barcode.BarCodeType.Code39
            bc.ShowText = True

            Dim bc2 As New BarCodeControl()
            bc2.Type = Spire.Barcode.BarCodeType.QRCode
            bc2.ShowText = False

            ' Update DataTable with barcode image
            Dim row As Simex_DesDataSet.ExpedienteRow

            For Each row In dt.Rows
                ' Set the value to encode
                bc.Data = row.Id.ToString()
                bc.Data2D = row.Id.ToString()
                bc2.Data = My.Settings.URLMobilQ & row.Id.ToString()
                bc2.Data2D = My.Settings.URLMobilQ & row.Id.ToString()

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

            'Create Report Data Source
            Dim rptDataSource2 As New ReportDataSource()
            rptDataSource2.Name = "DataSet2"
            rptDataSource2.Value = dt2

            'Create Report Data Source
            Dim rptDataSource3 As New ReportDataSource()
            rptDataSource3.Name = "dsRequisitos"
            rptDataSource3.Value = dt3

            AddHandler rp.LocalReport.SubreportProcessing, AddressOf Me.SubreportProcessingEventHandler

            Me.rp.LocalReport.ReportPath = Server.MapPath("rptComprobanteSimpleVarios.rdlc")
            Me.rp.LocalReport.DataSources.Add(rptDataSource)
            Me.rp.LocalReport.DataSources.Add(rptDataSource2)
            Me.rp.LocalReport.DataSources.Add(rptDataSource3)
            Me.rp.LocalReport.Refresh()
            Me.rp.ShowPrintButton = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Sub SubreportProcessingEventHandler(sender As Object, e As SubreportProcessingEventArgs)
        Dim nExp As String = Session("ID")
        Dim ta3 As New Simex_DesDataSetTableAdapters.ExpedienteRequisitosTableAdapter
        Dim dt3 As New Simex_DesDataSet.ExpedienteRequisitosDataTable
        ta3.Fill(dt3, nExp)

        'Create Report Data Source
        Dim rptDataSource3 As New ReportDataSource()
        rptDataSource3.Name = "dsRequisitos"
        rptDataSource3.Value = dt3
        e.DataSources.Add(rptDataSource3)
    End Sub
#End Region

    Function bTieneDetalle() As Boolean
        Try
            Dim tbl As DataTable = cFunciones.Filldatatable("pExpedienteCliente_List", dtParamClientes)
            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function dtParamClientes() As DataTable
        Try
            dtParamClientes = cFunciones.dtDatos.Clone
            dtParamClientes.Rows.Add("idExpediente", Session("ID"))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#Region "Metodos"
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
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

#End Region

    Protected Sub btnRecibo_Click(sender As Object, e As EventArgs) Handles btnRecibo.Click
        CargarComprobante(2)
    End Sub
End Class