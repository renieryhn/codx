<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmPaises_Add.aspx.vb" Inherits="smx.wfmPaises_Add" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="True" Int="False" FieldName="id" Align="Izquierda" 
                        MaxLength="4" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="350" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Paises/wfmPaises_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Paises/wfmPaises_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>

</asp:Content>


