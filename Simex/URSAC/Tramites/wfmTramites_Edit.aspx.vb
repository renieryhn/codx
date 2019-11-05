Imports prjDatos
Public Class wfmTramites_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pTramites_Edit"
    Private Const spListNombre As String = "pTramites_List"
    Private pageTitle = "Editar Asociación Civil"
    Protected PageBody As HtmlGenericControl
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

    Private Sub cboDepartamento_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.ComboChangedItem
        If sender.ToString <> "" Then
            cboMunicipio.LLenarCombo(sender)
        End If
    End Sub
#End Region

#Region "Metodos"
    Private Sub CargarValores()
        Try
            If Session("IdRegistro") <> "" Then
                txtNumRegistro.Text = Session("IdRegistro")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)

                If dtDatos.Rows.Count > 0 Then
                    dtcFechaRegistro.Value = dtDatos.Rows(0).Item(dtcFechaRegistro.FieldName).ToString
                    Asociacion.idEntidad = dtDatos.Rows(0).Item("IdInstitucion").ToString
                    Asociacion.TipoEntidadCombo = "I"
                    Asociacion.LoadDefaults()
                    Dim sNombreTipo As String = ""
                    Dim iIdEntidad As Integer = 0
                    Select Case dtDatos.Rows(0).Item("TipoSolicitante")
                        Case 1
                            sNombreTipo = "A"
                            iIdEntidad = dtDatos.Rows(0).Item("IdApoderado").ToString
                        Case 2
                            sNombreTipo = "C"
                            iIdEntidad = dtDatos.Rows(0).Item("IdSolicitanteCliente").ToString
                        Case 3
                            sNombreTipo = "I"
                            iIdEntidad = dtDatos.Rows(0).Item("IdSolicitanteInstitucion").ToString
                    End Select
                    EncargadoResponsable.idEntidad = iIdEntidad
                    EncargadoResponsable.TipoEntidadCombo = sNombreTipo
                    EncargadoResponsable.LoadDefaults()
                    cboDepartamento.Value = dtDatos.Rows(0).Item(cboDepartamento.FieldName).ToString
                    cboMunicipio.LLenarCombo(cboDepartamento.Value)
                    cboMunicipio.Value = dtDatos.Rows(0).Item(cboMunicipio.FieldName).ToString
                    cboTipoAsoc.Value = dtDatos.Rows(0).Item("idTipoAsociacion").ToString
                    txtFolio.Text = dtDatos.Rows(0).Item("Folio").ToString
                    txtTomo.Text = dtDatos.Rows(0).Item("Tomo").ToString
                    txtNotasMarginales.Text = dtDatos.Rows(0).Item("NotasMarginales").ToString
                End If
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
            dtParametrosBusqueda.Rows.Add(txtNumRegistro.FieldName, txtNumRegistro.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
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
            dtParametros.Rows.Add(txtNumRegistro.FieldName, txtNumRegistro.Text)
            dtParametros.Rows.Add(dtcFechaRegistro.FieldName, dtcFechaRegistro.Value)
            dtParametros.Rows.Add("IdInstitucion", Asociacion.Institucion)
            dtParametros.Rows.Add("TipoSolicitante", iTipoEntidad)
            dtParametros.Rows.Add("IdSolicitanteCliente", EncargadoResponsable.cliente)
            dtParametros.Rows.Add("IdSolicitanteApoderado", EncargadoResponsable.Apoderado)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(cboTipoAsoc.FieldName, cboTipoAsoc.Value)
            dtParametros.Rows.Add(txtFolio.FieldName, txtFolio.Text)
            dtParametros.Rows.Add(txtTomo.FieldName, txtTomo.Text)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametros.Rows.Add(txtNotasMarginales.FieldName, txtNotasMarginales.Text)
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


End Class