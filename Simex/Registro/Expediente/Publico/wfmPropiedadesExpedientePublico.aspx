<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmPropiedadesExpedientePublico.aspx.vb" Inherits="smx.wfmPropiedadesExpedientePublico" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="15" 
                        EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" Width="571px" >
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" 
                DataFormatString="{0:dd/MM/yyyy}" />
        </Columns>
        <EmptyDataRowStyle ForeColor="#FF3300" />
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
