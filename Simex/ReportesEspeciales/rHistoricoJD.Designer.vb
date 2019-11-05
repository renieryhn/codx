Partial Class Report1

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim Group2 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.textBox14 = New Telerik.Reporting.TextBox()
        Me.textBox13 = New Telerik.Reporting.TextBox()
        Me.textBox12 = New Telerik.Reporting.TextBox()
        Me.textBox11 = New Telerik.Reporting.TextBox()
        Me.textBox10 = New Telerik.Reporting.TextBox()
        Me.textBox9 = New Telerik.Reporting.TextBox()
        Me.shape1 = New Telerik.Reporting.Shape()
        Me.textBox2 = New Telerik.Reporting.TextBox()
        Me.textBox1 = New Telerik.Reporting.TextBox()
        Me.groupFooterSection1 = New Telerik.Reporting.GroupFooterSection()
        Me.groupHeaderSection1 = New Telerik.Reporting.GroupHeaderSection()
        Me.textBox17 = New Telerik.Reporting.TextBox()
        Me.textBox16 = New Telerik.Reporting.TextBox()
        Me.textBox15 = New Telerik.Reporting.TextBox()
        Me.shape2 = New Telerik.Reporting.Shape()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.textBox24 = New Telerik.Reporting.TextBox()
        Me.textBox23 = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.textBox20 = New Telerik.Reporting.TextBox()
        Me.textBox19 = New Telerik.Reporting.TextBox()
        Me.textBox18 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.textBox21 = New Telerik.Reporting.TextBox()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        Me.textBox8 = New Telerik.Reporting.TextBox()
        Me.textBox7 = New Telerik.Reporting.TextBox()
        Me.textBox6 = New Telerik.Reporting.TextBox()
        Me.textBox5 = New Telerik.Reporting.TextBox()
        Me.textBox4 = New Telerik.Reporting.TextBox()
        Me.textBox3 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.50000083446502686R)
        Me.groupFooterSection.Name = "groupFooterSection"
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6463499069213867R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.textBox14, Me.textBox13, Me.textBox12, Me.textBox11, Me.textBox10, Me.textBox9, Me.shape1, Me.textBox2, Me.textBox1})
        Me.groupHeaderSection.Name = "groupHeaderSection"
        '
        'textBox14
        '
        Me.textBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.795415878295898R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox14.Name = "textBox14"
        Me.textBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox14.Style.Font.Bold = True
        Me.textBox14.Value = "FIN VIGENCIA"
        '
        'textBox13
        '
        Me.textBox13.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.308332443237305R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox13.Name = "textBox13"
        Me.textBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox13.Style.Font.Bold = True
        Me.textBox13.Value = "INICIO VIGENCIA"
        '
        'textBox12
        '
        Me.textBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7947912216186523R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox12.Name = "textBox12"
        Me.textBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox12.Style.Font.Bold = True
        Me.textBox12.Value = "SOLICITUD REGISTRO"
        '
        'textBox11
        '
        Me.textBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.3077077865600586R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox11.Name = "textBox11"
        Me.textBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox11.Style.Font.Bold = True
        Me.textBox11.Value = "FECHA ELECCIÓN"
        '
        'textBox10
        '
        Me.textBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7941668033599854R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox10.Name = "textBox10"
        Me.textBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox10.Style.Font.Bold = True
        Me.textBox10.Value = "FECHA TOMA"
        '
        'textBox9
        '
        Me.textBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30708354711532593R), Telerik.Reporting.Drawing.Unit.Cm(1.7463500499725342R))
        Me.textBox9.Name = "textBox9"
        Me.textBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox9.Style.Font.Bold = True
        Me.textBox9.Value = "FECHA DE INSCRIPCIÓN"
        '
        'shape1
        '
        Me.shape1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(1.0319751501083374R))
        Me.shape1.Name = "shape1"
        Me.shape1.ShapeType = New Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW)
        Me.shape1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.600400924682617R), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224R))
        '
        'textBox2
        '
        Me.textBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.700400352478027R), Telerik.Reporting.Drawing.Unit.Cm(0.99999988079071045R))
        Me.textBox2.Value = "=Fields.Denominacion"
        '
        'textBox1
        '
        Me.textBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6000001430511475R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.textBox1.Value = "=Fields.NumRegistro"
        '
        'groupFooterSection1
        '
        Me.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.59999960660934448R)
        Me.groupFooterSection1.Name = "groupFooterSection1"
        '
        'groupHeaderSection1
        '
        Me.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.4536507129669189R)
        Me.groupHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.textBox17, Me.textBox16, Me.textBox15, Me.shape2, Me.textBox8, Me.textBox7, Me.textBox6, Me.textBox5, Me.textBox4, Me.textBox3})
        Me.groupHeaderSection1.Name = "groupHeaderSection1"
        '
        'textBox17
        '
        Me.textBox17.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.699999809265137R), Telerik.Reporting.Drawing.Unit.Cm(0.85365021228790283R))
        Me.textBox17.Name = "textBox17"
        Me.textBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9004008769989014R), Telerik.Reporting.Drawing.Unit.Cm(0.60000050067901611R))
        Me.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox17.Style.Font.Bold = True
        Me.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox17.Value = "FECHA"
        '
        'textBox16
        '
        Me.textBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.0006251335144043R), Telerik.Reporting.Drawing.Unit.Cm(0.85365021228790283R))
        Me.textBox16.Name = "textBox16"
        Me.textBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6997995376586914R), Telerik.Reporting.Drawing.Unit.Cm(0.60000050067901611R))
        Me.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox16.Style.Font.Bold = True
        Me.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox16.Value = "PUESTO QUE OCUPA"
        '
        'textBox15
        '
        Me.textBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20624871551990509R), Telerik.Reporting.Drawing.Unit.Cm(0.85365021228790283R))
        Me.textBox15.Name = "textBox15"
        Me.textBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.7999997138977051R), Telerik.Reporting.Drawing.Unit.Cm(0.60000050067901611R))
        Me.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox15.Style.Font.Bold = True
        Me.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox15.Value = "NOMBRE"
        '
        'shape2
        '
        Me.shape2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.023541843518614769R), Telerik.Reporting.Drawing.Unit.Cm(0.55364996194839478R))
        Me.shape2.Name = "shape2"
        Me.shape2.ShapeType = New Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW)
        Me.shape2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.586262702941895R), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224R))
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.7999998331069946R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.textBox24, Me.textBox23})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'textBox24
        '
        Me.textBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582R))
        Me.textBox24.Name = "textBox24"
        Me.textBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100401878356934R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.textBox24.Style.Font.Bold = False
        Me.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox24.Value = "Historial de Juntas Directivas de Asociaciones Civiles"
        '
        'textBox23
        '
        Me.textBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(0.012083402834832668R))
        Me.textBox23.Name = "textBox23"
        Me.textBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.100400924682617R), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269R))
        Me.textBox23.Style.Font.Bold = True
        Me.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox23.Value = "Unidad de Registro y Seguimiento de Asociaciones Civiles"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.59999960660934448R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.textBox20, Me.textBox19, Me.textBox18})
        Me.detail.Name = "detail"
        '
        'textBox20
        '
        Me.textBox20.Format = "{0:d}"
        Me.textBox20.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.70000171661377R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox20.Name = "textBox20"
        Me.textBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9098026752471924R), Telerik.Reporting.Drawing.Unit.Cm(0.59979945421218872R))
        Me.textBox20.Style.BorderColor.Bottom = System.Drawing.Color.Black
        Me.textBox20.Style.BorderColor.Left = System.Drawing.Color.Black
        Me.textBox20.Style.BorderColor.Right = System.Drawing.Color.Black
        Me.textBox20.Style.BorderColor.Top = System.Drawing.Color.Black
        Me.textBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox20.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox20.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox20.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox20.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox20.Value = "=Fields.FechaToma"
        '
        'textBox19
        '
        Me.textBox19.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.0006265640258789R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox19.Name = "textBox19"
        Me.textBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.699798583984375R), Telerik.Reporting.Drawing.Unit.Cm(0.59979945421218872R))
        Me.textBox19.Style.BorderColor.Bottom = System.Drawing.Color.Black
        Me.textBox19.Style.BorderColor.Left = System.Drawing.Color.Black
        Me.textBox19.Style.BorderColor.Right = System.Drawing.Color.Black
        Me.textBox19.Style.BorderColor.Top = System.Drawing.Color.Black
        Me.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox19.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox19.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox19.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox19.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox19.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox19.Value = "=Fields.NombrePuesto"
        '
        'textBox18
        '
        Me.textBox18.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20625032484531403R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox18.Name = "textBox18"
        Me.textBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(0.59979945421218872R))
        Me.textBox18.Style.BorderColor.Bottom = System.Drawing.Color.Black
        Me.textBox18.Style.BorderColor.Left = System.Drawing.Color.Black
        Me.textBox18.Style.BorderColor.Right = System.Drawing.Color.Black
        Me.textBox18.Style.BorderColor.Top = System.Drawing.Color.Black
        Me.textBox18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.textBox18.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox18.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox18.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox18.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.textBox18.Value = "=Fields.NombreCliente"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.3999999761581421R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.textBox21})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'textBox21
        '
        Me.textBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(0.30000025033950806R))
        Me.textBox21.Name = "textBox21"
        Me.textBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.099998474121094R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.textBox21.Value = "= ""Página"" + PageNumber + "" de "" + PageCount"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionString = "Simex_DesConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@NumRegistro", System.Data.DbType.Int64, "=Parameters.NumRegistro.Value"), New Telerik.Reporting.SqlDataSourceParameter("@IdJuntaDirectiva", System.Data.DbType.Int32, "=Parameters.IdJuntaDirectiva.Value")})
        Me.SqlDataSource1.SelectCommand = "dbo.pUR_ReporteJuntaDirectivaHist"
        Me.SqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'textBox8
        '
        Me.textBox8.Format = "{0:d}"
        Me.textBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.795416831970215R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox8.Name = "textBox8"
        Me.textBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox8.Value = "=Fields.FechaFinVig"
        '
        'textBox7
        '
        Me.textBox7.Format = "{0:d}"
        Me.textBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.308333396911621R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox7.Name = "textBox7"
        Me.textBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox7.Value = "=Fields.FechaInicioVig"
        '
        'textBox6
        '
        Me.textBox6.Format = "{0:d}"
        Me.textBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.7947921752929687R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox6.Name = "textBox6"
        Me.textBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox6.Value = "=Fields.FechaSolRegistroJD"
        '
        'textBox5
        '
        Me.textBox5.Format = "{0:d}"
        Me.textBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.3077082633972168R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox5.Name = "textBox5"
        Me.textBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox5.Value = "=Fields.FechaEleccion"
        '
        'textBox4
        '
        Me.textBox4.Format = "{0:d}"
        Me.textBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7941668033599854R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox4.Value = "= Fields.FechaTomaPosesion"
        '
        'textBox3
        '
        Me.textBox3.Format = "{0:d}"
        Me.textBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.30708354711532593R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749331R))
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5R), Telerik.Reporting.Drawing.Unit.Cm(0.5R))
        Me.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.textBox3.Value = "=Fields.FechaInscripcion"
        '
        'Report1
        '
        Me.DataSource = Me.SqlDataSource1
        Group1.GroupFooter = Me.groupFooterSection
        Group1.GroupHeader = Me.groupHeaderSection
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.NumRegistro"))
        Group1.Name = "Registro"
        Group2.GroupFooter = Me.groupFooterSection1
        Group2.GroupHeader = Me.groupHeaderSection1
        Group2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Id"))
        Group2.Name = "JD"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1, Group2})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.groupHeaderSection, Me.groupFooterSection, Me.groupHeaderSection1, Me.groupFooterSection1, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "Report1"
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.AllowNull = True
        ReportParameter1.Name = "NumRegistro"
        ReportParameter1.Text = "NumRegistro"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter2.AllowNull = True
        ReportParameter2.Name = "IdJuntaDirectiva"
        ReportParameter2.Text = "IdJuntaDirectiva"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.[Integer]
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(15.609804153442383R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents textBox24 As Telerik.Reporting.TextBox
    Friend WithEvents textBox23 As Telerik.Reporting.TextBox
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents textBox20 As Telerik.Reporting.TextBox
    Friend WithEvents textBox19 As Telerik.Reporting.TextBox
    Friend WithEvents textBox18 As Telerik.Reporting.TextBox
    Friend WithEvents textBox21 As Telerik.Reporting.TextBox
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents textBox14 As Telerik.Reporting.TextBox
    Friend WithEvents textBox13 As Telerik.Reporting.TextBox
    Friend WithEvents textBox12 As Telerik.Reporting.TextBox
    Friend WithEvents textBox11 As Telerik.Reporting.TextBox
    Friend WithEvents textBox10 As Telerik.Reporting.TextBox
    Friend WithEvents textBox9 As Telerik.Reporting.TextBox
    Friend WithEvents shape1 As Telerik.Reporting.Shape
    Friend WithEvents textBox2 As Telerik.Reporting.TextBox
    Friend WithEvents textBox1 As Telerik.Reporting.TextBox
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents groupHeaderSection1 As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents textBox17 As Telerik.Reporting.TextBox
    Friend WithEvents textBox16 As Telerik.Reporting.TextBox
    Friend WithEvents textBox15 As Telerik.Reporting.TextBox
    Friend WithEvents shape2 As Telerik.Reporting.Shape
    Friend WithEvents groupFooterSection1 As Telerik.Reporting.GroupFooterSection
    Friend WithEvents textBox8 As Telerik.Reporting.TextBox
    Friend WithEvents textBox7 As Telerik.Reporting.TextBox
    Friend WithEvents textBox6 As Telerik.Reporting.TextBox
    Friend WithEvents textBox5 As Telerik.Reporting.TextBox
    Friend WithEvents textBox4 As Telerik.Reporting.TextBox
    Friend WithEvents textBox3 As Telerik.Reporting.TextBox
End Class