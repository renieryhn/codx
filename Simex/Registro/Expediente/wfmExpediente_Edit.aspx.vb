Imports prjDatos
Imports System.Data.SqlClient
Public Class wfmExpediente_Edit
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pExpediente_Edit"
    Private Const spListNombre As String = "pExpediente_List"
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private sNombreBusquedaApoderado As String = "pApoderados_List"
    Private sNombreAltaApoderado As String = "pApoderados_Add"
    Private sNombreBusquedaInstitucion As String = "pInstituciones_List"
    Private sNombreAltaInstitucion As String = "pInstituciones_Add"
    Private sNombreBusquedaSubServicio As String = "pSubServicios_List"
    Private sNombreMantenimiento As String = "Editar Expediente"
    Private dtDatosCliente, dtDatosApoderado, dtDatosInstitucion As New DataTable
    Private idTipoSolicitante As String
    Private idTipoInteresado As String
    Dim objTransac As SqlTransaction = Nothing
    Dim dtDatos As New DataTable
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            CargarValores()
        End If
        Spire.Barcode.BarcodeSettings.ApplyKey("8LXF1-2G6GL-TBJZP-HL7CT-SANVP")
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            Redirect()
        Else
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If

        End If
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            RedirectSelf()
        Else
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
        End If
    End Sub
    Private Sub cboServicio_ComboChangedItem(sender As Object, e As System.EventArgs) Handles cboServicio.ComboChangedItem
        If sender.ToString <> "" Then
            cboSubServicio.LLenarCombo(sender)
        End If
    End Sub
    Private Sub cboDepartamentoExpediente_ComboChangedItem(sender As Object, e As System.EventArgs) Handles cboDepartamentoExpediente.ComboChangedItem
        If sender.ToString <> "" Then
            cboMunicipioExpediente.LLenarCombo(sender)
        End If
    End Sub
#End Region
#Region "Metodos"
    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtCodigoExpediente.Text = Session("ID")
                dtDatos = cFunciones.Filldatatable(spListNombre, dtParametrosBusqueda)

                EncargadoResponsable.idEntidad = dtDatos.Rows(0).Item("idResponsable").ToString
                EncargadoResponsable.TipoEntidadCombo = dtDatos.Rows(0).Item("NombreTipoResponsable").ToString.Substring(0, 1)

                InteresadoSolicitante.idEntidad = dtDatos.Rows(0).Item("idSolicitante").ToString
                InteresadoSolicitante.TipoEntidadCombo = dtDatos.Rows(0).Item("NombreTipoSolicitante").ToString.Substring(0, 1)

                cboServicio.Value = dtDatos.Rows(0).Item(cboServicio.FieldName)

                cboSubServicio.Value = dtDatos.Rows(0).Item(cboSubServicio.FieldName)
                txtNumRecibo.Text = dtDatos.Rows(0).Item(txtNumRecibo.FieldName).ToString
                cboDepartamentoExpediente.Value = dtDatos.Rows(0).Item(cboDepartamentoExpediente.FieldName)
                cboMunicipioExpediente.Value = dtDatos.Rows(0).Item(cboMunicipioExpediente.FieldName)
                bCode.Data = txtCodigoExpediente.Text
                bCode.Data2D = txtCodigoExpediente.Text
                bCode2.Data = My.Settings.URLMobilQ & txtCodigoExpediente.Text
                bCode2.Data2D = My.Settings.URLMobilQ & txtCodigoExpediente.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function bModificar() As Boolean
        Dim lst As WebControls.ListBox = InteresadoSolicitante.Clientes
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, sMensaje)
        If Ok Then
            ActualizarClientes(txtCodigoExpediente.Text, lst)
        End If
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Function ActualizarClientes(ByVal numExpediente As String, lst As WebControls.ListBox) As Boolean
        Try
            Dim OK As Boolean
            Dim numCliente As String = ""
            OK = QuitarClientes(numExpediente)
            If OK Then
                If Not lst Is Nothing Then
                    For i = 0 To lst.Items.Count - 1
                        numCliente = lst.Items(i).Value.ToString()
                        OK = cFunciones.Ejecutar("pExpedientesCliente_Add", dtParametrosExpCliente(numExpediente, numCliente), sMensaje)
                    Next
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function QuitarClientes(ByVal numExpediente As String) As Boolean
        Try
            Dim OK As Boolean
            Dim dtParam As DataTable = cFunciones.dtDatos.Clone
            dtParam.Rows.Add("idExpediente", numExpediente)
            OK = cFunciones.Ejecutar("pExpedientesCliente_Delete", dtParam, sMensaje)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function dtParametrosExpCliente(numExpediente As String, NumCliente As String) As DataTable

        Try
            dtParametrosExpCliente = cFunciones.dtDatos.Clone
            dtParametrosExpCliente.Rows.Add("idExpediente", numExpediente)
            dtParametrosExpCliente.Rows.Add("idCliente", NumCliente)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub Redirect()
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Private Sub RedirectSelf()
        Response.Redirect(linkMe.NavigateUrl)
    End Sub

    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = cFunciones.dtDatos.Clone
            'dtParametrosBusqueda.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
            dtParametrosBusqueda.Rows.Add(txtCodigoExpediente.FieldName, txtCodigoExpediente.Text)

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtCodigoExpediente.FieldName, txtCodigoExpediente.Text)
            dtParametros.Rows.Add(txtNumRecibo.FieldName, txtNumRecibo.Text)
            dtParametros.Rows.Add(cboServicio.FieldName, cboServicio.Value)
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
            dtParametros.Rows.Add("idClienteResponsable", EncargadoResponsable.cliente)
            dtParametros.Rows.Add("idInstitucionResponsable", EncargadoResponsable.Institucion)
            dtParametros.Rows.Add("idApoderadoResponsable", EncargadoResponsable.Apoderado)
            dtParametros.Rows.Add("idClienteSolicitante", InteresadoSolicitante.cliente)
            dtParametros.Rows.Add("idInstitucionSolicitante", InteresadoSolicitante.Institucion)
            dtParametros.Rows.Add(cboMunicipioExpediente.FieldName, cboMunicipioExpediente.Value)
            dtParametros.Rows.Add(txtObservacionesExpediente.FieldName, txtObservacionesExpediente.Text)
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
        Session("Mensaje") = ""
    End Sub
#End Region

End Class