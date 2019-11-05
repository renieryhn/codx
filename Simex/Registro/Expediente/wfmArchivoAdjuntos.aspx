<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmArchivoAdjuntos.aspx.vb" Inherits="smx.wfmArchivoAdjuntos" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="fuAdjuntarArchivo" runat="server" BackColor="White" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
    <asp:Button ID="btnAdjuntar" runat="server" Text="Adjuntar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
    <br />
    <asp:GridView ID="gvArchivosAdjuntos" runat="server" Visible = "False" 
        Width="767px" AutoGenerateColumns="False" CellPadding="3" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid">
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" Text="Ver"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                        CommandName="Delete" Text="Borrar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="Nombre" HeaderText="Archivo" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
<asp:BoundField DataField="Tamaño" HeaderText="Tamaño(Mb)"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle HorizontalAlign="Center" CssClass="pgr" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
</asp:Content>
