Imports prjDatos
Public Class wfmTramites_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pTramites_Add"
    Private Const spNombreMAX As String = "pTramites_MAX"
    Private pageTitle = "Registrar Asociación Comunitaria"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = pageTitle
        If Not IsPostBack Then
            Me.dtcFechaRegistro.Value = Now.Date
        End If
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
            Session("Mensaje") = ""
        End If
    End Sub
    Sub LoadNumRegistro()
        Dim tbl As DataTable = Funciones.Filldatatable(spNombreMAX, dtParamMax)
        If tbl.Rows.Count > 0 Then
            txtNumRegistro.Text = tbl.Rows(0).Item(0).ToString
        End If
        dtcFechaRegistro.Value = Now.Date
    End Sub
    Public Function dtParamMax() As DataTable
        Try
            dtParamMax = Funciones.dtDatos.Clone
            'dtParamMax.Rows.Add(dtcFecha.FieldName, dtcFecha.Value)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

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

    Private Sub cboDepartamento_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.ComboChangedItem
        If sender.ToString <> "" Then
            cboMunicipio.LLenarCombo(sender)
        End If
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
            Dim iTipoEntidad As Integer = 0
            If EncargadoResponsable.cliente <> "" Then
                iTipoEntidad = 2
            ElseIf EncargadoResponsable.Apoderado <> "" Then
                iTipoEntidad = 1
            Else
                iTipoEntidad = 0
            End If
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(dtcFechaRegistro.FieldName, dtcFechaRegistro.Value)
            dtParametros.Rows.Add("IdInstitucion", Asociacion.Institucion)
            dtParametros.Rows.Add("TipoSolicitante", iTipoEntidad)
            dtParametros.Rows.Add("IdSolicitanteCliente", EncargadoResponsable.cliente)
            dtParametros.Rows.Add("IdSolicitanteApoderado", EncargadoResponsable.Apoderado)
            dtParametros.Rows.Add(cboDepartamento.FieldName, cboDepartamento.Value)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(cboTipoAsoc.FieldName, cboTipoAsoc.Value)
            dtParametros.Rows.Add(txtFolio.FieldName, txtFolio.Text)
            dtParametros.Rows.Add(txtTomo.FieldName, txtTomo.Text)
            dtParametros.Rows.Add(txtNotasMarginales.FieldName, txtNotasMarginales.Text)
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

    Private Sub cboMunicipio_ComboChangedItem(sender As Object, e As EventArgs) Handles cboMunicipio.ComboChangedItem
        Try
            LoadNumRegistro()
        Catch ex As Exception

        End Try
    End Sub
End Class