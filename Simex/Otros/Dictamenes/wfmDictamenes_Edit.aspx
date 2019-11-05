﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmDictamenes_Edit.aspx.vb" Inherits="smx.wfmDictamenes_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class ="DD">
    <table class="style1" width="571">
            <tr>
                <td class="style2" align="left">
                    &nbsp;</td>
                <td style="width: 323px">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" 
                        Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Dictamen</td>
                <td style="width: 323px">
                    <uc1:TextBox ID="txtNumeroDictamen" runat="server" FieldName="NumeroDictamen" 
                        MaxLength="17" Habilitado="False" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Expediente</td>
                <td style="width: 323px">
                    <uc1:TextBox ID="txtExpediente" runat="server" FieldName="idExpediente" 
                        MaxLength="17" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    Justificacion</td>
                <td colspan="2" style="height: 23px">
                    <uc1:TextBox ID="txtJustificacion" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Justificacion" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
                <td style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    &nbsp;</td>
                <td style="height: 23px; width: 323px;">
                    &nbsp;</td>
                <td colspan="2" style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    &nbsp;&nbsp;<asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Otros/Dictamenes/wfmDictamenes_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td style="width: 323px">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Otros/Dictamenes//wfmDictamenes_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>

