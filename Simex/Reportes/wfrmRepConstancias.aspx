<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.master" CodeBehind="wfrmRepConstancias.aspx.vb" Inherits="smx.wfrmRepConstancias" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="rp" runat="server" Height="572px" Width="984px">
    </rsweb:ReportViewer>
</asp:Content>
