<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="LibroSubMenu.Master" EnableEventValidation="false" CodeBehind="wfmRegistroInformesConst.aspx.vb" Inherits="smx.wfmRegistroInformesConstLibro" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ MasterType VirtualPath="LibroSubMenu.Master"%>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


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
           
       <table style="width: 100%">
           <tr>
               <td style="text-align: left; width: 223px;">

        <asp:Button ID="btnCaratural" runat="server" Text="Carátula para el Folder" CssClass="Boton" Height="45px" Width="243px" Visible="False" />
            
               </td>
               <td style="text-align: left; width: 215px;">

                   <asp:Button ID="btnConsJD" runat="server" CssClass="Boton" Height="45px" Text="Constancia Junta Directiva" Width="230px" />
            
               </td>
               <td style="text-align: left">

                   <asp:Button ID="btnConsReg" runat="server" CssClass="Boton" Height="45px" Text="Constancia Registro" Width="230px" />
            
               </tr>
           </table>

        <rsweb:ReportViewer ID="rp" runat="server" Height="700px" Width="900px">
       </rsweb:ReportViewer>

        <br />
            
       <br />
       <br />

        <br />
       <br />



    <br />
       </div>
    </asp:Content>
