<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApoderadoEmail.aspx.vb" Inherits="smx.ApoderadoEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 353px;
            text-align: left;
        }
        .auto-style3 {
            width: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
    
        <table class="auto-style1">
            <tr>
                <td colspan="2"><strong><em>INGRESE EL CORREO ELECTRÓNICO DEL APODERADO</em></strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
    
        <asp:TextBox ID="txtId" runat="server" Width="92px" BackColor="White" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" style="text-align: left"></asp:TextBox>
    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
    
        <asp:TextBox ID="txtEmail" runat="server" Width="302px" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
    
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Requerido"></asp:RequiredFieldValidator>
    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
    
        <asp:Button ID="btnSave" runat="server" Text="Guardar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Height="28px" Width="143px" />
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
