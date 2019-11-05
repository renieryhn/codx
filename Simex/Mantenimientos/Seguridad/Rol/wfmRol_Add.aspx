﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRol_Add.aspx.vb" Inherits="smx.wfmRol_Add" MasterPageFile="~/Propiedades.Master" %>
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
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtDescripcion" runat="server" Height="250" MaxLength="50" 
                        FieldName="Descripcion" width="300" Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/Rol/wfmRol_List.aspx" 
                        Visible="False">[HyperLink1]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/Rol/wfmRol_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>

