<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmDicResMas.aspx.vb" Inherits="smx.wfmDicResMas" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class ="DD">
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Otros/Dictamenes/wfmDictamenes_List.aspx" Visible="False">[linkMain]</asp:HyperLink>
    <asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_Add.aspx" Visible="False">[linkMe]</asp:HyperLink>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="height: 38px"></td>
                <td style="width: 144px; height: 38px;"></td>
                <td style="height: 38px;" colspan="2">

                    Este Formulario le permite generar Resoluciones y Dictámentes basados en un número de expediente.
                    <br />
                    Puede carga un archivo de excel que contenga una única Hoja con una sola columna &quot;A&quot; conteniendo los números de Expedientes para los cuales se generarán los Dictamentes o Resuluciones.<br />
                </td>
            </tr>
            <tr>
                <td style="height: 32px"></td>
                <td style="width: 144px; height: 32px;">Selecciones el Tipo de Registro a Generar:</td>
                <td style="width: 199px; height: 32px;">

                    <asp:RadioButton ID="rDic" runat="server" Checked="True" GroupName="GEN" Text="Generar Dictámenes" />
                    <br />
                    <asp:RadioButton ID="rRes" runat="server" GroupName="GEN" Text="Generar Resoluciones" />

                </td>
                <td style="height: 32px">
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">
                    Cargar Archivo:</td>
                <td style="width: 199px">
                    <asp:FileUpload ID="FlUploadcsv" runat="server" Height="35px" Width="341px" />
                    <asp:Button ID="btnLoad" runat="server" CssClass="Boton" Text="Cargar Archivo" Width="234px" Height="44px" />
                    <asp:Label ID="lblMSG" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">
                    Expedientes:</td>
                <td style="width: 199px">
                        <asp:TextBox ID="txtExpediente" runat="server" Width="270px" AutoPostBack="True"></asp:TextBox>
                    &nbsp;*Si desea incluir un expediente, digitelo aquí y presione la tecla &quot;Enter&quot;.</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 144px">
                    &nbsp;</td>
                <td style="width: 199px">
                        <asp:GridView ID="gExp" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="353px">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
