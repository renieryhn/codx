<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmRecibo_Edit.aspx.vb" Inherits="smx.wfmRecibo_Edit" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
    <table style="width: 100%">
        <tr>
            <td style="width: 121px">
    <asp:Label ID="lblNumRecibo" runat="server" Text="Número recibo Finanzas"></asp:Label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxNumRecibo" runat="server" ReadOnly = "true" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
            </td>
            <td style="width: 124px">
    <asp:Label ID="lblExpediente" runat="server" Text="Expediente"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxIdExpediente" runat="server" ReadOnly = "true" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:Button ID="btnExpediente" runat="server" Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:Label ID="lblFechaPago" runat="server" Text="Fecha Pago"></asp:Label>
            </td>
            <td style="width: 444px">
    <uc3:DateControl ID="dcFechaPago" runat="server" FechaHora="False" FieldName="FechaPago" />
            </td>
            <td style="width: 124px">
    <asp:Label ID = "lblFechaEmision" runat="server" Text= "Fecha Emisión"></asp:Label>
            </td>
            <td>
    <uc3:DateControl ID="dcFechaEmision" runat="server" FechaHora="False" FieldName= "FechaEmision" />
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxCantidad" runat="server" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
            </td>
            <td style="width: 124px">
    <asp:label ID="lblPrecioEnDollares" runat="server" Text="Valor Dolares"></asp:label>
            </td>
            <td>
    <asp:TextBox ID="tbxPrecioEnDollares" runat="server" ReadOnly="True" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="recibo" />
    <asp:label ID="lblCliente" runat="server" Text="Cliente"></asp:label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxCliente" runat="server" ReadOnly="True" Width="222px" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:label ID="lblClienteKey" runat="server" Visible="False"></asp:label>
    <asp:label ID="lblClienteValue" runat="server" Visible="False"></asp:label>
            </td>
            <td style="width: 124px">
    <asp:label ID="lblPrecioEnLempiras" runat="server" Text="Valor en Lempiras"></asp:label>
            </td>
            <td>
    <asp:TextBox ID="tbxPrecioEnLempiras" runat="server" ReadOnly="True" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="recibo" />
    <asp:label ID="lblApoderado" runat="server" Text="Apoderado"></asp:label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxApoderado" runat="server" ReadOnly="True" Width="222px" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:label ID="lblApoderadoKey" runat="server" Visible="False"></asp:label>
    <asp:label ID="lblApoderadoValue" runat="server" Visible="False"></asp:label>
            </td>
            <td style="width: 124px">
    <asp:label ID="lblTasaCambio" runat="server" Text="Tasa de Cambio"></asp:label>
            </td>
            <td>
    <asp:TextBox ID="tbxTasaCambio" runat="server" ReadOnly="True" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="recibo" />
    <asp:Label ID="lblTercero" runat="server" Text="Tercero:"></asp:Label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxTercero" runat="server" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
            <td style="width: 124px">
    <asp:label ID="lblTotalLempiras" runat="server" Text="Total Lempiras"></asp:label>
            </td>
            <td>
    <asp:TextBox ID="tbxLempiras" runat="server" ReadOnly="True" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:label ID="lblPagado" runat="server" Text="Pagado"></asp:label>
            </td>
            <td style="width: 444px">
    <uc2:ComboBox ID="cboEstadoRecibo" runat="server" AutoFill="True" FieldName="indPagado" idFieldName="id" postBack="False" TableName="Si_No" textFieldName="Nombre" />
            </td>
            <td style="width: 124px">
    <asp:label ID="lblSubservicioValue" runat="server" Visible="False"></asp:label>
            </td>
            <td>
    <asp:label ID="lblOficinaValue" runat="server" Visible="False"></asp:label>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">
    <asp:label ID="lblObservacionesTercero" runat="server" Text="Observacion"></asp:label>
            </td>
            <td style="width: 444px">
    <asp:TextBox ID="tbxObservacionesTercero" runat="server" TextMode="MultiLine" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
            </td>
            <td style="width: 124px">
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_List.aspx"  Visible="False">[linkMain]</asp:HyperLink>
            </td>
            <td>
    <asp:HyperLink ID="LinkMe" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_Add.aspx" Visible="False">[LinkMe]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 121px">&nbsp;</td>
            <td style="width: 444px">&nbsp;</td>
            <td style="width: 124px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 121px">&nbsp;</td>
            <td style="width: 444px">&nbsp;</td>
            <td style="width: 124px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
        </div>
    </asp:Content>