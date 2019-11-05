<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmConstancia_Add.aspx.vb" Inherits="smx.wfmConstancia_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../../../Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<div class="DD">
<div style="width: 636px">
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 104px">
    <asp:Label ID="Label1" runat="server" Text="Crear Constancia:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 104px">
    <asp:Label ID="lblIdExpediente" runat="server" Text="Expediente: "></asp:Label>
            </td>
            <td>
    <uc1:TextBox ID="TextBox1" runat="server" MaxLength="32" FieldName = "IdExpediente" />
    <asp:Button ID="Button1" runat="server" Text="Verificar" />
            </td>
        </tr>
        <tr>
            <td style="width: 104px">
    <asp:Label ID="ExpedienteDetalle" runat="server" Text="Label" Visible = "false"></asp:Label>
            </td>
            <td>
    <asp:RadioButton ID="rbPJ" runat="server"  Visible ="false" Text="PJ" 
        GroupName="Estilo" />
    <asp:RadioButton ID="rbExtranjeria" runat="server" Visible ="false" Text="E" 
        GroupName="Estilo" />
            </td>
        </tr>
        <tr>
            <td style="width: 104px">
    <asp:Label ID="lblNRF" runat="server" Text="Recibo Finanzas: "></asp:Label>
            </td>
            <td>
    <uc1:TextBox ID="TextBox2" runat="server" FieldName ="NumReciboFinanzas" />
    <asp:Button ID="Button2" runat="server" Text="Verificar" />
    <asp:Label ID="ReciboDetalle" runat="server" Text="Label" Visible = "false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 104px">&nbsp;</td>
            <td>
    <asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Mantenimientos/Generales/Constancia/wfmConstancia_Add.aspx" 
        Visible="False">[linkMe]</asp:HyperLink>
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Mantenimientos/Generales/Constancia/wfmConstancia_list.aspx"
        Visible="False">[linkMain]</asp:HyperLink>
            </td>
        </tr>
    </table>
    <br />
    </div>
    </div>
</asp:Content>
