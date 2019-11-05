Imports prjDatos

Public Class IngresosMensuales
    Inherits System.Web.UI.Page
    Private Const szReportMensual = "pReporteMensual"
    Dim cFunciones As New funciones

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If gvReporte.Columns.Count > 0 Then
            For i = gvReporte.Columns.Count - 1 To 0 Step -1
                gvReporte.Columns.RemoveAt(i)
            Next
        End If
        If Not "" = dcFechaInicio.Value AndAlso Not "" = dcFechafin.Value AndAlso dcFechaInicio.Value < dcFechafin.Value AndAlso dcFechafin.Value.ToString.Substring(0, 4) = dcFechaInicio.Value.ToString.Substring(0, 4) Then
            mostrarReporteMensual(rbSubservicio.Checked, dcFechaInicio.Value, dcFechafin.Value)
        Else
            Mensaje("Ingrese fechas de el mismo año y verifique que la fecha fin sea mayor a la de inicio.")
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not "" = dcFechaInicio.Value AndAlso Not "" = dcFechafin.Value AndAlso dcFechaInicio.Value < dcFechafin.Value AndAlso Date.Parse(dcFechafin.Value).Year = Date.Parse(dcFechaInicio.Value).Year Then
            Dim dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("Fecha Inicio", dcFechaInicio.Value)
            dtParametros.Rows.Add("Fecha Fin", dcFechafin.Value)
            gvReporte.AllowPaging = False
            Master.Exportar(gvReporte, dtParametros, "Reporte Mensual")
        Else
            Mensaje("Ingrese fechas de el mismo año y verifique que la fecha fin sea mayor a la de inicio.")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Master.setNuevoVisible = False

        AddHandler Master.btnBuscar_Click, AddressOf btnAceptar_Click
        AddHandler Master.btnExportar_Click, AddressOf btnCancelar_Click
        If Session("Mensaje") <> "" And Session("Mensaje") <> "Error" Then
            Mensaje(Session("Mensaje"))
        End If
    End Sub

    Private Sub mostrarReporteMensual(ByVal bPorSubServicio As Boolean, ByVal szFechaInicio As String, ByVal szFechaFin As String)
        Dim dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("tipo", bPorSubServicio)
        dtParametros.Rows.Add("FechaDesde", szFechaInicio)
        dtParametros.Rows.Add("FechaHasta", szFechaFin)
        Dim Data = cFunciones.Filldatatable("pReporteMensual", dtParametros)
        Dim meses = New SortedList
        Dim OficinaOSubServicio = New SortedList
        Dim superDataStructure = New Hashtable
        If bPorSubServicio Then
            For Each row In Data.Rows
                If Not OficinaOSubServicio.ContainsKey(row.item("idSubServicio")) Then
                    OficinaOSubServicio.Add(row.item("idSubServicio"), row.item("Nombre"))
                    superDataStructure.Add(row.item("idSubServicio"), New Hashtable)
                End If
                If Not meses.ContainsKey(row.item("column1")) Then
                    meses.Add(row.item("column1"), row.item("mes"))
                End If
                superDataStructure.Item(row.item("idSubServicio")).Add(row.item("column1"), row.item("totalMes"))
            Next
        Else
            For Each row In Data.Rows
                If Not OficinaOSubServicio.ContainsKey(row.item("idOficina")) Then
                    OficinaOSubServicio.Add(row.item("idOficina"), row.item("Nombre"))
                    superDataStructure.Add(row.item("idOficina"), New Hashtable)
                End If
                If Not meses.ContainsKey(row.item("column1")) Then
                    meses.Add(row.item("column1"), row.item("mes"))
                End If
                superDataStructure.Item(row.item("idOficina")).Add(row.item("column1"), row.item("totalMes"))
            Next
        End If
        Dim Reporte = New DataTable
        If bPorSubServicio Then
            Reporte.Columns.Add("Subservicio")
            For i = 0 To meses.Count - 1
                Reporte.Columns.Add(meses.Item(meses.GetKey(i)))
            Next
            Reporte.Columns.Add("Total Subservicio")
            For Each osKey In OficinaOSubServicio.Keys
                Dim row = Reporte.NewRow
                row.Item("Subservicio") = OficinaOSubServicio.Item(osKey)
                Dim totalRow = 0.0
                For Each mesKey In meses.Keys
                    Dim value = 0.0
                    If superDataStructure.ContainsKey(osKey) Then
                        If superDataStructure.Item(osKey).ContainsKey(mesKey) Then
                            value = superDataStructure.Item(osKey).Item(mesKey)
                        End If
                    End If
                    totalRow += value
                    row.Item(meses.Item(mesKey)) = value
                Next
                row.Item("Total Subservicio") = totalRow
                Reporte.Rows.Add(row)
            Next
        Else
            Reporte.Columns.Add("Oficina")
            For i = 0 To meses.Count - 1
                Reporte.Columns.Add(meses.Item(meses.GetKey(i)))
            Next
            Reporte.Columns.Add("Total Oficina")
            For Each osKey In OficinaOSubServicio.Keys
                Dim row = Reporte.NewRow
                row.Item("Oficina") = OficinaOSubServicio.Item(osKey)
                Dim totalRow = 0.0
                For Each mesKey In meses.Keys
                    Dim value = 0.0
                    If superDataStructure.ContainsKey(osKey) Then
                        If superDataStructure.Item(osKey).ContainsKey(mesKey) Then
                            value = superDataStructure.Item(osKey).Item(mesKey)
                        End If
                    End If
                    totalRow += value
                    row.Item(meses.Item(mesKey)) = value
                Next
                row.Item("Total Oficina") = totalRow
                Reporte.Rows.Add(row)
            Next
        End If
        For Each col In Reporte.Columns
            Dim gvcol = New BoundField()
            gvcol.DataField = col.ColumnName
            gvcol.HeaderText = col.ColumnName
            gvReporte.Columns.Add(gvcol)
        Next
        gvReporte.DataSource = Reporte
        gvReporte.DataBind()
        gvReporte.Visible = True
    End Sub

End Class