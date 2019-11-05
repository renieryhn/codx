Imports prjDatos
Imports Telerik.Web.UI

Class Site
    Inherits MasterPage
    Private Funciones As New funciones
    Dim dtPermisos As New DataTable

#Region "Propiedades"
    Public Property Usuario() As String
        Get
            Return m_usuario
        End Get
        Protected Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Private m_usuario As String
    Public m_titulo As String

    Public Property Modificacion() As Boolean
        Get
            Return m_Modificacion
        End Get
        Protected Set(ByVal value As Boolean)
            m_Modificacion = value
        End Set
    End Property
    Private m_Modificacion As Boolean

    Public Property Borrado() As Boolean
        Get
            Return m_Borrado
        End Get
        Protected Set(ByVal value As Boolean)
            m_Borrado = value
        End Set
    End Property
    Private m_Borrado As Boolean

    Public Property Alta() As Boolean
        Get
            Return m_Alta
        End Get
        Protected Set(ByVal value As Boolean)
            m_Alta = value
        End Set
    End Property
    Private m_Alta As Boolean
#End Region

#Region "Eventos"

    Private Sub Page_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Usuario = "" Then
            Usuario = Session("Usuario")
        End If
        SetSecurity()
    End Sub
#End Region

#Region "Metodos"

    Public Sub SetSecurity()
        If Usuario <> "" Then
            If Not Request.Url.AbsolutePath.ToString() = "~/Autenticacion/Login.aspx" And Not Request.Url.AbsolutePath.ToString() = "/Usuario.aspx" Then
                If Not ValidarURL() Then
                    Session("Mensaje") = ""
                    Session("BackURL") = Request.UrlReferrer
                    Session("Ruta") = Request.Url.AbsolutePath.ToString()
                    Response.Redirect("~/Permiso.aspx")
                Else
                    If Not IsPostBack Then
                        LLenarMenu()
                    End If
                End If
            End If
        Else
            Response.Redirect("~/Autenticacion/Login.aspx")
        End If

    End Sub

    Public Function ValidarURL() As Boolean
        Dim valido As Boolean = True
        Dim sURL As String = Request.Url.AbsolutePath.ToString()
        sURL = Replace(sURL, "/codex", "")
        dtPermisos = Funciones.Filldatatable("ObtenerOpcionesMenu", dtParametros(sURL))
        If dtPermisos.Rows.Count < 1 Then
            valido = False
        Else
            Alta = dtPermisos.Rows(0).Item("indAlta")
            Modificacion = dtPermisos.Rows(0).Item("indModificacion")
            Borrado = dtPermisos.Rows(0).Item("indBorrado")
        End If
        Return valido
    End Function
    Private Sub LLenarMenu()
        Try
            Dim iCont As Integer = 0
            Dim mnuItem As RadMenuItem
            Dim dtDatos As DataTable
            If Usuario <> "" Then
                If rMenu.Items.Count <= 0 Then
                    mnuItem = New RadMenuItem()
                    mnuItem.Value = "0"
                    mnuItem.Text = "Home"
                    mnuItem.NavigateUrl = "~/Default.aspx"
                    rMenu.Items.Add(mnuItem)
                    dtDatos = Funciones.Filldatatable("ObtenerOpcionesMenu", dtParametros(, True))
                    For iCont = 0 To dtDatos.Rows.Count - 1
                        If dtDatos.Rows(iCont)("Menuid").ToString() = dtDatos.Rows(iCont)("Padreid").ToString() Or dtDatos.Rows(iCont)("Padreid").ToString() = "" Then
                            mnuItem = New RadMenuItem()
                            mnuItem.Value = dtDatos.Rows(iCont)("Menuid").ToString()
                            mnuItem.Text = dtDatos.Rows(iCont)("Descripcion").ToString()
                            mnuItem.NavigateUrl = dtDatos.Rows(iCont)("Url").ToString()
                            rMenu.Items.Add(mnuItem)
                            AgregarMenuItems(mnuItem, dtDatos)
                        End If
                    Next iCont
                    mnuItem = New RadMenuItem()
                    mnuItem.Value = "10001"
                    mnuItem.Text = "Mi Cuenta"
                    mnuItem.NavigateUrl = "~/Usuario.aspx"
                    rMenu.Items.Add(mnuItem)

                    mnuItem = New RadMenuItem()
                    mnuItem.Value = "10000"
                    mnuItem.Text = "Cerrar Sesión"
                    mnuItem.NavigateUrl = "~/Autenticacion/Login.aspx"
                    rMenu.Items.Add(mnuItem)
                End If
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
                    'mnuItem.ChildItems.Add(mnuNewItem)
                    mnuItem.Items.Add(mnuNewItem)
                    AgregarMenuItems(mnuNewItem, dtMenuItems)
                End If
            Next iCont
        Catch ex As Exception
            Throw New ApplicationException("", ex)
        End Try
    End Sub 'AgregarMenuItems

    Private Function dtParametros(Optional ByVal URL As String = "", Optional ByVal bMostrarMenu As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add("Usuario", Usuario)
            dtParametros.Rows.Add("URL", URL)
            If bMostrarMenu = True Then
                dtParametros.Rows.Add("MostrarEnMenu", "1")
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region

    Public Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try

            lblTitulo.Text = m_titulo
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub

End Class
