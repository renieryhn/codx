Imports prjDatos
Public Class wfmMenuEdit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pUsuario_Edit"
    Private Const spListNombre As String = "pUsuario_List"
    Private sNombreMantenimiento = "Editar Usuario"
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf Redirect
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            CargarValores()
        End If
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            Redirect()
        ElseIf sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bModificar() Then
            RedirectSelf()
        ElseIf sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
    End Sub
#End Region
#Region "Metodos"

    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtCodigo.Text = Session("ID")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                txtNombre.Text = dtDatos.Rows(0).Item(txtNombre.FieldName)
                cbRol.Value = dtDatos.Rows(0).Item(cbRol.FieldName)
                dtFecha.Value = dtDatos.Rows(0).Item(dtFecha.FieldName)
                cbActivo.Checked = dtDatos.Rows(0).Item("Estado")
                cbEmpleado.Value = dtDatos.Rows(0).Item(cbEmpleado.FieldName).ToString
                cbAsignacionAuto.Checked = dtDatos.Rows(0).Item("AsignacionAuto")
                If dtDatos.Rows(0).Item("FotoURL").ToString <> "" Then
                    imgFoto.ImageUrl = dtDatos.Rows(0).Item("FotoURL").ToString
                Else
                    imgFoto.ImageUrl = "~/Fotos/oficial.png"
                End If
                cbCargaTrabajo.Checked = dtDatos.Rows(0).Item("CargaTrabajo")
                cbUbicacion.Value = dtDatos.Rows(0).Item(cbUbicacion.FieldName)
                txtAsignacionOrden.Text = dtDatos.Rows(0).Item(txtAsignacionOrden.FieldName).ToString
            End If
            txtAsignacionOrden.SoloLectura = Not cbAsignacionAuto.Checked
            LoadCarga()
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(spNombre, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Private Sub Redirect()
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Private Sub RedirectSelf()
        Response.Redirect(linkMe.NavigateUrl)
    End Sub

    Public Function dtParametrosBusqueda(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            Dim iUsuario As Integer
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
            dtParametrosBusqueda.Rows.Add("Usuario", iUsuario)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
            dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
            dtParametros.Rows.Add(txtPassword.FieldName, txtPassword.Text)
            dtParametros.Rows.Add(cbRol.FieldName, cbRol.Value)
            dtParametros.Rows.Add(dtFecha.FieldName, dtFecha.Value)
            dtParametros.Rows.Add("Estado", cbActivo.Checked)
            dtParametros.Rows.Add(cbEmpleado.FieldName, cbEmpleado.Value)
            dtParametros.Rows.Add("CargaTrabajo", cbCargaTrabajo.Checked)
            dtParametros.Rows.Add("AsignacionAuto", cbAsignacionAuto.Checked)
            If Me.imgFoto.ImageUrl <> "" Then
                dtParametros.Rows.Add("FotoURL", Me.imgFoto.ImageUrl)
            End If
            dtParametros.Rows.Add(cbUbicacion.FieldName, cbUbicacion.Value)
            dtParametros.Rows.Add(txtAsignacionOrden.FieldName, txtAsignacionOrden.Text)
            If Session("Mensaje") = "Error" Then
                Session("Mensaje") = ""
            End If
        Catch ex As Exception
            Return Nothing
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


    Protected Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        imgFoto.ImageUrl = ""
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        If upFoto.HasFile Then
            Dim filePath As String = _
            Server.MapPath("~/Fotos/" & upFoto.FileName)
            upFoto.SaveAs(filePath)
            imgFoto.ImageUrl = "~/Fotos/" & upFoto.FileName
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Me.cboServicio.SelectedIndex <= 0 Then
            Mensaje("Por favor seleccione un Servicio.")
            Exit Sub
        End If
        If Me.txtPorcentaje.Text = "" Then
            Mensaje("Por favor introduzca un porcentaje para la carga de trabajo.")
            Exit Sub
        End If

        Dim tblParam As DataTable
        tblParam = Funciones.dtDatos.Clone
        tblParam.Rows.Add("IdUsuario", txtNombre.Text)
        tblParam.Rows.Add("IdServicio", cboServicio.Value)
        tblParam.Rows.Add("PorcentajeCarga", Me.txtPorcentaje.Text)

        Dim Ok As Boolean
        Ok = Funciones.Ejecutar("pUsuarioAsignacion_Add", tblParam, sMensaje)
        Session("Mensaje") = sMensaje
        If Ok Then
            LoadCarga()
        End If
    End Sub

    Sub DeleteCarga(sIndex As String)
        Dim iIndex As Integer = -1
        iIndex = CInt(sIndex)
        If iIndex > -1 Then
            Dim tblParam As DataTable
            tblParam = Funciones.dtDatos.Clone
            tblParam.Rows.Add("IdUsuario", txtNombre.Text)
            tblParam.Rows.Add("IdServicio", gvCarga.Rows(iIndex).Cells(1).Text)
            Dim Ok As Boolean
            Ok = Funciones.Ejecutar("pUsuarioAsignacion_Delete", tblParam, sMensaje)
            Session("Mensaje") = sMensaje
            If Ok Then
                LoadCarga()
            End If
        End If
    End Sub
    Private Sub gvCarga_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCarga.RowCommand
        If e.CommandName = "Del" Then
            DeleteCarga(e.CommandArgument.ToString)
        End If
    End Sub

    Sub LoadCarga()
        Try
            Dim tbl As DataTable
            Dim tblParam As DataTable

            tblParam = Funciones.dtDatos.Clone
            tblParam.Rows.Add("IdUsuario", txtNombre.Text)
            tbl = Funciones.Filldatatable("pUsuarioAsignacion_List", tblParam)
            gvCarga.DataSource = tbl
            gvCarga.DataBind()
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Protected Sub cbAsignacionAuto_CheckedChanged(sender As Object, e As EventArgs) Handles cbAsignacionAuto.CheckedChanged
        txtAsignacionOrden.SoloLectura = Not cbAsignacionAuto.Checked
    End Sub
End Class