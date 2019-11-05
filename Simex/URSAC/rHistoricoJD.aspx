<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/URSAC/URSubMenu.Master" CodeBehind="rHistoricoJD.aspx.vb" Inherits="smx.rHistoricoJD" %>
<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnBack" runat="server" Text="Volver" CssClass="Boton" Height="45px" Width="244px" />

    &nbsp;
    <br />

    <telerik:ReportViewer ID="rp" runat="server" Height="400px" ProgressText="Generando reporte..." Width="900px">
<typereportsource typename="smx.Report1, SIMEX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
</telerik:ReportViewer>

    <br />
        </asp:Content>
