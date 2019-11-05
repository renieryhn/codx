Imports prjDatos
Public Class wfmDispensaEdicto_List
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private sMensaje As String = ""
    Private Codigo As String = ""
    Dim Ok As Boolean
    Private sNombreBusqueda As String = "pDispensaEdicto_List"
    Private sNombreBorrado As String = "pDispensaEdicto_Delete"
    Private sNombreMantenimiento As String = "Mantenimiento de Dispensas de Edicto"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.btnBuscar_Click, AddressOf btnBuscar_Click
        AddHandler Master.btnNuevo_Click, AddressOf btnNuevo_Click
        AddHandler Master.PreRender, AddressOf Page_PreRender
        AddHandler Master.btnExportar_Click, AddressOf btnExportar_Click
        AddHandler Master.btnImprimir_Click, AddressOf btnImprimir_Click
        Master.Master.m_titulo = sNombreMantenimiento
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
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridView1.Columns(0).Visible = Master.Master.Modificacion
        GridView1.Columns(1).Visible = Master.Master.Borrado
        If Not IsPostBack Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("TipoReporte") = "LDE"
        Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
    End Sub
    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Master.Exportar(GridView1, dtParametrosExportar, "Mantenimiento de Dispensas de Edicto")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
        llenarGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Codigo = GridView1.Rows(e.RowIndex).Cells(2).Text
        Dim s As String = GridView1.Rows(e.RowIndex).ID
        Ok = cFunciones.Ejecutar(sNombreBorrado, dtParametros(Codigo), sMensaje)
        Mensaje(sMensaje)
        If Ok Then
            llenarGrid()
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        If VerificarNumeroAcuerdo() Then
            Response.Redirect(linkNuevo.NavigateUrl)
        End If

    End Sub

    Private Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("ID") = GridView1.Rows(e.NewEditIndex).Cells(2).Text
        Response.Redirect(linkModificar.NavigateUrl)
    End Sub
    Sub ChangeSelectedItemDepto(ByVal sender As Object, ByVal e As EventArgs) Handles cboDepartamento.ComboChangedItem
        Try
            cboMunicipio.LLenarCombo(sender)
        Catch ex As Exception
            '    'excError.RecoveryException(ex)
        End Try
    End Sub
#End Region

#Region "Metodos"
    Private Function VerificarNumeroAcuerdo() As Boolean
        Dim bValido As Boolean = False
        Dim dtNumeroAcuerdo As New DataTable

        dtNumeroAcuerdo = cFunciones.Filldatatable("pAcuerdoEdicto_List", dtParametrosNumeroAcuerdo)
        If dtNumeroAcuerdo.Rows.Count() < 1 Then
            Mensaje("No se ha generado el numero de acuerdo correspondiente a la fecha actual")
        Else
            bValido = True
        End If
        Return bValido
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
    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametrosExportar.Rows.Add("Numero de acuerdo", txtNumAcuerdoEdicto.Text)
            dtParametrosExportar.Rows.Add("Nombre El", txtNombreEl.Text)
            dtParametrosExportar.Rows.Add("Nombre Ella", txtNombreElla.Text)
            dtParametrosExportar.Rows.Add("Número de Identidad de El", txtIdentidadEl.Text)
            dtParametrosExportar.Rows.Add("Número de Identidad de Ella", txtIdentidadElla.Text)
            dtParametrosExportar.Rows.Add("Firma Autorizada", cboFirmaAutorizada.Value)
            dtParametrosExportar.Rows.Add("Departamento", cboDepartamento.Value)
            dtParametrosExportar.Rows.Add("Municipio", cboMunicipio.Value)
            dtParametrosExportar.Rows.Add("Fecha de Registro Hasta", dtcFechaDispensaEdictoHasta.Value)
            dtParametrosExportar.Rows.Add("Fecha de Registro Desde", dtcFechaDispensaEdictoDesde.Value)

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function
    Private Sub llenarGrid()
        GridView1.DataSource = cFunciones.Filldatatable(sNombreBusqueda, dtParametros)
        GridView1.DataBind()
    End Sub

    Private Function dtParametrosNumeroAcuerdo() As DataTable
        Try
            dtParametrosNumeroAcuerdo = cFunciones.dtDatos.Clone
            dtParametrosNumeroAcuerdo.Rows.Add("AcuerdoEdictoActual", 1)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add(txtNumAcuerdoEdicto.FieldName, txtNumAcuerdoEdicto.Text)
            dtParametros.Rows.Add(txtNombreEl.FieldName, txtNombreEl.Text)
            dtParametros.Rows.Add(txtNombreElla.FieldName, txtNombreElla.Text)
            dtParametros.Rows.Add(txtIdentidadEl.FieldName, txtIdentidadEl.Text)
            dtParametros.Rows.Add(txtIdentidadElla.FieldName, txtIdentidadElla.Text)
            dtParametros.Rows.Add(cboFirmaAutorizada.FieldName, cboFirmaAutorizada.Value)
            dtParametros.Rows.Add(cboDepartamento.FieldName, cboDepartamento.Value)
            dtParametros.Rows.Add(cboMunicipio.FieldName, cboMunicipio.Value)
            dtParametros.Rows.Add(dtcFechaDispensaEdictoHasta.FieldName, dtcFechaDispensaEdictoHasta.Value)
            dtParametros.Rows.Add(dtcFechaDispensaEdictoDesde.FieldName, dtcFechaDispensaEdictoDesde.Value)
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
#End Region

End Class