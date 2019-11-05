<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmEvaluarDictamen_List.aspx.vb" Inherits="smx.wfmEvaluarDictamen_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register src="../../Controles/TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="DD" style="font-size: small">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="15" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Height="372px" Width="805px" CssClass="mGrid">
        <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <%--<asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Evaluar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Evaluar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                       onClientClick="return confirm('Seguro que desea Anular el dictamen?');" 
                                    CommandName="Delete" Text="Anular"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Codigo" />
            <asp:BoundField DataField="NumeroDictamen" HeaderText="Dictamen" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha Dictamen" />
            <asp:BoundField DataField="Tipo" HeaderText="Evaluación" />
            <asp:BoundField HeaderText="Justificacion" DataField="Justificacion" />
            <asp:BoundField HeaderText="Fecha Cambio" DataField="fmodificacion" />
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

                <asp:Panel runat="server" CssClass="modalPopup" 
        ID="pnlEvaluarDictamen" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
<table align="center">
            
                <tr>
                    <td style="width: 229px">
                        <asp:Label ID="Label11" runat="server" 
                            Text="Seleccione la evaluación del dictamen:"></asp:Label>
                    </td>
                    <td style="width: 75%">
                        <uc2:ComboBox ID="cboEvaluacionDictamen" runat="server" AutoFill="True" 
                            FieldName="Tipo" idFieldName="id" Obligatorio="True" 
                            TableName="EvaluacionDictamen" textFieldName="Nombre" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 229px">
                        <asp:Button ID="btnEvaluarDictamen" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 75%">
                        <asp:Button ID="btnCancelarDictamen" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>
            <br />
            <asp:Panel runat="server" CssClass="modalPopup" 
        ID="pnlAnularDictamen" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
<table align="center">
            
                <tr>
                    <td style="width: 229px">
                        <asp:Label ID="Label1" runat="server" 
                            Text="Justificación:"></asp:Label>
                    </td>
                    <td style="width: 75%">
                        <uc1:textbox ID="txtJustificacion" runat="server" Habilitado="True" 
                            Height="200" Obligatorio="True" width="300" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 229px">
                        <asp:Button ID="btnAnularDictamen" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Dashed" BorderWidth="1px" />
                    </td>
                    <td style="width: 75%">
                        <asp:Button ID="btnCancelAnulacion" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />

         <asp:ModalPopupExtender ID="mpeEvaluarDictamen" runat="server" PopupControlID="pnlEvaluarDictamen" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarDictamen"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
             
 </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeAnularDictamen" runat="server" PopupControlID="pnlAnularDictamen" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarAnulacion"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        
</asp:ModalPopupExtender>

    <asp:HyperLink ID="LinkNuevo" runat="server">[LinkNuevo]</asp:HyperLink>
           </div>
</asp:Content>
