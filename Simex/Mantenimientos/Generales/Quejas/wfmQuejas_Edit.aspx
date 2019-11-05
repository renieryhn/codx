<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmQuejas_Edit.aspx.vb" Inherits="smx.wfmQuejas_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <div class="DD">
        <table style="width: 100%">
            <tr>
                <td style="width: 119px">
<asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
<uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px">
<asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
<uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
MaxLength="50" width="300" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px">&nbsp;</td>
                <td>
<asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Mantenimientos/Generales/Quejas/wfmQuejas_List.aspx" 
Visible="False">[linkMain]</asp:HyperLink>
<asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Mantenimientos/Generales/Quejas/wfmQuejas_Add.aspx" 
Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
<br />
</div>
</asp:Content>



