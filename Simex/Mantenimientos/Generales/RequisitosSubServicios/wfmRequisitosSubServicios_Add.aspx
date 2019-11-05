﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRequisitosSubServicios_Add.aspx.vb" Inherits="smx.wfmRequisitosSubServicios_Add" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<table class="DD" style="width: 571px">
            <tr>
                <td class="style2" align="left" style="width: 122px; height: 26px;">
                    Servicio</td>
                <td colspan="3" style="height: 26px">
                <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" FieldName="idServicio"
                    idFieldName="ID" postBack="True" TableName="Servicios" textFieldName="Nombre" />
                    </td>
                <td style="width: 100px; height: 26px;">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 30px; width: 122px">
                    SubServicio</td>
                <td style="height: 30px; width: 165px" colspan="2">
                <uc2:ComboBox ID="cboSubServicios" runat="server" AutoFill="True" FieldName="idSubServicio"
                    idFieldName="Codigo" idParentComboBox="idServicio" 
                    TableName="SubServicios" textFieldName="Nombre"
                    AditionalCondition="indEstado='A'" postBack="False" />
                </td>
                <td colspan="2" style="height: 30px">
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 30px; width: 122px">
                    Requsito</td>
                <td style="height: 30px; width: 165px" colspan="2">
                    <uc2:ComboBox ID="cboRequisitos" runat="server" AutoFill="True" 
                        FieldName="idRequisito" idFieldName="id" TableName="Requisitos" 
                        textFieldName="Nombre" Ordenacion="Nombre" />
                </td>
                <td colspan="2" style="height: 30px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    Estado</td>
                <td style="height: 23px; width: 69px;">
                    <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
                </td>
                <td style="height: 23px">
                    </td>
                    <td colspan="2" style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    </td>
                <td style="height: 23px; " colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 122px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td colspan="4">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>
