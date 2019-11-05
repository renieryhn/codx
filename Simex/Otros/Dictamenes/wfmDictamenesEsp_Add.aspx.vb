Imports prjDatos
Public Class wfmDictamenesEsp_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private ConsultaPuesto As String
    Private idFieldName As String
    Private TableName As String
    Private sMensaje As String = ""
    Private nombre = "Agregar Dictamen Especial"

    Private Const spNombre As String = "pDictamenesEsp_Add"
    Private Const spNombreSPMax As String = "pDictamenesMax"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = nombre
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
        Dim i = ""
        Ok = Funciones.Ejecutar(spNombre, dtParametros)
        If Ok = False Then
            If Session("Mensaje") <> "" Then
                Mensaje(Session("Mensaje"))
            End If
        End If
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(dtcFecha.FieldName, dtcFecha.Value)
            dtParametros.Rows.Add(txtExpediente.FieldName, txtExpediente.Text)
            dtParametros.Rows.Add(txtJustificacion.FieldName, txtJustificacion.Text)
            dtParametros.Rows.Add(txtNumeroDictamen.FieldName, txtNumeroDictamen.Text)
            dtParametros.Rows.Add(txtSeccion.FieldName, UCase(txtSeccion.Text))
            dtParametros.Rows.Add("Tipo", "3")
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
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


    Protected Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim tbl As DataTable = Funciones.Filldatatable(spNombreSPMax, dtParamMax)
        txtNumeroDictamen.Text = tbl.Rows(0).Item(0).ToString
    End Sub

    Public Function dtParamMax() As DataTable
        Try
            dtParamMax = Funciones.dtDatos.Clone
            dtParamMax.Rows.Add(dtcFecha.FieldName, dtcFecha.Value)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
End Class