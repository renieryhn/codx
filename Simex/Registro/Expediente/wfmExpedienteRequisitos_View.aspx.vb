Imports prjDatos
Imports System.Data.SqlClient
Public Class ExpedienteRequisitos

    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones
    Private szListRequisitosPorExpediente As String = "pExpedienteRequisito_List"
    Private szUpdateRequisito As String = "pExpedientesRequisitos_Edit"
    Private szUsarioList As String = "pUsuario_List"
    Private sNombreMantenimiento As String = "Requisitos de Expediente"
    Private m_DataTable As DataTable
    Private m_bValorArray() As Boolean

#Region "Metodos"

    Private Function dtParametrosExportar() As DataTable
        Try
            dtParametrosExportar = cFunciones.dtDatos.Clone
            dtParametrosExportar.Rows.Add("IdExpediente", Master.idExpediente)
            dtParametrosExportar.Rows.Add("Subservicio", Master.SubServicio)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function dtParametrosUpdate(ByVal valor As Boolean, ByVal idRequisito As Integer, ByVal idUsuario As Integer) As DataTable
        Try
            dtParametrosUpdate = cFunciones.dtDatos.Clone
            dtParametrosUpdate.Rows.Add("IdExpediente", Master.idExpediente)
            dtParametrosUpdate.Rows.Add("Valor", valor)
            dtParametrosUpdate.Rows.Add("IdRequisito", idRequisito)
            dtParametrosUpdate.Rows.Add("IdUsuario", idUsuario)
        Catch ex As Exception
            Throw (ex)
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

    Private Function GetUsarioIdFromName(ByRef szMessage As String) As Integer
        Dim pSendDataTable = cFunciones.dtDatos.Clone
        pSendDataTable.Rows.Add("Nombre", Master.Master.Usuario)
        pSendDataTable.Rows.Add("Usuario", 0)
        Dim pReciveDataTable = cFunciones.Filldatatable(szUsarioList, pSendDataTable, szMessage)
        If Not IsNothing(pReciveDataTable) Then
            If pReciveDataTable.Rows.Count > 0 Then
                Dim IdUsuario As Integer = pReciveDataTable.Rows.Item(0).Item(0)
                Return IdUsuario
            End If
        End If
    End Function

    Private Sub ActualizarRequisitosDeExpedientes()
        'para cada objeto verificar que hay un cambio y si lo hay llamar al procedimiento almacenado.
        Dim trans As SqlTransaction = Nothing
        Dim szMessage As String = ""
        Dim bError = False
        LoadInformacionDelServidor()
        Dim IdUsuario = GetUsarioIdFromName(szMessage)
        Try
            If ExpedienteRequisitosRepeater.Items.Count > 0 Then
                For Each Fila As RepeaterItem In ExpedienteRequisitosRepeater.Items
                    Dim RequisitoIDlbl As Label
                    Dim szRequisitoID As String
                    RequisitoIDlbl = Fila.FindControl("IdRequisito")
                    szRequisitoID = RequisitoIDlbl.Text
                    Dim ValorChkbx As CheckBox
                    ValorChkbx = TryCast(Fila.FindControl("Valor"), CheckBox)
                    If ValorChkbx.Checked <> m_bValorArray(Fila.ItemIndex) Then
                        cFunciones.Ejecutar(szUpdateRequisito, dtParametrosUpdate(ValorChkbx.Checked, szRequisitoID, IdUsuario), trans, szMessage)
                    End If
                Next
                'pop up si la consulta fue hecha con exito o no
                'null check
                trans.Commit()
                Mensaje(szMessage)
            End If
        Catch ex As SqlException
            trans.Rollback()
            Mensaje(szMessage)
        End Try
    End Sub

    Sub LoadInformacionDelServidor()
        m_DataTable = cFunciones.Filldatatable(szListRequisitosPorExpediente, dtParametrosExportar)
        If Not m_DataTable Is Nothing Then
            Dim tempBoolArray(m_DataTable.Rows.Count - 1) As Boolean
            m_bValorArray = tempBoolArray.Clone()
            For i = 0 To m_DataTable.Rows.Count - 1 Step 1
                m_bValorArray(i) = m_DataTable.Rows.Item(i).Item(2)
            Next
        End If
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Not IsPostBack Then
            LoadInformacionDelServidor()
            ExpedienteRequisitosRepeater.DataSource = m_DataTable
            ExpedienteRequisitosRepeater.DataBind()
        End If
        
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ActualizarRequisitosDeExpedientes()
        'redireccionar a la pagina estado del expediente
        Response.Redirect(HyperLink1.NavigateUrl)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        'redireccionar a la pagina estado del expediente
        Response.Redirect(HyperLink1.NavigateUrl)
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Response.Redirect("~/Reportes/ExReporter.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
    End Sub
#End Region



End Class