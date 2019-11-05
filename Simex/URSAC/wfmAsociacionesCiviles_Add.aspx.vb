Imports prjDatos
Public Class wfmAsociacionesCiviles_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pUR_Registro_Add"
    Private Const spNombreMAX As String = "pUR_Registro_MAX"
    Private pageTitle = "Agregar Asociación Civil"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = pageTitle
        If Not IsPostBack Then
            LoadDefaultValues()
        End If
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
            Session("Mensaje") = ""
        End If
    End Sub
    Sub LoadDefaultValues()
        Dim tbl As DataTable = Funciones.Filldatatable(spNombreMAX, dtParamMax)
        If tbl.Rows.Count > 0 Then
            txtNumRegistro.Text = tbl.Rows(0).Item(0).ToString
        End If
        dtcFechaRegistro.Value = Now.Date
    End Sub
    Public Function dtParamMax() As DataTable
        Try
            dtParamMax = Funciones.dtDatos.Clone
            'dtParamMax.Rows.Add(dtcFecha.FieldName, dtcFecha.Value)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

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

    Private Sub cboTipo_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAsoc.ComboChangedItem
        If sender.ToString <> "" Then
            cboSubtipo.LLenarCombo(sender)
        End If
    End Sub
    Private Sub cboDepartamento_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.ComboChangedItem
        If sender.ToString <> "" Then
            cboMunicipio.LLenarCombo(sender)
        End If
    End Sub
#End Region

#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Session("Mensaje") = ""
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
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
      
            dtParametros.Rows.Add(dtcFechaRegistro.FieldName, dtcFechaRegistro.Value)
            dtParametros.Rows.Add("IdInstitucion", Asociacion.Institucion)
            dtParametros.Rows.Add("TipoSolicitante", iTipoEntidad)
            dtParametros.Rows.Add("IdSolicitanteCliente", EncargadoResponsable.cliente)
            dtParametros.Rows.Add("IdSolicitanteApoderado", EncargadoResponsable.Apoderado)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(cboTipoAsoc.FieldName, cboTipoAsoc.Value)
            dtParametros.Rows.Add(cboSubtipo.FieldName, cboSubtipo.Value)
            dtParametros.Rows.Add(txtNumExpediente.FieldName, txtNumExpediente.Text)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametros.Rows.Add("Denominacion", Asociacion.NombreInstitucion)
            dtParametros.Rows.Add("Siglas", Asociacion.Siglas)
            Return dtParametros
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
    Protected Sub btnValidateExpediente_Click(sender As Object, e As ImageClickEventArgs) Handles btnValidateExpediente.Click
        Try
            If txtNumExpediente.Text <> "" Then
                Dim tbl As DataTable = Funciones.Filldatatable("pExpediente_List", dtParamExp)
                If tbl.Rows.Count > 0 Then
                    Asociacion.idEntidad = tbl.Rows(0).Item("idSolicitante").ToString
                    Asociacion.TipoEntidadCombo = "I"
                    Asociacion.LoadDefaults()
                    EncargadoResponsable.idEntidad = tbl.Rows(0).Item("idResponsable").ToString
                    EncargadoResponsable.TipoEntidadCombo = "A"
                    EncargadoResponsable.LoadDefaults()
                    cboDepartamento.Value = tbl.Rows(0).Item("idDepartamento").ToString
                    cboMunicipio.LLenarCombo(cboDepartamento.Value)
                    cboMunicipio.Value = tbl.Rows(0).Item("idMunicipio").ToString
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function dtParamExp() As DataTable
        Try
            dtParamExp = Funciones.dtDatos.Clone
            dtParamExp.Rows.Add("Id", txtNumExpediente.Text)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region

 
End Class