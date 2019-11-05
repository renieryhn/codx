Imports prjDatos
Public Class wfmConstancia_list
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private m_szMensaje = ""
    Private m_szProcedimientoList = "pConstancia_List"
    Private m_szProcedimientoDelete = "pConstancia_Delete"
    Private m_szExpediente = ""
    Private m_szContancia = ""
    Private pageTitle = "Constancias"

#Region "METODOS"

    Public Function getServicio() As String
        Dim retval = ""
        If m_szExpediente <> "" Then
            Dim tokens = m_szExpediente.Split("-")
            retval = tokens(0).ToUpper()
        End If
        Return retval
    End Function

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub

    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(tbExpedientes.FieldName, tbExpedientes.Text)
            dtParametros.Rows.Add(tbNumeroConstancia.FieldName, tbNumeroConstancia.Text)
            dtParametros.Rows.Add(tbNumeroRecibo.FieldName, tbNumeroRecibo.Text)
            dtParametros.Rows.Add(tbUsuario.FieldName, tbUsuario.Text)
        Catch ex As Exception
            'Throw (ex)
            Return Nothing
        End Try
    End Function

    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("IdConstancia", id)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(tbExpedientes.FieldName, tbExpedientes.Text)
            dtParametros.Rows.Add(tbNumeroConstancia.FieldName, tbNumeroConstancia.Text)
            dtParametros.Rows.Add(tbNumeroRecibo.FieldName, tbNumeroRecibo.Text)
            dtParametros.Rows.Add(tbUsuario.FieldName, tbUsuario.Text)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Sub LlenarGridView()
        gvList.DataSource = cFunciones.Filldatatable(m_szProcedimientoList, dtParametros)
        gvList.DataBind()
    End Sub
#End Region

#Region "EVENTOS"

    Private Sub gvList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvList.RowCommand
        If e.CommandName = "Constancia" Then
            Dim rowIndex As Integer = e.CommandArgument
            Constancia(rowIndex)
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvList.RowDeleting
        Dim s As String = gvList.Rows(e.RowIndex).ID
        Dim bOk = cFunciones.Ejecutar(m_szProcedimientoDelete, dtParametros(gvList.Rows(e.RowIndex).Cells(4).Text), m_szMensaje)
        Mensaje(m_szMensaje)
        If bOk Then
            LlenarGridView()
        End If
    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvList.RowEditing
        Dim index = e.NewEditIndex
        Session("ID") = gvList.Rows(index).Cells(4).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        LlenarGridView()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkNuevo.NavigateUrl)
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Master.Exportar(gvList, dtParametrosExportar, "Mantenimiento Constancia")
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'siempre falso por varios
        gvList.Columns(0).Visible = False
        gvList.Columns(1).Visible = Master.Master.Modificacion
        gvList.Columns(2).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            LlenarGridView()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = pageTitle

        m_szMensaje = Session("Mensaje")
        If m_szMensaje <> "" Then
            Mensaje(m_szMensaje)
        End If
    End Sub
#End Region

    Public Function getServicio(sExpediente As String) As String
        Dim retval = ""
        If sExpediente <> "" Then
            Dim tokens = sExpediente.Split("-")
            retval = tokens(0).ToUpper
        End If
        Return retval
    End Function


    Sub Constancia(iRow As Integer)
        Try
            'TODO: demostrar el reporte.
            m_szExpediente = gvList.Rows(iRow).Cells(5).Text
            m_szContancia = gvList.Rows(iRow).Cells(4).Text
            Session("TipoReporte") = getServicio(m_szExpediente)
            Session("id") = m_szContancia
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('YourURL','_newtab');", True)
            Response.Redirect("~/Reportes/wfrmRepConstancias.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class