<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="wfmSeguimientoRegistro.aspx.vb" Inherits="smx.wfmSeguimientoRegistro" MasterPageFile="URSubMenu.Master" %>
<%@ MasterType VirtualPath="URSubMenu.Master"%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 237px">
                                            <br />
                                <asp:Button ID="btnRecibir" runat="server" Text="Recibir Expediente" onclientclick="ClientSideClick(this)" BorderStyle="None" CssClass="Boton" Width="189px" UseSubmitBehavior="False" Enabled="False" Height="37px" BackColor="Black" EnableTheming="True" ForeColor="White" />
                    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 237px; height: 18px;">
                                            <asp:HiddenField ID="hActivarEliminacionEspecial" runat="server" Value="False" />
                                        </td>
                                    </tr>
                                </table>
                    
            <asp:Panel runat='server' Width="933px" ID="Panel1" Height="24px">
                <asp:GridView ID="GridView1" runat ="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" CssClass="mGrid" 
                        AllowSorting="True" DataKeyNames="id" 
                        EmptyDataText="No se encontraron registros" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Height="100px" Width="791px" PageSize="9" >
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditar" runat=server CausesValidation="False" 
                                        CommandName="Edit" Text="Editar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEliminar" runat=server CausesValidation="False" onClientClick="return confirm('Seguro que desea eliminar el registro?');" 
                                    CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="Código" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                        <asp:BoundField DataField="RecibidoPor" 
                                HeaderText="Recibido Por" />
                        <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" />
                        <asp:BoundField DataField="AsignadoA" HeaderText="Asignado A" />
                        <asp:BoundField DataField="UsuarioRecibido" HeaderText="Recibido Por" Visible="False" />
                        <asp:BoundField DataField="UsuarioRecibido" HeaderText="Usuario Recibido" />
                    </Columns>
                    <EditRowStyle ForeColor="#FF6600" />
                    <EmptyDataRowStyle ForeColor="#FF3300" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle HorizontalAlign="Center" CssClass="pgr" />
                    <RowStyle ForeColor="#333333" />
                    <SelectedRowStyle Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <br />
                <div class ="" >
                <table>
                    <tr>
                        <td style="width: 112px; height: 20px;">
                            <asp:Label ID="Label15" runat="server" Text=" Nuevo Estado"></asp:Label>
                            :</td>
                        <td style="width: 371px; height: 20px;">
                            <telerik:RadDropDownTree ID="cboNuevoEstado" runat="server" AutoPostBack="True" CheckNodeOnClick="True" Culture="es-ES" DataFieldID="" DataFieldParentID="" DataTextField="" DataValueField="" EnableFiltering="True" ExpandNodeOnSingleClick="True" Height="16px" Width="362px">
                                <DropDownSettings AutoWidth="Enabled" CloseDropDownOnSelection="True" />
                                <FilterSettings Highlight="None" />
                            </telerik:RadDropDownTree>
                        </td>
                        <td style="width: 126px; height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 112px; height: 20px;">
                            <asp:Label ID="Label16" runat="server" Text="Nuevo Empleado"></asp:Label>
                            :</td>
                        <td style="width: 371px; height: 20px;">
                            <telerik:RadDropDownTree ID="cboNuevoEmpleado" runat="server" CheckNodeOnClick="True" Culture="es-ES" DataFieldID="IdEmpleado" DataFieldParentID="IdRol" DataTextField="NombreCompleto" DataValueField="idEmpleado" EnableFiltering="True" ExpandNodeOnSingleClick="True" Height="16px" OnClientEntryAdded="onEntryAdded" OnClientEntryAdding="OnClientEntryAdding1" Width="362px">
                                <DropDownSettings AutoWidth="Enabled" CloseDropDownOnSelection="True" />
                                <FilterSettings Highlight="None" />
                            </telerik:RadDropDownTree>
                        </td>
                        <td style="height: 20px; width: 126px">
                            <asp:Button ID="btnAceptar" runat="server" BorderStyle="None" CssClass="Boton" Enabled="False" Height="39px" onclientclick="ClientSideClick(this)" Text="Cambiar Estado" UseSubmitBehavior="False" Width="167px" BackColor="Black" ForeColor="White" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 112px; height: 27px;">&nbsp;</td>
                        <td style="width: 371px; height: 27px; text-align: right;">
                            &nbsp;</td>
                        <td style="height: 27px; width: 126px">&nbsp;</td>
                    </tr>
                </table>
                </div>

                <br />
                <asp:HyperLink ID="linkNuevo"  runat =server 
                    Visible="False">[linkNuevo]</asp:HyperLink>
                <asp:HyperLink ID="linkModificar" runat =server 
                    Visible="False" NavigateUrl="~/URSAC/wfmAsociacionesCivilesEstado_Edit.aspx">[linkModificar]</asp:HyperLink>

            </asp:Panel>
                                <br />
                                <br />
    </div>    

      <script language="javascript" type="text/javascript">
     function onEntryAdded(sender, eventArgs) {
        /* if (sender.get_count  == 0) {
             eventArgs.set_cancel(true);
         }
         else {
             $(".rddtInner").removeClass("rddtFocused");

         }*/
     }
     function OnClientEntryAdding1(sender, eventArgs) {
         var entry = eventArgs.get_entry()
         if (entry.get_value() >= 10000) {
             eventArgs.set_cancel(true);
         }
     }
     function ClientSideClick(myButton) {
         // Client side validation
         if (typeof (Page_ClientValidate) == 'function') {
             if (Page_ClientValidate() == false)
             { return false; }
         }

         //make sure the button is not of type "submit" but "button"
         if (myButton.getAttribute('type') == 'button') {
             // disable the button
             myButton.disabled = true;
             myButton.className = "btn-inactive";
             myButton.value = "procesando...";
         }
         return true;
     }
     document.onkeydown = KeyDownHandler;
     document.onkeyup = KeyUpHandler;
     var CTRL = false;
     var SHIFT = false;
     var ALT = false;
     var CHAR_CODE = -1;
     function KeyDownHandler(e) {
         var x = '';
         if (document.all) {
             var evnt = window.event;
             x = evnt.keyCode;
         }
         else {
             x = e.keyCode;
         }
         DetectKeys(x, true);
         
         var lblBrand = document.getElementById('<%= hActivarEliminacionEspecial.ClientID%>').value;
         
        if (CTRL == true) {
             lblBrand = "True";
         }
         else {
             lblBrand = "False";
        }
        document.getElementById('<%= hActivarEliminacionEspecial.ClientID%>').value = lblBrand;
     }
     function KeyUpHandler(e) {
         var x = '';
         if (document.all) {
             var evnt = window.event;
             x = evnt.keyCode;
         }
         else {
             x = e.keyCode;
         }
         DetectKeys(x, false);
     }
     function DetectKeys(KeyCode, IsKeyDown) {
         if (KeyCode == '16') {
             SHIFT = IsKeyDown;
         }
         else if (KeyCode == '17') {
             CTRL = IsKeyDown;
         }
         else if (KeyCode == '18') {
             ALT = IsKeyDown;
         }
         else {
             if (IsKeyDown)
                 CHAR_CODE = KeyCode;
             else
                 CHAR_CODE = -1;
         }
     }
    </script> 
</asp:Content>


