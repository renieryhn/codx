<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmUsuario_Add.aspx.vb" Inherits="smx.wfmUsuario" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
<div class="DD">
    <table style="width: 100%">
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" MaxLength="50" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtPassword" runat="server" Apariencia="Password" Obligatorio="True" FieldName="PassWord" Align="Izquierda" MaxLength="25" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label10" runat="server" Text="Confirmar Password"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtConfirmPass" runat="server" Apariencia="Password" Align="Izquierda" MaxLength="25" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label>
            </td>
            <td>
<uc2:ListBox ID="cbRol" runat="server" idFieldName="id" Obligatorio="True" TableName="Rol" textFieldName="Nombre" FieldName="idRol" AutoFill="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label11" runat="server" Text="Empleado"></asp:Label>      
            </td>
            <td>      
<uc2:ListBox ID="cbEmpleado" runat="server" idFieldName="id" Obligatorio="True" 
TableName="Empleados" textFieldName="isnull([Nombre1], '') + ' ' + isnull([Nombre2], '') + ' ' + isnull([Apellido1], '') + ' ' + isnull([Apellido2], '')" FieldName="idEmpleado" AutoFill="True" 
AditionalCondition="Empleados.ID not in (select idempleado from Usuario where idEmpleado is not  null)" Ordenacion="Empleados.ID" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:Label ID="Label9" runat="server" Text="Ubicación"></asp:Label>      
            </td>
            <td>      
<uc2:ListBox ID="cbUbicacion" runat="server" idFieldName="id" Obligatorio="True" TableName="Ubicacion" textFieldName="Nombre" 
FieldName="idUbicacion" AutoFill="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 138px">
<asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_List.aspx" 
Visible="False">[HyperLink1]</asp:HyperLink>                
<asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_Add.aspx" 
Visible="False">[linkMe]</asp:HyperLink>
               </td>
            <td>&nbsp;</td>
        </tr>
    </table>
               </div>
</asp:Content>




