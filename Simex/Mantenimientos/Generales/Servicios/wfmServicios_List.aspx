<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmServicios_List.aspx.vb" Inherits="smx.wfmServicios_List" MasterPageFile="~/Consulta.Master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
	  <table class="style1" style="width: 636px">
            <tr>
                <td class="style4" style="width: 91px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 868px">
                    <uc1:TextBox ID="txtNombre" runat="server" FieldName="Nombre" Lenght="300" 
                        width="300" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px">
                    </td>
                <td class="style5" style="width: 868px">
                    </td>
            </tr>
            <tr>                
                <td class="style2" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="15" 
                        EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="617px" >
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                        <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Editar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" onClientClick="return confirm('Seguro que desea eliminar el registro?');" 
                                    CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Codigo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="fModificacion" HeaderText="Modificado" />
                            <asp:BoundField DataField="idUsuario" HeaderText="Usuario" />
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
                    <br />
                    <asp:HyperLink ID="linkNuevo" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Servicios/wfmServicios_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Servicios/wfmServicios_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
           </div>
</asp:Content>


