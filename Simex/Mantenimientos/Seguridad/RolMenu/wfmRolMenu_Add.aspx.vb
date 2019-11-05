Imports prjDatos
Public Class wfmRolMenu_Add
    Inherits System.Web.UI.Page
#Region "Declaraciones"
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pRolMenu_Add"
    Private sNombreMantenimiento = "Agregar Menu a Rol"
    Public Event ComboChangedItem(ByVal sender As Object, ByVal e As EventArgs)
#End Region
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
        If Not IsPostBack Then
            If Session("Pre") <> "" Then
                Me.cbRol.Value = Session("Pre")
            End If
        End If

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMain.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkMain.NavigateUrl)
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMe.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

    End Sub
    Sub ChangeSelectedItem(ByVal sender As Object, ByVal e As EventArgs) Handles cbRol.ComboChangedItem
        Try
            cboMenu.LLenarCombo(sender)
            Session("Pre") = Me.cbRol.Value
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(cboMenu.FieldName, cboMenu.Value)
            dtParametros.Rows.Add(cbRol.FieldName, cbRol.Value)
            dtParametros.Rows.Add("indAlta", chkAlta.Checked)
            dtParametros.Rows.Add("indModificacion", chkModificacion.Checked)
            dtParametros.Rows.Add("indBorrado", chkBorrado.Checked)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        If sMensaje <> "" Then
            Dim strScript As String = "<script language=JavaScript>"
            strScript += "alert(""" & sMensaje & """);"
            strScript += "</script>"
            If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
            End If
            Session("Mensaje") = ""
        End If
    End Sub
#End Region
End Class