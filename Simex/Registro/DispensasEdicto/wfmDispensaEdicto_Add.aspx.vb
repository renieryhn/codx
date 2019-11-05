Imports prjDatos
Public Class wfmDispensaEdicto_Add
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private spNombre As String = "pDispensaEdicto_Add"
    Private sNombreCliente, codigo, idPais As String
    Private sNombreMantenimiento As String = "Nueva dispensa de edicto"
    Dim sMensaje As String = ""
    Dim dtDatosEl, dtDatosElla As New DataTable
    Dim iId As Integer
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        'If Session("Mensaje") <> "" And Session("Mensaje") <> "Error" Then
        '    Mensaje(Session("Mensaje"))
        '    Session("Mensaje") = ""
        'End If
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            RecuperarNumeroAcuerdo()
        End If
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            If cboTipoEdicto.Value <> "-1" Then
                Session("id") = id
                If cboTipoEdicto.Value = "1" Then
                    Session("TipoReporte") = "DE"
                ElseIf cboTipoEdicto.Value = "0" Then
                    Session("TipoReporte") = "DENP"
                End If
                Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
            End If
        ElseIf sMensaje <> "Error" And sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkMain.NavigateUrl)
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            If cboTipoEdicto.Value <> "-1" Then
                Session("id") = id
                If cboTipoEdicto.Value = "1" Then
                    Session("TipoReporte") = "DE"
                ElseIf cboTipoEdicto.Value = "0" Then
                    Session("TipoReporte") = "DENP"
                End If
                Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
            End If
            'Response.Redirect(LinkMe.NavigateUrl)
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
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, "idNuevo", id, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    
    Private Sub RecuperarNumeroAcuerdo()
        Dim dtNumeroAcuerdo As New DataTable
        dtNumeroAcuerdo = cFunciones.Filldatatable("pAcuerdoEdicto_List", dtParametrosNumeroAcuerdo)
        If dtNumeroAcuerdo.Rows.Count() < 1 Then
            'Mensaje("No se ha generado el numero de acuerdo correspondiente a la fecha actual")
            Session("Mensaje") = "No se ha generado el numero de acuerdo correspondiente a la fecha actual"
            Response.Redirect(Me.linkMain.NavigateUrl)
        Else
            txtNumeroAcuerdo.Text = dtNumeroAcuerdo.Rows(0).Item(txtNumeroAcuerdo.FieldName).ToString
            Session("idAcuerdoEdicto") = dtNumeroAcuerdo.Rows(0).Item("id").ToString
        End If

    End Sub

    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idAcuerdoEdicto", Session("idAcuerdoEdicto"))
            dtParametros.Rows.Add("idClienteEl", ClienteEl.cliente)
            dtParametros.Rows.Add("idClienteElla", ClienteElla.cliente)
            dtParametros.Rows.Add(cboMunicipioDispensaEdicto.FieldName, cboMunicipioDispensaEdicto.Value)
            ' dtParametros.Rows.Add("FechaEdicto", Date.Now.ToShortDateString)
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

    Private Function dtParametrosNumeroAcuerdo() As DataTable
        Try
            dtParametrosNumeroAcuerdo = cFunciones.dtDatos.Clone
            dtParametrosNumeroAcuerdo.Rows.Add("AcuerdoEdictoActual", 1)
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