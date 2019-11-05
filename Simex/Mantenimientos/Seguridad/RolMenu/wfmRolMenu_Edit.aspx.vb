Imports prjDatos
Public Class wfmRolMenu_Edit
    Inherits System.Web.UI.Page
#Region "Declaraciones"
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pRolMenu_Edit"
    Private Const spListNombre As String = "pRolMenu_List"
    Private sNombreMantenimiento = "Editar Menu Rol"
    Public Event ComboChangedItem(ByVal sender As Object, ByVal e As EventArgs)
    Private dtDatos As New DataTable
#End Region
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            CargarValores()
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            Redirect()
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            RedirectSelf()
        Else
            Mensaje(sMensaje)
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Sub Redirect()
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Private Sub RedirectSelf()
        Response.Redirect(linkMe.NavigateUrl)
    End Sub
    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtCodigo.Text = Session("ID")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                cbRol.Value = dtDatos.Rows(0).Item(cbRol.FieldName)
                cboMenu.Value = dtDatos.Rows(0).Item(cboMenu.FieldName)
                chkAlta.Checked = dtDatos.Rows(0).Item("indAlta")
                chkModificacion.Checked = dtDatos.Rows(0).Item("indModificacion")
                chkBorrado.Checked = dtDatos.Rows(0).Item("indBorrado")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
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