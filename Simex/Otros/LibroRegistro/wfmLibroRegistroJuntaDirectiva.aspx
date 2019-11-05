<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="LibroSubMenu.Master" EnableEventValidation="false" CodeBehind="wfmLibroRegistroJuntaDirectiva.aspx.vb" Inherits="smx.wfmRegistroJuntaDirectiva" %>
<%@ MasterType VirtualPath="LibroSubMenu.Master"%>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>

<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="../../Modal.css" />
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode) 
        {
            if (keyCode == 16)
            {
                isShift = false;
            }
        }
        function isNumeric(keyCode) 
        {
            if (keyCode == 16) 
            {
                isShift = true;
            }
            return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 || (keyCode >= 96 && keyCode <= 105)) && isShift == false);
        }
    </script>

   <div id="Forma" style="width: 166%; height: 235%; border: thin none #E0E0E0; position: relative; top: 15px; left: -5px;" >

    <br />

        <asp:Button ID="btnNuevo" runat="server" Text="Crear Junta Directiva" CssClass="Boton" Height="45px" Width="244px" />
            
     <asp:ModalPopupExtender ID="mpeFormulario" runat="server" PopupControlID="pnlForm" 
                  TargetControlID="btnNuevo" BackgroundCssClass="lean_overlay" 
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True">
    </asp:ModalPopupExtender>

    &nbsp;<asp:Button ID="btnImprimir" runat="server" Text="Imprimir Histórico" CssClass="Boton" Height="45px" Width="244px" Visible="False" />
            


    &nbsp;<asp:Button ID="btnImprimir0" runat="server" Text="Imprimir Constancia" CssClass="Boton" Height="45px" Width="244px" Visible="False" />
            


    <br />
       <br />
       <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False"  CssClass="mGrid" 
        CellPadding="3" Width="626px" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField ShowHeader="False" InsertVisible="False" >
                <ItemTemplate>
                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Editar" CommandArgument='<%# Container.DisplayIndex %>' ImageUrl="~/Imagenes/grid_editar.png" Text="Editar" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="lnkEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                        CommandName="Delete" Text="Eliminar" ImageUrl="~/Imagenes/grid_eliminar.png"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="lnkJD" runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%# Container.DisplayIndex %>' ImageUrl="~/Imagenes/juntadirectiva.png" Text="Junta Directiva" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="Código" />
<asp:BoundField DataField="FechaInscripcion" HeaderText="Fecha de Inscripción" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="FechaTomaPosesion" DataFormatString="{0:d}" HeaderText="Toma Posesión" />
            <asp:BoundField DataField="FechaEleccion" DataFormatString="{0:d}" HeaderText="Fecha Elección" />
            <asp:BoundField DataField="FechaSolRegistroJD" DataFormatString="{0:d}" HeaderText="Fecha Solicitud de Registro" />
            <asp:BoundField DataField="FechaInicioVig" DataFormatString="{0:d}" HeaderText="Vigencia Inicial" />
            <asp:BoundField DataField="FechaFinVig" DataFormatString="{0:d}" HeaderText="Vigencia Final" />
            <asp:BoundField DataField="TotalMiembros" HeaderText="Miembros" />
            <asp:BoundField DataField="fModificacion" HeaderText="Fecha" DataFormatString="{0:d}" Visible="False" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" Visible="False" />
        </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle HorizontalAlign="Center" CssClass="pgr" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="White" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
       <br />
       </div>

    <br />
            <asp:UpdateProgress ID="upprog" runat="server" DisplayAfter="100">
                <ProgressTemplate>
                    Cargando detalle de Junta Directiva, por favor espere...
                </ProgressTemplate>
            </asp:UpdateProgress>
<asp:Button ID="btnNuevoMiembro" runat="server" CssClass="Boton" Height="45px" Text="Crear Miembro de Junta Directiva" Width="311px" />
    <asp:UpdatePanel ID="upJuntaDet" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvDatosDet" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="mGrid" Width="626px" Caption="Listado de Miembros de la Junta Directiva">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkEdit0" runat="server" CausesValidation="false" CommandArgument="<%# Container.DisplayIndex %>" CommandName="Editar" ImageUrl="~/Imagenes/grid_editar.png" Text="Editar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkEliminar0" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Imagenes/grid_eliminar.png" OnClientClick="return confirm('Seguro que desea eliminar el registro?');" Text="Eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IdJuntaDirectivaDet" HeaderText="Código" />
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
        </ContentTemplate>

    </asp:UpdatePanel>
    <br />
    <br />

    <asp:Panel ID="pnlForm" runat="server" >
        <div id="signup">
             <div id="signup-ct">
                <div id="signup-header">
                    <div class="modal_close">
                        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                    </div>
                    <h2>Junta Directiva</h2>
                </div>
                <form action="" >
                    <div class="txt-fld">
                         <label for="dtcfInscripcion">Inscripción</label>
                    </div>
                         <uc3:DateControl ID="dtcfInscripcion" runat="server" FechaHora="False" FieldName="FechaInscripcion" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="dtcfTomaPosesion">Toma de Posesión</label>
                    </div>
                        <uc3:DateControl ID="dtcfTomaPosesion" runat="server" FechaHora="False" FieldName="FechaTomaPosesion" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="dtcfEleccion">Elección</label>
                    </div>
                        <uc3:DateControl ID="dtcfEleccion" runat="server" FechaHora="False" FieldName="FechaEleccion" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="dtcfRegistro">Registro</label>
                    </div>
                        <uc3:DateControl ID="dtcfRegistro" runat="server" FechaHora="False" FieldName="FechaSolRegistroJD" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="dtcfVigenciaDesde">Vigencia Desde</label>
                    </div>
                        <uc3:DateControl ID="dtcfVigenciaDesde" runat="server" FechaHora="False" FieldName="FechaInicioVig" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="dtcfVigenciaHasta">Vigencia Hasta</label>
                    </div>
                        <uc3:DateControl ID="dtcfVigenciaHasta" runat="server" FechaHora="False" FieldName="FechaFinVig" Obligatorio="true" />
                <div class="btn-fld">
                    <asp:Button ID="btnAddJunta" class="button" runat="server" Text="Guardar Junta Directiva" />
                </div>
                </form>
             </div>
        </div>
    </asp:Panel>

    </asp:Content>

