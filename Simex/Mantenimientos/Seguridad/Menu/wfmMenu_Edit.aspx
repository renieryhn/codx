﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmMenu_Edit.aspx.vb" Inherits="smx.wfmMenu_Edit" MasterPageFile="~/Propiedades.Master" %>
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
                        Habilitado="False" Int="True" FieldName="MenuId" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Descipción"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtDescripcion" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Descripcion" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label3" runat="server" Text="Menu Superior"></asp:Label>
                </td>
                <td>
                    <uc2:ListBox ID="cboMenuPadre" runat="server" idFieldName="MenuId" Obligatorio="False" 
                        TableName="Menu" textFieldName="Descripcion" FieldName="PadreId" 
                        AutoFill="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label10" runat="server" Text="Posición"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtPosicion" runat="server" Apariencia="SingleText" 
                        Align="Izquierda" Int="True" Obligatorio="True" FieldName="Posicion" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    <asp:CheckBox ID="cbHabilitado" runat="server" Text="Habilitado" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label5" runat="server" Text="Dirección"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtUrl" runat="server" FieldName="Url" Int="False" 
                        Obligatorio="False" MaxLength="300" width="600" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    </td>
                <td>
                    <asp:CheckBox ID="cbMostrarMenu" runat="server" Text="Mostrar en menu" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/Menu/wfmMenu_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/Menu/wfmMenu_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>

