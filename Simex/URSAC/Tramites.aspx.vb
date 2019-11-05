Imports prjDatos
Imports Telerik.Web.UI

Public Class Tramites
    Inherits System.Web.UI.Page
    Dim cFunciones As New funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                RadDropDownList1.SelectedValue = Now.Month
                CargarOficiales()
                rGrid.EditIndexes.Add(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rTab_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles rTab.TabClick
        Try
            Session("IdEstado") = e.Tab.PageViewID
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            If cboEmpleado.SelectedText = "" Then
                lblMSG.Visible = True
                lblMSG.Text = "Seleccione un Oficial Jurído para asignar el trámite"
                Exit Sub
            End If
            CambioEstado(2)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Try
            CambioEstado(5)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Try
            CambioEstado(6)
        Catch ex As Exception

        End Try
    End Sub

    Sub CambioEstado(idEstado As Integer)
        lblMSG.Visible = False
        Try
            Dim item As Telerik.Web.UI.GridItem
            Dim i As Integer
            Dim idSolicitud As Integer
            For i = 0 To Me.rGrid.Items.Count - 1
                If Me.rGrid.Items(i).Selected Then
                    idSolicitud = Me.rGrid.SelectedValues(i)
                    If idEstado = 2 Then
                        Dim idOficial As Integer = 0
                        Dim sNombre As String = ""
                        idOficial = cboEmpleado.SelectedValue
                        sNombre = cboEmpleado.SelectedText
                        Dim t As New dsTramitesTableAdapters.SolicitudesTableAdapter
                        t.UpdateAsignar(Now.Date, idOficial, sNombre, idEstado, idSolicitud)
                    Else
                        Dim t As New dsTramitesTableAdapters.SolicitudesTableAdapter
                        t.UpdateEstado(idEstado, idSolicitud)
                    End If
                End If
            Next
            rGrid.DataBind()
        Catch ex As Exception

        End Try
    End Sub


#Region "Carga"
    Private Sub CargarOficiales()
        Try
            Dim tblData As DataTable = cFunciones.Filldatatable("pUsuario_List", dtParametrosEmpleado)
            With cboEmpleado
                .DataFieldID = "IdEmpleado"
                .DataValueField = "IdEmpleado"
                .DataTextField = "NombreEmpleado"
                .DataSource = tblData
                .DataBind()
            End With
            cboEmpleado.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Function dtParametrosEmpleado() As DataTable
        Try
            dtParametrosEmpleado = cFunciones.dtDatos.Clone
            dtParametrosEmpleado.Rows.Add("Usuario", 0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

    Private Sub rGrid_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rGrid.ItemCommand
        Try
            'If e.CommandName = "RowClick" Then
            '    Dim item As GridEditableItem = TryCast(e.Item, GridEditableItem)
            '    Dim chk As Object = item.Cells(0).Controls(0)
            '    chk.text = "1"
            '    'If (TypeOf item Is GridCheckBoxColumn) Then
            '    '    fileId = CInt(item.GetDataKeyValue("EmployeeID"))
            '    'End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

End Class