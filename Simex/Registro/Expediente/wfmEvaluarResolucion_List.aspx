<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmEvaluarResolucion_List.aspx.vb" Inherits="smx.wfmEvaluarResolucion_List" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register src="../../Controles/TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="DD" style="font-size: small">
    <br />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="15" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Height="361px" Width="778px" CssClass="mGrid">
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
        <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Evaluar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                       onClientClick="return confirm('Seguro que desea Anular el número de resolución?');" 
                                    CommandName="Delete" Text="Anular"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:BoundField DataField="Id" HeaderText="Codigo" />
            <asp:BoundField DataField="NumResolucion" HeaderText="Resolucion" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha Resolucion" />
            <asp:BoundField DataField="NumResolucion" HeaderText="Evaluación" />
            <asp:BoundField DataField="idUsuario" HeaderText="Usuario" />
            <asp:BoundField HeaderText="Fecha Cambio" DataField="fmodificacion" />
            <asp:BoundField HeaderText="Justificacion" DataField="Justificacion" />
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

                <asp:Panel runat="server" CssClass="modalPopup" 
        ID="pnlAgregarComentario" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
<table style="width: 100%" align="center">
            
                <tr>
                    <td style="width: 129px">
                        <asp:Label ID="Label11" runat="server" Text="Comentario"></asp:Label>
                    </td>
                    <td style="width: 91%">
                        <uc1:TextBox ID="txtComentarios" runat="server" Height="300" MaxLength="4000" 
                            width="400" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 129px">
                        <asp:Button ID="btnAgregarComentario" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 91%">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>
            <br />
<table style="width: 100%" align="center" __designer:mapid="22b">
            
                <tr __designer:mapid="22c">
                    <td style="width: 229px" __designer:mapid="22d">
                        <asp:Label ID="Label1" runat="server" 
                            Text="Justificación:"></asp:Label>
                    </td>
                    <td style="width: 75%" __designer:mapid="22f">
                        <uc1:textbox ID="txtJustificacion" runat="server" Habilitado="True" 
                            Height="200" Obligatorio="True" width="300" />
                    </td>
                </tr>
                
                <tr __designer:mapid="231">
                    <td style="width: 229px" __designer:mapid="232">
                        <asp:Button ID="btnAnularDictamen" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 75%" __designer:mapid="234">
                        <asp:Button ID="btnCancelAnulacion" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
    <br />
    <asp:HyperLink ID="LinkNuevo" runat="server">[LinkNuevo]</asp:HyperLink>
           </div>
</asp:Content>
