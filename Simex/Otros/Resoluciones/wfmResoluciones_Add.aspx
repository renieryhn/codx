<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmResoluciones_Add.aspx.vb" Inherits="smx.wfmResoluciones_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class ="DD">
    <asp:Label ID="Label1" runat="server" Text="Justificacion"></asp:Label>
    <uc1:TextBox ID="txtJustificacion" runat="server" Habilitado="True" Obligatorio="False" FieldName="Justificacion" Int="False" Align="Izquierda" MaxLength="400" width="250" EnableViewState="True" Height="100" Apariencia="Multiline" />
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_List.aspx" Visible="False">[linkMain]</asp:HyperLink>
    <asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_Add.aspx" Visible="False">[linkMe]</asp:HyperLink>
    </div>
</asp:Content>
