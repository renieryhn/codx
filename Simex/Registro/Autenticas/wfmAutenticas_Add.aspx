<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAutenticas_Add.aspx.vb" Inherits="smx.wfmAutenticas_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
    <table class="style1" style="width: 684px">
            <tr>
                <td class="style2" align="left" style="margin-left: 160px; width: 452px;">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td style="width: 396px">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
                <td style="width: 401px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 452px">
                    <asp:Label ID="Label2" runat="server" Text="Firma que antecede y dice"></asp:Label>
                </td>
                <td style="width: 396px">
                    <uc1:TextBox ID="txtFirmaAntecede" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="FirmaAntecede" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
                <td style="width: 401px">
                    <asp:Label ID="Label16" runat="server" Text="Puesta en caracter de"></asp:Label>
                </td>
                <td style="width: 460px">
                    <uc1:TextBox ID="txtPuestaCaracter" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="PuestaCaracter" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 452px">
                    <asp:Label ID="Label17" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td style="width: 396px">
                    <uc3:DateControl ID="dtcFechaAutentica" runat="server" FechaHora="False" 
                        FieldName="FechaAutentica" />
                </td>
                <td style="width: 401px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 452px">
                    Firma Autorizada</td>
                <td style="width: 396px">
                    <uc2:ComboBox ID="cboFirma" runat="server" AutoFill="True" 
                        FieldName="idEmpleado" idFieldName="idEmpleado" 
                        textFieldName="Nombre" 
                        Consulta="SELECT Firmas.id,isnull(Empleados.Nombre1, '') + ' ' + isnull(Empleados.Nombre2, '') + ' ' + isnull(Empleados.Apellido1, '') + ' ' + isnull(Empleados.Apellido2, '') AS Nombre FROM Firmas INNER JOIN Empleados ON Firmas.idEmpleado = Empleados.ID WHERE (Firmas.Estado = 'A')" />
                </td>
                <td style="width: 401px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 452px">
                    &nbsp;</td>
                <td style="width: 396px">
                    &nbsp;</td>
                <td style="width: 401px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 452px">
                    &nbsp;&nbsp;<asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td style="width: 396px">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
                <td style="width: 401px">
                    &nbsp;</td>
                <td style="width: 460px">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
</asp:Content>