﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmEstadosRol_Edit.aspx.vb" Inherits="smx.wfmEstadosRol_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <table class="DD" width="571">
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:TextBox ID="txtidRol" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="idRol" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    </td>
                <td colspan="2">
                    <uc1:TextBox ID="txtidEstado" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="idEstado" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    Rol</td>
                <td colspan="2">
                    <uc2:ComboBox ID="cboRoles" runat="server" AutoFill="True" 
                        FieldName="idRol" idFieldName="id" Obligatorio="False" 
                        TableName="Rol" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 99px">
                    Estado</td>
                <td colspan="3" style="height: 23px; width: 178px;">
                    <uc2:ComboBox ID="cboEstados" runat="server" AutoFill="True" FieldName="idEstado" 
                        idFieldName="id" TableName="Estado" textFieldName="Nombre" />
                </td>
                <td style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 99px">
                    Permisos</td>
                <td style="height: 23px; width: 110px;">
                    <asp:CheckBox ID="chkEnviar" runat="server" Text="Enviar" />
                </td>
                <td style="height: 23px; width: 222px;">
                    </td>
                <td colspan="2" style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 99px">
                    </td>
                <td style="height: 23px; width: 110px;">
                    <asp:CheckBox ID="chkRecibir" runat="server" Text="Recibir" />
                </td>
                <td style="height: 23px; width: 222px;">
                    </td>
                <td colspan="2" style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/EstadosRol/wfmEstadosRol_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td colspan="2">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/EstadosRol/wfmEstadosRol_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>

