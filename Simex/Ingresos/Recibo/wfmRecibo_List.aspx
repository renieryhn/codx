<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="wfmRecibo_List.aspx.vb" Inherits="smx.wfmRecibo_List" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode) {
            if (keyCode == 16) {
                isShift = false;
            }
        }
        function isNumeric(keyCode) {
            if (keyCode == 16) {
                isShift = true;
            }
            return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 || (keyCode >= 96 && keyCode <= 105)) && isShift == false);
        }
    </script>
<div>
    <table style="width: 100%">
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label3" runat="server" Text="No. Recibo Finanzas"></asp:Label>
<asp:label ID = "lblNumReciboFinanzas" Text = "NumReciboFinanzas" Visible ="false" runat ="server"></asp:label>
            </td>
            <td style="width: 185px">
<asp:TextBox ID="txtNumReciboFinanzas" runat="server" Width="300px" onkeyup = "keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" MaxLength="32" BackColor="White" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" style="margin-left: 0px" />
            </td>
            <td style="width: 125px">                
<asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td>
<uc1:TextBox ID="txtUsuario" runat="server" FieldName="Usuario" Lenght="300" width="300" MaxLength="50" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label4" runat="server" Text="No. Expediente"></asp:Label>
            </td>
            <td style="width: 185px">
<uc1:TextBox ID="txtId" runat="server" FieldName="IdExpediente" Lenght="300" width="300" MaxLength="17"/>
            </td>
            <td style="width: 125px">
<asp:Label ID="Label6" runat="server" Text="Oficina"></asp:Label>
            </td>
            <td>
<uc2:ListBox ID="cboOficina" runat="server" AutoFill="True" FieldName="idOficina" idFieldName="id" TableName="Oficina" textFieldName="Nombre" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label5" runat="server" Text="Solicitante"></asp:Label>
            </td>
            <td style="width: 185px">
<uc1:TextBox ID="txtSolicitante" runat="server" FieldName="Solicitante" Lenght="300" width="300" MaxLength="60" Int="False" />
            </td>
            <td style="width: 125px">
<asp:Label ID="Label7" runat="server" Text="Servicio"></asp:Label>
            </td>
            <td>
<uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" textFieldName="Nombre" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label14" runat="server" Text="Valor Dolares"></asp:Label>
            </td>
            <td style="width: 185px">
<uc1:TextBox ID="txtValorDolares" runat="server" FieldName="ValorDolares" Lenght="300" width="300" MaxLength="12" Int="False" />
            </td>
            <td style="width: 125px">
<asp:Label ID="Label8" runat="server" Text="Sub Servicio"></asp:Label>
            </td>
            <td>
<uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="False" FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" 
TableName="SubServicios" textFieldName="Nombre" AditionalCondition="indEstado='A'" postBack="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label9" runat="server" Text="Fecha Emisión: Inicio"></asp:Label>
            </td>
            <td style="width: 185px">
<uc3:DateControl ID="dtcFechaEmisionDesde" runat="server" FechaHora="False" FieldName="FechaEmisionDesde" />
            </td>
            <td style="width: 125px">
<asp:Label ID="Label10" runat="server" Text="Fecha Emisión: Fin"></asp:Label>
            </td>
            <td>
<uc3:DateControl ID="dtcFechaEmisionHasta" runat="server" FechaHora="False" FieldName="FechaEmisionDesde" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label11" runat="server" Text="Fecha Pago: Inicio"></asp:Label>
            </td>
            <td style="width: 185px">
<uc3:DateControl ID="dtcFechaPagoDesde" runat="server" FechaHora="False" FieldName="FechaPagoDesde" />
            </td>
            <td style="width: 125px">
<asp:Label ID="Label12" runat="server" Text="Fecha Pago: Fin"></asp:Label>
            </td>
            <td>
<uc3:DateControl ID="dtcFechaPagoHasta" runat="server" FechaHora="False" FieldName="FechaPagoHasta" />
            </td>
        </tr>
        <tr>
            <td style="width: 177px">
<asp:Label ID="Label13" runat="server" Text="Pagado"></asp:Label>
            </td>
            <td style="width: 185px">
<uc2:ListBox ID="cboPagado" runat="server" FieldName="indPagado" idFieldName="id" TableName="Si_No" textFieldName="Nombre" AutoFill="True" />
            </td>
            <td style="width: 125px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</div>
<div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" AllowPaging="True" 
                        AllowSorting="True" DataKeyNames="Id" PageSize="12" 
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
                            <asp:BoundField DataField="NumReciboFinanzas" HeaderText="Recibo Finanzas" />
                            <asp:BoundField DataField="NombreOficina" HeaderText="Oficina" />
                            <asp:BoundField DataField="NombreServicio" HeaderText="Servicio" />
                            <asp:BoundField DataField="NombreSubServicio" HeaderText="Sub Servicio" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="idUsuario" HeaderText="Usuario" />
                            
                            <asp:BoundField DataField="IdExpediente" HeaderText="Expediente" />
                            
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
                        NavigateUrl="~/Ingresos/Recibo/wfmRecibo_Add.aspx" 
                        Visible="False">[linkNuevo]</asp:HyperLink>
                    <asp:HyperLink ID="linkModificar" runat="server" 
                        NavigateUrl="~/Ingresos/Recibo/wfmRecibo_Edit.aspx" 
                        Visible="False">[linkModificar]</asp:HyperLink>
               </div>
           </div>
</asp:Content>



