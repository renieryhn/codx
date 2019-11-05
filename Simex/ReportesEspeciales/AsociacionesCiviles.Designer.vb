Partial Class AsociacionesCiviles
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsociacionesCiviles))
        Dim Corners1 As Telerik.Reporting.Charting.Styles.Corners = New Telerik.Reporting.Charting.Styles.Corners()
        Dim ChartMargins1 As Telerik.Reporting.Charting.Styles.ChartMargins = New Telerik.Reporting.Charting.Styles.ChartMargins()
        Dim ChartSeries1 As Telerik.Reporting.Charting.ChartSeries = New Telerik.Reporting.Charting.ChartSeries()
        Dim GradientElement1 As Telerik.Reporting.Charting.GradientElement = New Telerik.Reporting.Charting.GradientElement()
        Dim GradientElement2 As Telerik.Reporting.Charting.GradientElement = New Telerik.Reporting.Charting.GradientElement()
        Dim GradientElement3 As Telerik.Reporting.Charting.GradientElement = New Telerik.Reporting.Charting.GradientElement()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.currentTimeTextBox = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.titleTextBox = New Telerik.Reporting.TextBox()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.SqlDataSource2 = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.cht = New Telerik.Reporting.Chart()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(10.351040840148926R), Telerik.Reporting.Drawing.Unit.Cm(0.55562502145767212R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.TextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.Value = "TIPO DE ASOCIACION"
        '
        'TextBox3
        '
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9637482166290283R), Telerik.Reporting.Drawing.Unit.Cm(0.55562502145767212R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.Value = "CANTIDAD"
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(1.1058331727981567R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.currentTimeTextBox, Me.pageInfoTextBox})
        Me.pageFooter.Name = "pageFooter"
        '
        'currentTimeTextBox
        '
        Me.currentTimeTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.currentTimeTextBox.Name = "currentTimeTextBox"
        Me.currentTimeTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.1227083206176758R), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045R))
        Me.currentTimeTextBox.StyleName = "PageInfo"
        Me.currentTimeTextBox.Value = "=NOW()"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.228541374206543R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.1227083206176758R), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045R))
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=PageNumber"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(4.0R)
        Me.reportHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.titleTextBox, Me.Table1})
        Me.reportHeader.Name = "reportHeader"
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(0.0R))
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.404167175292969R), Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842R))
        Me.titleTextBox.Style.Font.Bold = True
        Me.titleTextBox.Style.Font.Italic = True
        Me.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.titleTextBox.StyleName = "Title"
        Me.titleTextBox.Value = "Asociaciones Civiles Registradas en CODEX hasta la fecha"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(10.351041793823242R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9637482166290283R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.44979178905487061R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox9)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox10)
        TableGroup1.Name = "tableGroup"
        TableGroup1.ReportItem = Me.TextBox1
        TableGroup2.Name = "tableGroup1"
        TableGroup2.ReportItem = Me.TextBox3
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.DataSource = Me.SqlDataSource2
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox9, Me.TextBox10, Me.TextBox1, Me.TextBox3})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475R), Telerik.Reporting.Drawing.Unit.Cm(2.5R))
        Me.Table1.Name = "Table1"
        TableGroup3.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup3.Name = "detailTableGroup"
        Me.Table1.RowGroups.Add(TableGroup3)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.314789772033691R), Telerik.Reporting.Drawing.Unit.Cm(1.0054168701171875R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        '
        'TextBox9
        '
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(10.351040840148926R), Telerik.Reporting.Drawing.Unit.Cm(0.44979187846183777R))
        Me.TextBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224R)
        Me.TextBox9.Value = "=Fields.Nombre"
        '
        'TextBox10
        '
        Me.TextBox10.Format = "{0:N0}"
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9637480974197388R), Telerik.Reporting.Drawing.Unit.Cm(0.44979187846183777R))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox10.Value = "=Fields.Expr1"
        '
        'SqlDataSource2
        '
        Me.SqlDataSource2.ConnectionString = "Simex_DesConnectionString"
        Me.SqlDataSource2.Name = "SqlDataSource2"
        Me.SqlDataSource2.SelectCommand = resources.GetString("SqlDataSource2.SelectCommand")
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144R)
        Me.detail.Name = "detail"
        Me.detail.Style.Visible = False
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(6.6677083969116211R)
        Me.reportFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.cht})
        Me.reportFooter.Name = "reportFooter"
        Me.reportFooter.Style.Visible = True
        '
        'cht
        '
        Me.cht.Appearance.Border.Color = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cht.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cht.BitmapResolution = 96.0!
        Me.cht.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Empty
        Me.cht.ChartTitle.Appearance.Visible = False
        Me.cht.ChartTitle.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(4, Byte), Integer))
        Me.cht.ChartTitle.TextBlock.Text = ""
        Me.cht.ChartTitle.Visible = False
        Me.cht.DataSource = Me.SqlDataSource1
        Me.cht.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf
        Me.cht.Legend.Appearance.Border.Color = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(201, Byte), Integer))
        Corners1.BottomLeft = Telerik.Reporting.Charting.Styles.CornerType.Round
        Corners1.BottomRight = Telerik.Reporting.Charting.Styles.CornerType.Round
        Corners1.RoundSize = 6
        Corners1.TopLeft = Telerik.Reporting.Charting.Styles.CornerType.Round
        Corners1.TopRight = Telerik.Reporting.Charting.Styles.CornerType.Round
        Me.cht.Legend.Appearance.Corners = Corners1
        Me.cht.Legend.Appearance.ItemTextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.cht.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39999979734420776R), Telerik.Reporting.Drawing.Unit.Cm(0.3677084743976593R))
        Me.cht.Name = "cht"
        Me.cht.PlotArea.Appearance.Border.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        ChartMargins1.Bottom = New Telerik.Reporting.Charting.Styles.Unit(12.0R, Telerik.Reporting.Charting.Styles.UnitType.Percentage)
        ChartMargins1.Left = New Telerik.Reporting.Charting.Styles.Unit(10.0R, Telerik.Reporting.Charting.Styles.UnitType.Percentage)
        ChartMargins1.Right = New Telerik.Reporting.Charting.Styles.Unit(23.0R, Telerik.Reporting.Charting.Styles.UnitType.Percentage)
        ChartMargins1.Top = New Telerik.Reporting.Charting.Styles.Unit(18.0R, Telerik.Reporting.Charting.Styles.UnitType.Percentage)
        Me.cht.PlotArea.Appearance.Dimensions.Margins = ChartMargins1
        Me.cht.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.cht.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent
        Me.cht.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.cht.PlotArea.XAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.cht.PlotArea.XAxis.Appearance.MajorTick.Color = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.cht.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.cht.PlotArea.XAxis.AxisLabel.Appearance.RotationAngle = 270.0!
        Me.cht.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.cht.PlotArea.XAxis.AxisLabel.TextBlock.Text = "Cantidad"
        Me.cht.PlotArea.XAxis.MinValue = 1.0R
        Me.cht.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.cht.PlotArea.YAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cht.PlotArea.YAxis.Appearance.MajorTick.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.cht.PlotArea.YAxis.Appearance.MinorGridLines.Color = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cht.PlotArea.YAxis.Appearance.MinorTick.Color = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.cht.PlotArea.YAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.cht.PlotArea.YAxis.AxisLabel.Appearance.RotationAngle = 0.0!
        Me.cht.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.cht.PlotArea.YAxis.MaxValue = 100.0R
        Me.cht.PlotArea.YAxis.Step = 10.0R
        Me.cht.PlotArea.YAxis2.AxisLabel.Appearance.RotationAngle = 0.0!
        ChartSeries1.Appearance.Border.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(40, Byte), Integer))
        GradientElement1.Color = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(119, Byte), Integer))
        GradientElement2.Color = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(82, Byte), Integer))
        GradientElement2.Position = 0.5!
        GradientElement3.Color = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(44, Byte), Integer))
        GradientElement3.Position = 1.0!
        ChartSeries1.Appearance.FillStyle.FillSettings.ComplexGradient.AddRange(New Telerik.Reporting.Charting.GradientElement() {GradientElement1, GradientElement2, GradientElement3})
        ChartSeries1.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.ComplexGradient
        ChartSeries1.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(119, Byte), Integer))
        ChartSeries1.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(56, Byte), Integer))
        ChartSeries1.DataLabelsColumn = "Nombre"
        ChartSeries1.DataYColumn = "Expr1"
        ChartSeries1.Name = "Tipo de Asociación"
        Me.cht.Series.AddRange(New Telerik.Reporting.Charting.ChartSeries() {ChartSeries1})
        Me.cht.SeriesOrientation = Telerik.Reporting.Charting.ChartSeriesOrientation.Horizontal
        Me.cht.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.90000057220459R), Telerik.Reporting.Drawing.Unit.Cm(5.6999993324279785R))
        Me.cht.Skin = "LightGreen"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionString = "Simex_DesConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.SelectCommand = resources.GetString("SqlDataSource1.SelectCommand")
        '
        'TextBox6
        '
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137R))
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137R))
        '
        'TextBox2
        '
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137R))
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(1.2699999809265137R))
        '
        'AsociacionesCiviles
        '
        Me.DataSource = Me.SqlDataSource1
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "AsociacionesCiviles"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(74, Byte), Integer))
        StyleRule1.Style.Font.Name = "Georgia"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(173, Byte), Integer))
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(212, Byte), Integer))
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        StyleRule2.Style.Color = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer))
        StyleRule2.Style.Font.Name = "Georgia"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Georgia"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Georgia"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(16.404167175292969R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents currentTimeTextBox As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents titleTextBox As Telerik.Reporting.TextBox
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents SqlDataSource2 As Telerik.Reporting.SqlDataSource
    Friend WithEvents cht As Telerik.Reporting.Chart
End Class