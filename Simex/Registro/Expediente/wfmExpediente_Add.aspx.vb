Imports prjDatos
Imports System.Data.SqlClient
Imports Telerik.Web
Imports Telerik.Web.UI

Public Class wfmExpediente_Add
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pExpediente_Add"
    Private sNombreBusquedaCliente As String = "pCliente_List"
    Private sNombreAltaCliente As String = "pCliente_Add"
    Private sNombreBusquedaApoderado As String = "pApoderados_List"
    Private sNombreAltaApoderado As String = "pApoderados_Add"
    Private sNombreBusquedaInstitucion As String = "pInstituciones_List"
    Private sNombreAltaInstitucion As String = "pInstituciones_Add"
    Private sNombreBusquedaSubServicio As String = "pSubServicios_List"
    Private sNombreBusquedaRequisitos As String = "pRequisitosSubServicios_List"
    Private sNombreAltaExpedientesRequisitos As String = "pExpedientesRequisitos_Add"
    Private sNombreMantenimiento As String = "Nuevo Expediente"
    Private dtDatosCliente, dtDatosApoderado, dtDatosInstitucion As New DataTable
    Private idTipoSolicitante As String
    Private idTipoInteresado As String
    Dim dtDatos As New DataTable
    Dim _numExpediente As String = ""

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If IsPostBack Then
            If Session("Mensaje") <> "" Then
                Mensaje(Session("Mensaje"))
            End If
        Else
            Session("ID") = "0"
            Session("Mensaje") = ""
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMain.NavigateUrl)
        Else
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(LinkMe.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub


    Private Sub cboServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicio.LLenarCombo(sender)
    End Sub
    Private Sub cboSubServicio_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubServicio.ComboChangedItem
        If cboSubServicio.SelectedIndex > 0 Then
            llenarRequisitos()
        End If
    End Sub
    Private Sub cboDepartamento_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamentoExpediente.ComboChangedItem
        cboMunicipioExpediente.LLenarCombo(sender)
    End Sub
#End Region
#Region "Metodos"



#Region "Metodos Busqueda PopUp"

    Private Sub llenarRequisitos()
        Dim tbl As DataTable
        Dim i As Integer
        tbl = cFunciones.Filldatatable(sNombreBusquedaRequisitos, dtParametrosRequisitosVerificar)
        rlstRequisitos.Items.Clear()
        For i = 0 To tbl.Rows.Count - 1
            Dim itm As New RadListBoxItem(tbl.Rows(i).Item("NombreRequisito").ToString, tbl.Rows(i).Item("IdRequisito").ToString)
            rlstRequisitos.Items.Add(itm)
        Next
        rlstRequisitos.DataBind()
    End Sub

    Private Function dtParametrosRequisitosVerificar() As DataTable
        Try
            dtParametrosRequisitosVerificar = cFunciones.dtDatos.Clone
            dtParametrosRequisitosVerificar.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#End Region
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Dim numExpediente As String = ""
        Dim lst As WebControls.ListBox = InteresadoSolicitante.Clientes
        Ok = cFunciones.Ejecutar(spNombre, dtParametros, "NumExpedienteNuevo", numExpediente, sMensaje)
        _numExpediente = numExpediente
        If Ok Then
            ActualizarRequisitos(numExpediente)
            ActualizarClientes(numExpediente, lst)
            sMensaje = sMensaje & " Expediente Numero: " & numExpediente
            Session("ID") = numExpediente
        End If
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtNumRecibo.FieldName, txtNumRecibo.Text)
            dtParametros.Rows.Add(cboServicio.FieldName, cboServicio.Value)
            dtParametros.Rows.Add(cboSubServicio.FieldName, cboSubServicio.Value)
            dtParametros.Rows.Add("idClienteResponsable", EncargadoResponsable.cliente)
            dtParametros.Rows.Add("idInstitucionResponsable", EncargadoResponsable.Institucion)
            dtParametros.Rows.Add("idApoderadoResponsable", EncargadoResponsable.Apoderado)
            If InteresadoSolicitante.cliente <> "" Then
                dtParametros.Rows.Add("idClienteSolicitante", InteresadoSolicitante.cliente)
            Else
                If InteresadoSolicitante.Clientes.Items.Count > 0 Then
                    dtParametros.Rows.Add("idClienteSolicitante", InteresadoSolicitante.Clientes.Items(0).Value)
                End If
            End If
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
    Public Function dtParametrosRequisitos(ByVal numExpediente As String, ByVal idrequisito As Integer, ByVal valor As Boolean) As DataTable
        Try
            dtParametrosRequisitos = cFunciones.dtDatos.Clone
            dtParametrosRequisitos.Rows.Add("idExpediente", numExpediente)
            dtParametrosRequisitos.Rows.Add("idRequisito", idrequisito)
            dtParametrosRequisitos.Rows.Add("Valor", valor)
            dtParametrosRequisitos.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
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

    Public Function ActualizarRequisitos(ByVal numExpediente As String) As DataTable
        Try
            Dim Ok As Boolean
            ActualizarRequisitos = cFunciones.dtDatos.Clone
            Dim bVal As Boolean
            Dim iValue As Integer
            For i = 0 To rlstRequisitos.Items.Count - 1
                iValue = rlstRequisitos.Items(i).Value
                bVal = rlstRequisitos.Items(i).Checked
                Ok = cFunciones.Ejecutar(sNombreAltaExpedientesRequisitos, dtParametrosRequisitos(numExpediente, iValue, bVal), sMensaje)
            Next
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function ActualizarClientes(ByVal numExpediente As String, lst As WebControls.ListBox) As Boolean
        Try
            Dim OK As Boolean
            Dim numCliente As String = ""

            If Not lst Is Nothing Then
                For i = 0 To lst.Items.Count - 1
                    numCliente = lst.Items(i).Value.ToString()
                    OK = cFunciones.Ejecutar("pExpedientesCliente_Add", dtParametrosExpCliente(numExpediente, numCliente), sMensaje)
                Next
            End If
            Return True
        Catch ex As Exception
            Return False
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

#Region "Validacion de Email de Apoderado"

    Function ApoderadoHasEmail() As Boolean
        Try
            Dim bHasEmail As Boolean = False
            Dim tbl As DataTable
            Dim i As Integer
            tbl = cFunciones.Filldatatable("pApoderados_HasEmail", dtParametrosApoderadoHasEmail)
            rlstRequisitos.Items.Clear()
            For i = 0 To tbl.Rows.Count - 1
                If tbl.Rows(i).Item(1).ToString = "" Then
                    bHasEmail = False
                Else
                    bHasEmail = True
                End If
            Next
            Return bHasEmail
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function dtParametrosApoderadoHasEmail() As DataTable
        Try
            dtParametrosApoderadoHasEmail = cFunciones.dtDatos.Clone
            dtParametrosApoderadoHasEmail.Rows.Add("Id", EncargadoResponsable.Apoderado)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub ShowWindowModal(sWindowURL As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "popupWindow = window.open('" & sWindowURL & "', 'popUpWindow', 'height=160,width=450,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub

#End Region
#End Region

    Private Sub EncargadoResponsable_VerificarApoderado() Handles EncargadoResponsable.VerificarApoderado
        If Not ApoderadoHasEmail() Then
            If EncargadoResponsable.Apoderado.ToString <> "" Then
                ShowWindowModal("ApoderadoEmail.aspx?id=" & EncargadoResponsable.Apoderado.ToString)
            End If
        End If
    End Sub

    Private Sub cboMunicipioExpediente_ComboChangedItem(sender As Object, e As EventArgs) Handles cboMunicipioExpediente.ComboChangedItem

    End Sub
End Class