Imports prjDatos
Public Class wfmRequisitosSubServicios_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private ConsultaPuesto As String
    Private idFieldName As String
    Private TableName As String
    Private sMensaje As String = ""
    Private Const spNombre As String = "pRequisitosSubServicios_Add"
    Private sNombreMantenimiento = "Agregar Requisito Sub Servicio"
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If Session("Mensaje").ToString() <> "" Then
            Mensaje(Session("Mensaje"))
        End If
        If Not IsPostBack Then
            If Request.QueryString("Serv") <> "" Then
                cboServicio.Value = Request.QueryString("Serv")
            End If
            If Request.QueryString("Subserv") <> "" Then
                cboSubServicios.Value = Request.QueryString("Subserv")
                chkActivo.Checked = True
            End If
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
    Private Sub llenarCombo()

    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Dim sUrl As String = linkMe.NavigateUrl & "?Serv=" & cboServicio.Value & "&Subserv=" & cboSubServicios.Value
            Response.Redirect(sUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Private Sub cboRoles_ComboChangedItem(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubServicios.ComboChangedItem
        'cboEstados.LLenarCombo(sender)

    End Sub
    Private Sub cboServicio_ComboChangedItem(sender As Object, e As EventArgs) Handles cboServicio.ComboChangedItem
        cboSubServicios.LLenarCombo(sender)
    End Sub
#End Region
#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        If sMensaje <> "" Then
            lblMsg.Text = sMensaje
        End If
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(cboRequisitos.FieldName, cboRequisitos.Value)
            dtParametros.Rows.Add(cboSubServicios.FieldName, cboSubServicios.Value)
            dtParametros.Rows.Add("Activo", chkActivo.Checked)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            If Session("Mensaje") = "Error" Then
                Return Nothing
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        If sMensaje <> "" Then
            Dim strScript As String = "<script language=JavaScript>"
            strScript += "alert(""" & sMensaje & """);"
            strScript += "</script>"
            If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
            End If
            Session("Mensaje") = ""
        End If
    End Sub
#End Region

End Class