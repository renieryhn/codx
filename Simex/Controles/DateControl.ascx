<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DateControl.ascx.vb" Inherits="smx.DateControl" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
        .TextBox
        {
        	background-color:Transparent;
        	border: 1px solid #0066cc;
        }
        
        .Label
        {
        	padding-left:20px;
        }
</style>


<asp:TextBox ID="txtDate" runat="server" Font-Names="Calibri" 
    Font-Size="Small" Height="16px" Width="122px" MaxLength="18" CssClass="DDTextBox" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:ImageButton ID="btnDate" runat="server" 
    ImageUrl="~/Imagenes/ImgCalendario.png" BackColor="Transparent" Height="16px" />
    <cc1:CalendarExtender ID="dteDate" runat="server" TargetControlID="txtDate" Animated="true"
                    PopupPosition="Right" PopupButtonID="btnDate" 
    Format="dd/MM/yyyy"  >
                    </cc1:CalendarExtender>
                    
<asp:Label ID="lblMessage" runat="server" Font-Names="Calibri" 
    Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
<link href="../Site.css" rel="stylesheet" type="text/css">

