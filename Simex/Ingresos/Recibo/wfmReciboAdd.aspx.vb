﻿Imports prjDatos
Public Class wfmReciboAdd
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private szMensaje As String = ""
    Private Const spNombre As String = "pRecibo_Add"
    Private szCliente As String = "pCliente_List"
    Private szApoderado As String = "pApoderados_List"
    Private szInstitucion As String = "pInstituciones_List"
    Private sNombreBusquedaSubServicio As String = "pSubServicios_List"
    Private szNombreBusquedaExpediente As String = "pExpediente_List"
    Private szTasaCambio As String = "pTasaCambio_Actual"
    Private szGetClienteApoderado As String = "pRecibo_ConsultaExpediente"
#Region "methodos"

    Private Sub verificarExpediente()
        lblServicio.Visible = False
        lblSubServicio.Visible = False
        cboServicio.Visible = False
        cboSubServicio.Visible = False
        If dcFechaEmision.Value = "" Or dcFechaPago.Value = "" Then
            Return
        End If
        Dim datos = cFunciones.dtDatos.Clone
        datos.Rows.Add("IdExpediente", tbxIdExpediente.Text)
        Dim table = cFunciones.Filldatatable(szGetClienteApoderado, datos)
        Dim szSubservicio = ""
        If table.Rows.Count > 0 Then
            Dim tokens = tbxIdExpediente.Text.Split("-")
            szSubservicio = tokens(0).ToUpper
            If rbUsarSubServicioCombo.Checked Or "V" = szSubservicio Then
                lblClienteKey.Text = table.Rows(0).Item("NombreTipoSolicitante")
                lblClienteValue.Text = table.Rows(0).Item("IdSolicitante")
                tbxCliente.Text = table.Rows(0).Item("Solicitante")
                lblApoderadoKey.Text = table.Rows(0).Item("NombreTipoResponsable")
                lblApoderadoValue.Text = table.Rows(0).Item("IdResponsable")
                tbxApoderado.Text = table.Rows(0).Item("Responsable")
                lblServicio.Visible = True
                lblSubServicio.Visible = True
                cboServicio.Visible = True
                cboSubServicio.Visible = True
            Else
                lblClienteKey.Text = table.Rows(0).Item("NombreTipoSolicitante")
                lblClienteValue.Text = table.Rows(0).Item("IdSolicitante")
                tbxCliente.Text = table.Rows(0).Item("Solicitante")
                lblApoderadoKey.Text = table.Rows(0).Item("NombreTipoResponsable")
                lblApoderadoValue.Text = table.Rows(0).Item("IdResponsable")
                tbxApoderado.Text = table.Rows(0).Item("Responsable")
                lblSubservicioValue.Text = table.Rows(0).Item("idSubServicio")
                datos = cFunciones.dtDatos.Clone
                datos.Rows.Add("Codigo", lblSubservicioValue.Text)
                Dim ConsultaSubservicios = cFunciones.Filldatatable(sNombreBusquedaSubServicio, datos)
                datos = cFunciones.dtDatos.Clone
                datos.Rows.Add("Fecha", dcFechaPago.Value)
                Dim ConsultaTasa = cFunciones.Filldatatable(szTasaCambio, datos)
                If ConsultaSubservicios.Rows(0).Item("IndTipoMoneda") = "L" Then
                    tbxPrecioEnLempiras.Text = ConsultaSubservicios.Rows(0).Item("Valor")
                    tbxTasaCambio.Text = ConsultaTasa.Rows(0).Item("ValorLempiras")
                    tbxPrecioEnDollares.Text = (Double.Parse(tbxPrecioEnLempiras.Text.ToString()) / Double.Parse(tbxTasaCambio.Text.ToString())).ToString()
                Else
                    tbxPrecioEnDollares.Text = ConsultaSubservicios.Rows(0).Item("Valor")
                    tbxTasaCambio.Text = ConsultaTasa.Rows(0).Item("ValorLempiras")
                    tbxPrecioEnLempiras.Text = (Double.Parse(tbxPrecioEnDollares.Text.ToString()) * Double.Parse(tbxTasaCambio.Text.ToString())).ToString()
                End If
            End If
        End If
    End Sub

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            If tbxNumRecibo.Text <> tbxNumRecibo2.Text Then
                lblMesajeRecibo.Visible = True
                Session("Mensaje") = "Error"
            End If
            dtParametros.Rows.Add("NumReciboFinanzas", tbxNumRecibo.Text)
            dtParametros.Rows.Add(cboOficina.FieldName, cboOficina.Value)
            dtParametros.Rows.Add("idSubServicio", lblSubservicioValue.Text)
            If rbUsarSubServicio0.Checked Then
                dtParametros.Rows.Add("Valor", tbxLempiras.Text)
            Else
                dtParametros.Rows.Add("Valor", tbxPrecioEnLempiras.Text)
            End If
            dtParametros.Rows.Add("ValorDolares", tbxPrecioEnDollares.Text)
            dtParametros.Rows.Add("Cantidad", tbxCantidad.Text)
            dtParametros.Rows.Add(dcFechaEmision.FieldName, dcFechaEmision.Value)
            dtParametros.Rows.Add(dcFechaPago.FieldName, dcFechaPago.Value)
            dtParametros.Rows.Add("TasaCambio", tbxTasaCambio.Text)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametros.Rows.Add(cboEstadoRecibo.FieldName, cboEstadoRecibo.Value)
            dtParametros.Rows.Add("idExpediente", tbxIdExpediente.Text)
            'a nombre de quien esta el recibo
            If RadioButton1.Checked Then
                dtParametros.Rows.Add(lblClienteKey.Text, lblClienteValue.Text)
            ElseIf RadioButton2.Checked Then
                dtParametros.Rows.Add(lblApoderadoKey.Text, lblApoderadoValue.Text)
            Else
                dtParametros.Rows.Add("Tercero", tbxTercero.Text)
                dtParametros.Rows.Add("ObservacionTercero", tbxObservacionesTercero.Text)
            End If
            If Session("Mensaje") = "Error" Then
                Session("Mensaje") = ""
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, szMensaje)
        Session("Mensaje") = szMensaje
        Return Ok
    End Function
#End Region
#Region "eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click

        tbxNumRecibo.Attributes.Add("onkeydown", "return isNumeric(event.keyCode);")
        tbxNumRecibo.Attributes.Add("onpaste", "return false")
        tbxNumRecibo.Attributes.Add("onkeyup", "keyUP(event.keyCode)")
        tbxNumRecibo2.Attributes.Add("onkeydown", "return isNumeric(event.keyCode);")
        tbxNumRecibo2.Attributes.Add("onpaste", "return false")
        tbxNumRecibo2.Attributes.Add("onkeyup", "keyUP(event.keyCode)")
        tbxCantidad.Attributes.Add("onkeydown", "return isNumeric(event.keyCode);")
        tbxCantidad.Attributes.Add("onpaste", "return false")
        tbxCantidad.Attributes.Add("onkeyup", "keyUP(event.keyCode)")
        SetControlsEnable(Not rbUsarSubServicio0.Checked)
        If Session("Mensaje") <> "" And Session("Mensaje") <> "Error" Then
            Mensaje(Session("Mensaje"))
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMain.NavigateUrl)
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(LinkMe.NavigateUrl)
        Else
            Mensaje(szMensaje)
        End If
    End Sub

    Protected Sub btnExpediente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpediente.Click
        verificarExpediente()
    End Sub
#End Region

    Protected Sub btnCalcular_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalcular.Click
        Dim fCantidad As Double
        If tbxPrecioEnLempiras.Text.Length > 0 And Double.TryParse(tbxCantidad.Text, fCantidad) Then
            tbxLempiras.Text = (Double.Parse(tbxPrecioEnLempiras.Text) * fCantidad).ToString()
        End If
    End Sub

    Private Sub cboServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub

    Private Sub cboSubServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubServicio.ComboChangedItem
        'recuperar los datos del detalle del costo del sub servicio
        'recuperar la tasa de cambio
        If cboSubServicio.Value <> "-1" And cboSubServicio.Value <> Nothing Then
            lblSubservicioValue.Text = cboSubServicio.Value
            Dim datos = cFunciones.dtDatos.Clone
            datos.Rows.Add("Codigo", cboSubServicio.Value)
            Dim ConsultaSubservicios = cFunciones.Filldatatable(sNombreBusquedaSubServicio, datos)
            datos = cFunciones.dtDatos.Clone
            datos.Rows.Add("Fecha", dcFechaPago.Value)
            Dim ConsultaTasa = cFunciones.Filldatatable(szTasaCambio, datos)
            If ConsultaSubservicios.Rows(0).Item("IndTipoMoneda") = "L" Then
                tbxPrecioEnLempiras.Text = ConsultaSubservicios.Rows(0).Item("Valor")
                tbxTasaCambio.Text = ConsultaTasa.Rows(0).Item("ValorLempiras")
                tbxPrecioEnDollares.Text = (Double.Parse(tbxPrecioEnLempiras.Text.ToString()) / Double.Parse(tbxTasaCambio.Text.ToString())).ToString()
            Else
                tbxPrecioEnDollares.Text = ConsultaSubservicios.Rows(0).Item("Valor")
                tbxTasaCambio.Text = ConsultaTasa.Rows(0).Item("ValorLempiras")
                tbxPrecioEnLempiras.Text = (Double.Parse(tbxPrecioEnDollares.Text.ToString()) * Double.Parse(tbxTasaCambio.Text.ToString())).ToString()
            End If
        End If
    End Sub

    Protected Sub rbUsarSubServicio0_CheckedChanged(sender As Object, e As EventArgs) Handles rbUsarSubServicio0.CheckedChanged
        tbxLempiras.ReadOnly = Not rbUsarSubServicio0.Checked
        If rbUsarSubServicio0.Checked Then
            tbxLempiras.Text = My.Settings.ReciboDefVal
        End If
        SetControlsEnable(Not rbUsarSubServicio0.Checked)
    End Sub

    Sub SetControlsEnable(bVal As Boolean)
        lblExpediente.Visible = bVal
        tbxIdExpediente.Visible = bVal
        btnExpediente.Visible = bVal
        lblServicio.Visible = bVal
        cboServicio.Visible = bVal
        lblSubServicio.Visible = bVal
        cboSubServicio.Visible = bVal
        RadioButton1.Visible = bVal
        RadioButton2.Visible = bVal
        RadioButton3.Visible = bVal
        tbxCliente.Visible = bVal
        tbxApoderado.Visible = bVal
        tbxTercero.Visible = bVal
        lblPrecioEnDollares.Visible = bVal
        tbxPrecioEnDollares.Visible = bVal
        lblPrecioEnLempiras.Visible = bVal
        tbxPrecioEnLempiras.Visible = bVal
        lblTasaCambio.Visible = bVal
        tbxTasaCambio.Visible = bVal
        tbxCantidad.Visible = bVal
        btnCalcular.Visible = bVal
        lblCliente.Visible = bVal
        lblApoderado.Visible = bVal
        lblTercero.Visible = bVal
        tbxLempiras.ReadOnly = bVal
    End Sub

    Protected Sub rbUsarSubServicio_CheckedChanged(sender As Object, e As EventArgs) Handles rbUsarSubServicio.CheckedChanged
        SetControlsEnable(rbUsarSubServicio.Checked)
    End Sub

    Protected Sub rbUsarSubServicioCombo_CheckedChanged(sender As Object, e As EventArgs) Handles rbUsarSubServicioCombo.CheckedChanged
        SetControlsEnable(rbUsarSubServicioCombo.Checked)
    End Sub
End Class