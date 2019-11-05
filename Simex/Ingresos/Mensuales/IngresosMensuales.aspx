<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="IngresosMensuales.aspx.vb" Inherits="smx.IngresosMensuales" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc1" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
       <div class="DD">
           <table style="width: 100%">
               <tr>
                   <td style="width: 144px">
        <asp:Label ID="lblrbSubservicio" runat="server" Text="Subservicio"></asp:Label>
                   </td>
                   <td>
        <asp:RadioButton ID="rbSubservicio" runat="server" GroupName="tipoReporte" Checked = "true" />
                   </td>
               </tr>
               <tr>
                   <td style="width: 144px">
        <asp:Label ID="lblrbOficina" runat="server" Text="Oficina"></asp:Label>
                   </td>
                   <td>
        <asp:RadioButton ID="rbOficina" runat="server" GroupName="tipoReporte" />
                   </td>
               </tr>
               <tr>
                   <td style="width: 144px">Fecha Inicio</td>
                   <td>
        <uc1:DateControl ID="dcFechaInicio" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td style="width: 144px">Fecha Fin</td>
                   <td>
        <uc1:DateControl ID="dcFechafin" runat="server" />
                   </td>
               </tr>
           </table>
    <asp:GridView ID="gvReporte" runat="server" Visible = "False" 
        AutoGenerateColumns="False" CellPadding="3" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="mGrid">
        <AlternatingRowStyle CssClass="alt" />
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
    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Ingresos/Recibo/wfmRecibo_List.aspx" Visible="False"></asp:HyperLink>
           </div>
</asp:Content>

