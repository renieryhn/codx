<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmConstancia_Edit.aspx.vb" Inherits="smx.wfmConstancia_Edit" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../../../Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
        <table style="width: 100%">
            <tr>
                <td style="width: 115px">
    <asp:Label ID="Label1" runat="server" Text="Editar Constancia:"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 115px">
    <asp:Label ID="lblIdExpediente" runat="server" Text="Expediente: "></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="TextBox1" runat="server" Habilitado="False" 
        FieldName="IdConstancia" />
                </td>
            </tr>
            <tr>
                <td style="width: 115px">
    <asp:Label ID="Label2" runat="server" Text="Número Constancia: "></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="TextBox3" runat="server" Habilitado="False" 
        FieldName="IdConstancia" />
                </td>
            </tr>
            <tr>
                <td style="width: 115px">&nbsp;</td>
                <td>
    <asp:RadioButton ID="rbPJ" runat="server"  Visible ="false" Text="PJ" 
        GroupName="Estilo" />
    <asp:RadioButton ID="rbExtranjeria" runat="server" Visible ="false" Text="E" 
        GroupName="Estilo" />
                </td>
            </tr>
            <tr>
                <td style="width: 115px">
    <asp:Label ID="lblNRF" runat="server" Text="Recibo Finanzas: "></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="TextBox2" runat="server" FieldName="NumReciboFinanzas" />
                </td>
            </tr>
            <tr>
                <td style="width: 115px">&nbsp;</td>
                <td>
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Mantenimientos/Generales/Constancia/wfmConstancia_list.aspx"
        Visible="False">[linkMain]</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
