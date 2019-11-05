﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAutenticas_Edit.aspx.vb" Inherits="smx.wfmAutenticas_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
        <div class="DD">
    <table class="style1" style="width: 913px">
        <tr>
            <td class="style2" align="left" style="margin-left: 160px; width: 171px;">
                <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </td>
            <td style="width: 245px">
                <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
            </td>
            <td style="width: 127px">
                    &nbsp;</td>
            <td style="width: 235px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="left" style="height: 49px; width: 171px;">
                Numero de Autentica</td>
            <td style="width: 245px; height: 49px;">
                <uc1:TextBox ID="txtNumeroAutentica" runat="server" 
                    FieldName="NumeroAutentica" Habilitado="False" />
            </td>
            <td style="width: 127px; height: 49px;">
                &nbsp;</td>
            <td style="width: 235px; height: 49px;">
                </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 171px">
                <asp:Label ID="Label2" runat="server" Text="Firma que antecede y dice"></asp:Label>
            </td>
            <td style="width: 245px">
                <uc1:TextBox ID="txtFirmaAntecede" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="FirmaAntecede" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
            </td>
            <td style="width: 127px">
                <asp:Label ID="Label16" runat="server" Text="Puesta en caracter de"></asp:Label>
            </td>
            <td style="width: 235px">
                <uc1:TextBox ID="txtPuestaCaracter" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="PuestaCaracter" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 171px">
                    Firma Autorizada</td>
            <td style="width: 245px">
                <uc2:ComboBox ID="cboFirma" runat="server" AutoFill="True" 
                        FieldName="idFirmaSEIP" idFieldName="idEmpleado" 
                        textFieldName="Nombre" 
                    
                    
                    
                    Consulta="SELECT Firmas.id, isnull(Empleados.Nombre1, '') + ' ' + isnull(Empleados.Nombre2, '') + ' ' + isnull(Empleados.Apellido1, '') + ' ' + isnull(Empleados.Apellido2, '') AS Nombre FROM Firmas INNER JOIN Empleados ON Firmas.idEmpleado = Empleados.ID" />
            </td>
            <td style="width: 127px">
                    &nbsp;</td>
            <td style="width: 235px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 171px">
                <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
            </td>
            <td style="width: 245px">
                    <uc3:DateControl ID="dtFechaAutentica" runat="server" FechaHora="True" 
                        FieldName="FechaAutentica" SoloLectura="True" />
            </td>
            <td style="width: 127px">
                    &nbsp;</td>
            <td style="width: 235px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 171px">
                    &nbsp;&nbsp;<asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
            </td>
            <td style="width: 245px">
                <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
            </td>
            <td style="width: 127px">
                    &nbsp;</td>
            <td style="width: 235px">
                    &nbsp;</td>
        </tr>
    </table>
            </div>
</asp:Content>

