Imports System.Net.Mail
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Module mEmail
    Public Function EnviarEmail(sDestinatario As String, sAsunto As String, sMensaje As String) As Boolean
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(My.Settings.SMTPUserEmail, My.Settings.SMTPPwd, "sdhjgd.gob.hn")
            SmtpServer.EnableSsl = My.Settings.SMTPEnableSSL

            SmtpServer.Port = My.Settings.SMTPPort
            SmtpServer.Host = My.Settings.SMTPServer


            mail = New MailMessage()
            mail.From = New MailAddress(My.Settings.SMTPUserEmail, My.Settings.NombreCortoSistema)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls

            mail.To.Add(sDestinatario)
            mail.Subject = sAsunto
            mail.Body = sMensaje
            mail.IsBodyHtml = True
            mail.Priority = Net.Mail.MailPriority.High
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            SmtpServer.Send(mail)
            Return True
        Catch ex As SmtpException
            Throw (ex)
        End Try
    End Function
  
End Module
