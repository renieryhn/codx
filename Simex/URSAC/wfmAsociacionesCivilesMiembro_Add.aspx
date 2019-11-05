<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAsociacionesCivilesMiembro_Add.aspx.vb" Inherits="smx.wfmAsociacionesCivilesMiembro_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
<table class="DD">
            <tr>
                <td align="left" style="width: 468px">
            
                <uc4:SolicitanteResponsable ID="Miembro" runat="server" MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" TipoEntidad="Miembro" TipoEntidadCombo="1" />
                    </td>
                <td>
            <asp:GridView ID="gvDatosDet" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="mGrid" Width="626px" Caption="Listado de Miembros de la Junta Directiva">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:BoundField DataField="NombreCliente" HeaderText="Nombre" />
                    <asp:BoundField DataField="NombrePuesto" HeaderText="Puesto" />
                    <asp:BoundField DataField="fModificacion" DataFormatString="{0:d}" HeaderText="Fecha" Visible="False" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" Visible="False" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="pgr" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 468px">
                    <label for="dtcfTomaPosesion">
            <div style="width:440px;">
                    <label for="dtcfTomaPosesion">Puesto: 
                         </label>
                <br />
                <uc2:ComboBox ID="cboPuesto" runat="server" AutoFill="True" FieldName="IdPuesto" idFieldName="id" Obligatorio="True" TableName="UR_PuestoJuntaDirectiva" textFieldName="Nombre" />
            </div>
                         </label>
                    </td>
                <td>
                         &nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 468px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/URSAC/wfmRegistroJuntaDirectiva.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/URSAC/wfmAsociacionesCivilesMiembro_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
            </tr>
        </table>

</asp:Content>