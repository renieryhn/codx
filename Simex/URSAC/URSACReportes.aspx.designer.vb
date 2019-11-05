'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class URSACReportes

    '''<summary>
    '''Control btnMostrarReporte.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnMostrarReporte As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control hiddenTargetControlForModalPopup.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hiddenTargetControlForModalPopup As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control dlgFiltrosFin.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dlgFiltrosFin As Global.AjaxControlToolkit.ModalPopupExtender

    '''<summary>
    '''Control lstReportes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lstReportes As Global.System.Web.UI.WebControls.RadioButtonList

    '''<summary>
    '''Control rp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rp As Global.Microsoft.Reporting.WebForms.ReportViewer

    '''<summary>
    '''Control pnlForm.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlForm As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Control btnCerrar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCerrar As Global.System.Web.UI.WebControls.ImageButton

    '''<summary>
    '''Control dFechaDesde.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dFechaDesde As Global.Telerik.Web.UI.RadDateInput

    '''<summary>
    '''Control dFechaHasta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dFechaHasta As Global.Telerik.Web.UI.RadDateInput

    '''<summary>
    '''Control btnAddParam.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAddParam As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control rpTel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rpTel As Global.Telerik.ReportViewer.WebForms.ReportViewer

    '''<summary>
    '''Propiedad Master.
    '''</summary>
    '''<remarks>
    '''Propiedad generada automáticamente.
    '''</remarks>
    Public Shadows ReadOnly Property Master() As smx.Consulta
        Get
            Return CType(MyBase.Master, smx.Consulta)
        End Get
    End Property
End Class
