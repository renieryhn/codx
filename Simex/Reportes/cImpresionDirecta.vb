Imports Microsoft.Reporting.WebForms
Imports System.Drawing.Imaging
Imports System.Drawing
Imports Spire.Barcode
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class cImpresionDirecta
    Implements IDisposable

    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private m_LocalReport As LocalReport
    Sub New(Report As LocalReport)
        m_LocalReport = Report
    End Sub

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function


    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>8.5in</PageWidth>" & _
            "<PageHeight>11in</PageHeight>" & _
            "<MarginTop>0.25in</MarginTop>" & _
            "<MarginLeft>0.25in</MarginLeft>" & _
            "<MarginRight>0.25in</MarginRight>" & _
            "<MarginBottom>0.25in</MarginBottom>" & _
            "</DeviceInfo>"
        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            printDoc.Print()
        End If
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    Public Sub Run()
        Dim i As Integer
        Dim report As New LocalReport()
        report.ReportPath = m_LocalReport.ReportPath
        For i = 0 To m_LocalReport.DataSources.Count - 1
            report.DataSources.Add(m_LocalReport.DataSources(i))
        Next
        Export(report)
        Print()
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

End Class
