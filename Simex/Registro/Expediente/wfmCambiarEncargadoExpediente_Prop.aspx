<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmCambiarEncargadoExpediente_Prop.aspx.vb" Inherits="smx.wfmCambiarEncargadoExpediente_Prop" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc1" %>
<%@ Register src="../../Controles/TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="background-color: #FFFFFF">
<tr>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>

                <asp:Panel runat="server" 
        ID="pnlAgregarComentario" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="White">
<table style="width: 100%" align="center">
            
                <tr>
                    <td style="width: 467px">
                        <asp:Label ID="Label11" runat="server" Text="Comentario"></asp:Label>
                    </td>
                    <td style="width: 81%">
                        <uc1:TextBox ID="txtComentarios" runat="server" Height="150" MaxLength="1000" 
                            width="400" Obligatorio="True" Apariencia="Multiline" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 467px">
                        <asp:Label ID="Label17" runat="server" Text=" Nuevo Estado"></asp:Label>
                    </td>
                    <td style="width: 81%">
                        <uc1:ComboBox ID="cboNuevoEstado" runat="server" AutoFill="False" FieldName="idEstadoAsignado" postBack="True" Procedimiento="True" TableName="pEstado_List" Obligatorio="True" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 467px">
                        <asp:Label ID="Label16" runat="server" Text="Nuevo Empleado"></asp:Label>
                    </td>
                    <td style="width: 81%">
                        <telerik:RadDropDownTree ID="cboNuevoEmpleado" runat="server" CheckNodeOnClick="True" Culture="es-ES" DataFieldID="IdEmpleado" DataFieldParentID="IdRol" DataTextField="NombreCompleto" DataValueField="idEmpleado" EnableFiltering="True" ExpandNodeOnSingleClick="True" Height="16px" OnClientEntryAdded="onEntryAdded" OnClientEntryAdding="OnClientEntryAdding1" Width="362px">
                            <DropDownSettings AutoWidth="Enabled" CloseDropDownOnSelection="True" />
                            <FilterSettings Highlight="None" />
                        </telerik:RadDropDownTree>
                    </td>
                </tr>
                <tr>
                    <td style="width: 467px">&nbsp;</td>
                    <td style="width: 81%">&nbsp;</td>
                </tr>
                
                <tr>
                    <td style="width: 467px">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 81%">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                
             </table>
</asp:Panel>

</td>
</tr>
</table>
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
