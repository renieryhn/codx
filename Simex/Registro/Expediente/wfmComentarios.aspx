<%@ Page Title="SIMEX/Modulo de Expedientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmComentarios.aspx.vb" Inherits="smx.wfmComentarios" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
                <asp:Panel runat="server" Width="933px" ID="Panel1" Height="24px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" CssClass="mGrid" 
                        AllowSorting="True" DataKeyNames="id" PageSize="15" 
                        EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="670px" >
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
                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                        <asp:BoundField DataField="RecibidoPor" 
                                HeaderText="Recibido Por" />
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
                <asp:Button ID="btnAgregarComentario" runat="server" Text="Comentarios" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" style="height: 24px" />
                <br />

                <asp:Panel runat="server" CssClass="modalPopup" ID="pnlAgregarComentario" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#CCCCCC" Font-Names="Tahoma">
<table style="width: 40%" align="center">
            
                <tr>
                    <td style="width: 129px; height: 356px;">
                        <asp:Label ID="Label11" runat="server" Text="Comentario"></asp:Label>
                    </td>
                    <td style="width: 91%; height: 356px;">
                        <telerik:RadEditor ID="txtComentarios2" Runat="server" Language="es-ES" Height="339px" Width="586px">
                            <Tools>
                                <telerik:EditorToolGroup Tag="MainToolbar">
                                    <telerik:EditorTool Name="FindAndReplace" />
                                    <telerik:EditorSeparator />
                                    <telerik:EditorSplitButton Name="Undo">
                                    </telerik:EditorSplitButton>
                                    <telerik:EditorSplitButton Name="Redo">
                                    </telerik:EditorSplitButton>
                                    <telerik:EditorSeparator />
                                    <telerik:EditorTool Name="Cut" />
                                    <telerik:EditorTool Name="Copy" />
                                    <telerik:EditorTool Name="Paste" ShortCut="CTRL+V / CMD+V" />
                                </telerik:EditorToolGroup>
                                <telerik:EditorToolGroup Tag="Formatting">
                                    <telerik:EditorTool Name="Bold" />
                                    <telerik:EditorTool Name="Italic" />
                                    <telerik:EditorTool Name="Underline" />
                                    <telerik:EditorSeparator />
                                    <telerik:EditorSplitButton Name="ForeColor">
                                    </telerik:EditorSplitButton>
                                    <telerik:EditorSplitButton Name="BackColor">
                                    </telerik:EditorSplitButton>
                                    <telerik:EditorSeparator />
                                    <telerik:EditorDropDown Name="FontName">
                                    </telerik:EditorDropDown>
                                    <telerik:EditorDropDown Name="RealFontSize">
                                    </telerik:EditorDropDown>
                                </telerik:EditorToolGroup>
                            </Tools>
                            <Content>
</Content>
                            <TrackChangesSettings CanAcceptTrackChanges="False" />
                        </telerik:RadEditor>
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 129px">
                        &nbsp;</td>
                    <td style="width: 91%">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td style="width: 129px">&nbsp;</td>
                    <td style="width: 91%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 129px">&nbsp;</td>
                    <td style="width: 91%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 129px">&nbsp;</td>
                    <td style="width: 91%">
                        <asp:Button ID="btnAceptar0" runat="server" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Text="Aceptar" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" Text="Cancelar" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>
            </asp:Panel>
              <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
         <asp:ModalPopupExtender ID="mpeAgregarComentario" runat="server" PopupControlID="pnlAgregarComentario" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelar"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True">
         </asp:ModalPopupExtender>
            
        </asp:Content>



