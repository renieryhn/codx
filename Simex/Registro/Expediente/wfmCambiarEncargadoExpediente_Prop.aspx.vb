Imports prjDatos
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Public Class wfmCambiarEncargadoExpediente_Prop
    Inherits System.Web.UI.Page
    Private cFunciones = New prjDatos.funciones()
    Dim Funciones As New funciones
    Private sMensaje As String = ""
    Dim Ok As Boolean
    Dim dtDatos As New DataTable
    Dim _numExpediente As String = ""
    Private sNombreNuevoEstado As String = "pDetalleExpediente_AgregarEstado"
    Private sNombreMantenimiento As String = "Cambio de Estado"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then
                If Session("Mensaje") <> "" Then
                    Mensaje(Session("Mensaje"))
                End If
                AddHandler Master.PreRender, AddressOf Page_PreRender
                Master.Master.m_titulo = sNombreMantenimiento
            Else
                Session("Mensaje") = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try
            If Master.idExpediente <> "" And Not IsPostBack Then
                CargarValores()
            End If
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub
#End Region

#Region "Metodos"
    Private Sub CargarValores()

        Try
            cboNuevoEstado.LLenarCombo(dtParametroComboEstadoEnviar)
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub

    Private Function bInsertar() As Boolean
        Dim Ok As Boolean = False
        Try
            Dim numExpediente As String = ""
            'Ok = cFunciones.Ejecutar(sNombreNuevoEstado, dtParametrosAgregarEstado, "NumExpedienteNuevo", numExpediente, sMensaje)
            Ok = Funciones.Ejecutar(sNombreNuevoEstado, dtParametrosAgregarEstado, sMensaje)
            _numExpediente = numExpediente

            Return Ok
        Catch ex As Exception
            Return Ok
        End Try
    End Function

    Public Sub Mensaje(ByVal sMensaje As String)
        If sMensaje <> "Error" Then
            Dim strScript As String = "<script language=JavaScript>"
            strScript += "alert(""" & sMensaje & """);"
            strScript += "</script>"
            If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
            End If
        End If
    End Sub
#End Region

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If bInsertar() = True Then
            Response.Redirect("~/Registro/Expediente/wfmSeguimientoExpediente.aspx")
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/Registro/Expediente/wfmExpedienteMantenimiento.aspx")
    End Sub

    Private Sub cboNuevoEstado_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNuevoEstado.ComboChangedItem
        Try
            If cboNuevoEstado.Value <> "-1" And cboNuevoEstado.Value <> Nothing Then
                Dim tblData As DataTable = Funciones.Filldatatable("pPersonaEstadoRol_List2", dtParametrosEmpleadoEstado)
                With cboNuevoEmpleado
                    .DataFieldID = "IdEmpleado"
                    .DataFieldParentID = "IdRol"
                    .DataValueField = "IdEmpleado"
                    .DataTextField = "NombreCompleto"
                    .DataSource = tblData
                    .DataBind()
                End With
                cboNuevoEmpleado.DataBind()
            End If
        Catch ex As Exception
            Session("Mensaje") = ""
        End Try
    End Sub

    Private Function dtParametrosAgregarEstado() As DataTable
        Try
            Dim ComentariosModificacion As String = "Expediente:" & Master.idExpediente & Session("Modificacion") & " DATOS NUEVOS: ESTADO:" & cboNuevoEstado.Text
            ComentariosModificacion = ComentariosModificacion & " USUARIO RECIBE:" & cboNuevoEmpleado.SelectedText
            dtParametrosAgregarEstado = Funciones.dtDatos.Clone
            dtParametrosAgregarEstado.Rows.Add("idExpediente", Master.idExpediente)
            dtParametrosAgregarEstado.Rows.Add(cboNuevoEstado.FieldName, cboNuevoEstado.Value)
            dtParametrosAgregarEstado.Rows.Add("IdEmpleado", cboNuevoEmpleado.SelectedValue)
            dtParametrosAgregarEstado.Rows.Add("Modificacion", ComentariosModificacion)
            dtParametrosAgregarEstado.Rows.Add("idusuario", Master.Master.Usuario)
            dtParametrosAgregarEstado.Rows.Add("IndReasignado", "1")
            dtParametrosAgregarEstado.Rows.Add("Comen", Me.txtComentarios.Text)
            If Session("Mensaje") = "Error" Then
                Session("Mensaje") = ""
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function dtParametrosEmpleadoEstado() As DataTable
        Try
            dtParametrosEmpleadoEstado = Funciones.dtDatos.Clone
            dtParametrosEmpleadoEstado.Rows.Add("idEstado", cboNuevoEstado.Value)
            dtParametrosEmpleadoEstado.Rows.Add("Recibir", "1")
            dtParametrosEmpleadoEstado.Rows.Add("Activo", "0")
        Catch ex As Exception
            Session("Mensaje") = ""
            Return Nothing
        End Try
    End Function


    Public Function dtParametroComboEstadoEnviar() As DataTable
        Try
            dtParametroComboEstadoEnviar = Funciones.dtDatos.Clone
            dtParametroComboEstadoEnviar.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametroComboEstadoEnviar.Rows.Add("Enviar", 1)
            'If Not Master.Master.Alta Then
            '    dtParametroComboEstadoEnviar.Rows.Add("idEstadoActual", 1)
            '    dtParametroComboEstadoEnviar.Rows.Add("idServicio", Master.idExpediente.ToString.Substring(0, 2))
            '    dtParametroComboEstadoEnviar.Rows.Add("idExpediente", Master.idExpediente)
            'End If



        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
End Class