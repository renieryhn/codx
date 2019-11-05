Imports prjDatos
Imports smx.FormsAuth
Public Class Login
    Inherits System.Web.UI.Page
    Dim Funciones As New funciones
    Dim dtPermisos As New DataTable
    Dim Autenticacion As New LdapAuthentication
    Dim nombreDominio As String = "sdhjgd.gob.hn"
    Dim spBitacora_Add As String = "pBitacora_Add"
    Dim sMensaje As String
    Private bAuthenticated As Boolean = False
    Dim cFunciones As New funciones

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserName.Focus()
        If Not IsNothing(Session("Usuario")) Then
            UsuarioActivo(False)
        End If
        If Not IsPostBack Then
            ' ListarUsuarios()
        End If
    End Sub
#End Region

#Region "Metodos"
    'Sub ListarUsuarios()
    '    Dim iPageMax As Integer = 0
    '    Dim dtParam As DataTable
    '    dtParam = cFunciones.dtDatos.Clone
    '    dtParam.Rows.Add("StartIndex", 0)
    '    dtParam.Rows.Add("EndIndex", 1000000)
    '    Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_ListByIndex", dtParam)

    '    Dim tblResultado As DataTable = tbl.Select("FotoURL<>'~/Fotos/oficial.png'").CopyToDataTable()
    '    RadRotator1.DataSource = tblResultado
    '    RadRotator1.DataBind()

    'End Sub
    Private Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            Dim iUser As Integer = 0
            dtParametros.Rows.Add("Usuario", iUser)
            dtParametros.Rows.Add("Nombre", UserName.Text)
            dtParametros.Rows.Add("Password", Password.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
#End Region

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim tblUser As DataTable = Funciones.Filldatatable("pUsuario_List", dtParametros, sMensaje)
        If tblUser.Rows.Count = 0 Then
            bAuthenticated = False
            FailureText.Text = "El Nombre de Usuario o la contraseña que ha introducido no son correctas."
        Else
            bAuthenticated = True
            Session("Usuario") = Trim(UserName.Text)
            Session("UsuarioId") = tblUser.Rows(0).Item("Id")
            Session("UsuarioNombre") = tblUser.Rows(0).Item("NombreEmpleado")
            Session("UsuarioRol") = tblUser.Rows(0).Item("idRol")
            Session.Timeout = 480
            UsuarioActivo(True)
            Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
        End If
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
    End Sub

    Public Function UsuarioActivo(bActivo As Boolean) As Boolean
        Dim sMsg As String = ""
        Dim OK As Boolean = Funciones.Ejecutar("pUsuario_UpdateEstado", dtParametrosEstadoUsuario(bActivo), sMsg)
        Return OK
    End Function
    Private Function dtParametrosEstadoUsuario(bActivo As Boolean) As DataTable
        Try
            Dim sUserName As String = Session("Usuario")
            dtParametrosEstadoUsuario = Funciones.dtDatos.Clone
            dtParametrosEstadoUsuario.Rows.Add("Nombre", Trim(sUserName))
            dtParametrosEstadoUsuario.Rows.Add("Logged", bActivo)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Sub Login_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If Not IsNothing(Session("Usuario")) Then
            UserName.Text = Session("Usuario")
        End If
    End Sub
End Class