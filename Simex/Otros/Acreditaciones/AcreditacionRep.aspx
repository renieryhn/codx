<%@ Page Language="VB" MasterPageFile="~/Site.Master" CodeBehind="AcreditacionRep.aspx.vb" Inherits="smx.AcreditacionRep" EnableSessionState="True" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Forma" style="width: 166%; height: 235%; border: thin none #E0E0E0; position: relative; top: 15px; left: -5px;" >


    <div style="position: absolute; top: 20px; left: 150px; height: 83%; width: 1000px;">
        <rsweb:ReportViewer ID="rp" runat="server" Height="700px" Width="900px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ZoomMode="FullPage" BorderStyle="Double" BorderWidth="5px" InteractivityPostBackMode="AlwaysSynchronous" PromptAreaCollapsed="True" SizeToReportContent="True">
            <LocalReport ReportPath="">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>

   
   

        <asp:Button ID="btnPrintALl" runat="server" Height="31px" Text="Imprimir Año:" Width="128px" />
        <br />
        <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="40px"></asp:TextBox>

   
   

 </div>
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    
</asp:Content>



