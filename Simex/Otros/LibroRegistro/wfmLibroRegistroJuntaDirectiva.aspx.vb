Imports prjDatos
Imports System.Threading

Public Class wfmRegistroJuntaDirectiva
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = "pUR_RegistroJunta_List"
    Dim m_sAgregarRegistro = "pUR_RegistroJunta_Add"
    Dim m_sAgregarRegistroDet = "pUR_RegistroJDDet_Add"
    Dim m_sEditarRegistroDet = "pUR_RegistroJDDet_Edit"
    Dim m_sEditarRegistro = "pUR_RegistroJunta_Edit"
    Dim m_sEliminarRegistro = "pUR_RegistroJunta_DeleteLibro"
    Dim m_sListaDatosDet = "pUR_RegistroJuntaDet_List"
    Dim m_sEliminarRegistroDet = "pUR_RegistroJuntaDet_Delete"
    Private sNombreMantenimiento As String = "Libro de Regstro / Registro de Junta Directiva"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
        If Not IsPostBack Then
            Session("CodigoRegistroJD") = ""
            Session("CodigoRegistroJDDet") = ""
            CleanData()
        End If
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Not IsPostBack Then
            gvDatos.Columns(0).Visible = Master.Master.Borrado
            gvDatosDet.Columns(0).Visible = Master.Master.Borrado
            LlenarGrid()
            If Session("Mensaje") <> "" Then
                Mensaje(Session("Mensaje"))
                Session("Mensaje") = ""
            End If
        End If
    End Sub
    Sub LlenarGrid()
        If Master.IdLibro <> "" Then
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("IdLibro", Master.IdLibro.ToString)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable(m_sListaDatos, prams, sMensaje)
            gvDatos.DataSource = dtDatos
            gvDatos.DataBind()
        End If
    End Sub

    Sub LlenarGridDet(sCodigo As String)
        If gvDatos.SelectedRow.RowIndex > -1 Then
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("IdJuntaDirectiva", sCodigo)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable(m_sListaDatosDet, prams, sMensaje)
            gvDatosDet.DataSource = dtDatos
            gvDatosDet.DataBind()
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

    Private Sub gvDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Dim iRow As Integer
        Select Case e.CommandName
            Case "Editar"
                iRow = e.CommandArgument
                Session("CodigoRegistroJD") = gvDatos.Rows(iRow).Cells(3).Text
                If CargarRegistro(Session("CodigoRegistroJD")) Then
                    mpeFormulario.Show()
                End If
            Case "JuntaDirectiva"
                iRow = e.CommandArgument
                Session("CodigoRegistroJD") = gvDatos.Rows(iRow).Cells(3).Text
        End Select
    End Sub


    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDatos.RowDeleting
        Dim Codigo As String = Me.gvDatos.Rows(e.RowIndex).Cells(3).Text
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

    Protected Sub btnAddJunta_Click(sender As Object, e As EventArgs) Handles btnAddJunta.Click
        If bValidar() Then
            If bInsertar() Then
                mpeFormulario.Hide()
                LlenarGrid()
                CleanData()
            End If
        Else
            mpeFormulario.Show()
        End If
    End Sub
    Function bValidar() As Boolean
        Dim bValido As Boolean = True
        If Not Master.Master.Alta Then
            Mensaje("No tiene permisos para modificar este registro.")
            bValido = False
        End If
        If dtcfInscripcion.Value = "" Then
            Mensaje("Por favor ingrese la fecha de Inscripción de la Junta Directiva.")
            bValido = False
        End If
        Return bValido
    End Function
    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Dim sFuncion As String = ""
        If Session("CodigoRegistroJD") = "" Then
            sFuncion = m_sAgregarRegistro
        Else
            sFuncion = m_sEditarRegistro
        End If
        Ok = cFunciones.Ejecutar(sFuncion, dtParametros, sMensaje)
        Session("Mensaje") = sMensaje
        Return Ok
    End Function

    Function dtParametros() As DataTable
        dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("IdJuntaDirectiva", Session("CodigoRegistroJD"))
        dtParametros.Rows.Add("IdLibro", Master.IdLibro.ToString)
        dtParametros.Rows.Add(dtcfInscripcion.FieldName, dtcfInscripcion.Value)
        dtParametros.Rows.Add(dtcfTomaPosesion.FieldName, dtcfTomaPosesion.Value)
        dtParametros.Rows.Add(dtcfEleccion.FieldName, dtcfEleccion.Value)
        dtParametros.Rows.Add(dtcfRegistro.FieldName, dtcfRegistro.Value)
        dtParametros.Rows.Add(dtcfVigenciaDesde.FieldName, dtcfVigenciaDesde.Value)
        dtParametros.Rows.Add(dtcfVigenciaHasta.FieldName, dtcfVigenciaHasta.Value)
        dtParametros.Rows.Add("idUsuario", Master.Master.Usuario)
    End Function
    Function dtParametros(sCodigo As String) As DataTable
        dtParametros = cFunciones.dtDatos.Clone
        dtParametros.Rows.Add("IdLibro", Master.IdLibro.ToString)
        dtParametros.Rows.Add("IdJuntaDirectiva", sCodigo)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles btnCerrar.Click
        mpeFormulario.Hide()
    End Sub

    Function CargarRegistro(sCodigo As String) As Boolean
        Try
            If Master.Master.Modificacion Then
                If Master.IdLibro <> "" Then
                    Dim prams = cFunciones.dtDatos.Clone
                    prams.Rows.Add("IdLibro", Master.IdLibro.ToString)
                    prams.Rows.Add("IdJuntaDirectiva", sCodigo)
                    Dim dtDatos As DataTable
                    dtDatos = cFunciones.Filldatatable(m_sListaDatos, prams, sMensaje)
                    If dtDatos.Rows.Count = 1 Then
                        dtcfInscripcion.Value = dtDatos.Rows(0).Item(dtcfInscripcion.FieldName)
                        dtcfTomaPosesion.Value = dtDatos.Rows(0).Item(dtcfTomaPosesion.FieldName)
                        dtcfEleccion.Value = dtDatos.Rows(0).Item(dtcfEleccion.FieldName)
                        dtcfRegistro.Value = dtDatos.Rows(0).Item(dtcfRegistro.FieldName)
                        dtcfVigenciaDesde.Value = dtDatos.Rows(0).Item(dtcfVigenciaDesde.FieldName)
                        dtcfVigenciaHasta.Value = dtDatos.Rows(0).Item(dtcfVigenciaHasta.FieldName)
                    End If
                    Return True
                End If
            Else
                Mensaje("No tiene permisos para modificar este registro.")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    'Function CargarRegistroDet(sCodigo As String) As Boolean
    '    Try
    '        If Master.Master.Modificacion Then
    '            If Master.IdLibro <> "" Then
    '                Dim prams = cFunciones.dtDatos.Clone
    '                prams.Rows.Add("IdJuntaDirectivaDet", sCodigo)
    '                Dim dtDatos As DataTable
    '                dtDatos = cFunciones.Filldatatable(m_sListaDatosDet, prams, sMensaje)
    '                If dtDatos.Rows.Count = 1 Then
    '                    txtPersonaID.Text = dtDatos.Rows(0).Item(txtPersonaID.FieldName)
    '                    cboPuesto.Value = dtDatos.Rows(0).Item(cboPuesto.FieldName)
    '                End If
    '                Return True
    '            End If
    '        Else
    '            Mensaje("No tiene permisos para modificar este registro.")
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Private Sub CleanData()
        Session("CodigoRegistroJD") = ""
        dtcfInscripcion.Value = Now
        dtcfTomaPosesion.Value = Now
        dtcfEleccion.Value = Now
        dtcfRegistro.Value = Now
        dtcfVigenciaDesde.Value = Now
        dtcfVigenciaHasta.Value = Now.AddYears(1)
    End Sub

    Private Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        LlenarGridDet(gvDatos.SelectedRow.Cells(3).Text)
    End Sub

    Private Sub gvDatosDet_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDatosDet.RowCommand
        Dim iRow As Integer
        Select Case e.CommandName
            Case "Editar"
                iRow = e.CommandArgument
                Dim sCodigo As String = gvDatosDet.Rows(iRow).Cells(2).Text
                Session("CodigoRegistroJDDet") = sCodigo
                Response.Redirect("/Otros/LibroRegistro/wfmLibroRegistroMiembro_Edit.aspx")
                'If CargarRegistroDet(Session("CodigoRegistroJDDet")) Then
                '    mpeMiembros.Show()
                'Else
                '    Mensaje("No se puede cargar el registro seleccionado.")
                'End If
        End Select
    End Sub

    Private Sub gvDatosDet_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvDatosDet.RowDeleting
        Dim Codigo As String = Me.gvDatos.SelectedRow.Cells(3).Text
        Dim OK As Boolean = False
        If Master.Master.Borrado Then
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("IdJuntaDirectivaDet", Me.gvDatosDet.Rows(e.RowIndex).Cells(2).Text)
            OK = cFunciones.Ejecutar(m_sEliminarRegistroDet, prams, sMensaje)
            If sMensaje <> "" Then
                Mensaje(sMensaje)
            End If
            If OK Then
                LlenarGridDet(Codigo)
            End If
        Else
            Mensaje("No tiene permisos para eliminar este registro.")
        End If
    End Sub

    'Function bValidarDet() As Boolean
    '    Dim bValido As Boolean = True
    '    If Not Master.Master.Alta Then
    '        Mensaje("No tiene permisos para modificar este registro.")
    '        bValido = False
    '    End If
    '    If txtPersonaID.Text = "" Then
    '        Mensaje("Por favor ingrese los datos de la persona.")
    '        bValido = False
    '    End If
    '    If cboPuesto.Value.ToString = "" Then
    '        Mensaje("Por favor ingrese el puesto de la persona.")
    '        bValido = False
    '    End If
    '    Return bValido
    'End Function
    'Private Function bInsertarDet() As Boolean
    '    Dim Ok As Boolean
    '    Dim sFuncion As String = ""
    '    If Session("CodigoRegistroJDDet") = "" Then
    '        sFuncion = m_sAgregarRegistroDet
    '    Else
    '        sFuncion = m_sEditarRegistroDet
    '    End If
    '    Ok = cFunciones.Ejecutar(sFuncion, dtParametrosDet, sMensaje)
    '    Session("Mensaje") = sMensaje
    '    CleanData()
    '    Return Ok
    'End Function
    'Function dtParametrosDet() As DataTable
    '    dtParametrosDet = cFunciones.dtDatos.Clone
    '    dtParametrosDet.Rows.Add("IdJuntaDirectiva", Session("CodigoRegistroJD"))
    '    dtParametrosDet.Rows.Add("@IdJuntaDirectivaDet", Nothing)
    '    dtParametrosDet.Rows.Add("@IdPersona", txtPersonaID.Text)
    '    dtParametrosDet.Rows.Add("@IdPuesto", cboPuesto.Value)
    '    dtParametrosDet.Rows.Add("idUsuario", Master.Master.Usuario)
    'End Function

    'Protected Sub btnAddMiembro_Click(sender As Object, e As EventArgs) Handles btnAddMiembro.Click
    '    Try
    '        If bValidarDet() Then
    '            If bInsertarDet() Then
    '                mpeMiembros.Hide()
    '            End If
    '        Else
    '            mpeMiembros.Show()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnAgregarMiembro_Click(sender As Object, e As EventArgs) Handles btnAgregarMiembro.Click
    '    Try
    '        If bValidarDet() Then
    '            If bInsertarDet() Then
    '                mpeMiembros.Hide()
    '            End If
    '        Else
    '            mpeMiembros.Show()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub btnNuevoMiembro_Click(sender As Object, e As EventArgs) Handles btnNuevoMiembro.Click
        If gvDatos.SelectedRow Is Nothing Then
            Mensaje("Por favor seleccione un registro de junta directiva para continuar.")
        Else
            Session("CodigoRegistroJD") = gvDatos.SelectedRow.Cells(3).Text
            Response.Redirect("~/Otros/LibroRegistro/wfmLibroRegistroMiembro_Add.aspx")
        End If
    End Sub

    Protected Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Session("URTipoRep") = 1
        Session("ID") = Master.IdLibro.ToString
        Response.Redirect("/rHistoricoJD.aspx")
    End Sub

    Protected Sub btnImprimir0_Click(sender As Object, e As EventArgs) Handles btnImprimir0.Click
        If gvDatos.SelectedRow Is Nothing Then
            Mensaje("Por favor seleccione un registro de junta directiva para continuar.")
        Else
            Session("CodigoRegistroJD") = gvDatos.SelectedRow.Cells(3).Text
            Session("ID") = Master.IdLibro.ToString
            Response.Redirect("/wfmRegistroInformesConst.aspx")
        End If
    End Sub
End Class