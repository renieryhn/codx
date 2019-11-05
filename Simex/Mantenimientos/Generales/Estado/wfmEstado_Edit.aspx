<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmEstado_Edit.aspx.vb" Inherits="smx.wfmEstado_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD">
            <tr>
                <td class="style2" align="left" style="width: 112px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 112px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 29px; width: 112px;">
                    <asp:Label ID="Label4" runat="server" Text="Tiempo"></asp:Label>
                &nbsp;Promedio</td>
                <td style="height: 29px">
                    <asp:TextBox ID="txtTiempo" runat="server" Width="50px" MaxLength="2"></asp:TextBox>
                    <asp:NumericUpDownExtender ID="txtTiempo_NumericUpDownExtender" runat="server" 
                        Enabled="True" Maximum="1.7976931348623157E+308" 
                        Minimum="-1.7976931348623157E+308" RefValues="" ServiceDownMethod="" 
                        ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                        TargetButtonUpID="" TargetControlID="txtTiempo" Width="100">
                    </asp:NumericUpDownExtender>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 29px; width: 112px;">
                    Tiempo Máximo</td>
                <td style="height: 29px">
                    <asp:TextBox ID="txtTiempoMax" runat="server" Width="50px" MaxLength="2"></asp:TextBox>
                    <asp:NumericUpDownExtender ID="txtTiempoMax_NumericUpDownExtender" runat="server" 
                        Enabled="True" Maximum="50000" 
                        Minimum="0" RefValues="" ServiceDownMethod="" 
                        ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                        TargetButtonUpID="" TargetControlID="txtTiempoMax" Width="100">
                    </asp:NumericUpDownExtender>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="height: 79px; width: 112px;">
                    <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td style="height: 79px">
                    <uc3:DateControl ID="dtFecha" runat="server" FechaHora="False" 
                        FieldName="Fecha" Obligatorio="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 112px; height: 48px">
                    <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
                </td>
                <td style="height: 48px">
                    <asp:RadioButtonList ID="rbEstado" runat="server">
                        <asp:ListItem Value="True">Activo</asp:ListItem>
                        <asp:ListItem Value="False">Inactivo</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 112px; height: 16px">
                    <asp:Label ID="Label3" runat="server" Text="Lugar"></asp:Label>
                </td>
                <td style="height: 16px">
                    <asp:RadioButtonList ID="rbLugar" runat="server">
                        <asp:ListItem Value="I">Interno</asp:ListItem>
                        <asp:ListItem Value="E">Externo</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 112px">
                    Tipo de Estado</td>
                <td>
                    <uc2:ComboBox ID="cboTipoEstado" runat="server" AutoFill="True" 
                        FieldName="idTipoEstado" idFieldName="idTipoEstado" Obligatorio="True" 
                        TableName="TipoEstado" textFieldName="NombreTipoEstado" />
                    </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 112px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Estado/wfmEstado_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Estado/wfmEstado_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>

</asp:Content>