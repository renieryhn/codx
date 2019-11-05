Partial Class Comprobante
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionString = "Simex_DesConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@id", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@NombreEncargado", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@NombreSolicitante", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@PersonaRelacionada", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@NRF", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@NumeroDictamen", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@NumeroResolucion", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@idServicio", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@idSubServicio", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@TipoResponsable", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@TipoSolicitante", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@idDepartamento", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@idMunicipio", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@FechaInicio", System.Data.DbType.[Date], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@FechaFinal", System.Data.DbType.[Date], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@Recibido", System.Data.DbType.[Boolean], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@idUsuario", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@SinRecibir", System.Data.DbType.[Boolean], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@SinEnviar", System.Data.DbType.[Boolean], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@EnviadoSinRecibir", System.Data.DbType.[Boolean], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@CodigoApoderado", System.Data.DbType.[String], Nothing), New Telerik.Reporting.SqlDataSourceParameter("@IdEmpleado", System.Data.DbType.Int32, Nothing), New Telerik.Reporting.SqlDataSourceParameter("@TipoFecha", System.Data.DbType.Int32, Nothing)})
        Me.SqlDataSource1.SelectCommand = "dbo.pExpediente_List"
        Me.SqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.71437495946884155R)
        Me.detail.Name = "detail"
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(4.7344832420349121R)
        Me.pageHeader.Name = "pageHeader"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0941667556762695R)
        Me.reportHeader.Name = "reportHeader"
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.71437495946884155R)
        Me.reportFooter.Name = "reportFooter"
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(1.1058331727981567R)
        Me.pageFooter.Name = "pageFooter"
        '
        'Comprobante
        '
        Me.DataSource = Me.SqlDataSource1
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "Comprobante"
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.Black
        StyleRule1.Style.Font.Bold = True
        StyleRule1.Style.Font.Italic = False
        StyleRule1.Style.Font.Name = "Tahoma"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        StyleRule1.Style.Font.Strikeout = False
        StyleRule1.Style.Font.Underline = False
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(15.814167022705078R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
End Class