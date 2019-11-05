Imports prjDatos
Imports System.Data.OleDb
Imports System.IO

Public Class wfmDicResMas
    Inherits System.Web.UI.Page
    Private cFunciones As New funciones
    Private ConsultaPuesto As String
    Private idFieldName As String
    Private TableName As String
    Private sMensaje As String = ""
    Private nombre = "Generar Dictamenes/Resoluciones (Modo Masivo)"
    Dim tblExp As DataTable
    Private sNombreBusqueda As String = "pDetalleExpediente_List"

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Master.Aceptar_Click, AddressOf btnAceptar_Click
        AddHandler Master.Aplicar_Click, AddressOf btnAplicar_Click
        AddHandler Master.Cancelar_Click, AddressOf btnCancelar_Click
        Master.Master.m_titulo = nombre
        If Session("Mensaje") <> "" Then
            Mensaje(Session("Mensaje"))
        End If

        If Not IsPostBack Then
            Session("tblExpR") = Nothing
            tblExp = New DataTable
            tblExp.Columns.Add("Expediente")
            tblExp.Columns.Add("EsValido")
            Session("tblExpR") = tblExp
            txtExpediente.Focus()
        Else
            If txtExpediente.Text <> "" Then
                Dim sExpediente As String = Trim(Replace(UCase(txtExpediente.Text), "'", "-"))
                AgregarExpediente(sExpediente)
                txtExpediente.Text = ""
                txtExpediente.Focus()
            End If
        End If
    End Sub
    Sub AgregarExpediente(sExpediente As String)
        Try
            If tblExp Is Nothing Then
                tblExp = Session("tblExpR")
            End If
            Dim i As Integer
            Dim bExiste As Boolean = False
            For i = 0 To tblExp.Rows.Count - 1
                If sExpediente = tblExp.Rows(i).Item(0).ToString Then
                    bExiste = True
                    Exit For
                End If
            Next
            If Not bExiste Then
                Dim row As DataRow
                Dim iDetalle As String = ""
                Dim iEstado As String = ""
                row = tblExp.NewRow
                row(0) = sExpediente
                row(1) = bExpValido(sExpediente)
                tblExp.Rows.Add(row)
                gExp.DataSource = tblExp
                gExp.DataBind()
                Session("tblExpR") = tblExp
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function bExpValido(sExpediente As String) As Boolean
        Try
            If sExpediente <> "" Then
                Dim tbl As DataTable = cFunciones.Filldatatable(sNombreBusqueda, dtParametros(sExpediente))

                Dim sRecibidoPor As String = tbl.Rows(0).Item("UsuarioRecibido").ToString
                Dim sFecha As String = tbl.Rows(0).Item("FechaRecepcion").ToString

                If sRecibidoPor.ToLower = Session("Usuario").ToString.ToLower And sFecha <> "" Then
                    Return True
                Else
                    Return False
                End If

            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Response.Redirect(linkMain.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect(linkMain.NavigateUrl)
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If bInsertar() Then
            Session("tblExpR") = Nothing
            Response.Redirect(linkMe.NavigateUrl)
        Else
            Mensaje(sMensaje)
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Function bInsertar() As Boolean
        Try
            Dim i As Integer
            Dim spNombre As String = ""

            If rDic.Checked Then
                spNombre = "pExpediente_DictamenMas"
            Else
                spNombre = "pExpediente_ResolucionMas"
            End If

            Dim sMsg As String = "Los registros han sido generados exitosamente: " & vbCrLf

            For i = 0 To gExp.Rows.Count - 1
                If gExp.Rows(i).Cells(2).Text = "True" Then
                    If cFunciones.Ejecutar(spNombre, dtParametros(gExp.Rows(i).Cells(1).Text), sMensaje) Then
                        sMsg += (i + 1).ToString & " - " & gExp.Rows(i).Cells(1).Text & vbCrLf
                    End If
                End If
            Next

            Mensaje(sMsg)
            Response.Redirect("~/Registro/Expediente/WfmExpediente_List.aspx")

            Return True

        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Function

    Private Function dtParametros(sExpediente As String) As DataTable
        Try
            dtParametros = cFunciones.dtDatos.Clone
            dtParametros.Rows.Add("idExpediente", sExpediente)
            dtParametros.Rows.Add("idUsuario", Session("Usuario"))
        Catch ex As Exception
            Mensaje(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub gExp_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gExp.RowDeleting
        Try
            tblExp = Session("tblExpR")
            tblExp.Rows(e.RowIndex).Delete()
            Session("tblExpR") = tblExp
            gExp.DataSource = tblExp
            gExp.DataBind()
            e.Cancel = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Mensaje(ByVal sMensaje As String)
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
#End Region


    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Dim sExt As String
            sExt = System.IO.Path.GetExtension(FlUploadcsv.FileName)
            If sExt = ".xls" Or sExt = ".xlsx" Then


                Dim i As Integer
                Dim FileName As String = FlUploadcsv.FileName
                Dim path As String = String.Concat(Server.MapPath("~/Document/" + FlUploadcsv.FileName))
                Dim conStr As String = ""
                Dim oHojas As DataTable
                Dim sPrimeraHoja As String

                If File.Exists(path) Then
                    File.Delete(path)
                End If

                FlUploadcsv.PostedFile.SaveAs(path)

                If sExt = ".xls" Then
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + path + ";" +
                    "Extended Properties=Excel 8.0;"
                Else
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=" + path + ";" +
                    "Extended Properties=Excel 8.0;"
                End If

                Dim OleDbcon As OleDbConnection = New OleDbConnection(conStr)
                OleDbcon.Open()
                oHojas = OleDbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                sPrimeraHoja = oHojas.Rows(0).Item("TABLE_NAME").ToString()
                OleDbcon.Close()

                Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [" + sPrimeraHoja + "]", OleDbcon)
                Dim objAdapter1 As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim dt As New DataTable
                objAdapter1.Fill(dt)

                For i = 0 To dt.Rows.Count - 1
                    AgregarExpediente(dt.Rows(i).Item(0))
                Next
                lblMSG.Text = "Se han Cargado " + dt.Rows.Count + " Expedientes."
            Else
                Mensaje("El tipo de Archivo seleccionado no es válido.")
            End If
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try
    End Sub
End Class