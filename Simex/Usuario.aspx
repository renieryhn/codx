<%@ Page Language="VB" MasterPageFile="Site.Master" CodeBehind="Usuario.aspx.vb" Inherits="smx._Usuario" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>

<%@ Register src="Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <div class ="DD">
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style19"></td>
            <td class="auto-style17"></td>
            <td class="auto-style18">
                <strong>Utilice esta pantalla para cambiar sus datos.</strong><br />
                Por favor escriba su Email, éste le servirá al momento de recuperar la contraseña.</td>
            <td class="auto-style18"></td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">
                Fotografía:</td>
            <td>
                <asp:Image ID="imgFoto" runat="server" ImageUrl="~/Imagenes/oficial.png" BackColor="Black" BorderColor="#666666" BorderStyle="Solid" BorderWidth="3px" Height="230px" Width="220px" />
                <br />
                
                <asp:Button ID="btnQuitar" runat="server" Height="30px" Text="Quitar Foto" Width="99px" CausesValidation="False" CssClass="btn" />
                <asp:FileUpload ID="upFoto" runat="server" Height="30px" CssClass="btn" />
                <asp:Button ID="btnCargar" runat="server" Height="30px" Text="Cargar Foto" Width="99px" CausesValidation="False" CssClass="btn" />
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21"></td>
            <td class="auto-style6">Usuario:</td>
            <td class="auto-style4">
<uc1:TextBox ID="txtNombre" runat="server" Habilitado="False" 
Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" MaxLength="50" width="300" />
<uc1:TextBox ID="txtCodigo" runat="server" Habilitado="False" 
Obligatorio="True" FieldName="id" Int="False" Align="Izquierda" MaxLength="50" width="300" Visible="False" />
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style8">Email:</td>
            <td class="auto-style9">
                    <uc1:TextBox ID="txtEmail1" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Email1" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" EnableViewState="True" MensajeError="Por favor escriba su diracción de correo electrónico" />
                </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style23"></td>
            <td class="auto-style11"></td>
            <td class="auto-style12"><strong>Datos de la Nueva Contraseña: </strong></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">Contraseña:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" MaxLength="25" TextMode="Password"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Escriba su contraseña">*</asp:RequiredFieldValidator>
                Tamaño máximo de la contraseña es 25 caracteres.</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">Repita la Contraseña:</td>
            <td>
                <asp:TextBox ID="txtPassword0" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" MaxLength="25" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword0" ErrorMessage="Escriba su contraseña">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style24"></td>
            <td class="auto-style14"></td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                                <asp:Button ID="Aceptar" runat="server" BorderStyle="Solid" BorderWidth="1px" CommandName="Aceptar" Font-Names="Verdana" Font-Size="Small" style="margin-left: 0px; text-align: center;" Text="Guardar" ValidationGroup="Login12" Width="135px" CssClass="btn" />
                            &nbsp;
                                <asp:Button ID="Cancelar" runat="server" BorderStyle="Solid" BorderWidth="1px" CommandName="Aceptar" Font-Names="Verdana" Font-Size="Small" style="margin-left: 0px; text-align: center;" Text="Cancelar" ValidationGroup="Login12" Width="135px" CssClass="btn" />
                            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </div>
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 147px;
        }
        .auto-style6 {
            height: 23px;
            width: 147px;
        }
        .auto-style8 {
            width: 147px;
            height: 24px;
        }
        .auto-style9 {
            height: 24px;
        }
        .auto-style11 {
            height: 10px;
            width: 147px;
        }
        .auto-style12 {
            height: 10px;
        }
        .auto-style14 {
            width: 147px;
            height: 18px;
        }
        .auto-style15 {
            height: 18px;
        }
        .auto-style17 {
            width: 147px;
            height: 64px;
        }
        .auto-style18 {
            height: 64px;
        }
        .auto-style19 {
            width: 237px;
            height: 64px;
        }
        .auto-style20 {
            width: 237px;
        }
        .auto-style21 {
            height: 23px;
            width: 237px;
        }
        .auto-style22 {
            width: 237px;
            height: 24px;
        }
        .auto-style23 {
            height: 10px;
            width: 237px;
        }
        .auto-style24 {
            width: 237px;
            height: 18px;
        }
    </style>
</asp:Content>



