<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRolMenu_List.aspx.vb" Inherits="smx.RolMenu" MasterPageFile="~/Consulta.Master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
	 <div class="DD">
    
        <table class="style1" style="width: 969px">
            <tr>
                <td style="width: 61px">
                    <asp:Label ID="Label1" runat="server" Text="Rol"></asp:Label>
                </td>
                <td align="left" style="width: 898px">
                    <uc2:ListBox ID="cbRol" runat="server" FieldName="idRol" idFieldName="id" 
                        TableName="Rol" textFieldName="Nombre" AutoFill="True" postBack="True" />
                </td>
            </tr>
            <tr>
                <td style="width: 61px">
                    <asp:Label ID="Label2" runat="server" Text="Menu"></asp:Label>
                </td>
                <td align="left" style="width: 898px">
                    <uc2:ListBox ID="cbMenu" runat="server" FieldName="idMenu" 
                        idFieldName="Menu.MenuId" TableName="Menu, RolMenu" textFieldName="Menu.Descripcion" 
                        AutoFill="True" idParentComboBox="idRol" 
                        AditionalCondition="menu.MenuId=RolMenu.MenuId" Ordenacion="Descripcion" />
                </td>
            </tr>
            <tr>
                <td style="width: 61px">
                    &nbsp;</td>
                <td align="left" style="width: 898px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 898px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="id" PageSize="12" 
                        EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="649px" >
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
                            <asp:BoundField DataField="id" HeaderText="Codigo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Rol" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Menú" />
                            <asp:BoundField DataField="indAlta" 
                                HeaderText="Alta" />
                            <asp:BoundField DataField="indModificacion" HeaderText="Modificación" />
                            <asp:BoundField DataField="indBorrado" HeaderText="Borrado" />
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
                        NavigateUrl="~/Mantenimientos/Seguridad/RolMenu/wfmRolMenu_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/RolMenu/wfmRolMenu_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>



