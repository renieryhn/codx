<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmReciboAdd.aspx.vb" Inherits="smx.wfmReciboAdd" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
        <table style="width: 100%">
            <tr>
                <td style="height: 11px; width: 137px">
    <asp:Label ID="lblOficina" runat="server" Text="Oficina"></asp:Label>
                </td>
                <td style="height: 11px; width: 181px">
    <uc2:ComboBox ID="cboOficina" runat="server" AutoFill="True" FieldName="idOficina" idFieldName="id" TableName="Oficina"  textFieldName="Nombre" />
                </td>
                <td style="height: 11px">    
    <asp:Label ID="lblExpediente" runat="server" Text="Expediente"></asp:Label>
                </td>
                <td style="height: 11px">
    <asp:TextBox ID="tbxIdExpediente" runat="server"></asp:TextBox>
    <asp:Button ID="btnExpediente" runat="server" Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                </td>
            </tr>
            <tr>
                <td style="width: 137px; height: 26px;">Tipo de Servicio</td>
                <td style="width: 181px; height: 26px;">
    <asp:RadioButton ID="rbUsarSubServicioCombo" runat="server" Text="Escojer Subservicio" GroupName="SubServicio" AutoPostBack="True" />
                </td>
                <td style="height: 26px">
    <asp:Label ID="lblServicio" runat="server" Text="Servicio" Visible="False">
    </asp:Label>
                </td>
                <td style="height: 26px">
    <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                            FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" 
                            textFieldName="Nombre" Visible="False" />
                </td>
            </tr>
            <tr>
                <td style="width: 137px; height: 10px;"></td>
                <td style="width: 181px; height: 10px;">
    <asp:RadioButton ID="rbUsarSubServicio" runat="server" Text="Subservicio Con Expediente" GroupName="SubServicio" AutoPostBack="True" />
                </td>
                <td style="height: 10px">
    <asp:Label ID="lblSubServicio" runat="server" Text="Subservicio" Visible="False">
    </asp:Label>
                </td>
                <td style="height: 10px">
    <uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="False" 
                            FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" 
                            TableName="SubServicios" textFieldName="Nombre" 
                    AditionalCondition="indEstado='A'" postBack="True" Visible="False" />
    <asp:label ID="lblSubservicioValue" runat="server" Visible="False"></asp:label>
                </td>
            </tr>
            <tr>
                <td style="width: 137px; height: 10px;">&nbsp;</td>
                <td style="width: 181px; height: 10px;">
    <asp:RadioButton ID="rbUsarSubServicio0" runat="server" Text="Valor Manual" GroupName="SubServicio" Checked="True" AutoPostBack="True" />
                </td>
                <td style="height: 10px">
                    &nbsp;</td>
                <td style="height: 10px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 10px; width: 137px;">
    <asp:Label ID="lblNumRecibo" runat="server" Text="Número recibo Finanzas"></asp:Label>
                </td>
                <td style="height: 10px; width: 181px;">
    <asp:TextBox ID="tbxNumRecibo" runat="server" ValidationGroup="Numrecibo" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" ></asp:TextBox>
                </td>
                <td style="height: 12px">
    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="recibo" />
    <asp:label ID="lblCliente" runat="server" Text="Cliente"></asp:label>
                </td>
                <td style="height: 12px">
    <asp:TextBox ID="tbxCliente" runat="server" ReadOnly="True" Width="222px"></asp:TextBox>
    <asp:label ID="lblClienteKey" runat="server" Visible="False"></asp:label>
    <asp:label ID="lblClienteValue" runat="server" Visible="False"></asp:label>
                </td>
            </tr>
            <tr>
                <td style="height: 12px; width: 137px;">
    <asp:Label ID="lblNumRecibo2" runat="server" Text="Verificación del recibo"></asp:Label>
                </td>
                <td style="height: 12px; width: 181px;">
    <asp:TextBox ID="tbxNumRecibo2" runat="server" ValidationGroup="Numrecibo" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);"></asp:TextBox>
                </td>
                <td style="height: 18px">
    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="recibo" />
    <asp:label ID="lblApoderado" runat="server" Text="Apoderado"></asp:label>
                </td>
                <td style="height: 18px">
    <asp:TextBox ID="tbxApoderado" runat="server" ReadOnly="True" Width="222px"></asp:TextBox>
    <asp:label ID="lblApoderadoKey" runat="server" Visible="False"></asp:label>
    <asp:label ID="lblApoderadoValue" runat="server" Visible="False"></asp:label>
                </td>
            </tr>
            <tr>
                <td style="width: 137px;">
    <asp:Label ID = "lblFechaEmision" runat="server" Text= "Fecha Emisión"></asp:Label>
                </td>
                <td style="width: 181px;">
    <uc3:DateControl ID="dcFechaEmision" runat="server" FechaHora="False" 
        FieldName= "FechaEmision" Obligatorio="False" />
                </td>
                <td>
    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="recibo" />
    <asp:Label ID="lblTercero" runat="server" Text="Tercero:"></asp:Label>
                </td>
                <td>
    <asp:TextBox ID="tbxTercero" runat="server"></asp:TextBox>
    <asp:Button ID="btnExpediente0" runat="server" Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                </td>
            </tr>
            <tr>
                <td style="height: 3px; width: 137px;">
    <asp:label ID="lblPagado" runat="server" Text="Pagado"></asp:label>
                </td>
                <td style="height: 3px; width: 181px;">
    <uc2:ComboBox ID="cboEstadoRecibo" runat="server" AutoFill="True" FieldName="indPagado" idFieldName="id" postBack="False" TableName="Si_No" textFieldName="Nombre" />
                </td>
                <td style="height: 42px">
    <asp:label ID="lblPrecioEnDollares" runat="server" Text="Valor Dolares"></asp:label>
                </td>
                <td style="height: 42px">
    <asp:TextBox ID="tbxPrecioEnDollares" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 137px;">
    <asp:Label ID="lblFechaPago" runat="server" Text="Fecha Pago"></asp:Label>
                </td>
                <td style="width: 181px;">
    &nbsp;
                    <br />
    <uc3:DateControl ID="dcFechaPago" runat="server" FechaHora="False" FieldName="FechaPago" />
                </td>
                <td>
    <asp:label ID="lblPrecioEnLempiras" runat="server" Text="Valor en Lempiras"></asp:label>
                </td>
                <td>
    <asp:TextBox ID="tbxPrecioEnLempiras" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 137px;">
    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                </td>
                <td style="width: 181px;">
    <asp:TextBox ID="tbxCantidad" runat="server" Text="1" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);"></asp:TextBox>
    <asp:Button ID="btnCalcular" runat="server" Text="Calcular Valor en Lps." BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                </td>
                <td>
    <asp:label ID="lblTasaCambio" runat="server" Text="Tasa de Cambio"></asp:label>
                </td>
                <td>
    <asp:TextBox ID="tbxTasaCambio" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 137px">
    <asp:label ID="lblTotalLempiras" runat="server" Text="Total Lempiras"></asp:label>
                </td>
                <td style="width: 181px">
    <asp:TextBox ID="tbxLempiras" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 137px">
    <asp:label ID="lblObservacionesTercero" runat="server" Text="Observacion"></asp:label>
                </td>
                <td style="width: 181px">
    <asp:TextBox ID="tbxObservacionesTercero" runat="server"></asp:TextBox>
                </td>
                <td>
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_List.aspx"  Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
    <asp:HyperLink ID="LinkMe" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmReciboAdd.aspx" Visible="False">[LinkMe]</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td style="width: 137px">
                    &nbsp;</td>
                <td style="width: 181px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 137px">
                    &nbsp;</td>
                <td style="width: 181px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode)
        {
            if (keyCode == 16)
            {
                isShift = false;
            }
        }
        function isNumeric(keyCode) 
        {
            if (keyCode == 16) 
            {
                isShift = true;
            }
            return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 || (keyCode >= 96 && keyCode <= 105)) && isShift == false);
        }
    </script>
    <asp:Label ID="lblMesajeRecibo" runat="server" Text="ingrese correctamente el número de recibo" Visible="False" ForeColor="Red"></asp:Label>
    <br />
    <br />
        </div>
</asp:Content>
