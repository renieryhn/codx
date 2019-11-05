<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmDictamenesEsp_Add.aspx.vb" Inherits="smx.wfmDictamenesEsp_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc2" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class ="DD">
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Otros/Dictamenes/wfmDictamenes_List.aspx" Visible="False">[linkMain]</asp:HyperLink>
    <asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_Add.aspx" Visible="False">[linkMe]</asp:HyperLink>
        <br />
        <table style="width: 100%">
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">&nbsp;</td>
                <td style="width: 199px">

                    Dictámenes Especiales:</td>
                <td>
                    Por favor seleccione una fecha y posteriormente presione el botón &quot;Obtener Múmero Máximo&quot;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">Fecha:</td>
                <td style="width: 199px">

    <uc2:DateControl ID="dtcFecha" runat="server" FechaHora="False" FieldName="Fecha" SoloLectura="False" Obligatorio="True" />

                </td>
                <td>
                    <asp:Button ID="btnGet" runat="server" CssClass="Boton" Text="Obtener Número Máximo" Width="231px" Height="43px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">Número de Dictámen:</td>
                <td style="width: 199px">
                    <uc1:TextBox ID="txtNumeroDictamen" runat="server" FieldName="NumeroDictamen" 
                        MaxLength="17" Habilitado="True" Int="True" SoloLectura="True" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 24px"></td>
                <td style="width: 144px; height: 24px;">Sección:</td>
                <td style="width: 199px; height: 24px;">
                    <uc1:TextBox ID="txtSeccion" runat="server" FieldName="Seccion" 
                        MaxLength="1" Habilitado="True" Int="False" SoloLectura="False" Obligatorio="True" />
                </td>
                <td style="height: 24px">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">Expediente:</td>
                <td style="width: 199px">
                    <uc1:TextBox ID="txtExpediente" runat="server" FieldName="idExpediente" 
                        MaxLength="17" SoloLectura="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">
    <asp:Label ID="Label1" runat="server" Text="Justificacion"></asp:Label>
                    :</td>
                <td style="width: 199px">
    <uc1:TextBox ID="txtJustificacion" runat="server" Habilitado="True" Obligatorio="False" FieldName="Justificacion" Int="False" Align="Izquierda" MaxLength="400" width="250" EnableViewState="True" Height="100" Apariencia="Multiline" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
