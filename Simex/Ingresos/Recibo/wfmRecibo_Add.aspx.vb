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

#End Region

#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Calcular()
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
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
            dtParametros.Rows.Add("idApoderado", Me.Solicitante.Apoderado)
            dtParametros.Rows.Add("idCliente", Solicitante.cliente)
            dtParametros.Rows.Add("idInstitucion", Solicitante.Institucion)
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
#End Region

    Private Sub cboServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub
    Protected Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        Try
            If txtCantidad.Text = "" Then
                txtCantidad.Text = 1
            End If
            Calcular()
        Catch ex As Exception

        End Try
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

    Private Sub txtTasaCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTasaCambio.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Function GuardarNuevaTasa() As Boolean
        Try
            If txtTasaCambio.Text <> "" Then
                Calcular()
                Dim Ok As Boolean
                Dim dParam As DataTable = cFunciones.dtDatos.Clone
                dParam.Rows.Add("ValorLempiras", txtTasaCambio.Text)
                dParam.Rows.Add("idUsuario", Master.Master.Usuario)
                Ok = cFunciones.Ejecutar("pTasaCambio_Add", dParam, sMensaje)
                Session("Mensaje") = sMensaje
                Return Ok
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub Calcular()

        Try
            If txtValor.Text <> "" And txtCantidad.Text <> "" Then
                txtValorTotalLempiras.Text = FormatNumber(txtValor.Text * txtCantidad.Text, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtValor_TextChanged(sender As Object, e As EventArgs) Handles txtValor.TextChanged
        Calcular()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        GuardarNuevaTasa()
    End Sub
End Class