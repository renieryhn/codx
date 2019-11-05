﻿Imports prjDatos
Public Class wfmCliente_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pCliente_Edit"
    Private Const spListNombre As String = "pCliente_List"
    Private pageTitle = "Editar Cliente"
#Region "Eventos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        Master.Master.m_titulo = pageTitle

        If Not IsPostBack Then
            CargarValores()
        End If
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            Redirect()
        ElseIf Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            RedirectSelf()
        ElseIf Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
    End Sub
    Sub ChangeSelectedItem(ByVal sender As Object, ByVal e As EventArgs) Handles cboDepartamento.ComboChangedItem
        Try
            cboMunicipio.LLenarCombo(sender)
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Metodos"
    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtCodigo.Text = Session("ID")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                txtNumIdentidad.Text = dtDatos.Rows(0).Item(txtNumIdentidad.FieldName).ToString
                txtNombre1.Text = dtDatos.Rows(0).Item(txtNombre1.FieldName).ToString
                txtNombre2.Text = dtDatos.Rows(0).Item(txtNombre2.FieldName).ToString
                txtApellido1.Text = dtDatos.Rows(0).Item(txtApellido1.FieldName).ToString
                txtApellido2.Text = dtDatos.Rows(0).Item(txtApellido2.FieldName).ToString
                txtPasaporte.Text = dtDatos.Rows(0).Item(txtPasaporte.FieldName).ToString
                cboPais.Value = dtDatos.Rows(0).Item(cboPais.FieldName).ToString
                cboDepartamento.Value = dtDatos.Rows(0).Item(cboDepartamento.FieldName).ToString
                cboMunicipio.Value = dtDatos.Rows(0).Item(cboMunicipio.FieldName).ToString
                txtTelefonoDomicilio.Text = dtDatos.Rows(0).Item(txtTelefonoDomicilio.FieldName).ToString
                txtTelefonoTrabajo.Text = dtDatos.Rows(0).Item(txtTelefonoTrabajo.FieldName).ToString
                txtNumFax.Text = dtDatos.Rows(0).Item(txtNumFax.FieldName).ToString
                txtTelefonoMovil1.Text = dtDatos.Rows(0).Item(txtTelefonoMovil1.FieldName).ToString
                txtTelefonoMovil2.Text = dtDatos.Rows(0).Item(txtTelefonoMovil2.FieldName).ToString
                txtEmail1.Text = dtDatos.Rows(0).Item(txtEmail1.FieldName).ToString
                txtDireccionDomicilio.Text = dtDatos.Rows(0).Item(txtDireccionDomicilio.FieldName).ToString
                txtDireccionTrabajo.Text = dtDatos.Rows(0).Item(txtDireccionTrabajo.FieldName).ToString
                txtObservaciones.Text = dtDatos.Rows(0).Item(txtObservaciones.FieldName).ToString
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
            dtParametrosBusqueda.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
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