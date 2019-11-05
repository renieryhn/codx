Imports prjDatos
Imports Telerik.Web.UI

Public Class SubMenu
    Inherits System.Web.UI.MasterPage
    Private cFunciones As New funciones
    Dim dtDatos As New DataTable
    Private Const spListNombre As String = "pExpediente_List"
    Private m_idExpediente As String
    Private m_subServicio As String
    Private m_idResponsable As String
    Private m_idTipoResponsable As String

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AddHandler Master.PreRender, AddressOf Page_PreRender
            If Request.QueryString("id") <> "" Then
                Session("id") = Request.QueryString("id")
                CargarValores()
            Else
                If Session("id") <> "" Then
                    CargarValores()
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub
#End Region

#Region "Propiedades"
    Public Property idExpediente() As String
        Get
            Return m_idExpediente
        End Get
        Protected Set(ByVal value As String)
            m_idExpediente = value
        End Set
    End Property
    Public Property SubServicio() As String
        Get
            Return m_subServicio
        End Get
        Set(ByVal value As String)
            m_subServicio = value
        End Set
    End Property

    Public Property idResponsable() As String
        Get
            Return m_idResponsable
        End Get
        Protected Set(ByVal value As String)
            m_idResponsable = value
        End Set
    End Property
    Public Property idTipoResponsable() As String
        Get
            Return m_idTipoResponsable
        End Get
        Protected Set(ByVal value As String)
            m_idTipoResponsable = value
        End Set
    End Property
#End Region

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
            If Session("id") <> "" Then
                dtDatos = cFunciones.Filldatatable(spListNombre, dtParametros)
                If Not IsNothing(dtDatos) Then
                    If dtDatos.Rows.Count = 1 Then
                        idExpediente = dtDatos.Rows(0).Item(txtCodigo.FieldName).ToString
                        m_subServicio = dtDatos.Rows(0).Item("IdSubservicio")
                        m_idResponsable = dtDatos.Rows(0).Item("IdResponsable").ToString
                        m_idTipoResponsable = dtDatos.Rows(0).Item(txtTipoEncargado.FieldName).ToString
                        txtCodigo.Text = dtDatos.Rows(0).Item(txtCodigo.FieldName).ToString
                        txtEncargadoResponsable.Text = dtDatos.Rows(0).Item(txtEncargadoResponsable.FieldName).ToString
                        txtInteresadoSolicitante.Text = dtDatos.Rows(0).Item(txtInteresadoSolicitante.FieldName).ToString
                        txtTipoSolicitante.Text = dtDatos.Rows(0).Item(txtTipoSolicitante.FieldName).ToString
                        txtTipoEncargado.Text = dtDatos.Rows(0).Item(txtTipoEncargado.FieldName).ToString
                        txtServicio.Text = dtDatos.Rows(0).Item(txtServicio.FieldName)
                        txtSubServicio.Text = dtDatos.Rows(0).Item(txtSubServicio.FieldName)
                        txtDepartamento.Text = dtDatos.Rows(0).Item(txtDepartamento.FieldName)
                        txtMunicipio.Text = dtDatos.Rows(0).Item(txtMunicipio.FieldName)
                    End If
                End If
            Else
                txtCodigo.Focus()
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
            dtParametros.Rows.Add("id", Session("id"))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosExpediente() As DataTable
        Try
            dtParametrosExpediente = cFunciones.dtDatos.Clone
            dtParametrosExpediente.Rows.Add("Usuario", Master.Usuario)
            dtParametrosExpediente.Rows.Add("SubMenu", "1")
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
            Session("id") = Trim(txtBuscarExp.Text)
            Dim tbl As DataTable = cFunciones.Filldatatable(spListNombre, dtParametros)
            If Not IsNothing(tbl) Then
                If tbl.Rows.Count = 1 Then
                    sURL = System.IO.Path.GetFileName(HttpContext.Current.Request.FilePath)
                Else
                    sURL = "~/Registro/Expediente/WfmExpediente_List.aspx"
                    Session("preBusqueda") = "1"
                End If
            End If
            Response.Redirect(sURL)
        End If
    End Sub

End Class