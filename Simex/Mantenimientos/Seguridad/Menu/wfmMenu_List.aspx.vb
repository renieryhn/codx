Imports prjDatos
Public Class wfmMenuList
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pMenu_List"
    Private sNombreBorrado As String = "pMenu_Delete"
    Private sNombreMantenimiento = "Mantenimiento de Menús"
    
#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        sMensaje = Session("Mensaje")
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If

        If Not IsPostBack Then
            GetSetPreBusqueda(False)
            llenarGrid()
        End If
    End Sub
    Protected Sub PageChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        llenarGrid()
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Menús")
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        GetSetPreBusqueda(True)
        llenarGrid()
    End Sub
    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(2).Text
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
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(2).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
#End Region

#Region "Metodos"
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
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametrosExportar.Rows.Add("Nombre", txtDescripcion.Text)
            dtParametrosExportar.Rows.Add("Menu Principal", cbMenuPrincipal.Text)
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
            dtParametros.Rows.Add(txtDescripcion.FieldName, txtDescripcion.Text)
            dtParametros.Rows.Add(cbMenuPrincipal.FieldName, cbMenuPrincipal.Value)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Function dtParametros(ByVal id As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("ID", id)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub GetSetPreBusqueda(bReset As Boolean)
        Dim sVariableName As String = "PB_Menu"

        If Not IsNothing(Session(sVariableName)) Then
            If txtDescripcion.Text <> "" Then
                If txtDescripcion.Text <> Session(sVariableName) Then
                    Session(sVariableName) = txtDescripcion.Text
                End If
            Else
                If bReset Then
                    Session(sVariableName) = txtDescripcion.Text
                Else
                    txtDescripcion.Text = Session(sVariableName)
                End If
            End If
        Else
            If txtDescripcion.Text <> "" Then
                Session(sVariableName) = txtDescripcion.Text
            End If
        End If
    End Sub
#End Region

    
End Class