<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmServicios_Add.aspx.vb" Inherits="smx.wfmServicios_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD">
            <tr>
                <td class="style2" align="left" style="width: 169px; height: 12px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td style="height: 12px">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="True" Int="False" FieldName="id" Align="Izquierda" MaxLength="3" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 169px; height: 7px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td style="height: 7px">
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="150" width="600" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 169px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Servicios/wfmServicios_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Servicios/wfmServicios_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>

</asp:Content>


