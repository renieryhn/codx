Public Class wfmExpedienteEncabezado
    Inherits System.Web.UI.Page
    Dim cDatos As New prjDatos.funciones
    Dim bbPin As String
    Dim idExpediente, sMensaje As String
    Dim spDetalleExpediente As String = "pDetalleExpedienteBB_List"
    Dim dtDatos As New DataTable
    Dim iContFilas As Integer = 0
    Dim iContColumnas As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bbPin = Request.QueryString("bbPin")
        idExpediente = Request.QueryString("idExpediente")
        dtDatos = cDatos.Filldatatable(spDetalleExpediente, dtParametros, sMensaje)
        For Me.iContFilas = 0 To dtDatos.Rows.Count - 1
            For Me.iContColumnas = 0 To dtDatos.Columns.Count - 1
                lblDatos.Text = lblDatos.Text & dtDatos.Rows(iContFilas).Item(iContColumnas)
                If Not (iContFilas = dtDatos.Rows.Count - 1 And iContColumnas = dtDatos.Columns.Count - 1) Then
                    lblDatos.Text = lblDatos.Text & "|"
                End If
            Next
        Next
    End Sub
    Private Function dtParametros() As DataTable
        dtParametros = cDatos.dtDatos.Clone
        dtParametros.Rows.Add("bbPin", bbPin)
        dtParametros.Rows.Add("idExpediente", idExpediente)
    End Function
End Class