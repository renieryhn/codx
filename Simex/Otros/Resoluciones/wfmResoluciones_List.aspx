<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmResoluciones_List.aspx.vb" Inherits="smx.wfmResoluciones_List" MasterPageFile="~/Consulta.Master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="DD">
<table class="style1" style="width: 969px">
            <tr>
                <td class="style4" style="width: 91px">
                    Resolucion</td>
                <td align="left" class="style5" style="width: 868px">
                    <uc1:TextBox ID="txtResolucion" runat="server" FieldName="NumResolucion" Lenght="300" 
                        width="300" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px">
                    &nbsp;</td>
                <td class="style5" style="width: 868px">
                </td>
            </tr>
            <tr>                
                <td class="style2" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="15" 
                        EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" Width="617px" >
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
                            <asp:BoundField DataField="NumeroResolucion" HeaderText="Resolucion" />
                            <asp:BoundField DataField="Seccion" HeaderText="Sección" />
                            <asp:BoundField DataField="idExpediente" HeaderText="Expediente" />
                            <asp:BoundField DataField="Justificacion" HeaderText="Justificacion" />
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
                        NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Otros/Resoluciones/wfmResoluciones_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
              </div>
</asp:Content>

