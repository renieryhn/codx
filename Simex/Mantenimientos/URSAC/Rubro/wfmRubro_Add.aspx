<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRubro_Add.aspx.vb" Inherits="smx.wfmRubro_Add" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <div class="DD">
    <table style="width: 100%">
        <tr>
            <td style="width: 99px">

                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                    </td>
            <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                        </td>
        </tr>
        <tr>
            <td style="width: 99px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                
                    </td>
            <td>
                
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
        </tr>
    </table>
                <p>
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/URSAC/Rubro/wfmRubro_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/URSAC/Rubro/wfmRubro_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </p>
    </div>
</asp:Content>



