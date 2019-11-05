﻿Public Class WebUserControl1
    Inherits System.Web.UI.UserControl
    Public Event TextChanged(ByVal sender As Object, ByVal e As EventArgs)

#Region "Declaraciones"
    Public Enum TextMode
        Multiline = 1
        SingleText = 2
        Password = 3
    End Enum
#End Region

#Region "Propiedades"
    Public WriteOnly Property Apariencia() As TextMode
        Set(ByVal value As TextMode)
            Select Case value
                Case TextMode.Multiline
                    TextBox1.TextMode = TextBoxMode.MultiLine
                Case TextMode.Password
                    TextBox1.TextMode = TextBoxMode.Password
                Case TextMode.SingleText
                    TextBox1.TextMode = TextBoxMode.SingleLine
            End Select
        End Set
    End Property

    Public Property MensajeError As String
        Get

            Return lblMensaje.Text
        End Get
        Set(ByVal value As String)
            lblMensaje.Text = value
        End Set
    End Property

    Public Property Text As String
        Get
            Valido()
            Return HttpUtility.HtmlDecode(TextBox1.Text)
        End Get
        Set(ByVal value As String)
            TextBox1.Text = HttpUtility.HtmlDecode(value)
        End Set
    End Property

    'Public Property TextoOculto As String
    '    Get
    '        Valido()
    '        Return HttpUtility.HtmlEncode(lblTextoOculto.Text)
    '    End Get
    '    Set(ByVal value As String)
    '        lblTextoOculto.Text = HttpUtility.HtmlDecode(value)
    '    End Set
    'End Property

    Public Property Name As String
        Get
            Return TextBox1.ID
        End Get
        Set(ByVal value As String)
            TextBox1.ID = value
        End Set
    End Property

    Public Property SoloLectura As Boolean
        Get
            Return TextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TextBox1.ReadOnly = value
        End Set
    End Property

    Public Property width As Integer
        Get
            Return TextBox1.Width.Value
        End Get
        Set(ByVal value As Integer)
            TextBox1.Width = value
        End Set
    End Property

    Public Property TabIndex As Integer
        Get
            Return TextBox1.TabIndex
        End Get
        Set(ByVal value As Integer)
            TextBox1.TabIndex = value
        End Set
    End Property

    Public Property MaxLength As Integer
        Get
            Return TextBox1.MaxLength
        End Get
        Set(ByVal value As Integer)
            TextBox1.MaxLength = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return TextBox1.Height.Value
        End Get
        Set(ByVal value As Integer)
            TextBox1.Height = value
        End Set
    End Property

    Public Property Habilitado As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property
    Public Property postBack As Boolean
        Get
            Return TextBox1.AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            TextBox1.AutoPostBack = value
        End Set
    End Property

    Public Property Obligatorio As Boolean

    Public Property ValorMinimo As String
    Public Property ValorMaximo As String
    Public Property Int As Boolean
    Public Property FieldName As String

#End Region

#Region "Metodos"
    Public Function Valido(Optional ByVal Validacion As Boolean = False) As Boolean
        Dim bValido As Boolean = True
        Dim bCampoVacio As Boolean = False
        lblMensaje.Text = ""
        If TextBox1.Text = "" Or TextBox1.Text = String.Empty Then
            If Obligatorio Then
                If Not Validacion Then
                    If MensajeError <> "" Then
                        lblMensaje.Text = MensajeError
                    Else
                        lblMensaje.Text = "Debe introducir un valor en el campo"
                    End If

                Else
                    lblMensaje.Text = "*"
                End If

                bValido = False
            End If
            bCampoVacio = True
        End If
        validarInteger(bValido, bCampoVacio)
        If lblMensaje.Text <> "" And Not Validacion Then
            Session("Mensaje") = "Error"
            'Else
            '    Session("Mensaje") = ""
        End If
        Return bValido
    End Function

    Private Sub validarInteger(ByRef bValido As Boolean, ByRef bCampoVacio As Boolean)
        Dim IntValue As Integer
        If Int = True And Not bCampoVacio Then
            Try
                IntValue = TextBox1.Text
                validarValorMinimo(bValido)
                validarValorMaximo(bValido)
            Catch ex As Exception
                lblMensaje.Text = "No es un valor numérico válido"
                If bValido = True Then
                    bValido = False
                End If
            End Try
        End If
    End Sub
    Private Sub validarValorMinimo(ByRef bValido As Boolean)
        If ValorMinimo <> "" Then
            If TextBox1.Text < ValorMinimo Then
                lblMensaje.Text = "El valor debe ser superior a: " & ValorMinimo.ToString
                If bValido = True Then
                    bValido = False
                End If
            End If

        End If
    End Sub
    Private Sub validarValorMaximo(ByRef bValido As Boolean)
        If ValorMaximo <> "" Then
            Dim valor1, valor2 As Integer
            valor1 = TextBox1.Text
            valor2 = ValorMaximo
            If valor1 > valor2 Then
                lblMensaje.Text = "El valor debe ser Inferior a: " & ValorMaximo.ToString
                If bValido = True Then
                    bValido = False
                End If
            End If
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("Mensaje") = ""
            If Obligatorio = True Then
                lblMensaje.Text = "*"
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent TextChanged(sender, e)
    End Sub
End Class