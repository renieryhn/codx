<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmSubtipo_Edit.aspx.vb" Inherits="smx.wfmSubtipo_Edit" MasterPageFile="../../../Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
<table class="DD">
            <tr>
                <td class="DD" align="left" style="width: 8%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 8%">
                    <asp:Label ID="Label1" runat="server" Text="Código" Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="False" FieldName="id" Align="Izquierda" 
                        MaxLength="3" Obligatorio="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 8%">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 8%">
                    <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboTipo" runat="server" AutoFill="True" 
                        FieldName="idTipo" idFieldName="id" Obligatorio="True" 
                        TableName="UR_Tipo" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 8%">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/URSAC/Subtipo/wfmSubtipo_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/URSAC/Subtipo/wfmSubtipo_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>

