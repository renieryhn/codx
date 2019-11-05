<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmLibroRegistro_List.aspx.vb" Inherits="smx.wfmLibroRegistro_List" MasterPageFile="~/Consulta.Master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
<div id="filtros" class="DD">
    <div style="background-position: left top; border: 1px solid #F5F5F5; width: 120px; position: absolute; top: 150px; left: 5px; height: 82%; background-color: #999999; background-image: url('../../Imagenes/LibroRegistro.jpg'); background-repeat: no-repeat; background-attachment: scroll;">

    </div>
    <div style="background-position: left top; position: absolute; top: 152px; left: 130px; width: 90%; height: 82%; background-image: url('../../Imagenes/LibroRegistro2.jpg'); background-repeat: repeat-x; background-attachment: scroll; background-color: #BFBFBF;">
        <table style="width: 100%">
            <tr>
                <td style="width: 181px; height: 48px;"></td>
                <td style="height: 48px">
                            </td>
                <td style="height: 48px"></td>
            </tr>
            <tr>
                <td style="width: 181px; height: 18px; color: #FFFFFF; font-weight: bold;">Número de Registro</td>
                <td style="height: 18px">
                                <uc1:TextBox ID="txtNumRegistro" runat="server" FieldName="NumRegistro" Lenght="300" MaxLength="50" width="300" />
                            </td>
                <td style="height: 18px"></td>
            </tr>
            </table>

     <asp:Panel ID="pnlHeader" runat="server" Width ="700px" Height="25px" style="margin-top: 0px">
                   <asp:Image ID="imgToogle" runat="server" ImageUrl="~/Imagenes/minus.png" />
   </asp:Panel>
        <asp:Panel ID="pnlMoreFilters" runat="server" Width ="100%" Height="200px"  BackColor="#E5E5E5" style="margin-top: 0px">
                <asp:Panel ID="panelFilters" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 149px; height: 18px;">Nombre de Asociación</td>
                            <td style="width: 311px; height: 18px">
                                <uc1:TextBox ID="txtNombreAsoc" runat="server" FieldName="NombreAsociacion" MaxLength="60" width="240" />
                            </td>
                            <td style="height: 18px">Encargado</td>
                            <td style="height: 18px">
                                <uc1:TextBox ID="txtEncargado" runat="server" FieldName="Encargado" MaxLength="60" width="240" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px; height: 18px;">Número de Expediente</td>
                            <td style="height: 18px; width: 311px">
                                <uc1:TextBox ID="tbxExpediente" runat="server" FieldName="NumExpediente" MaxLength="17" />
                            </td>
                            <td style="height: 18px">Año</td>
                            <td style="height: 18px">
                                <uc1:TextBox ID="txtAño" runat="server" FieldName="Año" Int="True" MaxLength="4" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px; height: 24px;">Tomo</td>
                            <td style="width: 311px; height: 24px">
                                <uc1:TextBox ID="txtTomo" runat="server" FieldName="Tomo" Int="True" MaxLength="4" />
                            </td>
                            <td style="height: 24px">Folio</td>
                            <td style="height: 24px">
                                <uc1:TextBox ID="txtFolio" runat="server" FieldName="Folio" Int="True" MaxLength="4" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" style="width: 148px">Tipo de Asociación</td>
                            <td>
                                <uc2:ComboBox ID="cboTipoAsoc" runat="server" AutoFill="True" EnableTheming="True" FieldName="idTipo" idFieldName="id" postBack="True" TableName="UR_Tipo" textFieldName="Nombre" />
                            </td>
                            <td style="width: 144px">Subtipo de Asociación</td>
                            <td>
                                <uc2:ComboBox ID="cboSubtipo" runat="server" AutoFill="False" FieldName="idSubtipo" idFieldName="Id" idParentComboBox="idTipo" postBack="False" TableName="UR_Subtipo" textFieldName="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" style="width: 148px">Departamento </td>
                            <td>
                                <uc2:ComboBox ID="cboDepartamento" runat="server" AutoFill="True" FieldName="idDepartamento" idFieldName="id" Obligatorio="False" postBack="True" TableName="Departamento" textFieldName="Nombre" />
                            </td>
                            <td style="width: 144px">Municipio </td>
                            <td>
                                <uc2:ListBox ID="cboMunicipio" runat="server" AutoFill="False" FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" TableName="Municipio" textFieldName="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" style="width: 148px">Fecha Inicial</td>
                            <td>
                                <uc3:DateControl ID="dtcFechaDesde" runat="server" FechaHora="False" FieldName="FechaInicio" Obligatorio="False" />
                            </td>
                            <td style="width: 144px">Fecha Final</td>
                            <td>
                                <uc3:DateControl ID="dtcFechaHasta" runat="server" FechaHora="False" FieldName="FechaFinal" Obligatorio="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
    </asp:Panel>

    <ajaxToolkit:CollapsiblePanelExtender ID="pnlMoreFilters_CollapsiblePanelExtender" runat="server" 
        BehaviorID="pnlMoreFilters_CollapsiblePanelExtender" Collapsed="True" 
        ExpandControlID="pnlHeader" ExpandedImage="~/Imagenes/minus.png" TargetControlID="pnlMoreFilters"
            CollapsedImage="~/Imagenes/plus.png" Enabled="True" CollapsedText="Mostrar más filtros" ExpandedText="Ocultar filtros"
            ImageControlID="imgToogle" SuppressPostBack="True" CollapseControlID="pnlHeader" AutoCollapse="False" AutoExpand="False" ScrollContents="False">
    </ajaxToolkit:CollapsiblePanelExtender>
<asp:Panel ID="pnlResults" runat="server">
    <div id ="Gridview">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="3" AllowPaging="True" 
                AllowSorting="True" DataKeyNames="Id" PageSize="7" 
                EmptyDataText="No se encontraron registros" CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="1214px" >
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:ButtonField CommandName="Select" Text="Junta Directiva" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False"
                                CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                                CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NumRegistro" HeaderText="Registro" />
                    <asp:BoundField DataField="NombreInstitucion" HeaderText="Nombre" >
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FechaRegistro" DataFormatString="{0:d}" HeaderText="Fecha de Registro" />
                    <asp:BoundField DataField="NombreTipo" HeaderText="Tipo Asoc." />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                    <asp:BoundField DataField="Tomo" HeaderText="Tomo" />
                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
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
                NavigateUrl="~/Otros/LibroRegistro/wfmLibroRegistro_Add.aspx" 
                Visible="False">[linkNuevo]</asp:HyperLink>
            <asp:HyperLink ID="linkModificar" runat="server" 
                NavigateUrl="~/Otros/LibroRegistro/wfmLibroRegistro_Edit.aspx" 
                Visible="False">[linkModificar]</asp:HyperLink>
        <asp:HyperLink ID="linkSeguimiento" runat="server" NavigateUrl="~/Otros/LibroRegistro/wfmLibroRegistroJuntaDirectiva.aspx"
            Visible="False">[linkSeguimiento]</asp:HyperLink>
</div>
</asp:Panel>
        </div>
</div>
</asp:Content>



