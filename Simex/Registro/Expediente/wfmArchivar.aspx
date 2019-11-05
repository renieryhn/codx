<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmArchivar.aspx.vb" Inherits="smx.wfmArchivar" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode) 
        {
            if (keyCode == 16)
            {
                isShift = false;
            }
        }
        function isNumeric(keyCode) 
        {
            if (keyCode == 16) 
            {
                isShift = true;
            }
            return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 || (keyCode >= 96 && keyCode <= 105)) && isShift == false);
        }
    </script>
   
    <asp:Button ID="btnIdCaja" runat="server" Text="Caja N." BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
    <asp:TextBox ID="tbIdCaja" runat="server" onkeyup = "keyUP(event.keyCode);" onkeydown = "return isNumeric(event.keyCode);" BorderColor="#FF9933" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    <asp:Label ID="lblCajaAntrerior" runat="server" Text="Label" Visible = "False"></asp:Label>
    <br />

        <asp:GridView ID="GVMovimiento" runat="server" AutoGenerateColumns="False"  CssClass="mGrid" 
        CellPadding="3" Width="529px" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:BoundField DataField="CajaAnterior" HeaderText="Caja Anterior" />
            <asp:BoundField DataField="CajaActual" HeaderText="Caja Actual" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="nombre" HeaderText="Usuario" />
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
    <br />
</asp:Content>
