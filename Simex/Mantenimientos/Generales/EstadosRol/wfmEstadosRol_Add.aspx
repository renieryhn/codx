<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmEstadosRol_Add.aspx.vb" Inherits="smx.wfmEstadosRol_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<table class="DD" style="width: 571px">
            <tr>
                <td class="style2" align="left" style="width: 122px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td colspan="3">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
                <td style="width: 100px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 30px; width: 122px">
                    Rol</td>
                <td style="height: 30px; width: 165px" colspan="2">
                    <uc2:ComboBox ID="cboRoles" runat="server" AutoFill="True" 
                        FieldName="idRol" idFieldName="id" Obligatorio="False" 
                        TableName="Rol" textFieldName="Nombre" Ordenacion="Nombre" />
                </td>
                <td colspan="2" style="height: 30px">
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 30px; width: 122px">
                    Estado</td>
                <td style="height: 30px; width: 165px" colspan="2">
                    <uc2:ComboBox ID="cboEstados" runat="server" AutoFill="True" FieldName="idEstado" 
                        idFieldName="id" TableName="Estado" textFieldName="Nombre" Ordenacion="Nombre" />
                </td>
                <td colspan="2" style="height: 30px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    Permisos</td>
                <td style="height: 23px; width: 69px;">
                    <asp:CheckBox ID="chkEnviar" runat="server" Text="Enviar" />
                </td>
                <td style="height: 23px">
                    </td>
                <td colspan="2" style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    </td>
                <td style="height: 23px; width: 69px;">
                    <asp:CheckBox ID="chkRecibir" runat="server" Text="Recibir" />
                </td>
                <td style="height: 23px">
                    </td>
                <td colspan="2" style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 122px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/EstadosRol/wfmEstadosRol_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td colspan="4">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/EstadosRol/wfmEstadosRol_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>
