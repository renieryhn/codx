<%@ Page Language="VB" MasterPageFile="Site.Master" CodeBehind="Default.aspx.vb" Inherits="smx._Default" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    

    
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Usuario.aspx">Cambiar mi Contraseña</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    

    
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>



