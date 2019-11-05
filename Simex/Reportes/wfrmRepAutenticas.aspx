<%@ Page Language="vb"  AutoEventWireup="false" MasterPageFile="~/Consulta.Master" CodeBehind="wfrmRepAutenticas.aspx.vb" Inherits="smx.wfrmRepAutenticas" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <rsweb:ReportViewer ID="rp" runat="server" Height="572px" Width="984px">
    </rsweb:ReportViewer>
</asp:Content>


