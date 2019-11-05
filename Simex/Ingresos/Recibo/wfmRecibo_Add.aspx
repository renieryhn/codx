<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmRecibo_Add.aspx.vb" Inherits="smx.wfmRecibo_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">

<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 12pt;
    }
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 300px;
        border: 3px solid #0DA9D0;
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .footer
    {
        padding: 3px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
</style>

    <div class="DD">
        <div class="clear" style="overflow: visible">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>     
            <table style="width: 100%">
                <tr>
            
                    <td colspan="4">
                                <asp:Label ID="Label43" runat="server" Font-Bold="True" 
                                    Text="Datos del encabezado del recibo"></asp:Label>
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label45" runat="server" Text="Oficina"></asp:Label>
                        </td>
                    <td style="width: 849px" colspan="3">
                         <asp:Panel ID="Panel1" runat="server">
              
                                <uc2:ComboBox ID="cboOficina" runat="server" AutoFill="True" 
                                    FieldName="idOficina" idFieldName="id" TableName="Oficina" 
                                    textFieldName="Nombre" Obligatorio="True" />
                         </asp:Panel>        
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label46" runat="server" Text="Número recibo Finanzas"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc1:TextBox ID="txtNumeroRecibo" runat="server" Align="Izquierda" 
                                    FieldName="NumReciboFinanzas" Habilitado="True" Int="False" MaxLength="8" 
                                    Obligatorio="True" width="50" />
               
                        </td>
                    <td style="width: 94px">
               
                                <asp:Label ID="Label47" runat="server" Text="Fecha Emisión"></asp:Label>
               
                        </td>
                    <td style="width: 421px">
               
                                <uc3:DateControl ID="dteFechaEmision" runat="server" FechaHora="False" 
                                    FieldName="FechaEmision" Obligatorio="True" />
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
               
                                <asp:Label ID="Label4" runat="server" Text="Verificación del recibo"></asp:Label>
               
                        </td>
                    <td style="width: 145px">
               
                                <uc1:TextBox ID="txtVerificacionNumeroRecibo" runat="server" Align="Izquierda" 
                                    FieldName="Nombre" Habilitado="True" Int="False" MaxLength="8" 
                                    Obligatorio="True" width="50" />
               
                        </td>
                    <td style="width: 94px">
               
                                <asp:Label ID="Label6" runat="server" Text="Fecha Pago"></asp:Label>
               
                        </td>
                    <td style="width: 421px">
               
                                <uc3:DateControl ID="dteFechaPago" runat="server" FechaHora="False" 
                                    FieldName="Fechapago" />
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label7" runat="server" Text="Servicio"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                                    FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" 
                                    textFieldName="Nombre" />
               
                        </td>
                    <td style="width: 94px">
               
                                </td>
                    <td style="width: 421px">

                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
               
                                <asp:Label ID="Label8" runat="server" Text="Sub Servicio"></asp:Label>
               
                        </td>
                    <td style="width: 145px">
               
                       <uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="False" 
                                    FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" 
                                    TableName="SubServicios" textFieldName="Nombre" 
                            AditionalCondition="indEstado='A'" postBack="True" />
               
                        </td>
                    <td style="width: 94px">
               
                                </td>
                    <td style="width: 421px">

                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                </td>
                    <td style="width: 849px" colspan="3">
               
                         <cc7:ConfirmButtonExtender ID="cbe" runat="server" DisplayModalPopupID="mpe" TargetControlID="btnNTasa">
    </cc7:ConfirmButtonExtender>
    <cc7:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnNTasa"
    OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
    </cc7:ModalPopupExtender>

    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
        Ha modificado la tasa de cambio.
    </div>
    <div class="body">
        Desea establecer éste valor como la nueva tasa de cambio?
    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnYes" runat="server" Text="Sí" CssClass="yes" />
        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
    </div>
</asp:Panel> 
                     <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
               <%-- <fieldset>--%>
              <%--  </fieldset>--%>
                </contenttemplate>
            </asp:UpdatePanel>
                                
                
                        
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                                <asp:Label ID="Label39" runat="server" Font-Bold="True" 
                                    Text="Datos del detalle del recibo"></asp:Label>
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label48" runat="server" Text="Valor Dolares"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc1:TextBox ID="txtValorDolares" runat="server" Align="Izquierda" 
                                    FieldName="ValorDolares" Habilitado="False" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="80" />
               
                        </td>
                    <td style="width: 94px">
               
                                <asp:Label ID="Label49" runat="server" Text="Valor Lempiras"></asp:Label>
               
                        </td>
                    <td style="width: 421px">
               
                                <uc1:TextBox ID="txtValor" runat="server" Align="Izquierda" FieldName="Valor" 
                                    Habilitado="True" Int="False" MaxLength="15" Obligatorio="True" width="80" postBack="True" />
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label50" runat="server" Text="Tasa Cambio"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc1:TextBox ID="txtTasaCambio" runat="server" Align="Izquierda" 
                                    FieldName="TasaCambio" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="80" postBack="True" />
               
                                <asp:ImageButton ID="btnNTasa" runat="server" ImageUrl="~/Imagenes/save.png" ToolTip="Guardar ésta tasa de cambio." />
               
                        </td>
                    <td style="width: 94px">
               
                                <asp:Label ID="Label51" runat="server" Text="Cantidad"></asp:Label>
               
                        </td>
                    <td style="width: 421px">
               
                                <asp:TextBox ID="txtCantidad" runat="server" Width="33px" AutoPostBack="True" Font-Size="Small" Height="15px">1</asp:TextBox>
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label52" runat="server" Text="Total Dolares"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc1:TextBox ID="txtTotalDolares" runat="server" Align="Izquierda" 
                                    FieldName="TotalDOlares" Habilitado="False" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="80" />
               
                        </td>
                    <td style="width: 94px">
               
                                <asp:Label ID="Label53" runat="server" Text="Total Lempiras"></asp:Label>
               
                        </td>
                    <td style="width: 421px">
               
                                <uc1:TextBox ID="txtValorTotalLempiras" runat="server" Align="Izquierda" 
                                    FieldName="TotalLempiras" Habilitado="False" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="80" />
               
                        </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px">
                                <asp:Label ID="Label54" runat="server" Text="Pagado"></asp:Label>
                        </td>
                    <td style="width: 145px">
               
                                <uc2:ComboBox ID="cboEstadoRecibo" runat="server" AutoFill="True" 
                                    FieldName="indPagado" idFieldName="id" postBack="False" TableName="Si_No" 
                                    textFieldName="Nombre" />
               
                        </td>
                    <td style="width: 94px">
               
                                </td>
                    <td style="width: 421px">
               
                                </td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 148px; height: 18px;">
                                </td>
                    <td style="width: 145px; height: 18px;">
               
            <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_List.aspx"  Visible="False">[linkMain]</asp:HyperLink>
            <asp:HyperLink ID="LinkMe" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_Add.aspx" Visible="False">[LinkMe]</asp:HyperLink>
               
                                </td>
                    <td style="width: 94px; height: 18px;">
               
                                </td>
                    <td style="width: 421px; height: 18px;">
               
                                </td>
                    <td style="width: 1%; height: 18px;">
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                                &nbsp;</td>
                    <td style="width: 1%">
                        </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: left">

                        </td>
                </tr>
                </table> 

                            </ContentTemplate>
                        </asp:UpdatePanel>
           </div>   
                                <div  style="width: 650px">
            
                        <uc4:SolicitanteResponsable ID="Solicitante" runat="server" 
                            TipoEntidad="Datos del Solicitante del recibo:" idMostrar="A, I, C" 
                            MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" TipoEntidadCombo="1" />
                        </div>
        </div>        
    

       
</asp:Content>
