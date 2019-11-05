<%@ Page Language="VB" MasterPageFile="~/Site.Master" CodeBehind="URSACReportes.aspx.vb" Inherits="smx.URSACReportes" EnableSessionState="True" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=8.0.14.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

    <div style="background-position: left bottom; border: 1px solid #F5F5F5; width: 235px; position: absolute; top: 20px; left: 5px; height: 81%">
         <asp:Button ID="btnMostrarReporte" runat="server" CssClass="Boton" Height="45px" Text="Mostrar Reporte" Width="230px" />

        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />

        <asp:ModalPopupExtender ID="dlgFiltrosFin" runat="server" PopupControlID="pnlForm"
             TargetControlID="hiddenTargetControlForModalPopup" 
            RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True" >
        </asp:ModalPopupExtender>

         <br />
         <asp:RadioButtonList ID="lstReportes" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" ForeColor="#666666">
             <asp:ListItem Value="0" Selected="True" >Estados Financieros registrados por período</asp:ListItem>
             <asp:ListItem Value="1">Juntas Directivas registradas por período</asp:ListItem>
             <asp:ListItem Value="2">AC por Tipo de Asociación</asp:ListItem>
             <asp:ListItem Value="3">AC Total por Departamento</asp:ListItem>
             <asp:ListItem Value="4">AC que no tienen Ninguna Junta Directiva Registrada</asp:ListItem>
             <asp:ListItem Value="5">AC que no tienen Ningún Estado Financiero Registrado</asp:ListItem>
             <asp:ListItem Value="6">AC Con Junta Directiva vigentes hasta el año 0000</asp:ListItem>
             <asp:ListItem Value="7">AC con estados financieros vigentes hasta el año 0000</asp:ListItem>
         </asp:RadioButtonList>

    </div>

    <div style="position: absolute; top: 20px; left: 250px; height: 83%;">
        <rsweb:ReportViewer ID="rp" runat="server" Height="700px" Width="900px">
        </rsweb:ReportViewer>
        <telerik:ReportViewer ID="rpTel" runat="server" ShowZoomSelect="True" Skin="Office2007" Height ="700px" Width ="900px"></telerik:ReportViewer>
    </div>

   
    <asp:Panel ID="pnlForm" runat="server" >
        <div id="signup" >
            <div id="signup-ct">
                <div id="signup-header">
                    <div class="modal_close">
                        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png"/>
                    </div>
                    <h2>Ingrese los Parámetros del Reporte</h2>
                </div>
                <form action="" >
                    <div class="txt-fld">
                    </div>
                    <telerik:RadDateInput ID="dFechaDesde" Runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Label="Fecha Inicial:" LabelWidth="150px" Width="132px">
                    </telerik:RadDateInput>
                    <div class="txt-fld">
                    </div>
                    <telerik:RadDateInput ID="dFechaHasta" Runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Label="Fecha Final:" LabelWidth="150px" Width="132px">
                    </telerik:RadDateInput>
                    <div class="btn-fld">
                        <asp:Button ID="btnAddParam" class="button" runat="server" Text="Aceptar" />

                    </div>
                </form>
            </div>
        </div>
    </asp:Panel>

 </div>
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    
</asp:Content>



