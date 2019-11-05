﻿Imports prjDatos
Public Class SolicitanteResponsable
    Inherits System.Web.UI.UserControl
    Private cFunciones As New funciones
    Private cMensaje As New Mensaje
    Private sMensaje As String = ""
    Private Const spNombre As String = "pExpediente_Add"
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private sNombreBusquedaApoderado As String = "pApoderados_List"
    Private sNombreAltaApoderado As String = "pApoderados_Add"
    Private sNombreBusquedaInstitucion As String = "pInstituciones_List"
    Private sNombreAltaInstitucion As String = "pInstituciones_Add"
    Private dtDatosCliente, dtDatosApoderado, dtDatosInstitucion As New DataTable
    Private idTipoSolicitante As String
    Dim iNuevo As Integer = 0
    Public Property MostrarCliente As Boolean
    Public Property MostrarInstitucion As Boolean
    Public Property MostrarApoderado As Boolean
    Public Property TipoEntidadCombo As String
    Public Property idEntidad As String
    Public Property MostrarClientesMultiples As Boolean = False

    Public Event VerificarApoderado()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadDefaults()
        End If
    End Sub
    Public Sub LoadDefaults()
        lblTipoPersona.Text = TipoEntidad

        If TipoEntidadCombo <> "" Then
            cboTipoSolicitante.Value = TipoEntidadCombo
            cboTipoSolicitante.LLenarComboDatatable(dtParametrosFiltroCombo())
        Else
            cboTipoSolicitante.LLenarComboDatatable(dtParametrosFiltroCombo())
        End If
        If dtParametrosFiltroCombo.Rows.Count = 1 Then
            cboTipoSolicitante.Value = Session("Tipo")
            ActualizarPaneles()
            cboTipoSolicitante.habilitado = False
        End If
        If Not IsNothing(Session("ID")) Then
            Dim tbl As DataTable = cFunciones.Filldatatable("pExpedienteCliente_List", dtParamClientes)
            For i = 0 To tbl.Rows.Count - 1
                Dim itm As New ListItem(tbl.Rows(i).Item(1), tbl.Rows(i).Item(0))
                lstClientes.Items.Add(itm)
            Next
        End If
    End Sub

#Region "Eventos"
    Private Sub cboDepartamentoClienteNuevo_ComboChangedItem(sender As Object, e As System.EventArgs) Handles cboDepartamentoClienteNuevo.ComboChangedItem
        cboMunicipioClienteNuevo.LLenarCombo(sender)
        If sender <> "-1" Then
            mpeAgregarCliente.Show()
        End If
    End Sub
    Private Sub cboDepartamentoApoderadoAdd_ComboChangedItem(sender As Object, e As System.EventArgs) Handles cboDepartamentoApoderadoAdd.ComboChangedItem
        cboMunicipioApoderadoAdd.LLenarCombo(sender)
        If sender <> "-1" Then
            mpeAgregarApoderado.Show()
        End If
    End Sub
    Private Sub cboDepartamentoApoderadoBuscar_ComboChangedItem(sender As Object, e As System.EventArgs) Handles cboDepartamentoApoderadoBuscar.ComboChangedItem
        cboMunicipioApoderadoBuscar.LLenarCombo(sender)
        cboMunicipioApoderadoBuscar.DataBind()
        If sender <> "-1" Then
            mpeBuscarApoderado.Show()
        End If
    End Sub
#End Region
#Region "Propiedades"

    Public Property TipoEntidad As String
        Get
            If lblTipoPersona.Text = "" Then
                Return ""
            Else
                Return lblTipoPersona.Text
            End If
        End Get
        Set(ByVal value As String)
            lblTipoPersona.Text = value
        End Set
    End Property

    Public Property cliente As String
        Get
            If cboTipoSolicitante.Value = "C" Then
                If lstClientes.Items.Count = 0 Then
                    txtClienteResponsable.Obligatorio = True
                Else
                    txtClienteResponsable.Obligatorio = False
                End If
            Else
                txtClienteResponsable.Obligatorio = False
            End If
            If txtClienteResponsable.Text = "" Then
                Return ""
            Else
                Return txtClienteResponsable.Text

            End If
        End Get
        Set(ByVal value As String)
            txtClienteResponsable.Text = value
        End Set
    End Property
    Public Property Institucion As String
        Get
            If cboTipoSolicitante.Value = "I" Then
                txtInstitucionResponsable.Obligatorio = True
            Else
                txtInstitucionResponsable.Obligatorio = False
            End If
            If txtInstitucionResponsable.Text = "" Then
                Return ""
            Else
                Return txtInstitucionResponsable.Text
            End If
        End Get
        Set(ByVal value As String)

            txtInstitucionResponsable.Text = value
        End Set
    End Property
    Public ReadOnly Property Siglas As String
        Get
            If cboTipoSolicitante.Value = "I" Then
                txtInstitucionResponsable.Obligatorio = True
            Else
                txtInstitucionResponsable.Obligatorio = False
            End If
            If txtInstitucionResponsable.Text = "" Then
                Return ""
            Else
                Return txtSiglas.Text
            End If
        End Get
    End Property
    Public ReadOnly Property NombreInstitucion As String
        Get
            If cboTipoSolicitante.Value = "I" Then
                txtInstitucionResponsable.Obligatorio = True
            Else
                txtInstitucionResponsable.Obligatorio = False
            End If
            If txtInstitucionResponsable.Text = "" Then
                Return ""
            Else
                Return txtNombreInstitucion.Text
            End If
        End Get
    End Property
    Public Property Apoderado As String
        Get
            If cboTipoSolicitante.Value = "A" Then
                txtApoderadoResponsable.Obligatorio = True
            Else
                txtApoderadoResponsable.Obligatorio = False
            End If
            If txtApoderadoResponsable.Text = "" Then
                Return ""
            Else
                Return txtApoderadoResponsable.Text
            End If
        End Get
        Set(ByVal value As String)

            txtApoderadoResponsable.Text = value
        End Set
    End Property

    Public Property Clientes As WebControls.ListBox
        Get
            Return lstClientes
        End Get
        Set(ByVal value As WebControls.ListBox)
            lstClientes = value
        End Set
    End Property
    Public Property ClientesMultiples As Boolean
        Get
            Return MostrarClientesMultiples
        End Get
        Set(ByVal value As Boolean)
            MostrarClientesMultiples = value
        End Set
    End Property
#End Region
#Region "Parametros alta Pop Up"
    Public Function dtParametrosFiltroCombo() As DataTable
        Try
            dtParametrosFiltroCombo = cFunciones.dtDatos.Clone
            If MostrarApoderado Then
                dtParametrosFiltroCombo.Rows.Add("A", "Apoderado")
                Session("Tipo") = "A"
            End If
            If MostrarCliente Then
                dtParametrosFiltroCombo.Rows.Add("C", "Cliente")
                Session("Tipo") = "C"
            End If
            If MostrarInstitucion Then
                dtParametrosFiltroCombo.Rows.Add("I", "Institución")
                Session("Tipo") = "I"
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function dtParametrosAltaCliente(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            Dim s As String = Session("Usuario")
            dtParametrosAltaCliente = cFunciones.dtDatos.Clone
            'dtParametrosAltaCliente.Rows.Add(txtNumIdentidad.FieldName, txtNumIdentidad.Text)
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
            dtParametrosAltaCliente.Rows.Add("idUsuario", Session("Usuario"))
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
            dtParametrosApoderadoAdd.Rows.Add(txtColegiacion.FieldName, txtColegiacion.Text)
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
            dtParametrosApoderadoAdd.Rows.Add("idUsuario", Session("Usuario"))
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
            dtParametrosAltaInstitucion.Rows.Add("idUsuario", Session("Usuario"))
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region "Parametros Busqueda Pop Up"
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
#End Region
#Region "Metodos Busqueda PopUp"
    Sub llenarDatosEl()
        If gvDatosEl.Rows.Count > 0 Then
            If gvDatosEl.SelectedIndex > -1 Then
                txtClienteResponsable.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(1).Text.ToString
                txtNombresEl.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(3).Text.ToString
                txtNombresEl.width = Len(txtNombresEl.Text) * 9
                txtNacionalidad.Text = gvDatosEl.Rows(gvDatosEl.SelectedIndex).Cells(5).Text.ToString
                upMainCliente.Update()
            End If
        End If
    End Sub
    Private Function dtParamClientes() As DataTable
        Try
            dtParamClientes = cFunciones.dtDatos.Clone
            dtParamClientes.Rows.Add("idExpediente", Session("ID"))
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub llenarDatosApoderado()
        If gvDatosApoderado.Rows.Count > 0 Then
            If gvDatosApoderado.SelectedIndex > -1 Then
                txtApoderadoResponsable.Text = gvDatosApoderado.Rows(gvDatosApoderado.SelectedIndex).Cells(1).Text.ToString
                txtNombreApoderado.Text = gvDatosApoderado.Rows(gvDatosApoderado.SelectedIndex).Cells(3).Text.ToString()
                txtNombreApoderado.width = Len(txtNombreApoderado.Text) * 9
                upMainApoderado.Update()
            End If
        End If
    End Sub
    Sub llenarDatosInstitucion()
        If gvDatosInstitucionBusqueda.Rows.Count > 0 Then
            If gvDatosInstitucionBusqueda.SelectedIndex > -1 Then
                txtInstitucionResponsable.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(1).Text.ToString
                txtNombreInstitucion.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(3).Text.ToString
                txtNombreInstitucion.width = Len(txtNombreInstitucion.Text) * 9
                txtSiglas.Text = gvDatosInstitucionBusqueda.Rows(gvDatosInstitucionBusqueda.SelectedIndex).Cells(4).Text.ToString
                upMainInstitucion.Update()
            End If
        End If
    End Sub
    Public Sub llenarDatosElVerificar()
        If txtClienteResponsable.Text <> "" Then
            dtDatosCliente = cFunciones.Filldatatable(sNombreBusquedaCliente, dtParametrosClienteVerificar)
            If Session("Mensaje") <> "Error" Then
                If dtDatosCliente.Rows.Count > 0 Then
                    txtNombresEl.Text = dtDatosCliente.Rows(0).Item(txtNombresEl.FieldName).ToString
                    txtNombresEl.width = Len(txtNombresEl.Text) * 9
                    txtNacionalidad.Text = dtDatosCliente.Rows(0).Item(txtNacionalidad.FieldName).ToString
                End If
            End If
        End If
    End Sub

    Private Function dtParametrosClienteVerificar() As DataTable
        Try
            dtParametrosClienteVerificar = cFunciones.dtDatos.Clone
            dtParametrosClienteVerificar.Rows.Add("id", txtClienteResponsable.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub llenarDatosApoderadoVerificar()
        If txtApoderadoResponsable.Text <> "" Then
            dtDatosApoderado = cFunciones.Filldatatable(sNombreBusquedaApoderado, dtParametrosApoderadoVerificar)
            If Session("Mensaje") <> "Error" Then
                If dtDatosApoderado.Rows.Count > 0 Then
                    txtNombreApoderado.Text = dtDatosApoderado.Rows(0).Item(txtNombreApoderado.FieldName).ToString
                    txtNombreApoderado.width = Len(txtNombreApoderado.Text) * 9
                End If
            End If
        End If
    End Sub
    Private Function dtParametrosInstitucionVerificar() As DataTable
        Try
            dtParametrosInstitucionVerificar = cFunciones.dtDatos.Clone
            dtParametrosInstitucionVerificar.Rows.Add("id", txtInstitucionResponsable.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub llenarDatosInstitucionVerificar()
        If txtInstitucionResponsable.Text <> "" Then
            dtDatosInstitucion = cFunciones.Filldatatable(sNombreBusquedaInstitucion, dtParametrosInstitucionVerificar)
            If Session("Mensaje") <> "Error" Then
                If dtDatosInstitucion.Rows.Count > 0 Then
                    txtNombreInstitucion.Text = dtDatosInstitucion.Rows(0).Item(txtNombreInstitucion.FieldName).ToString
                    txtNombreInstitucion.width = Len(txtNombreInstitucion.Text) * 9
                    txtSiglas.Text = dtDatosInstitucion.Rows(0).Item(txtSiglas.FieldName).ToString
                End If
            End If
        End If
    End Sub
    Private Function dtParametrosApoderadoVerificar() As DataTable
        Try
            dtParametrosApoderadoVerificar = cFunciones.dtDatos.Clone
            dtParametrosApoderadoVerificar.Rows.Add("id", txtApoderadoResponsable.Text)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region "Limpiar Pop Up"
    Private Sub LimpiarDatosCliente()
        txtClienteResponsable.Text = ""
        txtNombresEl.Text = ""
        txtNacionalidad.Text = ""
    End Sub
    Private Sub LimpiarDatosApoderado()
        txtApoderadoResponsable.Text = ""
        txtNombreApoderado.Text = ""
    End Sub
    Private Sub LimpiarDatosInstitucion()
        txtInstitucionResponsable.Text = ""
        txtNombreInstitucion.Text = ""
        txtSiglas.Text = ""
    End Sub
#End Region

#Region "Insertar Pop Up"
    Private Function bInsertarApoderado() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaApoderado, dtParametrosApoderadoAdd, "idNuevo", iNuevo, sMensaje)
        If Not Ok Then
            Session("Mensaje") = sMensaje
        Else
            txtApoderadoResponsable.Text = txtColegiacion.Text
            llenarDatosApoderadoVerificar()
            upMainApoderado.Update()
        End If
        Return Ok
    End Function
    Private Function bInsertarClienteEl() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaCliente, dtParametrosAltaCliente, "idNuevo", iNuevo, sMensaje)
        If Ok Then
            txtClienteResponsable.Text = iNuevo
            llenarDatosElVerificar()
            upMainCliente.Update()
        Else
            Session("Mensaje") = sMensaje
        End If
        Return Ok
    End Function
    Private Function bInsertarInstitucion() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreAltaInstitucion, dtParametrosAltaInstitucion, "idNuevo", iNuevo, sMensaje)
        If Ok Then
            txtInstitucionResponsable.Text = iNuevo
            llenarDatosInstitucionVerificar()
            upMainInstitucion.Update()
        Else
            Session("Mensaje") = sMensaje
        End If
        Return Ok
    End Function
#End Region
#Region "Paginacion Grids"
    Private Sub gvDatosApoderado_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatosApoderado.PageIndexChanging
        gvDatosApoderado.PageIndex = e.NewPageIndex
        llenarGridApoderadoBusqueda()
        mpeBuscarApoderado.Show()
    End Sub

    Private Sub gvDatosInstitucion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatosInstitucionBusqueda.PageIndexChanging
        gvDatosInstitucionBusqueda.PageIndex = e.NewPageIndex
        llenarGridInstitucionBusqueda()
        mpeBuscarInstitucion.Show()
    End Sub
    Private Sub gvDatosEl_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatosEl.PageIndexChanging
        gvDatosEl.PageIndex = e.NewPageIndex
        llenarGridClienteBusqueda()
        mpeBuscarCliente.Show()
    End Sub
    Private Sub gvDatosEl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosEl.SelectedIndexChanged
        llenarDatosEl()
        mpeBuscarCliente.Hide()
    End Sub
    Private Sub gvDatosInstitucionBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosApoderado.SelectedIndexChanged
        llenarDatosApoderado()
        mpeBuscarApoderado.Hide()

    End Sub
    Private Sub gvDatosApoderado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatosInstitucionBusqueda.SelectedIndexChanged
        llenarDatosInstitucion()
        mpeBuscarInstitucion.Hide()
    End Sub
#End Region
#Region "Mostrar Pop Up"
    Protected Sub btnGuardarApoderado_Click(sender As Object, e As EventArgs) Handles btnGuardarApoderado.Click
        If Not bInsertarApoderado() Then
            cMensaje.Show(sMensaje)
            mpeAgregarApoderado.Show()
            sMensaje = ""
            Session("Mensaje") = sMensaje
        End If
    End Sub
    Protected Sub btnGuardarCliente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGuardarClienteEl.Click
        If Not bInsertarClienteEl() Then
            cMensaje.Show(sMensaje)
            mpeAgregarCliente.Show()
            sMensaje = ""
            Session("Mensaje") = sMensaje
        End If
    End Sub
    Protected Sub btnGuardarInstitucion_Click(sender As Object, e As EventArgs) Handles btnGuardarInstitucion.Click
        If Not bInsertarInstitucion() Then
            cMensaje.Show(sMensaje)
            mpeAgregarInstitucion.Show()
            sMensaje = ""
            Session("Mensaje") = sMensaje
        End If
    End Sub
    Private Sub btnBuscarEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarEl.Click
        llenarGridClienteBusqueda()
        mpeBuscarCliente.Show()
    End Sub
    Protected Sub btnBuscarInstitucion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarInstitucion.Click
        llenarGridInstitucionBusqueda()
        mpeBuscarInstitucion.Show()
    End Sub
    Protected Sub btnBuscarApoderado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscarApoderado.Click
        llenarGridApoderadoBusqueda()
        mpeBuscarApoderado.Show()
    End Sub
    Private Sub btnMostrarPopupEl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarPopupEl.Click
        mpeBuscarCliente.Show()
    End Sub
    Private Sub btnMostrarBusquedaApoderado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarBusquedaApoderado.Click
        mpeBuscarApoderado.Show()
    End Sub
    Private Sub btnMostrarBusquedaInstitucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrarBusquedaInstitucion.Click
        mpeBuscarInstitucion.Show()
    End Sub
#End Region
#Region "Busqueda de cliente, institucion, Apoderado"
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
    Private Sub btnVerificarApoderado_Click(sender As Object, e As System.EventArgs) Handles btnVerificarApoderado.Click
        llenarDatosApoderadoVerificar()
        RaiseEvent VerificarApoderado()
    End Sub
    Private Sub btnVerificarInstitucion_Click(sender As Object, e As System.EventArgs) Handles btnVerificarInstitucion.Click
        llenarDatosInstitucionVerificar()
    End Sub
    Private Sub btnVerificarEl_Click(sender As Object, e As System.EventArgs) Handles btnVerificarEl.Click
        llenarDatosElVerificar()
    End Sub
#End Region

    Private Sub ActualizarPaneles()
        idTipoSolicitante = cboTipoSolicitante.Value
        pnlApoderado.Visible = False
        pnlCliente.Visible = False
        pnlInstitucion.Visible = False
        txtApoderadoResponsable.Obligatorio = False
        txtClienteResponsable.Obligatorio = False
        txtInstitucionResponsable.Obligatorio = False
        If idTipoSolicitante <> "" Then
            If idTipoSolicitante = "A" Then
                pnlApoderado.Visible = True
                txtApoderadoResponsable.Obligatorio = True
                txtApoderadoResponsable.Valido(True)
                LimpiarDatosCliente()
                LimpiarDatosInstitucion()
                If idEntidad <> "" Then
                    txtApoderadoResponsable.Text = idEntidad
                    llenarDatosApoderadoVerificar()
                End If
            ElseIf idTipoSolicitante = "I" Then
                pnlInstitucion.Visible = True
                txtInstitucionResponsable.Obligatorio = True
                txtInstitucionResponsable.Valido(True)
                LimpiarDatosApoderado()
                LimpiarDatosCliente()
                If idEntidad <> "" Then
                    txtInstitucionResponsable.Text = idEntidad
                    llenarDatosInstitucionVerificar()
                End If
            ElseIf idTipoSolicitante = "C" Then
                pnlCliente.Visible = True
                txtClienteResponsable.Obligatorio = True
                txtClienteResponsable.Valido(True)
                LimpiarDatosApoderado()
                LimpiarDatosInstitucion()
                If idEntidad <> "" Then
                    txtClienteResponsable.Text = idEntidad
                    llenarDatosElVerificar()
                End If
            End If
        End If
        btnTitula.Visible = MostrarClientesMultiples
        btnDellst.Visible = MostrarClientesMultiples
        btnAdd.Visible = MostrarClientesMultiples
        lstClientes.Visible = MostrarClientesMultiples
        btnUp.Visible = MostrarClientesMultiples
        btnDown.Visible = MostrarClientesMultiples
    End Sub
    Private Sub cboTipoSolicitante_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoSolicitante.ComboChangedItem
        Try
            ActualizarPaneles()
        Catch ex As Exception
            '    'excError.RecoveryException(ex)
        End Try
    End Sub
#Region "Eventos Alta Popup"
    Protected Sub btnNuevoEl_Click(sender As Object, e As EventArgs) Handles btnNuevoEl.Click
        mpeAgregarCliente.Show()
    End Sub
    Protected Sub btnNuevoApoderado_Click(sender As Object, e As EventArgs) Handles btnNuevoApoderado.Click
        mpeAgregarApoderado.Show()
    End Sub
    Protected Sub btnNuevoInstitucion_Click(sender As Object, e As EventArgs) Handles btnNuevoInstitucion.Click
        mpeAgregarInstitucion.Show()
    End Sub

#End Region

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtClienteResponsable.Text <> "" Then
            Dim itm As New ListItem(txtNombresEl.Text, txtClienteResponsable.Text)
            Me.lstClientes.Items.Add(itm)
            upLista.Update()
            txtClienteResponsable.Text = ""
            txtIdentidadElBuscar.Text = ""
            txtNombresEl.Text = ""
            txtNacionalidad.Text = ""
            ActualizarPaneles()
        End If
    End Sub

    Protected Sub btnDellst_Click(sender As Object, e As EventArgs) Handles btnDellst.Click
        If Not IsNothing(lstClientes.SelectedItem) Then
            lstClientes.Items.Remove(lstClientes.SelectedItem)
        End If
    End Sub

    Protected Sub btnTitula_Click(sender As Object, e As EventArgs) Handles btnTitula.Click
        If Not IsNothing(lstClientes.SelectedItem) Then
            txtNombresEl.Text = lstClientes.SelectedItem.Text
            txtClienteResponsable.Text = lstClientes.SelectedItem.Value
        End If
    End Sub

    Protected Sub btnUp_Click(sender As Object, e As ImageClickEventArgs) Handles btnUp.Click
        If lstClientes.SelectedIndex > 0 Then
            Dim I = lstClientes.SelectedIndex - 1
            lstClientes.Items.Insert(I, lstClientes.SelectedItem)
            lstClientes.Items.RemoveAt(lstClientes.SelectedIndex)
            lstClientes.SelectedIndex = I
        End If
    End Sub

    Protected Sub btnDown_Click(sender As Object, e As ImageClickEventArgs) Handles btnDown.Click
        If lstClientes.SelectedIndex < lstClientes.Items.Count - 1 Then
            Dim I = lstClientes.SelectedIndex + 2
            lstClientes.Items.Insert(I, lstClientes.SelectedItem)
            lstClientes.Items.RemoveAt(lstClientes.SelectedIndex)
            lstClientes.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub cboDepartamentoElBuscar_ComboChangedItem(sender As Object, e As EventArgs) Handles cboDepartamentoElBuscar.ComboChangedItem
        cboMunicipioElBuscar.LLenarCombo(sender)
        If sender <> "-1" Then
            mpeBuscarCliente.Show()
        End If
    End Sub
End Class