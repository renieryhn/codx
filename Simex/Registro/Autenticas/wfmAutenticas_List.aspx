<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAutenticas_List.aspx.vb" Inherits="smx.wfmAutenticas_List" MasterPageFile="~/Consulta.Master" %>

<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
    <table class="style1" style="width: 995px">
            <tr>
                <td class="style4" style="width: 338px">
                    <asp:Label ID="Label2" runat="server" Text="Autentica"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 640px" colspan="2">
                    <uc1:TextBox ID="txtAutentica" runat="server" FieldName="Autentica" Lenght="300" 
                        width="300" />
                </td>
                <td align="left" class="style5" style="width: 868px">
                    &nbsp;</td>
                <td align="left" class="style5" style="width: 868px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 338px">
                    Firma que antecede</td>
                <td class="style5" style="width: 400px">
                    <uc1:TextBox ID="txtFirmaAntecede" runat="server" FieldName="FirmaAntecede" 
                        MaxLength="50" />
                </td>
                <td class="style5" style="width: 868px" colspan="2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 338px; height: 30px;">
                    Puesta en Caracter</td>
                <td class="style5" style="width: 400px; height: 30px;">
                    <uc1:TextBox ID="txtPuestaCaracter" runat="server" FieldName="PuestaCaracter" 
                        MaxLength="50" />
                </td>
                <td class="style5" style="width: 868px; height: 30px;" colspan="2">
                    </td>
                <td class="style5" style="width: 868px; height: 30px;">
                    </td>
            </tr>
            <tr>
                <td class="style4" style="width: 338px">
                    <asp:Label ID="Label3" runat="server" Text="Firma"></asp:Label>
                </td>
                <td class="style5" style="width: 400px">
                    <uc2:ListBox ID="cboFirma" runat="server" AutoFill="True" FieldName="idEmpleado" 
                        idFieldName="idEmpleado" textFieldName="Nombre" 
                        
                        
                        
                        Consulta="SELECT Firmas.id, isnull(Empleados.Nombre1, '') + ' ' + isnull(Empleados.Nombre2, '') + ' ' + isnull(Empleados.Apellido1, '') + ' ' + isnull(Empleados.Apellido2, '') AS Nombre FROM Firmas INNER JOIN Empleados ON Firmas.idEmpleado = Empleados.ID" />
                </td>
                <td class="style5" style="width: 868px" colspan="2">
                    &nbsp;</td>
                <td class="style5" style="width: 868px">
                    &nbsp;</td>
            </tr>
            <tr>
                
                <td class="style2" colspan="5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="11" 
                        EmptyDataText="No se encontraron registros" Width="934px" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" >
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                                      <asp:BoundField Visible="False" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnImprimir" runat="server" CausesValidation="false" CommandName="Autentica" Text="Ver Autentica" CommandArgument="<%# Container.DataItemIndex %>" Target="_blank"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
                            <asp:BoundField DataField="Autentica" HeaderText="Autentica" />
                            <asp:BoundField DataField="FirmaAntecede" HeaderText="Firma que Antecede" />
                            <asp:BoundField DataField="PuestaCaracter" HeaderText="Puesta en Caracter" />
                            <asp:BoundField DataField="NombreFirma" HeaderText="Firma de SEIP" />
                            <asp:BoundField DataField="FechaAutentica" HeaderText="Fecha Auténtica" />
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
                    <asp:HyperLink ID="linkNuevo" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Registro/Autenticas/wfmAutenticas_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
           </div>
</asp:Content>


