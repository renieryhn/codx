﻿Imports prjDatos
Public Class wfmCliente_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pCliente_Add"
    Private pageTitle = "Agregar Cliente"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = pageTitle

        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMain.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Sub ChangeSelectedItem(ByVal sender As Object, ByVal e As EventArgs) Handles cboDepartamento.ComboChangedItem
        Try
            cboMunicipio.LLenarCombo(sender)
        Catch ex As Exception

        End Try
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
#End Region
#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Dim i As Integer
        Ok = Funciones.Ejecutar(spNombre, dtParametros, "idNuevo", i, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(txtNumIdentidad.FieldName, txtNumIdentidad.Text)
            dtParametros.Rows.Add(txtPasaporte.FieldName, txtPasaporte.Text)
            dtParametros.Rows.Add(txtNombre1.FieldName, txtNombre1.Text)
            dtParametros.Rows.Add(txtNombre2.FieldName, txtNombre2.Text)
            dtParametros.Rows.Add(txtApellido1.FieldName, txtApellido1.Text)
            dtParametros.Rows.Add(txtApellido2.FieldName, txtApellido2.Text)
            dtParametros.Rows.Add(cboPais.FieldName, cboPais.Value)
            dtParametros.Rows.Add(txtTelefonoDomicilio.FieldName, txtTelefonoDomicilio.Text)
            dtParametros.Rows.Add(txtTelefonoTrabajo.FieldName, txtTelefonoTrabajo.Text)
            dtParametros.Rows.Add(txtNumFax.FieldName, txtNumFax.Text)
            dtParametros.Rows.Add(txtTelefonoMovil1.FieldName, txtTelefonoMovil1.Text)
            dtParametros.Rows.Add(txtTelefonoMovil2.FieldName, txtTelefonoMovil2.Text)
            dtParametros.Rows.Add(txtEmail1.FieldName, txtEmail1.Text)
            dtParametros.Rows.Add(txtEmail2.FieldName, txtEmail2.Text)
            dtParametros.Rows.Add(txtDireccionDomicilio.FieldName, txtDireccionDomicilio.Text)
            dtParametros.Rows.Add(txtDireccionTrabajo.FieldName, txtDireccionTrabajo.Text)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(txtObservaciones.FieldName, txtObservaciones.Text)
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