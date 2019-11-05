Imports prjDatos
Public Class Comentarios
    Inherits System.Web.UI.UserControl
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Private sNombreNuevoComentario As String = "pDetalleExpediente_Edit"
#Region "Eventos"
    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        bModificar()
        
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        
    End Sub

#End Region
#Region "Metodos"
    Private Function bModificar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(sNombreNuevoComentario, dtParametrosComentario, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function
    Private Function dtParametrosComentario() As DataTable
        Try
            dtParametrosComentario = cFunciones.dtDatos.Clone
            dtParametrosComentario.Rows.Add("idExpediente", Session("idExpediente"))
            dtParametrosComentario.Rows.Add("Comentario", txtComentarios.Text)
            dtParametrosComentario.Rows.Add("idusuario", Session("idUsuario"))
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mpeAgregarComentario.Show()
    End Sub

End Class