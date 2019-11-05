<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RecuperarClave.aspx.vb" Inherits="smx.RecuperarClave" %>

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
            width: 240px;
        }
        .auto-style3 {
            width: 295px;
        }
        .auto-style4 {
            font-size: x-large;
            text-align: center;
            width: 810px;
        }
        .auto-style5 {
            font-size: medium;
        }
        .auto-style6 {
            width: 240px;
            font-size: large;
        }
        .auto-style7 {
            height: 67px;
        }
        .auto-style8 {
            width: 240px;
            font-size: large;
            height: 29px;
        }
        .auto-style9 {
            width: 295px;
            height: 29px;
        }
        .auto-style10 {
            height: 29px;
        }
        .auto-style11 {
            width: 200px;
        }
        .auto-style12 {
            height: 67px;
            width: 200px;
        }
        .auto-style13 {
            height: 67px;
            width: 810px;
        }
        .auto-style14 {
            width: 810px;
        }
        .auto-style16 {
            font-size: x-large;
            text-align: left;
            width: 810px;
            height: 50px;
        }
        .auto-style18 {
            height: 99px;
            width: 200px;
        }
        .auto-style19 {
            height: 99px;
            width: 810px;
        }
        .auto-style20 {
            height: 99px;
        }
        .auto-style21 {
            height: 50px;
            width: 200px;
        }
        .auto-style22 {
            height: 50px;
        }
        .auto-style23 {
            width: 810px;
            text-align: center;
        }
              .btn {
  background: #3498db;
  background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
  background-image: -moz-linear-gradient(top, #3498db, #2980b9);
  background-image: -ms-linear-gradient(top, #3498db, #2980b9);
  background-image: -o-linear-gradient(top, #3498db, #2980b9);
  background-image: linear-gradient(to bottom, #3498db, #2980b9);
  -webkit-border-radius: 28;
  -moz-border-radius: 28;
  border-radius: 28px;
  font-family: Arial;
  color: #ffffff;
  font-size: 20px;
  padding: 10px 20px 10px 20px;
  text-decoration: none;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style21"></td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style4" style="border: thin solid #CCCCCC"><strong style="font-family: tahoma; font-size: x-large; color: #3399FF">Perdió su contraseña</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style4" style="border: thin solid #CCCCCC">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/password_icon.png" Height="97px" Width="110px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style13" style="border: thin solid #CCCCCC">
                    <h1><span class="auto-style5" style="border-style: none; border-color: inherit; border-width: 0px; margin: 0px; padding: 0px; outline: 0px; color: rgb(51, 51, 51); font-family: Helvetica, Arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; line-height: 1.3em; background: rgb(255, 255, 255);">Si perdió su Contraseña (Password), puede recuperarla en ésta pagina, escriba su dirección de correo electrónico y su nombre de usuario, luego presione el botón <strong>&quot;Recuperar&quot;</strong>. De ésta manera usted recibirá su contraseña en su correo electrónico. <strong>RECUERDE</strong>: debe utilizar el mismo correo electrónico registrado en el sistema.<br />
                        </span></h1>
                </td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td style="border: thin solid #CCCCCC; font-family: tahoma;" class="auto-style23">
                    <strong>Por favor especifique la siguiente información</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style14" style="border: thin solid #CCCCCC">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style8" style="font-family: tahoma; font-size: medium;">Escriba su Email:</td>
                            <td class="auto-style9" style="font-family: tahoma">
                                <asp:TextBox ID="txtEmail" runat="server" Width="280px" CssClass="auto-style5" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            </td>
                            <td style="font-family: tahoma" class="auto-style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="El Email es Requerido" CssClass="auto-style5"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6" style="font-family: tahoma; font-size: medium;">Escriba su Nombre de Usuario:</td>
                            <td class="auto-style3" style="font-family: tahoma">
                                <asp:TextBox ID="txtUsuario" runat="server" Width="281px" CssClass="auto-style5" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            </td>
                            <td style="font-family: tahoma">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El nombre de Usuario es Requerido" CssClass="auto-style5"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" style="font-family: tahoma">&nbsp;</td>
                            <td class="auto-style3" style="font-family: tahoma">
                                <asp:Button ID="btnAceptar" runat="server" Text="Recuperar" Width="185px" BackColor="#0099CC" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" Height="48px" CssClass="btn" />
                            </td>
                            <td style="font-family: tahoma">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="El Formato de Email no es correcto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="auto-style19"></td>
                <td class="auto-style20"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
