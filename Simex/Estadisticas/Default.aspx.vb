Imports System.Web.DynamicData
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports prjDatos
Imports Telerik.Web.UI
Imports System.Security.Permissions



Class _EstadisticasDefault
    Inherits Page
    Private bURL As String = ""
    Private cMensaje As New Mensaje
    Dim cFunciones As New funciones
    Private sMensaje As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If IsPostBack Then
            If Not IsNothing(Session("BackURL")) Then
                bURL = Session("BackURL").ToString()
            End If
        Else
            LoadInitialData()
            AddTab("Expedientes")
            AddPageView(rTab.FindTabByText("Expedientes"))
            AddTab("Dictamenes")
            AddPageView(rTab.FindTabByText("Dictamenes"))
            AddTab("Resoluciones")
            AddPageView(rTab.FindTabByText("Resoluciones"))
        End If

        sMensaje = Session("Mensaje")
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If

    End Sub
    Private Sub AddTab(ByVal tabName As String)
        Dim tab As RadTab = New RadTab
        tab.Text = tabName
        rTab.Tabs.Add(tab)
    End Sub
    Private Sub AddPageView(ByVal tab As RadTab)
        Dim pageView As RadPageView = New RadPageView
        pageView.ID = tab.Text
        RadMultiPage1.PageViews.Add(pageView)
        tab.PageViewID = pageView.ID
    End Sub
    Protected Sub RadMultiPage1_PageViewCreated(ByVal sender As Object, ByVal e As RadMultiPageEventArgs) Handles RadMultiPage1.PageViewCreated
        Dim userControlName As String = e.PageView.ID & ".ascx"
        Dim userControl As Control = Page.LoadControl(userControlName)
        userControl.ID = e.PageView.ID & "_userControl"
        e.PageView.Controls.Add(userControl)
    End Sub
    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As RadTabStripEventArgs) Handles rTab.TabClick
        AddPageView(e.Tab)
        e.Tab.PageView.Selected = True
    End Sub

    Sub LoadInitialData()
        Try
            Dim iPageMax As Integer = 0
            Dim dtParam As DataTable
            dtParam = cFunciones.dtDatos.Clone
            dtParam.Rows.Add("StartIndex", 0)
            dtParam.Rows.Add("EndIndex", 1000000)
            Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_ListByIndex", dtParam)
            If (tbl.Rows.Count Mod 5) = 0 Then
                iPageMax = (tbl.Rows.Count / 5) - 1
            Else
                iPageMax = (tbl.Rows.Count / 5)
            End If
            PagerSlider.MinimumValue = 0
            PagerSlider.MaximumValue = iPageMax

            rList.DataSource = tbl
            rList.DataBind()
            rList.SelectedIndexes.Add(0)

            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim dayDiff2 As Integer = DayOfWeek.Friday - today.DayOfWeek
            Dim monday As Date = today.AddDays(-dayDiff)
            Dim friday As Date = today.AddDays(dayDiff2)

            fDesde.SelectedDate = monday
            fHasta.SelectedDate = friday
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub LoadContent()
        Try

            Dim idEmpleado As Integer = 0
            idEmpleado = rList.SelectedValue.ToString()
            Dim dtParam As DataTable = cFunciones.dtDatos.Clone
            dtParam.Rows.Add("id", idEmpleado)
            dtParam.Rows.Add("Usuario", 0)
            Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_List", dtParam)
            If Not tbl Is Nothing Then
                txtNombre.Text = tbl.Rows(0).Item("NombreEmpleado").ToString
                PicEmpleado.ImageUrl = tbl.Rows(0).Item("FotoURL").ToString

                Dim dtParametrosCargaTrabajo As DataTable
                dtParametrosCargaTrabajo = cFunciones.dtDatos.Clone
                dtParametrosCargaTrabajo.Rows.Add("idUsuario", tbl.Rows(0).Item("Nombre").ToString)
                Dim tCargaTrabajo As DataTable = cFunciones.Filldatatable("pCargaTrabajo_List", dtParametrosCargaTrabajo, sMensaje)

                Dim val As Decimal = tCargaTrabajo.Rows(0).Item("totalSinRecibir")
                If val > 500 Then
                    RadRadialGauge1.Scale.Max = val
                Else
                    RadRadialGauge1.Scale.Max = 500
                End If
                RadRadialGauge1.Pointer.Value = val
                Dim val2 As Decimal = tCargaTrabajo.Rows(0).Item("totalSinEnviar")
                If val2 > 500 Then
                    RadRadialGauge2.Scale.Max = val2
                Else
                    RadRadialGauge2.Scale.Max = 500
                End If

                RadRadialGauge2.Pointer.Value = val2
                Me.txtSinRecibir.Text = "Sin Recibir (" + val.ToString + ")"
                txtSinEnviar.Text = "Sin Enviar (" + val2.ToString + ")"
                upUser.Update()
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub
    Function GetSumTreeValues(intVal As Integer, tCargaTrabajo As DataTable) As Integer
        Dim i As Integer
        Dim dValor As Double = 0
        Dim sCampo As String = ""
        Select Case intVal
            Case 1
                sCampo = "SinRecibir"
            Case 2
                sCampo = "SinEnviar"
            Case 3
                sCampo = "EnviadoSinRecibir"
        End Select
        If Not tCargaTrabajo Is Nothing Then
            For i = 0 To tCargaTrabajo.Rows.Count - 1
                dValor += tCargaTrabajo.Rows(i).Item(sCampo)
            Next
        Else
            dValor = 0
        End If

        Return dValor
    End Function

    Sub CargarDatos()
        Try
            Dim tbl As DataTable = cFunciones.Filldatatable("pUsuario_ListByIndex", dtParametros)
            rList.DataSource = tbl
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Function dtParametros() As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("StartIndex", (rList.CurrentPageIndex * 5) + 1)
            dtParametros.Rows.Add("EndIndex", ((rList.CurrentPageIndex * 5) + 5))
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Protected Sub PagerSlider_ValueChanged(sender As Object, e As EventArgs) Handles PagerSlider.ValueChanged
        Try
            Dim newValue As String = (TryCast(sender, RadSlider)).Value.ToString()
            rList.CurrentPageIndex = newValue
            rList.Items(0).FireCommandEvent(RadListView.PageCommandName, newValue)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub l_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles rList.NeedDataSource
        CargarDatos()
    End Sub

    Protected Sub rList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rList.SelectedIndexChanged
        Session("idEmpleado") = CInt(rList.SelectedValue.ToString())
        LoadContent()
        'ScriptManager.RegisterStartupScript(Page, typeof(Page), "hide", "HideLoadingPanel()", true);
    End Sub
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
End Class
