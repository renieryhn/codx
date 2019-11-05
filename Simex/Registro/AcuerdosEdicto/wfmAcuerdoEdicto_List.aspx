<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="wfmAcuerdoEdicto_List.aspx.vb" Inherits="smx.wfmAcuerdoEdicto_List" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
    <table class="style1" style="width: 969px">
            <tr>
                <td class="style4" style="width: 182px">
                    <asp:Label ID="Label2" runat="server" Text="Número de acuerdo de edicto"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 777px">
                    <uc1:TextBox ID="txtNumeroAcuerdo" runat="server" FieldName="NumAcuerdoEdicto" Lenght="300" 
                        width="100" MaxLength="12" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 182px">
                    <asp:Label ID="Label3" runat="server" Text="Fecha de Registro: Inicio:"></asp:Label>
                </td>
                <td class="style5" style="width: 777px">
                    <uc3:DateControl ID="dFechaRegistroDesde" runat="server" FechaHora="False" 
                        FieldName="FechaAcuerdoEdictoDesde" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 182px">
                    <asp:Label ID="Label4" runat="server" Text="Fecha de Registro: Fin:"></asp:Label>
                </td>
                <td class="style5" style="width: 777px">
                    <uc3:DateControl ID="dFechaRegistroHasta" runat="server" FechaHora="False" 
                        FieldName="FechaAcuerdoEdictoHasta" />
                </td>
            </tr>
            <tr>                
                <td class="style2" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" 
                        EmptyDataText="No se encontraron Registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" Width="658px" PageSize="20" >
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
                            <asp:BoundField DataField="NumAcuerdoEdicto" HeaderText="Número Acuerdo" />
                            <asp:BoundField DataField="FechaAcuerdoEdicto" HeaderText="Fecha Acuerdo" 
                                DataFormatString="{0:d}" />
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
                        NavigateUrl="~/Registro/AcuerdosEdicto/wfmAcuerdoEdicto_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Registro/AcuerdosEdicto/wfmAcuerdoEdicto_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
           </div>
 </asp:Content>