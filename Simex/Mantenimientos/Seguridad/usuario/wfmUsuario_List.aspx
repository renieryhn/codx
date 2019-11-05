<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmUsuario_List.aspx.vb" Inherits="smx.wfmUsuario_List" MasterPageFile="~/Consulta.master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
<div class="DD">    
    <table style="width: 100%; height: 108px;">
        <tr>
            <td style="width: 172px; height: 18px;"></td>
            <td style="height: 18px">
                <asp:RadioButton ID="rbtnActivo" runat="server" Checked="True" GroupName="Estado" Text="Activos" />
                <asp:RadioButton ID="rbtnInactivo" runat="server" GroupName="Estado" Text="Inactivos" />
            </td>
        </tr>
        <tr>
            <td style="width: 172px">    
<asp:Label ID="Label1" runat="server" Text="Rol"></asp:Label>
            </td>
            <td>
<uc2:ListBox ID="cbRol" runat="server" FieldName="idRol" idFieldName="id" TableName="Rol" textFieldName="Nombre" AutoFill="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 172px">
<asp:Label ID="Label2" runat="server" Text="Ubicacion"></asp:Label>
            </td>
            <td>
<uc2:ListBox ID="cbUbicacion" runat="server" FieldName="idUbicacion" idFieldName="id" TableName="Ubicacion" textFieldName="Nombre" AutoFill="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 172px">
<asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtNombre" runat="server" FieldName="Nombre" Lenght="300" width="300" MaxLength="32" />
            </td>
        </tr>
    </table>
<br />
    <div id="GridView">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" 
AllowSorting="True" DataKeyNames="id" EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" PageSize="20" >
    <AlternatingRowStyle CssClass="alt" />
<Columns>
<asp:TemplateField ShowHeader="False">
    <ItemTemplate>
        <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
        <ItemTemplate>
        <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" onClientClick="return confirm('Seguro que desea eliminar el registro?');" 
        CommandName="Delete" Text="Eliminar"></asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="id" HeaderText="Codigo" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Rol" HeaderText="Rol" />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
        <asp:BoundField DataField="FechaUltimoIngreso" HeaderText="F. Ultimo Ingreso" />
        <asp:BoundField DataField="CargaTrabajo" HeaderText="Carga Trabajo" />
        <asp:BoundField DataField="Estado" HeaderText="Inactivo" />
        <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" />
        <asp:BoundField DataField="NombreEmpleado" HeaderText="Empleado" />
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
         <asp:HyperLink ID="linkNuevo" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_Add.aspx" 
         Visible="False">[linkNuevo]</asp:HyperLink>
         <asp:HyperLink ID="linkModificar" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_Edit.aspx" 
         Visible="False">[linkModificar]</asp:HyperLink>               
    </div>
</div>

  </asp:Content>





