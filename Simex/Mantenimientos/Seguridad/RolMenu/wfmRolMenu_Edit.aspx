﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRolMenu_Edit.aspx.vb" Inherits="smx.wfmRolMenu_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
<table class="DD">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Rol"></asp:Label>
                </td>
                <td>
                    <uc2:ListBox ID="cbRol" runat="server" AutoFill="True" FieldName="idRol" 
                        idFieldName="id" Obligatorio="True" postBack="False" TableName="Rol" 
                        textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label3" runat="server" Text="Menú"></asp:Label>
                </td>
                <td>
                    <uc2:ListBox ID="cboMenu" runat="server" FieldName="Menuid" 
                        idFieldName="Menuid" TableName="Menu" textFieldName="Descripcion" 
                        AutoFill="True" 
                        Obligatorio="True" ClientIDMode="Inherit" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    <asp:CheckBox ID="chkAlta" runat="server" Text="Alta" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    <asp:CheckBox ID="chkModificacion" runat="server" Text="Modificación" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    <asp:CheckBox ID="chkBorrado" runat="server" Text="Borrado" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/RolMenu/wfmRolMenu_List.aspx" 
                        Visible="False">[HyperLink1]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/RolMenu/wfmRolMenu_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>

