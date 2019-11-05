Imports prjDatos
Public Class wfmConstancia_Add
    Inherits System.Web.UI.Page
    Private Funciones As New funciones
    Private m_dtDatos As New DataTable
    Private m_szMensaje As String = ""
    Private m_szConstanciaCreada As String = ""
    Private Const szConstanciaAgregar As String = "pConstancia_Add"
    Private Const szExpedienteinfo As String = "pExpediente_List"
    Private Const szReciboInfo As String = "pRecibo_List"
    Private pageTitle = "Agregar constancia"

#Region "Metodos"
    Public Function getServicio() As String
        Dim retval = ""
        If TextBox1.Text <> "" Then
            Dim tokens = TextBox1.Text.Split("-")
            retval = tokens(0).ToUpper
        End If
        Return retval
    End Function

    Public Sub checkExp()
        rbExtranjeria.Visible = False
        rbPJ.Visible = False
        Dim dt = Funciones.dtDatos.Clone
        dt.Rows.Add("id", TextBox1.Text)
        Dim sztemp = "No se encontró el expediente."
        If TextBox1.Text <> "" Then
            Dim retdt = Funciones.Filldatatable(szExpedienteinfo, dt)
            If retdt.Rows.Count <> 0 Then
                sztemp = "Válido - " & retdt.Rows(0).Item("NombreTipoSolicitante") + ": " +
                    retdt.Rows(0).Item("Solicitante") + "  " + retdt.Rows(0).Item("NombreTipoResponsable") + ": " +
                    retdt.Rows(0).Item("Responsable")
                If getServicio() = "V" Then
                    rbExtranjeria.Visible = True
                    rbPJ.Visible = True
                    rbPJ.Checked = True
                End If
            End If
        End If
        ExpedienteDetalle.Text = sztemp
        ExpedienteDetalle.Visible = True
    End Sub

    Public Sub checkRecibo()
        Dim dt = Funciones.dtDatos.Clone
        dt.Rows.Add("NumReciboFinanzas", Me.TextBox2.Text)
        Dim sztemp = "No se encontró el Recibo."
        If TextBox2.Text <> "" Then
            Dim retdt = Funciones.Filldatatable(szReciboInfo, dt)
            If retdt.Rows.Count <> 0 Then
                sztemp = "Válido - " & retdt.Rows(0).Item("NombreServicio") + ": " +
                    retdt.Rows(0).Item("NombreSubServicio") + "  " + "Valor: " +
                    retdt.Rows(0).Item("Valor").ToString
            End If
        End If
        ReciboDetalle.Text = sztemp
        ReciboDetalle.Visible = True
    End Sub

    Private Function bInsertar() As Boolean
        Dim Ok As Boolean
        Ok = Funciones.Ejecutar(szConstanciaAgregar, dtParametrosAdd, "idConstancia", m_szConstanciaCreada, m_szMensaje)
        Session("Mensaje") = m_szMensaje
        Return Ok
    End Function

    Public Function dtParametrosAdd() As DataTable
        Try
            dtParametrosAdd = Funciones.dtDatos.Clone
            dtParametrosAdd.Rows.Add(TextBox1.FieldName, TextBox1.Text)
            dtParametrosAdd.Rows.Add(TextBox2.FieldName, TextBox2.Text)
            dtParametrosAdd.Rows.Add("IdUsuario", Master.Master.Usuario)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
#End Region

#Region "Eventos"
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            If getServicio() = "V" Then
                If rbPJ.Checked Then
                    Session("TipoReporte") = "PJ"
                Else
                    Session("TipoReporte") = "E"
                End If
            Else
                Session("TipoReporte") = getServicio()
            End If
            Session("id") = m_szConstanciaCreada
            Response.Redirect("~/Reportes/wfrmRepConstancias.aspx", False)
        Else
            Mensaje(m_szMensaje)
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkMain.NavigateUrl)
    End Sub

    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Session("TipoReporte") = getServicio()
            Session("id") = m_szConstanciaCreada
            Response.Redirect("~/Registro/DispensasEdicto/wfmReporteador.aspx")
        Else
            Mensaje(m_szMensaje)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.setAplicarVisible = False
        Master.Master.m_titulo = pageTitle

        'No permitiremos aplicar en esta forma
        'AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
    End Sub
#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        'Verificar expediente
        checkExp()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        'Verificar recibo
        checkRecibo()
    End Sub
End Class