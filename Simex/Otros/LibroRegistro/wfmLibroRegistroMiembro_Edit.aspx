<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmLibroRegistroMiembro_Edit.aspx.vb" Inherits="smx.wfmLibroRegistroMiembro_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="IdJuntaDirectivaDet" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 18px">
                    &nbsp;</td>
                <td style="height: 18px">
            
                <uc4:SolicitanteResponsable ID="Miembro" runat="server" MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" TipoEntidad="Miembro" TipoEntidadCombo="1" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Miembro:</td>
                <td>
                    <label for="dtcfTomaPosesion" __designer:mapid="58d"> <uc2:ComboBox ID="cboPuesto" runat="server" AutoFill="True" FieldName="IdPuesto" idFieldName="id" Obligatorio="True" TableName="UR_PuestoJuntaDirectiva" textFieldName="Nombre" />
                         </label>
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Otros/LibroRegistro/wfmLibroRegistroJuntaDirectiva.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Otros/LibroRegistro/wfmLibroRegistroMiembro_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>