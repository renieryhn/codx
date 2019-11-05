<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExReporter.aspx.vb" Inherits="smx.ExReporter" MasterPageFile="~/Consulta.Master" %>

<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>

<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>




<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>


    <div class="DD" id ="RepDiv">
    <div style="position: absolute; top: 160px; left: 200px; height: 667px;">
        <rsweb:ReportViewer ID="rp" runat="server" Width="879px" Height="950px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">

        </rsweb:ReportViewer>
    </div>
        
        <div style="position: absolute; top: 160px; left: 10px;width: 140px; height: 146px">
                <asp:Button ID="btnPortada" runat="server" BorderWidth="1px" Text="Portada " Width="140px" CssClass="btn" />
                <asp:Button ID="btnComprobante" runat="server" BorderWidth="1px" Text="Comprobante" Width="140px" CssClass="btn" />
                <br />
                <asp:Button ID="btnRecibo" runat="server" BorderWidth="1px" Text="Recibo" Width="140px" CssClass="btn" />
                <br />
                <asp:Button ID="btnPrint" runat="server" BorderWidth="1px" Text="Imprimir" Width="140px" onClientClick="printReport()" UseSubmitBehavior="False" CssClass="btn"/>
                <br />
                <asp:Button ID="btnBack" runat="server" BorderWidth="1px" Text="Volver" Width="140px" CssClass="btn" />
                <br />
            </div>
        
    </div>

<script type="text/javascript">
    //------------------------------------------------------------------
    // Cross-browser Multi-page Printing with ASP.NET ReportViewer
    // by Chtiwi Malek.
    // http://www.codicode.com
    //------------------------------------------------------------------

    // Linking the print function to the print button
    $('#printreport').click(function () {
        printReport('rp');
    });

    // Print function (require the reportviewer client ID)
    function printReport(report_ID) {
        var rp = $('#' + report_ID);
        var iDoc = rp.parents('html');

        // Reading the report styles
        var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
        if ((styles == undefined) || (styles == '')) {
            iDoc.find('head script').each(function () {
                var cnt = $(this).html();
                var p1 = cnt.indexOf('ReportStyles":"');
                if (p1 > 0) {
                    p1 += 15;
                    var p2 = cnt.indexOf('"', p1);
                    styles = cnt.substr(p1, p2 - p1);
                }
            });
        }
        if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
        styles = '<style type="text/css">' + styles + "</style>";

        // Reading the report html
        var table = rp.find("div[id$='_oReportDiv']");
        if (table == undefined) {
            alert("Report source not found.");
            return;
        }
        // Generating a copy of the report in a new window
        var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
        //var docCnt = styles + table.parent().html();
        var docCnt = styles + $($.find("div[id$='_oReportDiv']")).parent().html();
        var docHead = '<head><title></title><style>body{margin:5;padding:0;}</style></head>';
        var winAttr = "location=no,statusbar=no,directories=no,menubar=no,titlebar=no,toolbar=no,dependent=no,width=720,height=600,resizable=yes,screenX=200,screenY=200,personalbar=no,scrollbars=yes";;
        var newWin = window.open("", "_blank", winAttr);
        writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
        writeDoc.close();
        // The print event will fire as soon as the window loads
        newWin.focus();
        // uncomment to autoclose the preview window when printing is confirmed or canceled.
        // newWin.close();
    };

        </script>

</asp:Content>
