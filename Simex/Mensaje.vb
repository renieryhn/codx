Imports System.Web.UI.ClientScriptManager
Public Class Mensaje
    Inherits System.Web.UI.Page
    Public Sub Show(ByVal sMensaje As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & sMensaje & """);"
        strScript += "</script>"
        If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
        End If
    End Sub
End Class
