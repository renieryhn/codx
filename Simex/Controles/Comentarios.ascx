<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Comentarios.ascx.vb" Inherits="smx.Comentarios" %>
<%@ Register src="TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
                <asp:Panel runat="server" CssClass="modalPopup" 
    ID="pnlAgregarComentario" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
<table style="width: 100%" align="center">
            
                <tr>
                    <td style="width: 129px">
                        <asp:Label ID="Label11" runat="server" Text="Comentario" CssClass="DD"></asp:Label>
                    </td>
                    <td style="width: 91%">
                        <uc1:TextBox ID="txtComentarios" runat="server" Height="300" MaxLength="4000" 
                            width="400" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 129px">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 91%">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
         <asp:ModalPopupExtender ID="mpeAgregarComentario" runat="server" PopupControlID="pnlAgregarComentario" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelar"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
