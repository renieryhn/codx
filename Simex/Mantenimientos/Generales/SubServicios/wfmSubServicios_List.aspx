<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmSubServicios_List.aspx.vb" Inherits="smx.wfmSubServicios_List" MasterPageFile="~/Consulta.Master" %>

<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
	  <br />
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
      
                    <uc1:TextBox ID="txtNombre" runat="server" FieldName="Nombre" Lenght="300" 
                        width="400" MaxLength="60" />
      <br />
                    <asp:Label ID="Label3" runat="server" Text="Servicio"></asp:Label>
      
                    <uc2:ListBox ID="cboServicio" runat="server" 
                    AutoFill="True" FieldName="idServicio" idFieldName="id" 
          TableName="Servicios" Ordenacion="Nombre" Procedimiento="False" 
          textFieldName="Nombre" />      
      <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="codigo" PageSize="20" 
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
                            <asp:BoundField DataField="codigo" HeaderText="Código" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="valor" HeaderText="Valor" />
                            <asp:BoundField DataField="NombreMoneda" HeaderText="Moneda" />
                            <asp:BoundField DataField="NombreEstado" HeaderText="Estado" />
                            <asp:BoundField DataField="codFinanzas" HeaderText="Recibo Finanzas" />
                            <asp:BoundField DataField="Beneficiarios" HeaderText="Beneficiarios" />
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
                        NavigateUrl="~/Mantenimientos/Generales/SubServicios/wfmSubservicios_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/SubServicios/wfmSubservicios_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
      </div>
</asp:Content>


