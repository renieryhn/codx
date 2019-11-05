Imports prjdatos
Public Class ListBox
    Inherits System.Web.UI.UserControl

#Region "Declaraciones"
    Private _cDB As New cMetodos
    Public Event ComboChangedItem(ByVal sender As Object, ByVal e As EventArgs)
    Private _dataTable As New DataTable
#End Region
#Region "Propiedades"
    Public Property Obligatorio As Boolean
    Public Property AutoFill As Boolean
    Public Property FieldName As String
    Public Property idParentComboBox As String
    Public Property TableName As String
    Public Property idFieldName As String
    Public Property textFieldName As String
    Public Property AditionalCondition As String
    Public Property Consulta As String
    Public Property Ordenacion As String = ""
    Public Property Procedimiento As Boolean = False
    'Public Property itemVacio As Boolean = True
    Public Property Text As String
        Get
            If DropDownList1.SelectedValue.ToString = "-1" Then
                Return ""
            Else
                Return DropDownList1.SelectedItem.Text
            End If
        End Get
        Set(ByVal value As String)
            DropDownList1.Text = Text
        End Set
    End Property

    Public Property habilitado As Boolean
        Get
            Return DropDownList1.Enabled
        End Get
        Set(ByVal value As Boolean)
            DropDownList1.Enabled = value
        End Set
    End Property
    Public Property Value As String
        Get
            Valido()
            If DropDownList1.SelectedValue.ToString = "-1" Then
                Return Nothing
            Else
                Return DropDownList1.SelectedValue
            End If
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                DropDownList1.SelectedValue = value
            End If
        End Set
    End Property
    Public Property postBack As Boolean
        Get
            Return DropDownList1.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            DropDownList1.AutoPostBack = value
        End Set
    End Property
    Public Property SelectedIndex As Integer
        Get
            Return DropDownList1.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            DropDownList1.SelectedIndex = value
        End Set
    End Property
#End Region


#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Session("Mensaje") = ""
                If idParentComboBox = "" Then
                    If AutoFill Then
                        If Procedimiento Then
                            LLenarComboProcedimiento()
                        Else
                            LLenarCombo()
                        End If
                    End If
                End If
                If Obligatorio = True Then
                    lblMensaje.Text = "*"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            RaiseEvent ComboChangedItem(DropDownList1.SelectedValue, e)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Metodos"
    Public Sub LLenarCombo(Optional ByVal id As String = "")
        Try
            Dim strQuery As String
        Dim dtRow As DataRow
        Dim dtView As New DataView
        DropDownList1.DataSource = Nothing
        DropDownList1.Items.Clear()
        _dataTable = New DataTable
        If Consulta = "" Then
            strQuery = "Select " & idFieldName & ", " & textFieldName & " From " & TableName
            strQuery = strQuery & " where 1=1 "
            If id <> "" And id <> "-1" And idParentComboBox <> "" Then
                strQuery = strQuery & " and " & idParentComboBox & "='" & id & "' "
            End If
            If AditionalCondition <> "" Then
                strQuery = strQuery & " and " & AditionalCondition
            End If
        Else
            strQuery = Consulta
        End If
            strQuery = strQuery.Replace("@Filtro", id)
            If Ordenacion <> "" Then
                strQuery = strQuery & " Order by " & Ordenacion
            Else
                strQuery = strQuery & " Order by " & textFieldName
            End If
        If (idParentComboBox <> "" And id <> "" And id <> "-1") Or (idParentComboBox = "" And (id = "" Or id <> "-1")) Then
            _dataTable = _cDB.FillQuery(strQuery)
        Else
            _dataTable.Columns.Add(idFieldName, GetType(String))
            _dataTable.Columns.Add(textFieldName, GetType(String))
        End If
            dtRow = _dataTable.NewRow
        If _dataTable.Rows.Count > 0 Then
            dtRow.Item(0) = "-1"
            dtRow.Item(1) = "Seleccionar..."
            DropDownList1.DataValueField = _dataTable.Columns(0).ColumnName ' idFieldName
            DropDownList1.DataTextField = _dataTable.Columns(1).ColumnName ' textFieldName
                _dataTable.Rows.InsertAt(dtRow, 0)
            End If
            DropDownList1.DataSource = _dataTable
            DropDownList1.DataBind()
            RaiseEvent ComboChangedItem(DropDownList1.SelectedValue, Nothing)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try
    End Sub

    Public Sub LLenarCombo(ByVal dtFiltros As DataTable)
        Try
            Dim dtRow As DataRow
            DropDownList1.DataSource = Nothing
            DropDownList1.Items.Clear()
            _dataTable = New DataTable
            _dataTable = _cDB.Filldatatable(TableName, dtFiltros)
            dtRow = _dataTable.NewRow
            dtRow.Item(0) = "-1"
            dtRow.Item(1) = "Seleccionar..."
            DropDownList1.DataValueField = _dataTable.Columns(0).ColumnName 'idFieldName
            DropDownList1.DataTextField = _dataTable.Columns(1).ColumnName 'textFieldName

            _dataTable.Rows.InsertAt(dtRow, 0)
            DropDownList1.DataSource = _dataTable
            DropDownList1.DataBind()
            RaiseEvent ComboChangedItem(DropDownList1.SelectedValue, Nothing)
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub

    Public Sub LLenarComboDatatable(ByVal dtDatos As DataTable)
        Try
            Dim dtRow As DataRow
            DropDownList1.DataSource = Nothing
            DropDownList1.Items.Clear()

            dtRow = dtDatos.NewRow
            dtRow.Item(0) = "-1"
            dtRow.Item(1) = "Seleccionar..."
            DropDownList1.DataValueField = dtDatos.Columns(0).ColumnName 'idFieldName
            DropDownList1.DataTextField = dtDatos.Columns(1).ColumnName 'textFieldName

            dtDatos.Rows.InsertAt(dtRow, 0)
            DropDownList1.DataSource = dtDatos
            DropDownList1.DataBind()
            RaiseEvent ComboChangedItem(DropDownList1.SelectedValue, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LLenarComboProcedimiento(Optional ByVal id As String = "")
        Try

        
        Dim dtRow As DataRow
        DropDownList1.DataSource = Nothing
        DropDownList1.Items.Clear()
        _dataTable = New DataTable
            _dataTable = _cDB.Filldatatable(TableName)
        dtRow = _dataTable.NewRow
        dtRow.Item(0) = "-1"
        dtRow.Item(1) = "Seleccionar..."
        DropDownList1.DataValueField = _dataTable.Columns(0).ColumnName 'idFieldName
        DropDownList1.DataTextField = _dataTable.Columns(1).ColumnName 'textFieldName

        _dataTable.Rows.InsertAt(dtRow, 0)
        DropDownList1.DataSource = _dataTable
        DropDownList1.DataBind()
            RaiseEvent ComboChangedItem(DropDownList1.SelectedValue, Nothing)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            lblMensaje.Visible = True
        End Try
    End Sub
    Private Function Valido() As Boolean
        Dim bValido As Boolean = True
        lblMensaje.Text = ""
        If Obligatorio Then
            If DropDownList1.SelectedValue = "-1" Then
                bValido = False
                lblMensaje.Text = "Debe Seleccionar un valor de la lista"
                Session("Mensaje") = "Error"
                'Else
                '    Session("Mensaje") = ""
            End If
            'Else
            '    Session("Mensaje") = ""
        End If
        Return bValido
    End Function

#End Region
End Class