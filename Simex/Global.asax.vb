Imports prjDatos
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState
Imports System.Xml.Linq


Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)


    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
        UsuarioActivo(False)
    End Sub

    Public Function UsuarioActivo(bActivo As Boolean) As Boolean
        Dim Funciones As New funciones
        Dim sMsg As String = ""
        Dim OK As Boolean = Funciones.Ejecutar("pUsuario_UpdateEstado", dtParametrosEstadoUsuario(bActivo), sMsg)
        Return OK
    End Function
    Private Function dtParametrosEstadoUsuario(bActivo As Boolean) As DataTable
        Try
            Dim cFunciones As New funciones
            Dim sUserName As String = Session("Usuario")
            dtParametrosEstadoUsuario = cFunciones.dtDatos.Clone
            dtParametrosEstadoUsuario.Rows.Add("Nombre", sUserName)
            dtParametrosEstadoUsuario.Rows.Add("Logged", bActivo)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class