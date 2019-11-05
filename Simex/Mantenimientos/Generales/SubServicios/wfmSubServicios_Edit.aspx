<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmSubServicios_Edit.aspx.vb" Inherits="smx.wfmSubServicios_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label8" runat="server" Text="Servicio"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                        FieldName="idServicio" idFieldName="id" TableName="Servicios" 
                        textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigoSubServicio" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Codigo" Int="False" Align="Izquierda" 
                        MaxLength="6" width="50" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="150" width="600" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label4" runat="server" Text="Valor"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtValor" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Valor" Int="False" Align="Izquierda" 
                        MaxLength="25" width="50" Visible="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label5" runat="server" Text="Tipo de moneda"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboMoneda" runat="server" AutoFill="True" 
                        FieldName="indTipoMoneda" idFieldName="id" TableName="TipoMoneda" 
                        textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboEstado" runat="server" AutoFill="True" 
                        FieldName="indEstado" idFieldName="id" TableName="EstadoRegistro" 
                        textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Beneficiarios:</td>
                <td>
                    <uc1:TextBox ID="txtBeneficiarios" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Beneficiarios" Int="False" Align="Izquierda" 
                        MaxLength="2" width="50" Visible="True" MensajeError="Por favor escriba el número de beneficiarios para este subservicio" ValorMaximo="1" ValorMinimo="20" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label7" runat="server" Text="Codigo Finanzas"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtReciboFinanzas" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="CodFinanzas" Int="False" Align="Izquierda" 
                        MaxLength="5" width="50" Visible="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Leyes y Reglameto Asociado</td>
                <td id="tbxLeyesReglamento">
                    <asp:TextBox ID= "tbxLeyesReglamento" runat="server" TextMode="MultiLine" 
                        Height="66px" Width="387px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/SubServicios/wfmSubServicios_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/SubServicios/wfmSubServicios_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>


