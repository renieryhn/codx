Imports prjDatos
Imports System.Net.Mail
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class RecuperarClave
    Inherits System.Web.UI.Page
    Dim Funciones As New funciones
    Dim cMensaje As New Mensaje
    Dim sMensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtEmail.Text <> "" And txtUsuario.Text <> "" Then
            Dim tblUser As DataTable = Funciones.Filldatatable("pUsuario_List", dtParametros, sMensaje)
            If tblUser.Rows.Count = 1 Then
                Dim sPwd As String
                If Trim(tblUser.Rows(0).Item("Email1").ToString.ToLower) = Trim(txtEmail.Text.ToLower) Then
                    sPwd = tblUser.Rows(0).Item("PWD")
                    EnviarEmail(Trim(txtEmail.Text.ToLower), sPwd)
                    Mensaje("La contraseña ha sido enviada a su correo electrónico, por favor revise en SPAM si no encuentra nada en su bandeja de entrada.")
                    Response.Redirect("~/Autenticacion/Confirmacion.aspx")
                Else
                    Mensaje("Sus dirección de correo es incorrecta, por favor pongase en contacto con el administrador del sistema.")
                End If
            Else
                Mensaje("Sus dirección de correo o Nombre de Usuario es incorrecto, por favor pongase en contacto con el administrador del sistema.")
            End If
        End If
    End Sub
    Private Function dtParametros() As DataTable
        Try
            dtParametros = Funciones.dtDatos.Clone
            Dim iUser As Integer = 0
            dtParametros.Rows.Add("Usuario", iUser)
            dtParametros.Rows.Add("Nombre", Trim(txtUsuario.Text).ToLower)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub EnviarEmail(sEmail As String, sPwd As String)
        Try
            Dim sMsg As String = ""
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(My.Settings.SMTPUserEmail, My.Settings.SMTPPwd, "sdhjgd.gob.hn")
            SmtpServer.EnableSsl = My.Settings.SMTPEnableSSL

            SmtpServer.Port = My.Settings.SMTPPort
            SmtpServer.Host = My.Settings.SMTPServer

            mail = New MailMessage()
            mail.From = New MailAddress(My.Settings.SMTPUserEmail, My.Settings.NombreCortoSistema)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

            mail.To.Add(sEmail)
            mail.Subject = "RECUPERACIÓN DE CONTRASEÑA DE " & My.Settings.NombreCortoSistema

            sMsg = "<html><head></head><body><b>"
            sMsg += "<h2><span style=""color:#337FE5;"">" & My.Settings.NombreLargoSistema & "</span></h2>"
            sMsg += " <p><hr /></p><p>Recuperación de Contraseña:</p>"
            sMsg += " <p><table style=""width:60%;"" cellpadding=""2"" cellspacing=""0"" border=""1"" bordercolor=""#000000"">"
            sMsg += " <tbody>"
            sMsg += " <tr>"
            sMsg += " <td>"
            sMsg += " <strong>Usuario:</strong>"
            sMsg += " </td>"
            sMsg += " <td>"
            sMsg += txtUsuario.Text
            sMsg += " </td>"
            sMsg += " </tr>"
            sMsg += " <tr>"
            sMsg += " <td>"
            sMsg += " <strong>Con</strong><strong>t</strong><strong>ra</strong><strong>seña:</strong>"
            sMsg += " </td>"
            sMsg += " <td>"
            sMsg += sPwd
            sMsg += " </td>"
            sMsg += " </tr>"
            sMsg += " </tbody>"
            sMsg += " </table>"
            sMsg += " <br />"
            sMsg += " <p>"
            sMsg += " <hr /></p><p>Cualquier Sugerencia o Comentario, puede escribirnos a: " & My.Settings.EmailSoporte & " &nbsp;</p><p>"
            sMsg += " </p><p><span style=""line-height:1.5;"">Administrador <strong>CODEX</strong></span>"
            sMsg += " </p><p>" & My.Settings.NombreLargoSistema & "</p><p>"
            sMsg += "" & My.Settings.NombreSecretaria & "</p><p></p>"
            sMsg += " </p><p><br /></p>"
            sMsg += "</b></body>"

            mail.Body = sMsg
            mail.IsBodyHtml = True
            mail.Priority = Net.Mail.MailPriority.High
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            SmtpServer.Send(mail)
        Catch ex As SmtpException
            Throw (ex)
        End Try
    End Sub

    Sub Mensaje(message As String)
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub
End Class