Imports prjDatos
Public Class wfmPropiedadesExpedientePublico
    Inherits System.Web.UI.Page
#Region "Declaraciones"
    Dim cFunciones As New funciones
    Private sNombreBusqueda As String = "pDetalleExpediente_List"
    Dim sMensaje As String = ""
    Private Codigo As String = ""
    Dim dtDatos As DataTable
    Dim ok As Boolean
    Public Event ComboChangedItem(ByVal sender As Object, ByVal e As EventArgs)
#End Region
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender        
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub   
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Master.idExpediente <> "" Then
            llenarGrid()
        Else
            Session("Mensaje") = "El Expediente no ha sido encontrado, favor intente de nuevo"

            Response.Redirect("~/Registro/Expediente/Publico/wfmDetExpedientePublico.aspx")
        End If
    End Sub
#End Region
#Region "Metodos"
    
    Private Sub llenarGrid()
        If Master.idExpediente <> "" Then
            dtDatos = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
            GridView1.DataSource = dtDatos
            GridView1.DataBind()
        End If

    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idExpediente", Master.idExpediente)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    
    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("ID", id)
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            'dtParametrosExportar.Rows.Add("Nombre", txtNombre.Text)
            'dtParametrosExportar.Rows.Add("Rol", cbRol.Text)
            'dtParametrosExportar.Rows.Add("Ubicación", cbUbicacion.Text)
        Catch ex As Exception
            Throw (ex)
            Return Nothing
        End Try
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
        Session("Mensaje") = ""
    End Sub
#End Region
End Class