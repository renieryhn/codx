Imports prjDatos
Public Class wfmDispensaEdicto_Edit
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private spNombre As String = "pDispensaEdicto_Edit"
    Private spListNombre As String = "pDispensaedicto_List"
    Private sNombreCliente, codigo, idPais As String
    Private sNombreMantenimiento As String = "Editar Dispensa de Edicto"
    Dim sMensaje As String = ""
    Dim dtDatosEl, dtDatosElla, dtDatos As New DataTable
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        If Session("Mensaje") <> "" And Session("Mensaje") <> "Error" Then
            Mensaje(Session("Mensaje"))

        End If
        If Not IsPostBack Then
            'cargar datos
            CargarValores()
        End If
    End Sub
    Protected Sub brnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles brnImprimir.Click
        If cboTipoEdicto.Value <> "-1" Then
            Session("id") = txtNumeroEdicto.Text
            If cboTipoEdicto.Value = "1" Then
                Session("TipoReporte") = "DE"
            ElseIf cboTipoEdicto.Value = "0" Then
                Session("TipoReporte") = "DENP"
            End If
            Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
        End If
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            If cboTipoEdicto.Value <> "-1" Then
                Session("id") = ID
                If cboTipoEdicto.Value = "1" Then
                    Session("TipoReporte") = "DE"
                ElseIf cboTipoEdicto.Value = "0" Then
                    Session("TipoReporte") = "DENP"
                End If
                Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
            Else
                Redirect()
            End If
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
    
    Sub ChangeSelectedItemDeptoDispensaEdicto(ByVal sender As Object, ByVal e As EventArgs) Handles cboDepartamentoDispensaEdicto.ComboChangedItem
        Try
            cboMunicipioDispensaEdicto.LLenarCombo(sender)
        Catch ex As Exception
            '    'excError.RecoveryException(ex)
        End Try
    End Sub
    
#End Region
#Region "Metodos"

    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtNumeroEdicto.Text = Session("ID")
                dtDatos = cFunciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                txtNumeroAcuerdo.Text = dtDatos.Rows(0).Item(txtNumeroAcuerdo.FieldName)
                Session("idAcuerdoEdicto") = dtDatos.Rows(0).Item("idAcuerdoEdicto")
                ClienteEl.cliente = dtDatos.Rows(0).Item("idClienteEl").ToString
                ClienteElla.cliente = dtDatos.Rows(0).Item("idClienteElla").ToString
                cboDepartamentoDispensaEdicto.Value = dtDatos.Rows(0).Item(cboDepartamentoDispensaEdicto.FieldName)
                cboMunicipioDispensaEdicto.Value = dtDatos.Rows(0).Item(cboMunicipioDispensaEdicto.FieldName)
                cboFirmaAutorizada.Value = dtDatos.Rows(0).Item(cboFirmaAutorizada.FieldName)
                dtcFechaEdicto.Value = dtDatos.Rows(0).Item(dtcFechaEdicto.FieldName)
                ClienteEl.llenarDatosElVerificar()
                ClienteElla.llenarDatosElVerificar()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    
    Private Sub Redirect()
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Private Sub RedirectSelf()
        Response.Redirect(LinkMe.NavigateUrl)
    End Sub
    
    Private Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosBusqueda = cFunciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add(txtNumeroEdicto.FieldName, txtNumeroEdicto.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("id", txtNumeroEdicto.Text)
            dtParametros.Rows.Add("idAcuerdoEdicto", Session("idAcuerdoEdicto"))
            dtParametros.Rows.Add("idClienteEl", ClienteEl.cliente)
            dtParametros.Rows.Add("idClienteElla", ClienteElla.cliente)
            dtParametros.Rows.Add(cboMunicipioDispensaEdicto.FieldName, cboMunicipioDispensaEdicto.Value)
            dtParametros.Rows.Add(dtcFechaEdicto.FieldName, dtcFechaEdicto.Value)
            dtParametros.Rows.Add(cboFirmaAutorizada.FieldName, cboFirmaAutorizada.Value)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If ClienteEl.cliente = ClienteElla.cliente Then
                Session("Mensaje") = "Error"
            End If
            If Session("Mensaje") = "Error" Then
                Session("Mensaje") = "Ambos Contrayentes deben ser distintos"
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