﻿Imports prjDatos
Public Class wfmEstadosRol_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pEstadosRol_Edit"
    Private Const spListNombre As String = "pEstadosRol_List"
    Private sNombreMantenimiento = "Editar estados a rol"

#Region "Eventos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
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
    Private Sub CargarValores()
        Try
            If Session("IdRol") <> "" Then
                txtidRol.Text = Session("IdRol")
                txtidEstado.Text = Session("IdEstado")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                cboEstados.Value = dtDatos.Rows(0).Item(cboEstados.FieldName)
                cboRoles.Value = dtDatos.Rows(0).Item(cboRoles.FieldName)
                chkEnviar.Checked = dtDatos.Rows(0).Item("Enviar")
                chkRecibir.Checked = dtDatos.Rows(0).Item("Recibir")
            End If
        Catch ex As Exception

        End Try
    End Sub

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

    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add(txtidRol.FieldName, txtidRol.Text)
            dtParametrosBusqueda.Rows.Add(txtidEstado.FieldName, txtidEstado.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add("IdRolb", txtidRol.Text)
            dtParametros.Rows.Add("IdEstadob", txtidEstado.Text)
            dtParametros.Rows.Add(cboEstados.FieldName, cboEstados.Value)
            dtParametros.Rows.Add(cboRoles.FieldName, cboRoles.Value)
            dtParametros.Rows.Add("Enviar", chkEnviar.Checked)
            dtParametros.Rows.Add("Recibir", chkRecibir.Checked)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
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

End Class