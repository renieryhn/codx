<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="wfmConstancia_list.aspx.vb" Inherits="smx.wfmConstancia_list" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../../../Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="DD ">
	    <table style="width: 24%">
            <tr>
                <td style="width: 157px">
    <asp:Label ID="lblNumeroConstancia" runat="server" Text="Numero de constancia: "></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="tbNumeroConstancia" runat="server" FieldName="IdConstancia" 
        Obligatorio="False" MaxLength="64"/>
                </td>
            </tr>
            <tr>
                <td style="width: 157px">
    <asp:Label ID="lblNRF" runat="server" Text="Numero Recibo Finanzas:"></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="tbNumeroRecibo" runat="server" FieldName="NumReciboFinanzas" 
        Obligatorio="False" MaxLength="64" Int="True"/>
                </td>
            </tr>
            <tr>
                <td style="width: 157px">
    <asp:Label ID="lblUsuario" runat="server" FieldName="" Text="Usuario: "></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="tbUsuario" runat="server" FieldName="UsuarioNombre" 
        Obligatorio="False" MaxLength="64" />
                </td>
            </tr>
            <tr>
                <td style="width: 157px">
    <asp:Label ID="lblExpedientes" runat="server" Text="Expedientes:"></asp:Label>
                </td>
                <td>
    <uc1:TextBox ID="tbExpedientes" runat="server" FieldName="IdExpediente" 
        Obligatorio="False" MaxLength="64"/>
                </td>
            </tr>
        </table>
    <br />
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" PageSize="20">
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:BoundField Visible="False" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Constancia" Text="Ver Constancia" CommandArgument="<%# Container.DataItemIndex %>" Target="_blank"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                        CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IdConstancia" HeaderText="Constancia" /> 
            <asp:BoundField DataField="IdExpediente" HeaderText="Expediente" />
            <asp:BoundField DataField="NRF" HeaderText="NRF" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
        </Columns>
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
    <asp:HyperLink ID="linkNuevo" runat="server" NavigateUrl="~/Mantenimientos/Generales/Constancia/wfmConstancia_Add.aspx"
        Visible="False">[linkNuevo]</asp:HyperLink>
    <asp:HyperLink ID="linkModificar" runat="server" NavigateUrl="~/Mantenimientos/Generales/Constancia/wfmConstancia_Edit.aspx"
        Visible="False">[linkModificar]</asp:HyperLink>
        </div>
</asp:Content>
