﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmAcuerdoEdicto_Edit.aspx.vb" Inherits="smx.wfmAcuerdoEdicto_Edit" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
<table class="style1">
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
                    <asp:Label ID="Label3" runat="server" Text="Fecha del Acuerdo"></asp:Label>
                </td>
                <td>
                    <uc2:DateControl ID="dFechaAcuerdoEdicto" runat="server" FechaHora="False" 
                        FieldName="FechaAcuerdoEdicto" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Número de Acuerdo"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNumAcuerdoEdicto" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="NumAcuerdoEdicto" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    &nbsp;&nbsp;<asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Registro/AcuerdosEdicto/wfmAcuerdoEdicto_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Registro/AcuerdosEdicto/wfmAcuerdoEdicto_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>