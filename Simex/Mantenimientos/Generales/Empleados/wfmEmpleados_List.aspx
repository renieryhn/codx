<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmEmpleados_List.aspx.vb" Inherits="smx.wfmEmpleados_List" MasterPageFile="~/Consulta.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/messageBox.ascx" tagname="messageBox" tagprefix="uc3" %>


<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
	<table class="DD" style="width: 969px">
            <tr>
                <td class="style4" style="width: 91px" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 868px">
                    <uc1:TextBox ID="txtNombre" runat="server" FieldName="Nombre" Lenght="300" 
                        width="500" MaxLength="60" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px" align="left">
                    <asp:Label ID="Label3" runat="server" Text="No. Identidad"></asp:Label>
                </td>
                <td class="style5" style="width: 868px" align="left">
                    <uc1:TextBox ID="txtIdentidad" runat="server" FieldName="NumIdentidad" 
                        width="100" MaxLength="15" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px" align="left">
                    <asp:Label ID="Label4" runat="server" Text="Nacionalidad"></asp:Label>
                </td>
                <td class="style5" style="width: 868px" align="left">
                    <uc2:ListBox ID="cboPais" runat="server" AutoFill="True" FieldName="idPais" 
                        idFieldName="id" TableName="Paises" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px" align="left">
                    <asp:Label ID="Label5" runat="server" Text="Departamento"></asp:Label>
                </td>
                <td class="style5" style="width: 868px" align="left">
                    <uc2:ListBox ID="cboDepartamento" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 91px; height: 30px;" align="left">
                    <asp:Label ID="Label6" runat="server" Text="Municipio"></asp:Label>
                </td>
                <td class="style5" style="width: 868px; height: 30px;" align="left">
                    <uc2:ListBox ID="cboMunicipio" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        postBack="True" TableName="Municipio" textFieldName="Nombre" />
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
                        AllowSorting="True" DataKeyNames="Id" 
                        EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="954px" >
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
                            <asp:BoundField DataField="NumIdentidad" HeaderText="Identidad" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="TelefonoTrabajo" HeaderText="Tel. Trabajo" />
                            <asp:BoundField DataField="TelMovil1" HeaderText="Tel. Movil" />
                            <asp:BoundField DataField="Email1" HeaderText="Email" />
                            <asp:BoundField DataField="NombreDeptoOficina" HeaderText="Oficina" />
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
                        NavigateUrl="~/Mantenimientos/Generales/Empleados/wfmEmpleados_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Empleados/wfmEmpleados_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
            </tr>
        </table>
</asp:Content>
