<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="URSubMenu.Master" EnableEventValidation="false" CodeBehind="wfmRegistroResoluciones.aspx.vb" Inherits="smx.wfmRegistroResoluciones" %>
<%@ MasterType VirtualPath="URSubMenu.Master"%>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="../Modal.css" />
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

        <asp:Button ID="btnNuevo" runat="server" Text="Registrar Resolución" CssClass="Boton" Height="45px" Width="244px" />
            
     <asp:ModalPopupExtender ID="mpeFormulario" runat="server" PopupControlID="pnlForm" 
                  TargetControlID="btnNuevo" BackgroundCssClass="lean_overlay"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True">
    </asp:ModalPopupExtender>

        <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False"  CssClass="mGrid" 
        CellPadding="3" Width="574px" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <AlternatingRowStyle CssClass="alt" />
        <Columns>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                                    CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NumResolucion" HeaderText="No. Resolución" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha de Resolución" />
                        <asp:BoundField DataField="Justificacion" HeaderText="Justificación" />
            <asp:BoundField DataField="idUsuario" HeaderText="Usuario" />
        </Columns>
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
       </div>

    <asp:Panel ID="pnlForm" runat="server" >
        <div id="signup">
             <div id="signup-ct">
                <div id="signup-header">
                    <div class="modal_close">
                        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                    </div>
                    <h2>Registrar Resolución</h2>
                </div>
                <form action="" >
                    <div class="txt-fld">
                         &nbsp;</div>
                    <div class="txt-fld">
                         <label for="">Num. Resolución</label>
                    <uc1:TextBox ID="txtNumResolucion" runat="server" Habilitado="True" 
                        FieldName="NumResolucion" Int="False" Align="Izquierda" 
                        MaxLength="100" width="90" SoloLectura="False"  />
                    </div>
                    <div class="txt-fld">
                         <label for="">Fecha Resolución</label>
                    </div>
                                             <uc3:DateControl ID="dtcFecha" runat="server" FechaHora="False" FieldName="FechaInicio" Obligatorio="true" />
                    <div class="txt-fld">
                         <label for="">Justificación</label>
                    <uc1:TextBox ID="txtJustificacion" runat="server" Habilitado="True" 
                        Obligatorio="true" FieldName="Justificacion" Int="False" Align="Izquierda" 
                        MaxLength="20" width="400" Apariencia="Multiline"/>
                    </div>
                <div class="btn-fld">
                    <asp:Button ID="btnAddResolucion" class="button" runat="server" Text="Registrar Resolución" />
                </div>
                </form>
             </div>
        </div>
    </asp:Panel>
</asp:Content>
