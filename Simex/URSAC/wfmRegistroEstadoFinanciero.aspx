<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="URSubMenu.Master" CodeBehind="wfmRegistroEstadoFinanciero.aspx.vb" Inherits="smx.wfmRegistroEstadoFinanciero" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="URSubMenu.Master"%>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register src="../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
          <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Estado Financiero" CssClass="Boton" Height="45px" Width="305px" />
            
     <asp:ModalPopupExtender ID="mpeFormulario" runat="server" PopupControlID="pnlForm" 
                  TargetControlID="btnNuevo"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True">
    </asp:ModalPopupExtender>
  
        &nbsp;<asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False"  CssClass="mGrid" 
        CellPadding="3" Width="626px" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <AlternatingRowStyle CssClass="alt" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea eliminar el registro?');"
                        CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NumEstadoFinanciero" HeaderText="Código" />
<asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" DataFormatString="{0:d}"></asp:BoundField>
            <asp:BoundField DataField="FechaInicioPeriodo" DataFormatString="{0:d}" HeaderText="Período Inicial" />
            <asp:BoundField DataField="FechaFinPeriodo" DataFormatString="{0:d}" HeaderText="Período Final" />
            <asp:BoundField DataField="fModificacion" HeaderText="Fecha" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
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
                        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png"/>
                    </div>
                <h2>Agregar Estado Financiero</h2>
            </div>
            <form action="" >
                <div class="txt-fld">
                    <label for="">No.Registro</label>
                    <asp:TextBox ID="txtnRegistro" runat="server" ReadOnly="true"  Width ="100px"></asp:TextBox>
                </div>
                <div class="txt-fld">
                    <label for="">Inicio período</label>
                </div>
                    <uc3:DateControl ID="dtcFechaDesde" runat="server" FechaHora="False" FieldName="FechaInicio" Obligatorio="true" />
                <div class="txt-fld">
                    <label for="">Fin período</label>
                </div>
                    <uc3:DateControl ID="dtcFechaHasta" runat="server" FechaHora="False" FieldName="FechaFinal" Obligatorio="true"  />
                <div class="btn-fld">
                    <asp:Button ID="btnAddRecord" class="button" runat="server" Text="Agregar Estado Financiero" />
                </div>
            </form>
        </div>	
    </div>
    </asp:Panel>
</asp:Content>
