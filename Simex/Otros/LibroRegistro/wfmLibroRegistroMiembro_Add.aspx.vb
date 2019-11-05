﻿Imports prjDatos
Public Class wfmLibroRegistroMiembro_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pUR_RegistroJDDet_Add"
    Private sNombreMantenimiento = "Agregar Miembro de Junta Directiva"
    Private cFunciones = New prjDatos.funciones()

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If
        If Not IsPostBack Then
            LlenarGridDet()
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
#End Region
#Region "Metodos"
    Sub LlenarGridDet()
        Dim prams = cFunciones.dtDatos.Clone
        prams.Rows.Add("IdJuntaDirectiva", Session("CodigoRegistroJD"))
        Dim dtDatos As DataTable
        dtDatos = cFunciones.Filldatatable("pUR_RegistroJuntaDet_List", prams, sMensaje)
        gvDatosDet.DataSource = dtDatos
        gvDatosDet.DataBind()
    End Sub

    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add("IdJuntaDirectiva", Session("CodigoRegistroJD"))
            dtParametros.Rows.Add("IdJuntaDirectivaDet", Nothing)
            dtParametros.Rows.Add("IdPersona", Miembro.cliente)
            dtParametros.Rows.Add("IdPuesto", cboPuesto.Value)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
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