﻿Imports prjDatos
Public Class wfmConstancia_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private m_dtDatos As New DataTable
    Private m_szMensaje As String = ""
    Private Const szConstanciaEdit As String = "pConstancia_Edit"
    Private Const spListNombre As String = "pConstancia_List"
    Private pageTitle = "Editar Constancia"

    Public Function getServicio() As String
        Dim retval = ""
        If TextBox1.Text <> "" Then
            Dim tokens = TextBox1.Text.Split("-")
            retval = tokens(0).ToUpper
        End If
        Return retval
    End Function

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub

    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add("IdConstancia", Session("ID"))
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                m_dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                TextBox1.Text = m_dtDatos.Rows(0).Item("IdExpediente")
                TextBox2.Text = m_dtDatos.Rows(0).Item("NRF")
                TextBox3.Text = m_dtDatos.Rows(0).Item("IdConstancia")
                If getServicio() = "V" Then
                    rbExtranjeria.Visible = True
                    rbPJ.Visible = True
                    rbPJ.Checked = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function dtParametrosEdit() As DataTable
        Try
            dtParametrosEdit = Funciones.dtDatos.Clone
            dtParametrosEdit.Rows.Add(TextBox3.FieldName, TextBox3.Text)
            dtParametrosEdit.Rows.Add(TextBox2.FieldName, TextBox2.Text)
            dtParametrosEdit.Rows.Add("IdUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

   Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(szConstanciaEdit, dtParametrosEdit, m_szMensaje)
        Session("Mensaje") = m_szMensaje
        Return Ok
    End Function

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        'hacer el cambio,
        If bModificar() Then
            'Response.Redirect(linkMain.NavigateUrl)
            If getServicio() = "V" Then
                If rbPJ.Checked Then
                    Session("TipoReporte") = "PJ"
                Else
                    Session("TipoReporte") = "E"
                End If
            Else
                Session("TipoReporte") = getServicio()
            End If
            Session("id") = TextBox3.Text
            Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
        Else
            Mensaje(m_szMensaje)
        End If
        'generar reporte

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        'no hacer nada retornar a la pagina anterior
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = pageTitle

        Master.setAplicarVisible = False
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
        If Not IsPostBack Then
            CargarValores()
        End If
    End Sub

End Class