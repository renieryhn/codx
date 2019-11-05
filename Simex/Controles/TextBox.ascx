<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TextBox.ascx.vb" Inherits="smx.WebUserControl1" %>
<link href="../Site.css" rel="stylesheet" type="text/css">
<asp:TextBox ID="TextBox1" runat="server" CausesValidation="True" 
    MaxLength="10" CssClass="DDTextBox" BorderColor="Silver" BorderStyle="Solid"></asp:TextBox>
<asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Names="Calibri"></asp:Label>




