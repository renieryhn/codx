Public Class Propiedades
    Inherits System.Web.UI.MasterPage

#Region "Eventos"
    Public Event Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Aplicar_Click(ByVal sender As Object, ByVal e As EventArgs)
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click
        RaiseEvent Aceptar_Click(sender, e)
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        RaiseEvent Cancelar_Click(sender, e)
    End Sub
    Protected Sub btnAplicar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAplicar.Click
        RaiseEvent Aplicar_Click(sender, e)
    End Sub

    Public Property setAplicarVisible()
        Get
            Return Me.btnAplicar.Visible
        End Get
        Set(ByVal value)
            Me.btnAplicar.Visible = value
        End Set
    End Property
End Class