Imports prjDatos
Public Class wfmRecibo_Add
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pRecibo_Add"
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private sNombreBusquedaApoderado As String = "pApoderados_List"
    Private sNombreAltaApoderado As String = "pApoderados_Add"
    Private sNombreBusquedaInstitucion As String = "pInstituciones_List"
    Private sNombreAltaInstitucion As String = "pInstituciones_Add"
    Private sNombreBusquedaSubServicio As String = "pSubServicios_List"
    Private szNombreBusquedaExpediente As String = "pExpediente_List"
    Private dtDatosCliente, dtDatosApoderado, dtDatosInstitucion As New DataTable
    Private idTipoSolicitante As String
    Dim dtDatos As New DataTable

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        If Session("Mensaje") <> "" And Session("Mensaje") <> "Error" Then
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
    Sub ChangeSelectedItemTipoSolicitante(ByVal sender As Object, ByVal e As EventArgs) Handles cboTipoSolicitante.ComboChangedItem
        Try
            idTipoSolicitante = cboTipoSolicitante.Value
            pnlApoderado.Visible = False
            pnlCliente.Visible = False
            pnlInstitucion.Visible = False
            txtCodigoApoderado.Obligatorio = False
            txtCodigoEl.Obligatorio = False
            txtCodigoInstitucion.Obligatorio = False
            If idTipoSolicitante <> "" Then
                If idTipoSolicitante = "A" Then
                    pnlApoderado.Visible = True
                    txtCodigoApoderado.Obligatorio = True
                    LimpiarDatosCliente()
                    LimpiarDatosInstitucion()
                ElseIf idTipoSolicitante = "I" Then
                    pnlInstitucion.Visible = True
                    txtCodigoInstitucion.Obligatorio = True
                    LimpiarDatosApoderado()
                    LimpiarDatosCliente()
                ElseIf idTipoSolicitante = "C" Then
                    pnlCliente.Visible = True
                    txtCodigoEl.Obligatorio = True
                    LimpiarDatosApoderado()
                    LimpiarDatosInstitucion()
                ElseIf idTipoSolicitante = "E" Then
                    LimpiarDatosCliente()
                    LimpiarDatosInstitucion()
                    LimpiarDatosApoderado()
                End If
            End If
        Catch ex As Exception
            '    'excError.RecoveryException(ex)
        End Try
    End Sub
    Private Sub btnVerificarEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerificarEl.Click
        llenarDatosElVerificar()
    End Sub
    Protected Sub btnVerificarApoderado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerificarApoderado.Click
        llenarDatosApoderadoVerificar()
    End Sub
    Protected Sub btnVerificarInstitucion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerificarInstitucion.Click
        llenarDatosInstitucionVerificar()
    End Sub
#Region "Eventos Popup"
    Protected Sub btnBuscarEl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarEl.Click
        llenarGridClienteBusqueda()
        mpeBuscarCliente.Show()
    End Sub
    Protected Sub btnCancelarApoderadoAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelarApoderadoAdd.Click
        mpeAgregarApoderado.Hide()
    End Sub
    Protected Sub btnNuevoApoderado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevoApoderado.Click
        Me.mpeAgregarApoderado.Show()
    End Sub
    Protected Sub btnBuscarApoderado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarApoderado.Click
        llenarGridApoderadoBusqueda()
        mpeBuscarApoderado.Show()
    End Sub
    Protected Sub btnBuscarInstitucion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarInstitucion.Click
        llenarGridInstitucionBusqueda()
        mpeBuscarInstitucion.Show()
    End Sub
    Protected Sub btnMostrarPopUpApoderado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarBusquedaApoderado.Click
        Me.mpeBuscarApoderado.Show()
    End Sub
    Protected Sub btnCancelarAddApoderado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarBusquedaApoderado.Click
        mpeBuscarApoderado.Hide()
    End Sub
    Protected Sub btnMostrarPopUpEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarPopupEl.Click
        Me.mpeBuscarCliente.Show()
    End Sub
    Protected Sub btnCerrarEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarEl.Click
        mpeBuscarCliente.Hide()
    End Sub
    Protected Sub btnNuevoEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevoEl.Click
        'Panel1.Enabled = False
        Me.mpeAgregarCliente.Show()
    End Sub

    Protected Sub btnCerrarElAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarClienteEl.Click
        mpeAgregarCliente.Hide()
        'Panel1.Enabled = True
    End Sub

    Protected Sub btnNuevoInstitucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevoInstitucion.Click
        Me.mpeAgregarInstitucion.Show()
    End Sub

    Protected Sub btnCerrarInstitucionAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarInstitucionAdd.Click
        mpeAgregarInstitucion.Hide()
    End Sub

    Protected Sub btnMostrarBusquedaInstitucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarBusquedaInstitucion.Click
        Me.mpeBuscarInstitucion.Show()

    End Sub
    Protected Sub btnCancelarBusquedaInstitucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarBusquedaInstitucion.Click
        mpeBuscarInstitucion.Hide()
    End Sub
    Private Sub gvDatosInstitucion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosInstitucionBusqueda.SelectedIndexChanged
        llenarDatosInstitucion()
        mpeBuscarInstitucion.Hide()
    End Sub
    Private Sub gvDatosEl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosEl.SelectedIndexChanged
        llenarDatosEl()
        mpeBuscarCliente.Hide()
    End Sub
    Private Sub gvDatosApoderado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosApoderado.SelectedIndexChanged
        llenarDatosApoderado()
        mpeBuscarApoderado.Hide()
    End Sub

    Private Sub btnGaurdarClienteEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGaurdarClienteEl.Click
        Mensaje(sMensaje)
        If Not bInsertarClienteEl() Then
            mpeAgregarCliente.Show()
        End If
    End Sub
    Private Sub btnGuardarInstitucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarInstitucion.Click
        Mensaje(sMensaje)
        If Not bInsertarInstitucion() Then
            mpeAgregarInstitucion.Show()
        End If
    End Sub
    Private Sub cboDepartamentoApoderadoAdd_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamentoApoderadoAdd.ComboChangedItem
        cboMunicipioApoderadoAdd.LLenarCombo(sender)
        If IsPostBack Then
            mpeAgregarApoderado.Show()
        End If
    End Sub

    Private Sub cboServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub

    Private Sub cboSubServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubServicio.ComboChangedItem
        'recuperar los datos del detalle del costo del sub servicio
        'recuperar la tasa de cambio
        Dim dtDatosTasaCambio As New DataTable
        If cboSubServicio.Value <> "-1" And cboSubServicio.Value <> Nothing Then
            dtDatosTasaCambio = cFunciones.Filldatatable("pTasaCambio_Actual", dtParametrosBusquedaTasaCambio)
            dtDatos = cFunciones.Filldatatable(sNombreBusquedaSubServicio, dtParametrosBusquedaDatosSubServicio)
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0).Item("indTipoMoneda") = "D" Then
                    txtValorDolares.Text = FormatNumber(dtDatos.Rows(0).Item("Valor"), 2)
                    txtValor.Text = FormatNumber(dtDatos.Rows(0).Item("Valor") * dtDatosTasaCambio.Rows(0).Item("ValorLempiras"), 2)
                ElseIf dtDatos.Rows(0).Item("indTipoMoneda") = "L" Then
                    txtValor.Text = FormatNumber(dtDatos.Rows(0).Item("Valor"), 2)
                    txtValorDolares.Text = FormatNumber(dtDatos.Rows(0).Item("Valor") / dtDatosTasaCambio.Rows(0).Item("ValorLempiras"), 2)
                End If
                txtValorTotalLempiras.Text = FormatNumber(txtValor.Text * txtCantidad.Text, 2)
                txtTotalDolares.Text = FormatNumber(txtValorDolares.Text * txtCantidad.Text, 2)
            End If
            If dtDatosTasaCambio.Rows.Count > 0 Then
                txtTasaCambio.Text = FormatNumber(dtDatosTasaCambio.Rows(0).Item("ValorLempiras"), 4)
            End If
        End If
    End Sub
#End Region
#End Region
#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Sub LimpiarDatosCliente()
        txtCodigoEl.Text = ""
        txtIdentidadEl.Text = ""
        txtNombresEl.Text = ""
        cboNacionalidadEl.Value = -1
    End Sub
    Private Sub LimpiarDatosApoderado()
        txtCodigoApoderado.Text = ""
        txtIdentidadApoderado.Text = ""
        txtNombreApoderado.Text = ""
    End Sub
    Private Sub LimpiarDatosInstitucion()
        txtCodigoInstitucion.Text = ""
        txtRTN.Text = ""
        txtNombreInstitucion.Text = ""
        txtSiglas.Text = ""
    End Sub
    Private Sub llenarDatosElVerificar()
        Try
            dtDatosCliente = cFunciones.Filldatatable(sNombreBusquedaCliente, dtParametrosClienteVerificar)
            If Session("Mensaje") <> "Error" Then
                If dtDatosCliente.Rows.Count > 0 Then
                    'txtCodigoEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(1).Text
                    txtIdentidadEl.Text = dtDatosCliente.Rows(0).Item(txtIdentidadEl.FieldName)
                    txtNombresEl.Text = dtDatosCliente.Rows(0).Item(txtNombresEl.FieldName)
                    cboNacionalidadEl.Value = dtDatosCliente.Rows(0).Item(cboNacionalidadEl.FieldName)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function dtParametrosClienteVerificar() As DataTable
        Try
            dtParametrosClienteVerificar = cFunciones.dtDatos.Clone
            dtParametrosClienteVerificar.Rows.Add("id", txtCodigoEl.Text)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub llenarDatosApoderadoVerificar()
        dtDatosApoderado = cFunciones.Filldatatable(sNombreBusquedaApoderado, dtParametrosApoderadoVerificar)
        If Session("Mensaje") <> "Error" Then
            If dtDatosApoderado.Rows.Count > 0 Then
                'txtCodigoEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(1).Text
                txtIdentidadApoderado.Text = dtDatosApoderado.Rows(0).Item(txtIdentidadApoderado.FieldName)
                txtNombreApoderado.Text = dtDatosApoderado.Rows(0).Item(txtNombreApoderado.FieldName)
            End If
        End If
    End Sub
    Private Function dtParametrosInstitucionVerificar() As DataTable
        Try
            dtParametrosInstitucionVerificar = cFunciones.dtDatos.Clone
            dtParametrosInstitucionVerificar.Rows.Add("id", txtCodigoInstitucion.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub llenarDatosInstitucionVerificar()
        dtDatosInstitucion = cFunciones.Filldatatable(sNombreBusquedaInstitucion, dtParametrosInstitucionVerificar)
        If Session("Mensaje") <> "Error" Then
            If dtDatosInstitucion.Rows.Count > 0 Then
                txtRTN.Text = dtDatosInstitucion.Rows(0).Item(txtRTN.FieldName)
                txtNombreInstitucion.Text = dtDatosInstitucion.Rows(0).Item(txtNombreInstitucion.FieldName)
                txtSiglas.Text = dtDatosInstitucion.Rows(0).Item(txtSiglas.FieldName)
            End If
        End If
    End Sub
    Private Function dtParametrosApoderadoVerificar() As DataTable
        Try
            dtParametrosApoderadoVerificar = cFunciones.dtDatos.Clone
            dtParametrosApoderadoVerificar.Rows.Add("id", txtCodigoApoderado.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosBusquedaDatosSubServicio() As DataTable
        Try
            dtParametrosBusquedaDatosSubServicio = cFunciones.dtDatos.Clone
            dtParametrosBusquedaDatosSubServicio.Rows.Add("codigo", cboSubServicio.Value)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosBusquedaTasaCambio() As DataTable
        Try
            dtParametrosBusquedaTasaCambio = cFunciones.dtDatos.Clone
            dtParametrosBusquedaTasaCambio.Rows.Add("Fecha", Date.Now.ToShortDateString)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try

            dtParametros = cFunciones.dtDatos.Clone

            If txtNumeroRecibo.Text <> txtVerificacionNumeroRecibo.Text Then
                txtNumeroRecibo.MensajeError = "Ingrese el número de recibo y su verificación correctamente"
                txtVerificacionNumeroRecibo.MensajeError = "Ingrese el número de recibo y su verificación correctamente"
                Session("Mensaje") = "Error"
            End If
            If txtCodigo.Text = "" And txtCodigoApoderado.Text = "" And txtCodigoInstitucion.Text = "" Then
                txtCodigo.Valido()
                txtCodigoApoderado.Valido()
                txtCodigoInstitucion.Valido()
            End If
            If txtValorDolares.Text = "" And txtValor.Text <> "" Then
                txtValorDolares.Text = txtValor.Text * txtCantidad.Text
            End If
            
            dtParametros.Rows.Add(txtTasaCambio.FieldName, txtTasaCambio.Text)
            dtParametros.Rows.Add(txtNumeroRecibo.FieldName, txtNumeroRecibo.Text)
            dtParametros.Rows.Add(cboOficina.FieldName, cboOficina.Value)
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
            dtParametros.Rows.Add(cboEstadoRecibo.FieldName, cboEstadoRecibo.Value)
            dtParametros.Rows.Add(txtValor.FieldName, txtValor.Text)
            dtParametros.Rows.Add(txtValorDolares.FieldName, txtValorDolares.Text)
            dtParametros.Rows.Add("Cantidad", txtCantidad.Text)
            dtParametros.Rows.Add(txtCodigoApoderado.FieldName, txtCodigoApoderado.Text)
            dtParametros.Rows.Add(txtCodigoEl.FieldName, txtCodigoEl.Text)
            dtParametros.Rows.Add(txtCodigoInstitucion.FieldName, txtCodigoInstitucion.Text)
            dtParametros.Rows.Add(dteFechaEmision.FieldName, dteFechaEmision.Value)
            dtParametros.Rows.Add(dteFechaPago.FieldName, dteFechaPago.Value)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
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
#Region "Metodos PopUp"
    Private Function bInsertarApoderado() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaApoderado, dtParametrosApoderadoAdd, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function bInsertarClienteEl() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaCliente, dtParametrosAltaCliente, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function bInsertarInstitucion() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaInstitucion, dtParametrosAltaInstitucion, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Sub llenarDatosEl()
        If gvDatosEl.Rows.Count > 0 Then
            If gvDatosEl.SelectedIndex > -1 Then
                txtCodigoEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(1).Text
                txtIdentidadEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(2).Text
                txtNombresEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(3).Text
                cboNacionalidadEl.Value = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(4).Text
            End If
        End If
    End Sub
    Sub llenarDatosApoderado()
        If gvDatosApoderado.Rows.Count > 0 Then
            If gvDatosApoderado.SelectedIndex > -1 Then
                txtCodigoApoderado.Text = gvDatosApoderado.Rows(gvDatosApoderado.SelectedIndex).Cells(1).Text
                txtIdentidadApoderado.Text = gvDatosApoderado.Rows(gvDatosApoderado.SelectedIndex).Cells(2).Text
                txtNombreApoderado.Text = gvDatosApoderado.Rows(gvDatosApoderado.SelectedIndex).Cells(3).Text
            End If
        End If
    End Sub
    Sub llenarDatosInstitucion()
        If gvDatosInstitucionBusqueda.Rows.Count > 0 Then
            If gvDatosInstitucionBusqueda.SelectedIndex > -1 Then
                txtCodigoInstitucion.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(1).Text
                txtRTN.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(2).Text.ToString
                txtNombreInstitucion.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(3).Text
                txtSiglas.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(4).Text
            End If
        End If
    End Sub
    Private Sub llenarGridClienteBusqueda()
        gvDatosEl.DataSource = cFunciones.Filldatatable(sNombreBusquedaCliente, dtParametrosClientePopUp)
        gvDatosEl.DataBind()
    End Sub
    Private Sub llenarGridApoderadoBusqueda()
        gvDatosApoderado.DataSource = cFunciones.Filldatatable(sNombreBusquedaApoderado, dtParametrosApoderadoBusqueda)
        gvDatosApoderado.DataBind()
    End Sub
    Private Sub llenarGridInstitucionBusqueda()
        gvDatosInstitucionBusqueda.DataSource = cFunciones.Filldatatable(sNombreBusquedaInstitucion, dtParametrosInstitucionBusqueda)
        gvDatosInstitucionBusqueda.DataBind()
    End Sub
    Private Function dtParametrosClientePopUp() As DataTable
        Try
            dtParametrosClientePopUp = cFunciones.dtDatos.Clone
            dtParametrosClientePopUp.Rows.Add(txtIdentidadElBuscar.FieldName, txtIdentidadElBuscar.Text)
            dtParametrosClientePopUp.Rows.Add(txtNombresElBuscar.FieldName, txtNombresElBuscar.Text)
            dtParametrosClientePopUp.Rows.Add(cboNacionalidadElBuscar.FieldName, cboNacionalidadElBuscar.Value)
            dtParametrosClientePopUp.Rows.Add(cboDepartamentoElBuscar.FieldName, cboDepartamentoElBuscar.Value)
            dtParametrosClientePopUp.Rows.Add(cboMunicipioElBuscar.FieldName, cboMunicipioElBuscar.Value)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosApoderadoBusqueda() As DataTable
        Try
            dtParametrosApoderadoBusqueda = cFunciones.dtDatos.Clone
            dtParametrosApoderadoBusqueda.Rows.Add(txtIdentidadApoderadoBuscar.FieldName, txtIdentidadApoderadoBuscar.Text)
            dtParametrosApoderadoBusqueda.Rows.Add(txtNombreApoderadoBuscar.FieldName, txtNombreApoderadoBuscar.Text)
            dtParametrosApoderadoBusqueda.Rows.Add(txtNumColegiacion.FieldName, txtNumColegiacion.Text)
            dtParametrosApoderadoBusqueda.Rows.Add(cboDepartamentoApoderadoBuscar.FieldName, cboDepartamentoApoderadoBuscar.Value)
            dtParametrosApoderadoBusqueda.Rows.Add(cboMunicipioApoderadoBuscar.FieldName, cboMunicipioApoderadoBuscar.Value)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosInstitucionBusqueda() As DataTable
        Try
            dtParametrosInstitucionBusqueda = cFunciones.dtDatos.Clone
            dtParametrosInstitucionBusqueda.Rows.Add(txtRTNInstitucion.FieldName, txtRTNInstitucion.Text)
            dtParametrosInstitucionBusqueda.Rows.Add(txtNombreInstitucionBuscar.FieldName, txtNombreInstitucionBuscar.Text)
            dtParametrosInstitucionBusqueda.Rows.Add(txtSiglasInstitucion.FieldName, txtSiglasInstitucion.Text)
            dtParametrosInstitucionBusqueda.Rows.Add(txtNombreContacto.FieldName, txtNombreContacto.Text)
            dtParametrosInstitucionBusqueda.Rows.Add(cboPaisInstitucionBuscar.FieldName, cboPaisInstitucionBuscar.Value)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function dtParametrosAltaCliente(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosAltaCliente = cFunciones.dtDatos.Clone
            dtParametrosAltaCliente.Rows.Add(txtNumIdentidad.FieldName, txtNumIdentidad.Text)
            dtParametrosAltaCliente.Rows.Add(txtPasaporte.FieldName, txtPasaporte.Text)
            dtParametrosAltaCliente.Rows.Add(txtNombre1.FieldName, txtNombre1.Text)
            dtParametrosAltaCliente.Rows.Add(txtNombre2.FieldName, txtNombre2.Text)
            dtParametrosAltaCliente.Rows.Add(txtApellido1.FieldName, txtApellido1.Text)
            dtParametrosAltaCliente.Rows.Add(txtApellido2.FieldName, txtApellido2.Text)
            dtParametrosAltaCliente.Rows.Add(cboPais.FieldName, cboPais.Value)
            dtParametrosAltaCliente.Rows.Add(txtTelefonoDomicilio.FieldName, txtTelefonoDomicilio.Text)
            dtParametrosAltaCliente.Rows.Add(txtTelefonoTrabajo.FieldName, txtTelefonoTrabajo.Text)
            dtParametrosAltaCliente.Rows.Add(txtNumFax.FieldName, txtNumFax.Text)
            dtParametrosAltaCliente.Rows.Add(txtTelefonoMovil1.FieldName, txtTelefonoMovil1.Text)
            dtParametrosAltaCliente.Rows.Add(txtTelefonoMovil2.FieldName, txtTelefonoMovil2.Text)
            dtParametrosAltaCliente.Rows.Add(txtEmail1.FieldName, txtEmail1.Text)
            dtParametrosAltaCliente.Rows.Add(txtEmail2.FieldName, txtEmail2.Text)
            dtParametrosAltaCliente.Rows.Add(txtDireccionDomicilio.FieldName, txtDireccionDomicilio.Text)
            dtParametrosAltaCliente.Rows.Add(txtDireccionTrabajo.FieldName, txtDireccionTrabajo.Text)
            dtParametrosAltaCliente.Rows.Add(cboMunicipioClienteNuevo.FieldName, cboMunicipioClienteNuevo.Value)
            dtParametrosAltaCliente.Rows.Add(txtObservaciones.FieldName, txtObservaciones.Text)
            dtParametrosAltaCliente.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function dtParametrosApoderadoAdd(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosApoderadoAdd = cFunciones.dtDatos.Clone
            dtParametrosApoderadoAdd.Rows.Add(txtNumIdentidadApoderadoAdd.FieldName, txtNumIdentidadApoderadoAdd.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtPrimerNombreApoderado.FieldName, txtPrimerNombreApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtSegundoNombreApoderado.FieldName, txtSegundoNombreApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtPrimerApellidoApoderado.FieldName, txtPrimerApellidoApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtSegundoApellidoApoderado.FieldName, txtSegundoApellidoApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtTelefonoDomicilioApoderado.FieldName, txtTelefonoDomicilioApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtTelefonoTrabajoApoderado.FieldName, txtTelefonoTrabajoApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtFaxApoderado.FieldName, txtFaxApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtTelefonoMovil1Apoderado.FieldName, txtTelefonoMovil1Apoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtTelefonoMovil2.FieldName, txtTelefonoMovil2.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtEmail1Apoderado.FieldName, txtEmail1Apoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtEmail2Apoderado.FieldName, txtEmail2Apoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtDireccionDomicilioApoderado.FieldName, txtDireccionDomicilioApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(txtDireccionTrabajoApoderado.FieldName, txtDireccionTrabajoApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add(cboMunicipioApoderadoAdd.FieldName, cboMunicipioApoderadoAdd.Value)
            dtParametrosApoderadoAdd.Rows.Add(txtObservacionesApoderado.FieldName, txtObservacionesApoderado.Text)
            dtParametrosApoderadoAdd.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Public Function dtParametrosAltaInstitucion(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosAltaInstitucion = cFunciones.dtDatos.Clone
            dtParametrosAltaInstitucion.Rows.Add(txtRTNInstitucionAdd.FieldName, txtRTNInstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtNombreInstitucionAdd.FieldName, txtNombreInstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtSiglasInstitucionAdd.FieldName, txtSiglasInstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(cboPaisInstitucionAdd.FieldName, cboPaisInstitucionAdd.Value)
            dtParametrosAltaInstitucion.Rows.Add(txtTelefono1InstitucionAdd.FieldName, txtTelefono1InstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtTelefono2InstitucionAdd.FieldName, txtTelefono2InstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtNumFaxInstitucionAdd.FieldName, txtNumFaxInstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtDireccion1InstitucionAdd.FieldName, txtDireccion1InstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtDireccion2InstitucionAdd.FieldName, txtDireccion2InstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtNombreContactoInstitucionAdd.FieldName, txtNombreContactoInstitucionAdd.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtExtensionTelefonicaContacto.FieldName, txtExtensionTelefonicaContacto.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtTelMovilContacto.FieldName, txtTelMovilContacto.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtEmail1.FieldName, txtCargoContacto.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtEmailContactoInstitucion.FieldName, txtEmailContactoInstitucion.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtSitioWebContacto.FieldName, txtSitioWebContacto.Text)
            dtParametrosAltaInstitucion.Rows.Add(txtObservacionesInstitucion.FieldName, txtObservacionesInstitucion.Text)
            dtParametrosAltaInstitucion.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#End Region

   
    Protected Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        Try
            txtValorTotalLempiras.Text = FormatNumber(txtValor.Text * txtCantidad.Text, 2)
        Catch ex As Exception

        End Try
    End Sub
End Class