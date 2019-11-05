<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRequisitosSubServicios_List.aspx.vb" Inherits="smx.wfmRequisitosSubServicios_List" MasterPageFile="~/Consulta.Master" %>

<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
	<table class="style1" style="width: 969px">
            <tr>
                <td class="style4" style="width: 91px">
                    Servicio</td>
                <td align="left" class="style5" style="width: 868px">
                <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" FieldName="idServicio"
                    idFieldName="ID" postBack="True" TableName="Servicios" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px">
                    SubServicio</td>
                <td align="left" class="style5" style="width: 868px">
                <uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="True" FieldName="idSubServicio"
                    idFieldName="Codigo" idParentComboBox="idServicio" 
                    TableName="SubServicios" textFieldName="Nombre"
                    AditionalCondition="indEstado='A'" postBack="False" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px">
                    <asp:Label ID="Label2" runat="server" Text="Requisito"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 868px">
                    <uc1:TextBox ID="txtNombre" runat="server" FieldName="NombreRequisito" Lenght="300" 
                        width="300" MaxLength="50" />
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
                        AllowSorting="True" PageSize="12" 
                        EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="870px" >
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
                            <asp:BoundField DataField="idSubServicio" HeaderText="CodigoSubServicio" />
                            <asp:BoundField DataField="NombreSubServicio" HeaderText="SubServicio" />
                            <asp:BoundField DataField="idRequisito" HeaderText="Codigo Requisito" />
                            <asp:BoundField DataField="NombreRequisito" HeaderText="Requisito" />
                            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
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
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
           </div>
</asp:Content>


