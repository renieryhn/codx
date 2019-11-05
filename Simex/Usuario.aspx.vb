Imports System.Web.DynamicData
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports prjDatos
Imports System.IO

Class _Usuario
    Inherits Page
    Private bURL As String = ""
    Private cMensaje As New Mensaje
    Dim cFunciones As New funciones
    Private Const spEditarNombre As String = "pUsuario_EditProfile"
    Private sMensaje As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If IsPostBack Then
            If Not IsNothing(Session("BackURL")) Then
                bURL = Session("BackURL").ToString()
            End If
        Else
            txtNombre.Text = Session("Usuario")
            CargarDatos()
        End If
    End Sub

    Protected Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        If txtPassword.Text <> txtPassword0.Text Then
            cMensaje.Show("La contraseña no coincide, por favor asegurese que está bien escrita.")
            Exit Sub
        End If
        If bModificar() Then
            Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
        End If
    End Sub

    Protected Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        If (bURL <> "") Then
            Response.Redirect(bURL)
        Else
            Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")
        End If
    End Sub

    Sub CargarDatos()
        Try
            Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_List", dtParametros)
            If tbl.Rows.Count >= 0 Then
                txtCodigo.Text = tbl.Rows(0).Item("id").ToString
                txtEmail1.Text = tbl.Rows(0).Item("Email1").ToString
                txtPassword.Text = tbl.Rows(0).Item("PWD").ToString
                txtPassword0.Text = tbl.Rows(0).Item("PWD").ToString
                If tbl.Rows(0).Item("FotoURL").ToString <> "" Then
                    imgFoto.ImageUrl = tbl.Rows(0).Item("FotoURL").ToString
                Else
                    imgFoto.ImageUrl = "~/Fotos/oficial.png"
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtNombre.FieldName, txtNombre.Text)
            dtParametros.Rows.Add("Usuario", 0)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(spEditarNombre, dtParametrosEditar, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Public Function dtParametrosEditar(Optional ByVal bInactivo As Boolean = False) As DataTable
        Try
            dtParametrosEditar = cFunciones.dtDatos.Clone
            dtParametrosEditar.Rows.Add(txtCodigo.FieldName, txtCodigo.Text)
            dtParametrosEditar.Rows.Add("Password", txtPassword.Text)
            dtParametrosEditar.Rows.Add(txtEmail1.FieldName, txtEmail1.Text)
            If Me.imgFoto.ImageUrl <> "" Then
                dtParametrosEditar.Rows.Add("FotoURL", Me.imgFoto.ImageUrl)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Protected Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        imgFoto.ImageUrl = ""
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try
            If upFoto.HasFile Then
                Dim sExt As String = System.IO.Path.GetExtension(upFoto.PostedFile.FileName)
                Dim filePath As String = _
                Server.MapPath("~/Fotos/" & Session("Usuario") & sExt)
                If File.Exists(filePath) Then
                    File.Delete(filePath)
                End If
                upFoto.SaveAs(filePath)
                imgFoto.ImageUrl = "~/Fotos/" & Session("Usuario") & sExt
                imgFoto.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
