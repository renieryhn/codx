<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="wfmDispensaEdicto_List.aspx.vb" Inherits="smx.wfmDispensaEdicto_List" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="DD">
<table class="style1" style="width: 969px">
            <tr>
                <td style="width: 269px">
                    <asp:Label ID="Label2" runat="server" Text="Numero de acuerdo"></asp:Label>
                </td>
                <td align="left">
                    <uc1:TextBox ID="txtNumAcuerdoEdicto" runat="server" 
                        FieldName="NumAcuerdoEdicto" Lenght="300" 
                        width="100" MaxLength="12" />
                </td>
                <td align="left" class="style5" style="width: 346px">
                    <asp:Label ID="Label7" runat="server" Text="Firma Autorizada"></asp:Label>
                </td>
                <td align="left" class="style5" style="width: 795px">
                    <uc2:ListBox ID="cboFirmaAutorizada" runat="server" AutoFill="True" 
                        FieldName="idFirmaAutorizada" TableName="pFirma_List" 
                        Procedimiento="True" />
                </td>
            </tr>
            <tr>
                <td style="width: 269px">
                    <asp:Label ID="Label3" runat="server" Text="Nombre EL"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombreEl" runat="server" FieldName="NombreEl" Lenght="300" 
                        width="300" MaxLength="60" />
                </td>
                <td class="style5" style="width: 346px">
                    <asp:Label ID="Label8" runat="server" Text="Departamento"></asp:Label>
                </td>
                <td class="style5" style="width: 795px">
                    <uc2:ListBox ID="cboDepartamento" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td style="width: 269px">
                    <asp:Label ID="Label4" runat="server" Text="Nombre ELLA"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombreElla" runat="server" FieldName="NombreElla" Lenght="300" 
                        width="100" MaxLength="60" />
                </td>
                <td class="style5" style="width: 346px">
                    <asp:Label ID="Label9" runat="server" Text="Municipio"></asp:Label>
                </td>
                <td class="style5" style="width: 795px">
                    <uc2:ListBox ID="cboMunicipio" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        TableName="Municipio" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td style="width: 269px">
                    <asp:Label ID="Label5" runat="server" Text="Identidad EL"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtIdentidadEl" runat="server" FieldName="IdentidadEl" Lenght="300" 
                        width="100" MaxLength="15" />
                </td>
                <td class="style5" style="width: 346px">
                    <asp:Label ID="Label10" runat="server" Text="Fecha de Registro desde"></asp:Label>
                </td>
                <td class="style5" style="width: 795px">
                    <uc3:DateControl ID="dtcFechaDispensaEdictoDesde" runat="server" 
                        FechaHora="False" FieldName="FechaDispensaEdictoDesde" />
                </td>
            </tr>
            <tr>
                <td style="width: 269px">
                    <asp:Label ID="Label6" runat="server" Text="Identidad ELLA"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtIdentidadElla" runat="server" FieldName="IdentidadElla" Lenght="300" 
                        width="100" MaxLength="15" />
                </td>
                <td class="style5" style="width: 346px">
                    <asp:Label ID="Label11" runat="server" Text="Fecha de Registro hasta"></asp:Label>
                </td>
                <td class="style5" style="width: 795px">
                    <uc3:DateControl ID="dtcFechaDispensaEdictoHasta" runat="server" 
                        FechaHora="False" FieldName="FechaDispensaEdictoHasta" />
                </td>
            </tr>
            <tr>                
                <td class="style2" colspan="2">
                    <br />
                    <asp:HyperLink ID="linkNuevo" runat="server" 
                        NavigateUrl="~/Registro/DispensasEdicto/wfmDispensaEdicto_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Registro/DispensasEdicto/wfmDispensaEdicto_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
                </td>
                <td class="style2" style="width: 346px">
                    <br />
                </td>
                <td class="style2" style="width: 795px">
                    &nbsp;</td>
            </tr>
        </table>
           <div>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="15" 
                        EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid" >
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
                            <asp:BoundField DataField="NumAcuerdoEdicto" HeaderText="Acuerdo" />
                            <asp:BoundField DataField="FechaEdicto" HeaderText="Fecha" />
                            <asp:BoundField DataField="NombreClienteEl" HeaderText="El" />
                            <asp:BoundField DataField="NombreClienteElla" HeaderText="Ella" />
                            <asp:BoundField DataField="FirmaAutorizada" HeaderText="Firma Autorizada" />
                            <asp:BoundField DataField="NombreDepartamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="NombreMunicipio" HeaderText="Municipio" />
                            <asp:BoundField DataField="fModificacion" HeaderText="Modificado" />
                            <asp:BoundField DataField="idUsuario" HeaderText="Usuario" />
                            
                        </Columns>
                        <EmptyDataRowStyle ForeColor="#FF3300" />
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle HorizontalAlign="Center" CssClass="pgr" />
                        <RowStyle ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>

           </div>
           </div>
</asp:Content>
