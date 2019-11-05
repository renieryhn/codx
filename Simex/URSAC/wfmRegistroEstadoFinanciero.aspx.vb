Imports prjDatos
Public Class wfmRegistroEstadoFinanciero
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = "pUR_RegistroEstadoFinanciero_List"
    Dim m_sAgregarRegistro = "pUR_RegistroEstadoFinanciero_Add"
    Dim m_sEliminarRegistro = "pUR_RegistroEstadoFinanciero_Delete"
    Private sNombreMantenimiento As String = "Registro de Estados Financieros"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        gvDatos.Columns(0).Visible = Master.Master.Borrado
        LlenarGrid()
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
            Session("Mensaje") = ""
        End If
        txtnRegistro.Text = Session("IdRegistro")
    End Sub
    Sub LlenarGrid()
        If Master.NumRegistro <> "" Then
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("NumRegistro", Master.NumRegistro.ToString)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable(m_sListaDatos, prams, sMensaje)
            gvDatos.DataSource = dtDatos
            gvDatos.DataBind()
        End If
    End Sub
    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
        Session("Mensaje") = ""
    End Sub

    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDatos.RowDeleting
        Dim Codigo As String = Me.gvDatos.Rows(e.RowIndex).Cells(1).Text
        Dim OK As Boolean = False
        If Master.Master.Borrado Then
            OK = cFunciones.Ejecutar(m_sEliminarRegistro, dtParametros(Codigo), sMensaje)
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            If OK Then
                LlenarGrid()
            End If
        Else
            Mensaje("No tiene permisos para eliminar este registro.")
        End If
    End Sub

    Protected Sub btnAddRegistro_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        If bValidar() Then
            If bInsertar() Then
                dtcFechaDesde.Value = ""
                dtcFechaHasta.Value = ""
                LlenarGrid()
            End If
        Else
            mpeFormulario.Show()
        End If
    End Sub
    Function bValidar() As Boolean
        Dim bValido As Boolean = True
        sMensaje = ""
        If Not Master.Master.Alta Then
            sMensaje += "No tiene permisos para modificar este registro." + vbCrLf
            bValido = False
        End If
        If IsNothing(dtcFechaDesde.Value) Then
            sMensaje += "La fecha de Inicio del Período es requerida." + vbCrLf
            bValido = False
        Else
            If dtcFechaDesde.Value.ToString = "" Then
                sMensaje += "La fecha de Inicio del Período es requerida." + vbCrLf
                bValido = False
            End If
        End If
        If IsNothing(dtcFechaHasta.Value) Then
            sMensaje += "La fecha Final del Período es requerida." + vbCrLf
            bValido = False
        Else
            If dtcFechaHasta.Value.ToString = "" Then
                sMensaje += "La fecha Final del Período es requerida." + vbCrLf
                bValido = False
            End If
        End If
        If Not IsNothing(dtcFechaDesde.Value) And Not IsNothing(dtcFechaHasta.Value) Then
            If dtcFechaDesde.Value >= dtcFechaHasta.Value Then
                sMensaje += "La fecha Final del Período debe ser mayor que la Fecha Inicial." + vbCrLf
                bValido = False
            Else
                Dim dtDatos As DataTable = Me.gvDatos.DataSource
                Dim prams = cFunciones.dtDatos.Clone
                prams.Rows.Add("NumRegistro", Master.NumRegistro.ToString)
                prams.Rows.Add("FechaInicial", dtcFechaDesde.Value)
                prams.Rows.Add("FechaFinal", dtcFechaHasta.Value)
                dtDatos = cFunciones.Filldatatable(m_sListaDatos, prams, sMensaje)
                If Not IsNothing(dtDatos) Then
                    If dtDatos.Rows.Count = 1 Then
                        Mensaje("Las Fechas Indicadas para el estado Financiero, se Solapan con otros estados financieros. Por favor Verifique.")
                        bValido = False
                    End If
                End If
            End If
        End If
        'Session("Mensaje") = sMensaje
        If sMensaje <> "" Then
            Mensaje(sMensaje)
        End If
        Return bValido
    End Function
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = cFunciones.Ejecutar(m_sAgregarRegistro, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Function dtParametros() As DataTable
        dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("NumRegistro", Master.NumRegistro.ToString)
        dtParametros.Rows.Add("FechaInicioPeriodo", dtcFechaDesde.Value)
        dtParametros.Rows.Add("FechaFinPeriodo", dtcFechaHasta.Value)
        dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
    End Function
    Function dtParametros(sCodigo As String) As DataTable
        dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("NumEstadoFinanciero", sCodigo)
    End Function
End Class