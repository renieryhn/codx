<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmResoluciones_Edit.aspx.vb" Inherits="smx.wfmResoluciones_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class ="DD">
    <table class="style1" width="571">
            <tr>
                <td class="style2" align="left" style="height: 38px">
                    </td>
                <td style="width: 323px; height: 38px;">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" 
                        Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Resolucion</td>
                <td style="width: 323px">
                    <uc1:TextBox ID="txtNumeroResolucion" runat="server" FieldName="NumeroResolucion" 
                        MaxLength="17" Habilitado="False" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    Expediente</td>
                <td style="width: 323px">
                    <uc1:TextBox ID="txtExpediente" runat="server" FieldName="idExpediente" 
                        MaxLength="17" SoloLectura="False" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    Justificacion</td>
                <td colspan="2" style="height: 23px">
                    <uc1:TextBox ID="txtJustificacion" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Justificacion" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
                <td style="height: 23px">
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 23px; width: 122px">
                    Fecha</td>
                <td style="height: 23px; width: 323px;">

    <uc2:DateControl ID="dtcFecha" runat="server" FechaHora="False" FieldName="Fecha" SoloLectura="True" Obligatorio="True" />

                </td>
                <td colspan="2" style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    &nbsp;&nbsp;<asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td style="width: 323px">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Otros/Resoluciones//wfmResoluciones_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>

