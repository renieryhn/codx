Imports prjDatos
Public Class wfmAcreditaciones_List
    Inherits System.Web.UI.Page

    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pAcreditaciones_List"
    Private sNombreBorrado As String = "pAcreditaciones_Delete"
    Private nombre = "Acreditaciones"
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        Master.Master.m_titulo = nombre
        sMensaje = Session("Mensaje")
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub
    Private Sub gvList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Constancia" Then
            Dim rowIndex As Integer = e.CommandArgument
            Reporte(rowIndex)
        End If
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.AllowPaging = False
        llenarGrid()
        Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Acreditaciones")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(3).Text
        Dim s As String = GridView1.Rows(e.RowIndex).ID
        Ok = cFunciones.Ejecutar(sNombreBorrado, dtParametros(Codigo), sMensaje)
        Mensaje(sMensaje)
        If Ok Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkNuevo.NavigateUrl)
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(3).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
#End Region

#Region "Metodos"
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametrosExportar.Rows.Add("Nombre", txtDictamen.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub llenarGrid()
        GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
        GridView1.DataBind()
    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtDictamen.FieldName, txtDictamen.Text)
            dtParametros.Rows.Add(txtAsociacion.FieldName, txtAsociacion.Text)
            dtParametros.Rows.Add(txtRepresentante.FieldName, txtRepresentante.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("ID", id)
            '    dtParametros.Rows.Add("idRol", idRol)
            '    dtParametros.Rows.Add("idEstado", idEstado)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
#End Region


    Sub Reporte(iRow As Integer)
        Try
            iRow = iRow - (GridView1.PageIndex * 12)
            If iRow < 0 Then
                iRow = 0
            End If
            Dim sID As String = Me.GridView1.Rows(iRow).Cells(3).Text
            Session("IdAcre") = sID
            Response.Redirect("~/Otros/Acreditaciones/AcreditacionRep.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class