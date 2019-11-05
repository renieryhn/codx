Imports prjDatos
Public Class wfmRegistroTramitesEnLinea
    Inherits System.Web.UI.Page
    Dim m_sListaDatos = "pUR_Registro_List"
    Dim m_sEditarRegistro = "pUR_Registro_EditPWD"
    Private sNombreMantenimiento As String = "Transacciones en Línea"
    Private sMensaje = ""
    Private cFunciones = New prjDatos.funciones()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.PreRender, AddressOf Page_PreRender
        Master.Master.m_titulo = sNombreMantenimiento
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
            Session("Mensaje") = ""
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

    Private Function bModificarPwd(ByRef sPwd As String) As String
        Dim Ok As Boolean
        sPwd = GenerarPIN()
        Ok = cFunciones.Ejecutar(m_sEditarRegistro, dtParametros(sPwd), sMensaje)
        Session("Mensaje") = sMensaje
        Return sPwd
    End Function

    Function dtParametros(sPwd As String) As DataTable
        dtParametros = cFunciones.dtDatos.Clone
        Dim sPassWord As String = sPwd
        dtParametros.Rows.Add("NumRegistro", Master.NumRegistro.ToString)
        dtParametros.Rows.Add("Pwd", sPassWord)
    End Function
    'Function dtParametros(sCodigo As String) As DataTable
    '    dtParametros = cFunciones.dtDatos.Clone
    '    dtParametros.Rows.Add("NumRegistro", Master.NumRegistro.ToString)
    '    dtParametros.Rows.Add("idRubro", sCodigo)
    'End Function

    Private Sub btnCerrar_Click(sender As Object, e As ImageClickEventArgs) Handles btnCerrar.Click
        mpeFormulario.Hide()
    End Sub

    Protected Sub rApo_CheckedChanged(sender As Object, e As EventArgs) Handles rApo.CheckedChanged
        Try
            SeleccionarDestinatario(0)
        Catch ex As Exception
            sMensaje = "No se pudo cargar el registro"
        End Try
    End Sub

    Protected Sub rEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles rEmpresa.CheckedChanged
        Try
            SeleccionarDestinatario(1)
        Catch ex As Exception
            sMensaje = "No se pudo cargar el registro"
        End Try
    End Sub

    Protected Sub rMiembro_CheckedChanged(sender As Object, e As EventArgs) Handles rMiembro.CheckedChanged
        Try
            SeleccionarDestinatario(2)
        Catch ex As Exception
            sMensaje = "No se pudo cargar el registro"
        End Try
    End Sub

    Sub SeleccionarDestinatario(Sel As Integer)
        Try
            Select Case Sel
                Case 0
                    cmbMiembro.Visible = False
                    GetApoEmail()
                Case 1
                    cmbMiembro.Visible = False
                    GetEmailEmpresa()
                Case 2
                    cmbMiembro.Visible = True
                    LoadMiembrosJDVigente()
            End Select
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub btnNuevaClave_Click(sender As Object, e As EventArgs)

    End Sub
    Sub GetApoEmail()
        Try
            Dim sIdApoderado As String = Master.IdApoderado
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("Id", sIdApoderado)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable("pApoderados_HasEmail", prams, sMensaje)
            If dtDatos.Rows.Count > 0 Then
                txtDestinatario.Text = dtDatos.Rows(0).Item("Nombre").ToString
                txtCorreo.Text = dtDatos.Rows(0).Item("Email1").ToString
            Else
                txtCorreo.Text = ""
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Sub LoadMiembrosJDVigente()
        Try

            Dim prams = cFunciones.dtDatos.Clone
            Dim sNumRegistro As String = Master.NumRegistro
            prams.Rows.Add("NumRegistro", sNumRegistro)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable("pUR_RegistroJunta_List", prams, sMensaje)
            If dtDatos.Rows.Count > 0 Then
                Dim sIdActual As String = dtDatos.Rows(0).Item("Id").ToString
                If sIdActual <> "" Then
                    Dim pramsM = cFunciones.dtDatos.Clone
                    pramsM.Rows.Add("IdJuntaDirectiva", sIdActual)
                    Dim dtDatosMiembros As DataTable
                    dtDatosMiembros = cFunciones.Filldatatable("pUR_RegistroJuntaDet_List", pramsM, sMensaje)
                    cmbMiembro.DataSource = dtDatosMiembros
                    cmbMiembro.DataTextField = "NombrePuesto"
                    cmbMiembro.DataValueField = "IdPersona"
                    cmbMiembro.DataBind()
                    cmbMiembro.SelectedIndex = 0
                    Try
                        LoadDataMiembro(Me.cmbMiembro.SelectedValue.ToString)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Protected Sub cmbMiembro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMiembro.SelectedIndexChanged
        Try
            Dim sIdCliente As String = ""
            If cmbMiembro.SelectedIndex > -1 Then
                sIdCliente = Me.cmbMiembro.SelectedValue.ToString
                LoadDataMiembro(sIdCliente)
            End If
        Catch ex As Exception
            sMensaje = "No se completar la operación: " & ex.Message
        End Try
    End Sub

    Sub LoadDataMiembro(sIdPersona As String)
        Try
            txtDestinatario.Text = ""
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("Id", sIdPersona)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable("pCliente_List", prams, sMensaje)
            If dtDatos.Rows.Count > 0 Then
                txtDestinatario.Text = dtDatos.Rows(0).Item("Nombre").ToString
                txtCorreo.Text = dtDatos.Rows(0).Item("Email1").ToString
            Else
                txtCorreo.Text = ""
            End If
            cmbMiembro.Visible = True
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Sub GetEmailEmpresa()
        Try
            Dim sIdEmpresa As String = Master.IdEmpresa
            If sIdEmpresa = "" Then
                sIdEmpresa = "-1"
            End If
            Dim prams = cFunciones.dtDatos.Clone
            prams.Rows.Add("Id", sIdEmpresa)
            Dim dtDatos As DataTable
            dtDatos = cFunciones.Filldatatable("pInstituciones_List", prams, sMensaje)
            If dtDatos.Rows.Count > 0 Then
                txtDestinatario.Text = dtDatos.Rows(0).Item("NombreContacto").ToString
                txtCorreo.Text = dtDatos.Rows(0).Item("EmailContacto").ToString
            Else
                txtCorreo.Text = ""
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub


    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try

            Dim sPin As String = ""
            If bModificarPwd(sPin) Then
                Dim sMsg As String = ""
                sMsg = "<html><head></head><body><b>"
                sMsg += "<h2><span style=""color:#337FE5;"">" & My.Settings.NombreLargoSistema & "</span></h2>"
                sMsg += " <p><hr /></p><p>Recuperación de Contraseña:</p>"
                sMsg += " <p><table style=""width:60%;"" cellpadding=""2"" cellspacing=""0"" border=""1"" bordercolor=""#000000"">"
                sMsg += " <tbody>"
                sMsg += " <tr>"
                sMsg += " <td>"
                sMsg += " <strong>Su Número de Registro es:</strong>"
                sMsg += " </td>"
                sMsg += " <td>"
                sMsg += "" & Master.NumRegistro.ToString
                sMsg += " </td>"
                sMsg += " </tr>"
                sMsg += " <tr>"
                sMsg += " <td>"
                sMsg += " <strong>Su PIN de Acceso es:</strong>"
                sMsg += " </td>"
                sMsg += " <td>"
                sMsg += "" & sPin
                sMsg += " </td>"
                sMsg += " </tr>"
                sMsg += " </tbody>"
                sMsg += " </table>"
                sMsg += " <br />"
                sMsg += " <p>"
                sMsg += " <hr /></p><p>Puede Ingresar al sitema de trámites en línea aqui: https://ursac.sdhjgd.gob.hn &nbsp;</p><p>"
                sMsg += " <hr /></p><p>Cualquier Sugerencia o Comentario, puede escribirnos a: </p>" & My.Settings.EmailSoporte & " &nbsp;</p><p>"
                sMsg += " </p><p><span style=""line-height:1.5;"">Administrador <strong>CODEX</strong></span>"
                sMsg += " </p><p>" & My.Settings.NombreLargoSistema & "</p><p>"
                sMsg += "" & My.Settings.NombreSecretaria & "</p><p></p>"
                sMsg += " </p><p><br /></p>"
                sMsg += "</b></body>"


                If txtCorreo.Text <> "" Then
                    If EnviarEmail(txtCorreo.Text, "PIN DE ACCESO AL SISTEMA DE TRÁMITES EN LÍNEA", sMsg) Then
                        mpeFormulario.Hide()
                    End If
                End If
            End If

        Catch ex As Exception
            txtMsg.Visible = True
            txtMsg.Text = ex.Message
            sMensaje = "No se completar la operación: " & ex.Message
        End Try
    End Sub

    Private Sub pnlForm_Load(sender As Object, e As EventArgs) Handles pnlForm.Load
        Try
            'If IsPostBack Then
            '    SeleccionarDestinatario(0)
            'End If
        Catch ex As Exception
            sMensaje = "No se pudo cargar el registro"
        End Try
    End Sub

    Function GenerarPIN() As String
        Try
            Dim rng As New Random
            Dim number As Integer = rng.Next(1, 100000000)
            Dim digits As String = number.ToString("00000000")
            Return digits
        Catch ex As Exception
            Return "12348765"
        End Try
    End Function

    Private Sub mpeFormulario_Load(sender As Object, e As EventArgs) Handles mpeFormulario.Load
        If Not IsPostBack Then
            SeleccionarDestinatario(0)
        End If
    End Sub
End Class