Imports prjDatos
Imports Telerik.Web.UI

Public Class URSubMenu
    Inherits System.Web.UI.MasterPage
    Private cFunciones As New funciones
    Dim dtDatos As New DataTable
    Private Const spListNombre As String = "pUR_Registro_List"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AddHandler Master.PreRender, AddressOf Page_PreRender
            If Session("idRegistro") <> "" Then
                CargarValores()
            End If
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub
#End Region

    Public Property NumRegistro() As String
        Get
            Return m_NumRegistro
        End Get
        Protected Set(ByVal value As String)
            m_NumRegistro = value
        End Set
    End Property

    Public Property IdApoderado() As String
        Get
            Return m_IdApoderado
        End Get
        Protected Set(ByVal value As String)
            m_IdApoderado = value
        End Set
    End Property

    Public Property IdEmpresa() As String
        Get
            Return m_IdEmpresa
        End Get
        Protected Set(ByVal value As String)
            m_IdEmpresa = value
        End Set
    End Property

    Private m_NumRegistro As String
    Private m_IdApoderado As String
    Private m_IdEmpresa As String

#Region "Metodos"
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try
            If Not IsPostBack Then
                LLenarMenu()
            End If
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub
    Private Sub CargarValores()
        Try
            If Session("idRegistro") <> "" Then
                dtDatos = cFunciones.Filldatatable(spListNombre, dtParametros)
                If Not IsNothing(dtDatos) Then
                    If dtDatos.Rows.Count = 1 Then
                        If (dtDatos.Rows(0).Item(txtFecha.FieldName).ToString) <> "" Then
                            txtFecha.Text = CDate(dtDatos.Rows(0).Item(txtFecha.FieldName)).ToShortDateString
                        End If
                        txtPais.Text = dtDatos.Rows(0).Item(txtPais.FieldName).ToString
                        NumRegistro = dtDatos.Rows(0).Item(txtNumRegistro.FieldName).ToString
                        txtNumRegistro.Text = dtDatos.Rows(0).Item(txtNumRegistro.FieldName).ToString
                        txtEncargadoResponsable.Text = dtDatos.Rows(0).Item(txtEncargadoResponsable.FieldName).ToString
                        txtDenominacion.Text = dtDatos.Rows(0).Item(txtDenominacion.FieldName).ToString
                        txtTipoAsociacion.Text = dtDatos.Rows(0).Item(txtTipoAsociacion.FieldName).ToString
                        txtSiglas.Text = dtDatos.Rows(0).Item(txtSiglas.FieldName).ToString
                        txtNumExpediente.Text = dtDatos.Rows(0).Item(txtNumExpediente.FieldName).ToString
                        txtDepartamento.Text = dtDatos.Rows(0).Item(txtDepartamento.FieldName).ToString
                        txtMunicipio.Text = dtDatos.Rows(0).Item(txtMunicipio.FieldName).ToString
                        txtDireccion.Text = dtDatos.Rows(0).Item(txtDireccion.FieldName).ToString
                        txtDictamen.Text = dtDatos.Rows(0).Item(txtDictamen.FieldName).ToString
                        txtFDictamen.Text = dtDatos.Rows(0).Item(txtFDictamen.FieldName).ToString
                        txtResolucion.Text = dtDatos.Rows(0).Item(txtResolucion.FieldName).ToString
                        hfIdInstitucion.Value = dtDatos.Rows(0).Item("IdInstitucion").ToString

                        m_IdApoderado = dtDatos.Rows(0).Item("IdSolicitanteApoderado").ToString
                        m_IdEmpresa = dtDatos.Rows(0).Item("IdInstitucion").ToString


                        If dtDatos.Rows(0).Item("Estado").ToString = "A" Then
                            lblCancel.Visible = False
                        Else
                            lblCancel.Visible = True
                        End If
                    End If
                End If
            Else
                txtNumRegistro.Focus()
            End If
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub
    Private Sub LLenarMenu()
        Try
            Dim iCont As Integer = 0
            Dim mnuItem As RadMenuItem
            Dim dtDatos As DataTable
            RadMenu1.Items.Clear()
            If Master.Usuario <> "" Then
                dtDatos = cFunciones.Filldatatable("ObtenerOpcionesMenu", dtParametrosExpediente())
                For iCont = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(iCont)("Menuid").ToString() = dtDatos.Rows(iCont)("Padreid").ToString() Or dtDatos.Rows(iCont)("Padreid").ToString() = "" Then
                        mnuItem = New RadMenuItem()
                        mnuItem.Value = dtDatos.Rows(iCont)("Menuid").ToString()
                        mnuItem.Text = dtDatos.Rows(iCont)("Descripcion").ToString()
                        mnuItem.NavigateUrl = dtDatos.Rows(iCont)("Url").ToString()
                        RadMenu1.Items.Add(mnuItem)
                        AgregarMenuItems(mnuItem, dtDatos)
                    End If
                Next iCont
            End If
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub 'LLenarMenu

    Private Sub AgregarMenuItems(ByVal mnuItem As RadMenuItem, ByVal dtMenuItems As DataTable)
        Try
            Dim iCont As Integer = 0
            Dim mnuNewItem As RadMenuItem
            For iCont = 0 To dtMenuItems.Rows.Count - 1
                If dtMenuItems.Rows(iCont)("Padreid").ToString() = mnuItem.Value.ToString() And dtMenuItems.Rows(iCont)("Menuid").ToString() <> dtMenuItems.Rows(iCont)("Padreid").ToString() Then
                    mnuNewItem = New RadMenuItem()
                    mnuNewItem.Value = dtMenuItems.Rows(iCont)("Menuid").ToString()
                    mnuNewItem.Text = dtMenuItems.Rows(iCont)("Descripcion").ToString()
                    mnuNewItem.NavigateUrl = dtMenuItems.Rows(iCont)("Url").ToString()
                    mnuItem.Items.Add(mnuNewItem)
                    AgregarMenuItems(mnuNewItem, dtMenuItems)
                End If
            Next iCont
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub 'AgregarMenuItems
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("NumRegistro", Session("idRegistro"))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosExpediente() As DataTable
        Try
            dtParametrosExpediente = cFunciones.dtDatos.Clone
            dtParametrosExpediente.Rows.Add("Usuario", Master.Usuario)
            dtParametrosExpediente.Rows.Add("SubMenu", "2")
            'dtParametrosExpediente.Rows.Add("URL", URL)
            Return dtParametrosExpediente
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscar.Click
        Dim sURL As String = ""
        If txtBuscarExp.Text <> "" Then
            Session("idRegistro") = Trim(txtBuscarExp.Text)
            Dim tbl As DataTable = cFunciones.Filldatatable(spListNombre, dtParametros)
            If Not IsNothing(tbl) Then
                If tbl.Rows.Count = 1 Then
                    sURL = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath)
                Else
                    sURL = "~/URSAC/wfmAsociacionesCiviles_List.aspx"
                    Session("preBusqueda") = "1"
                    Session("NumRegistro") = Trim(txtBuscarExp.Text)
                End If
            End If
            Response.Redirect(sURL)
        End If
    End Sub

    Protected Sub btnEditInst_Click(sender As Object, e As ImageClickEventArgs) Handles btnEditInst.Click
        Response.Redirect("~/Mantenimientos/Generales/Instituciones/wfmInstituciones_Edit.aspx?ID=" & hfIdInstitucion.Value.ToString)
    End Sub
End Class