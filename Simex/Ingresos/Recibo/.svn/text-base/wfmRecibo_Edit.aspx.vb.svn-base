Imports prjDatos
Public Class wfmRecibo_Edit
     Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private szMensaje As String = ""
    Private Const szEdit As String = "pRecibo_Edit"
    Private Const szLookup = "pReciboDetalle"
    Private szCliente As String = "pCliente_List"
    Private szApoderado As String = "pApoderados_List"
    Private szInstitucion As String = "pInstituciones_List"
    Private sNombreBusquedaSubServicio As String = "pSubServicios_List"
    Private szNombreBusquedaExpediente As String = "pExpediente_List"
    Private szTasaCambio As String = "pTasaCambio_Actual"
    Private szGetClienteApoderado As String = "pRecibo_ConsultaExpediente"
#Region "methodos"

    Private Sub verificarExpediente()
        Dim datos = cFunciones.dtDatos.Clone
        datos.Rows.Add("IdExpediente", tbxIdExpediente.Text)
        Dim table = cFunciones.Filldatatable(szGetClienteApoderado, datos)
        If table.Rows.Count > 0 Then
            lblClienteKey.Text = table.Rows(0).Item("NombreTipoSolicitante").ToString()
            lblClienteValue.Text = table.Rows(0).Item("IdSolicitante").ToString()
            tbxCliente.Text = table.Rows(0).Item("Solicitante").ToString()
            lblApoderadoKey.Text = table.Rows(0).Item("NombreTipoResponsable").ToString()
            lblApoderadoValue.Text = table.Rows(0).Item("IdResponsable").ToString()
            tbxApoderado.Text = table.Rows(0).Item("Responsable").ToString()
            lblSubservicioValue.Text = table.Rows(0).Item("idSubServicio").ToString()
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
            dtParametros.Rows.Add("Id", Session("ID"))
            dtParametros.Rows.Add("NumReciboFinanzas", tbxNumRecibo.Text)
            dtParametros.Rows.Add("idSubServicio", lblSubservicioValue.Text)
            dtParametros.Rows.Add("idOficina", lblOficinaValue.Text)
            dtParametros.Rows.Add("Valor", tbxPrecioEnLempiras.Text)
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
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function bLlenear(ByRef params As DataTable) As Boolean
        If Not IsPostBack Then
            params.Rows.Add("Id", Session("ID"))
            Dim Ok = cFunciones.Filldatatable(szLookup, params, szMensaje)
            Session("Mensaje") = szMensaje
            If Ok.Rows.Count > 0 Then
                lblClienteKey.Text = Ok.Rows(0).Item("NombreTipoSolicitante").ToString()
                lblClienteValue.Text = Ok.Rows(0).Item("IdSolicitante").ToString()
                tbxCliente.Text = Ok.Rows(0).Item("Solicitante").ToString()
                lblSubservicioValue.Text = Ok.Rows(0).Item("idSubservicio").ToString()
                lblOficinaValue.Text = Ok.Rows(0).Item("idOficina").ToString()
                lblApoderadoKey.Text = Ok.Rows(0).Item("NombreTipoResponsable").ToString()
                lblApoderadoValue.Text = Ok.Rows(0).Item("IdResponsable").ToString()
                tbxApoderado.Text = Ok.Rows(0).Item("Responsable").ToString()
                tbxNumRecibo.Text = Ok.Rows(0).Item("NumReciboFinanzas").ToString()
                tbxCantidad.Text = Ok.Rows(0).Item("Cantidad").ToString()
                tbxIdExpediente.Text = Ok.Rows(0).Item("IdExpediente").ToString()
                tbxPrecioEnLempiras.Text = Ok.Rows(0).Item("Valor").ToString()
                tbxPrecioEnDollares.Text = Ok.Rows(0).Item("ValorDolares").ToString()
                tbxTasaCambio.Text = Ok.Rows(0).Item("TasaCambio").ToString()
                dcFechaEmision.Value = Ok.Rows(0).Item("FechaEmision").ToString()
                dcFechaPago.Value = Ok.Rows(0).Item("FechaPago").ToString()
                tbxTercero.Text = Ok.Rows(0).Item("Tercero").ToString()
                tbxObservacionesTercero.Text = Ok.Rows(0).Item("ObservacionTercero").ToString()
                Dim fCantidad As Double
                If tbxPrecioEnLempiras.Text.Length > 0 AndAlso Double.TryParse(tbxCantidad.Text, fCantidad) Then
                    tbxLempiras.Text = (Double.Parse(tbxPrecioEnLempiras.Text) * fCantidad).ToString()
                End If
                If Not IsDBNull(Ok.Rows(0).Item("indPagado")) AndAlso "0" = Ok.Rows(0).Item("indPagado") Then
                    cboEstadoRecibo.Value = 0
                Else
                    cboEstadoRecibo.Value = 1
                End If
                If Not IsDBNull(Ok.Rows(0).Item("idInstitucion")) Then
                    RadioButton1.Checked = True
                ElseIf Not IsDBNull(Ok.Rows(0).Item("idCliente")) Then
                    RadioButton1.Checked = True
                ElseIf Not IsDBNull(Ok.Rows(0).Item("idApoderado")) Then
                    RadioButton2.Checked = True
                Else
                    RadioButton3.Checked = True
                End If
                Return True
            End If
        End If
        Return False
    End Function

    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(szEdit, dtParametros, szMensaje)
        Session("Mensaje") = szMensaje
        Return Ok
    End Function
#End Region
#Region "eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Dim pDatos = cFunciones.dtDatos.Clone()
        bLlenear(pDatos)
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
End Class