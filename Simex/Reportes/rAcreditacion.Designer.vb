Partial Class rAcreditacion
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim NavigateToUrlAction1 As Telerik.Reporting.NavigateToUrlAction = New Telerik.Reporting.NavigateToUrlAction()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.bcBarras = New Telerik.Reporting.Barcode()
        Me.picQR = New Telerik.Reporting.PictureBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.ObjectDataSource1 = New Telerik.Reporting.ObjectDataSource()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(4.0R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Cm(2.5R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.199997901916504R), Telerik.Reporting.Drawing.Unit.Cm(1.4000000953674316R))
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Tahoma"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.Value = "TARJETA DE ACREDITACIÓN PARA LA ASAMBLEA DE LAS ORGANIZACIONES CIVILES"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(8.59999942779541R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.bcBarras, Me.picQR, Me.TextBox9})
        Me.detail.Name = "detail"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.0R), Telerik.Reporting.Drawing.Unit.Cm(0.0R))
        Me.TextBox2.Value = "TextBox2"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Cm(0.299999862909317R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.19999885559082R), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119R))
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Value = "INSTITUCIÓN QUE REPRESENTA: =Fields.Institucion"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.39999979734420776R), Telerik.Reporting.Drawing.Unit.Cm(1.399999737739563R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.199997901916504R), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119R))
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Value = "NOMBRE DEL REPRESENTANTE: =Fields.Cliente"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Cm(2.4000000953674316R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9999995231628418R), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119R))
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Value = "HORA: =Fields.Hora"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Cm(3.1999995708465576R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9999995231628418R), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119R))
        Me.TextBox6.Style.Font.Bold = True
        Me.TextBox6.Value = "FECHA: =Fields.Fecha"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Cm(4.0R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.199997901916504R), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119R))
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Value = "LUGAR: [=Fields.Lugar]"
        '
        'bcBarras
        '
        Me.bcBarras.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.4999995231628418R), Telerik.Reporting.Drawing.Unit.Cm(7.7000007629394531R))
        Me.bcBarras.Name = "bcBarras"
        Me.bcBarras.ShowText = False
        Me.bcBarras.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.0R), Telerik.Reporting.Drawing.Unit.Cm(0.80000042915344238R))
        Me.bcBarras.Symbology = Telerik.Reporting.Barcode.SymbologyType.EAN128
        Me.bcBarras.Value = "= Fields.NumAcreditacion"
        '
        'picQR
        '
        NavigateToUrlAction1.Url = """http://consulta.sdhjgd.gob.hn/waconsultasimex/mobil/acreditaciones.aspx?id="" & =" & _
    "Fields.NumAcreditacion"
        Me.picQR.Action = NavigateToUrlAction1
        Me.picQR.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1000003814697266R), Telerik.Reporting.Drawing.Unit.Cm(4.5999999046325684R))
        Me.picQR.Name = "picQR"
        Me.picQR.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684R), Telerik.Reporting.Drawing.Unit.Cm(2.8000009059906006R))
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3.0R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox8})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8000001907348633R), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.1000003814697266R), Telerik.Reporting.Drawing.Unit.Cm(1.1035408973693848R))
        Me.TextBox8.Style.Font.Bold = True
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.Value = "RICARDO ALFREDO MONTES NÁJERA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SECRETARIO GENERAL"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.8999996185302734R), Telerik.Reporting.Drawing.Unit.Cm(2.5999999046325684R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0R), Telerik.Reporting.Drawing.Unit.Cm(1.0000003576278687R))
        Me.TextBox9.Value = "[=Fields.Institucion]"
        '
        'ObjectDataSource1
        '
        Me.ObjectDataSource1.DataMember = "GetDataA"
        Me.ObjectDataSource1.DataSource = "smx.Simex_DesDataSetTableAdapters.pAcreditaciones_ListTableAdapter, SIMEX, Versio" & _
    "n=1.0.0.0, Culture=neutral, PublicKeyToken=null"
        Me.ObjectDataSource1.Name = "ObjectDataSource1"
        Me.ObjectDataSource1.Parameters.AddRange(New Telerik.Reporting.ObjectDataSourceParameter() {New Telerik.Reporting.ObjectDataSourceParameter("id", GetType(System.Nullable(Of Integer)), "2"), New Telerik.Reporting.ObjectDataSourceParameter("NumAcreditacion", GetType(String), Nothing)})
        '
        'rAcreditacion
        '
        Me.DataSource = Me.ObjectDataSource1
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "rAcreditacion"
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(15.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents bcBarras As Telerik.Reporting.Barcode
    Friend WithEvents picQR As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents ObjectDataSource1 As Telerik.Reporting.ObjectDataSource
End Class