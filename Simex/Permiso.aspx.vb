Imports System.Web.DynamicData

Class _Permiso
    Inherits Page
    Private bURL As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If IsPostBack Then
            If Not IsNothing(Session("BackURL")) Then
                bURL = Session("BackURL").ToString()
            End If
        End If
        If Not IsNothing(Session("Ruta")) Then
            lblMSG.Text = Session("Ruta").ToString
        End If
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        If (bURL <> "") Then
            Response.Redirect(bURL)
        Else
            Response.Redirect("~/Registro/Expediente/Publico/wfmDetExpedientePublico.aspx")
        End If
    End Sub
End Class
