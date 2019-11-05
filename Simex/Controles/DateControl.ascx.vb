﻿Public Class DateControl
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    Public Property FechaHora As Boolean
    Public Property Obligatorio As Boolean
    Public Property SoloLectura As Boolean = False
    Public Property ValorMinimo As Date
    Public Property ValorMaximo As Date
    Public Property FieldName As String
    Private dFecha As DateTime

    Private Sub validarValorMinimo(ByRef bValido As Boolean)
        If ValorMinimo.ToString <> "" Then
            If txtDate.Text < ValorMinimo Then
                lblMessage.Text = "El valor debe ser superior a: " & ValorMinimo.ToString
                If bValido = True Then
                    bValido = False
                End If
            End If
        End If
    End Sub
    Private Sub validarValorMaximo(ByRef bValido As Boolean)
        Dim s As String = ValorMaximo.ToString
        If ValorMaximo.ToString <> "01/01/2999 0:00:00" Then
            Dim valor1, valor2 As Date
            valor1 = txtDate.Text
            valor2 = ValorMaximo
            If ValorMaximo = "#12:00:00 AM#" Then
                bValido = True
                Exit Sub
            End If
            If valor1 > valor2 Then
                lblMessage.Text = "El valor debe ser Inferior a: " & ValorMaximo.ToString
                If bValido = True Then
                    bValido = False
                End If
            End If

        End If
    End Sub

    Public Property Value As Object
        Get
            Try
                Valido()
                Dim fecha As String
                If txtDate.Text = "" Then
                    Return Nothing
                Else
                    dFecha = CDate(txtDate.Text)
                    If FechaHora Then
                        Return dFecha.ToString("yyyy-MM-dd HH:mm:ss")
                    Else

                        dFecha = dFecha.ToShortDateString
                        fecha = dFecha.ToString("yyyyMMdd")
                        Return fecha
                    End If
                End If
                lblMessage.Visible = False
            Catch ex As Exception
                Session("Mensaje") = "Error"
                lblMessage.Text = "Formato de fecha no válido, el valor debe estar ingresarse en formato: dia/mes/año"
                lblMessage.Visible = True
                Return Nothing
            End Try
        End Get
        Set(ByVal value As Object)
            If Not IsNothing(value) Then
                If value.ToString <> "" Then
                    dFecha = value
                    If FechaHora Then
                        txtDate.Text = FormatDateTime(value, DateFormat.GeneralDate)
                    Else
                        txtDate.Text = dFecha.ToShortDateString
                    End If
                End If
            Else
                dFecha = Nothing
            End If
        End Set
    End Property
    Public ReadOnly Property sFecha() As String
        Get
            Return Value.ToString
        End Get
    End Property
#End Region

#Region "Metodos"
    Private Function Valido() As Boolean
        Dim bValido As Boolean = True
        Dim bCampoVacio As Boolean = False
        lblMessage.Text = ""
        If txtDate.Text = "" Or txtDate.Text = String.Empty Then
            If Obligatorio Then
                lblMessage.Text = "Debe introducir un valor en el campo"
                lblMessage.Visible = True
                bValido = False
            End If
        Else
            validarValorMaximo(bValido)
            validarValorMinimo(bValido)
        End If
        If lblMessage.Text <> "" Then
            Session("Mensaje") = "Error"
            'Else
            '    Session("Mensaje") = ""

        End If
        Return bValido
    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Session("Mensaje") = ""
        If Obligatorio Then
            lblMessage.Text = "*"
            lblMessage.Visible = True
        End If
        If SoloLectura Then
            txtDate.Enabled = False
            btnDate.Visible = False
        End If
    End Sub

End Class