<%@ Page Language="VB" MasterPageFile="~/Site.master" CodeBehind="MovimientoMasivo.aspx.vb" Inherits="smx.MovimientoMasivo" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div style="font-family: tahoma; font-size: medium; vertical-align: middle; text-align: left; height: 548px; background-color: #FFFFFF;">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style3">Ingrese Los Expedientes a Mover</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">
                            <asp:Label ID="Label15" runat="server" Text=" Nuevo Estado" style="text-align: left"></asp:Label>
                    </td>
                    <td class="auto-style4">
                            <uc1:ComboBox ID="cboNuevoEstado" runat="server" AutoFill="False" FieldName="idEstadoAsignado" postBack="True" Procedimiento="True" TableName="pEstado_List" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">
                            <asp:Label ID="Label16" runat="server" Text="Nuevo Empleado"></asp:Label>
                    </td>
                    <td class="auto-style4">
                            <telerik:RadDropDownTree ID="cboNuevoEmpleado" runat="server" CheckNodeOnClick="True" Culture="es-ES" DataFieldID="IdEmpleado" DataFieldParentID="IdRol" DataTextField="NombreCompleto" DataValueField="idEmpleado" EnableFiltering="True" ExpandNodeOnSingleClick="True" Height="16px" OnClientEntryAdded="onEntryAdded" OnClientEntryAdding="OnClientEntryAdding1" Width="362px">
                                <DropDownSettings AutoWidth="Enabled" CloseDropDownOnSelection="True" />
                                <FilterSettings Highlight="None" />
                            </telerik:RadDropDownTree>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">
                        Expediente:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtExpediente" runat="server" Width="270px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:GridView ID="gExp" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="353px">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        <br />
                    </td>
                    <td>
                            &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style3">
                            <asp:Button ID="btnAceptar" runat="server" BorderStyle="None" CssClass="BotonNegro" Height="39px" onclientclick="ClientSideClick(this)" Text="Cambiar Estado" UseSubmitBehavior="False" Width="170px" BorderColor="Black" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    </div>

</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 327px;
        }
        .auto-style4 {
            height: 23px;
            width: 327px;
        }
        .auto-style9 {
            width: 101px;
        }
        .auto-style10 {
            height: 23px;
            width: 101px;
        }
        .auto-style11 {
            width: 151px;
        }
        .auto-style12 {
            height: 23px;
            width: 151px;
        }
        .Boton {}
    </style>

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
    </script> 
</asp:Content>



