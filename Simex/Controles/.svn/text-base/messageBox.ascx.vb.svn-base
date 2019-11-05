Public Class msgBox
    Inherits System.Web.UI.UserControl
    Public Property OnOkScript As String
    Public Event btnOk1(ByVal sender As Object, ByVal e As EventArgs)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent btnOk1(sender, e)
    End Sub

    Public Sub Show(ByVal Mensaje As String, ByRef TargetControl As String, ByVal btnAceptar As Boolean, ByVal Cancelar As Boolean)
        Dim modalPop As New AjaxControlToolkit.ModalPopupExtender()
        'Dim btnAceptar As New Button
        'Dim btnCancelar As New Button
        'Dim lblMensaje As New Label
        modalPop.ID = "popUp"
        modalPop.PopupControlID = "ModalPanel"
        modalPop.TargetControlID = "Button1"
        modalPop.DropShadow = True
        modalPop.BackgroundCssClass = "modalBackground"
        lblMensaje.Text = Mensaje
        'btnCancelar.ID = "btnCancel"
        'btnAceptar.ID = "btnAceptar"
        'btnCancelar.Text = "Cancelar"
        'btnAceptar.Text = "Aceptar"
        'btnAceptar.OnClientClick = "btnOk_Click"
        modalPop.CancelControlID = "btnCancel"
        Me.Panel1.Controls.Add(modalPop)
        Me.ModalPanel.Controls.Add(lblMensaje)

        btnOk.Visible = btnAceptar
        btnCancel.Visible = Cancelar
        modalPop.Show()
    End Sub

End Class