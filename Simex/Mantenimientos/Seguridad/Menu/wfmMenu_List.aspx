<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmMenu_List.aspx.vb" Inherits="smx.wfmMenuList" MasterPageFile="~/Consulta.master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
	<div class="DD">
    
        <table class="style1" style="width: 969px">
            <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text="Menu Principal"></asp:Label>
                </td>
                <td align="left" class="style5">
                    <uc2:ListBox ID="cbMenuPrincipal" runat="server" FieldName="PadreId" idFieldName="MenuId" 
                        TableName="Menu" textFieldName="Descripcion" AutoFill="True" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td align="left" class="style5">
                    <uc1:TextBox ID="txtDescripcion" runat="server" FieldName="Descripcion" Lenght="300" 
                        width="300" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                
                <td class="style2" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="MenuId" PageSize="12" 
                        EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" >
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
                            <asp:BoundField DataField="MenuId" HeaderText="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="NombrePadre" HeaderText="Menu Principal" />
                            <asp:BoundField DataField="Posicion" 
                                HeaderText="Posición" />
                            <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                            <asp:BoundField DataField="Url" HeaderText="Dirección" />
                            <asp:BoundField DataField="indMostrarMenu" HeaderText="Mostrar en menú" />
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
                        NavigateUrl="~/Mantenimientos/Seguridad/Menu/wfmMenu_Add.aspx" Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Seguridad/Menu/wfmMenu_Edit.aspx" Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
        <style type="text/css">
        .style1
        {
            width: 68px;
        }
        .style2
        {
            width: 79px;
        }
        .style4
        {
            width: 91px;
        }
        .style5
        {
            width: 868px;
        }
    </style>
</asp:Content>











