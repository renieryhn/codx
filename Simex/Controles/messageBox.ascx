<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="messageBox.ascx.vb" Inherits="smx.msgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Panel ID="ModalPanel" runat="server" HorizontalAlign="Center" Style="display: none" BackColor="Gray">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnOk" runat="server" Text="Aceptar" onClick="btnOk_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar"/>
            
    </asp:Panel>

    </div>


