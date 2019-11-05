Imports prjDatos
Public Class wfmSubServicios_Edit
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private dtDatos As New DataTable
    Private sMensaje As String = ""
    Private Const spNombre As String = "pSubServicios_Edit"
    Private Const spListNombre As String = "pSubServicios_List"
    Private sNombreMantenimiento = "Editar Sub Servicio"
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
#End Region

#Region "Metodos"
    Private Sub CargarValores()
        Try
            If Session("ID") <> "" Then
                txtCodigoSubServicio.Text = Session("ID")
                dtDatos = Funciones.Filldatatable(spListNombre, dtParametrosBusqueda)
                cboServicio.Value = dtDatos.Rows(0).Item(cboServicio.FieldName).ToString
                txtNombre.Text = dtDatos.Rows(0).Item(txtNombre.FieldName)
                txtCodigoSubServicio.Text = dtDatos.Rows(0).Item(txtCodigoSubServicio.FieldName)
                txtValor.Text = dtDatos.Rows(0).Item(txtValor.FieldName)
                cboEstado.Value = dtDatos.Rows(0).Item(cboEstado.FieldName).ToString
                cboMoneda.Value = dtDatos.Rows(0).Item(cboMoneda.FieldName).ToString
                txtReciboFinanzas.Text = dtDatos.Rows(0).Item(txtReciboFinanzas.FieldName)
                txtBeneficiarios.Text = dtDatos.Rows(0).Item(txtBeneficiarios.FieldName)
                tbxLeyesReglamento.Text = dtDatos.Rows(0).Item("LeyesReglametoAsociado")
            End If
        Catch ex As Exception

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
            dtParametrosBusqueda = Funciones.dtDatos.Clone
            dtParametrosBusqueda.Rows.Add(txtCodigoSubServicio.FieldName, txtCodigoSubServicio.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(cboServicio.FieldName, cboServicio.Value)
            dtParametros.Rows.Add(txtCodigoSubServicio.FieldName, txtCodigoSubServicio.Text)
            dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
            dtParametros.Rows.Add(txtValor.FieldName, txtValor.Text)
            dtParametros.Rows.Add(txtBeneficiarios.FieldName, txtBeneficiarios.Text)
            dtParametros.Rows.Add(cboMoneda.FieldName, cboMoneda.Value)
            dtParametros.Rows.Add(cboEstado.FieldName, cboEstado.Value)
            dtParametros.Rows.Add(txtReciboFinanzas.FieldName, txtReciboFinanzas.Text)
            dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
            dtParametros.Rows.Add("LeyesReglametoAsociado", tbxLeyesReglamento.Text)
            If Session("Mensaje") = "Error" Then
                Return Nothing
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

End Class