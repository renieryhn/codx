<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="smx.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CODEX</title>
    <link id="simex" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />  
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 448px;
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

        .auto-style6 {
            width: 504px;
            height: 454px;
        }
        .auto-style22 {
            width: 16px;
        }
        .auto-style16 {
            text-align: left;
        }
        .auto-style18 {
            width: 90px;
        }
        .auto-style21 {
            width: 234px;
        }
        .auto-style23 {
            width: 16px;
            text-align: left;
        }
    
        .auto-style24 {
            height: 458px;
        }
           
  .footerx {
    position : absolute;
    bottom : 0;
    height : 150px;
   
  }

    </style>
</head>
<body style="background-position: center center; background-image: url('../Imagenes/simex_fondo.jpg'); " >
    <form id="form1" runat="server" defaultfocus="UserName">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
<div style="text-align: center;">
   <div style="width: 522px; margin-left: auto; margin-right:auto; background-image: url('../Imagenes/ribbon_orange.png'); background-repeat: no-repeat; height: 453px;">
 
       <table class="auto-style1">
           <tr>
               <td class="auto-style24">
                 
        <table cellpadding="30" cellspacing="0" style="border-collapse:collapse;">
            <tr>
                <td style="background-image: url('../Imagenes/ribbon_orange.png'); background-repeat: no-repeat; background-position: center center; font-family: tahoma; font-size: medium;" class="auto-style6">
                    <table cellpadding="0" style="height:148px; width:390px; position: relative; top: 64px; left: 30px; color: #FFFFFF;">
                        <tr>
                            <td align="center" class="auto-style22" style="color:Black;font-style:italic;">&nbsp;</td>
                            <td class="auto-style16" colspan="2" style="color:#FFFFFF; font-style:italic; font-weight: 700;">Inicio de Sesión</td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style22">
                                &nbsp;</td>
                            <td align="left" class="auto-style18"><strong>Usuario:</strong></td>
                            <td class="auto-style21">
                                <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em" Width="200px" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Height="20px" MaxLength="150"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Debe ingresar su nombre de usuario" ToolTip="Debe ingresar su nombre de usuario" ValidationGroup="Login12">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style22">
                                &nbsp;</td>
                            <td align="left" class="auto-style18">
                                <strong>Contraseña:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="auto-style21">
                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password" Width="200px" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Height="20px" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Debe ingresar su contraseña" ToolTip="Debe ingresar su contraseña" ValidationGroup="Login12">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="color:Red;" class="auto-style23">
                                &nbsp;</td>
                            <td colspan="2" style="color:Red;" class="auto-style16">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">
                                &nbsp;</td>
                            <td colspan="2" class="auto-style16">
                                <asp:Button ID="LoginButton" runat="server" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" Font-Size="Small" style="margin-left: 0px; text-align: center;" Text="Ingresar" ValidationGroup="Login12" Width="135px" CssClass="btn" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" ForeColor="#FF6600" NavigateUrl="~/Autenticacion/RecuperarClave.aspx">¿Olvidó su Contraseña?</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                 
               </td>
           </tr>
       </table>
 
   </div>
</div >

<div id="footerx" style="font-family: tahoma; font-size: x-small; color: #FFFFFF">
    
</div>
    </form>
</body>
</html>