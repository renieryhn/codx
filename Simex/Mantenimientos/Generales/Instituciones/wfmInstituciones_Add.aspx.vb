Imports prjDatos
Public Class wfmInstituciones_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private sMensaje As String = ""
    Private Const spNombre As String = "pInstituciones_Add"
    Private sNombreMantenimiento = "Agregar Institución"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = sNombreMantenimiento
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
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
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMe.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
#End Region
#Region "Metodos"
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Dim nuevo As Integer
        Ok = Funciones.Ejecutar(spNombre, dtParametros, "idNuevo", nuevo, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Public Function dtParametros(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            dtParametros.Rows.Add(txtRTN.FieldName, txtRTN.Text)
            dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
            dtParametros.Rows.Add(txtSiglas.FieldName, txtSiglas.Text)
            dtParametros.Rows.Add(cboPais.FieldName, cboPais.Value)
            dtParametros.Rows.Add(txtTelefono1.FieldName, txtTelefono1.Text)
            dtParametros.Rows.Add(txtTelefono2.FieldName, txtTelefono2.Text)
            dtParametros.Rows.Add(txtNumFax.FieldName, txtNumFax.Text)
            dtParametros.Rows.Add(txtDireccion1.FieldName, txtDireccion1.Text)
            dtParametros.Rows.Add(txtDireccion2.FieldName, txtDireccion2.Text)
            dtParametros.Rows.Add(txtNombreContacto.FieldName, txtNombreContacto.Text)
            dtParametros.Rows.Add(txtExtensionTelefonica.FieldName, txtExtensionTelefonica.Text)
            dtParametros.Rows.Add(txtTelMovilContacto.FieldName, txtTelMovilContacto.Text)
            dtParametros.Rows.Add(txtCargoContacto.FieldName, txtCargoContacto.Text)
            dtParametros.Rows.Add(txtEmailContacto.FieldName, txtEmailContacto.Text)
            dtParametros.Rows.Add(txtSitioWEB.FieldName, txtSitioWEB.Text)
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