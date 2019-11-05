<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAcreditaciones_Edit.aspx.vb" Inherits="smx.wfmAcreditaciones_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="DD" style="height:700px;">
    Código:<br> 
        <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" 
        Visible="False" SoloLectura="True" />
    &nbsp;<br>
     Institución que Representa:<br>            
        <uc4:SolicitanteResponsable ID="Institucion" runat="server" 
        TipoEntidad="Institución que Representa" idMostrar="A, I, C" 
        MostrarApoderado="False" MostrarCliente="False" MostrarInstitucion="True" TipoEntidadCombo="1" />
    &nbsp;<br>
     Nombre del Representante:<br>            
        <uc4:SolicitanteResponsable ID="Representante" runat="server" 
        TipoEntidad="Nombre del Representante" idMostrar="A, I, C" 
        MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" TipoEntidadCombo="2" />
    &nbsp;<br>
    Hora:<br> 
        <telerik:RadTimePicker ID="Hora" Runat="server">
        </telerik:RadTimePicker>
    &nbsp;
        <br>
    Fecha:<br> 
    <telerik:RadDatePicker ID="rFecha" Runat="server">
    </telerik:RadDatePicker>
    &nbsp; 
        <br>
        Lugar:<uc1:TextBox ID="txtLugar" runat="server" Habilitado="True" 
        Obligatorio="False" FieldName="Lugar" Int="False" Align="Izquierda" 
        MaxLength="200" width="200" EnableViewState="True" Height="100" 
        Apariencia="Multiline" />
    &nbsp;<br>
    </div>
</ContentTemplate>
</asp:UpdatePanel>

    <asp:HyperLink ID="linkMain" runat="server" 
    NavigateUrl="~/Otros/Acreditaciones/wfmAcreditaciones_List.aspx" 
    Visible="False">[linkMain]</asp:HyperLink>
    <asp:HyperLink ID="linkMe" runat="server" 
    NavigateUrl="~/Otros/Acreditaciones//wfmAcreditaciones_Add.aspx" 
    Visible="False">[linkMe]</asp:HyperLink>
</asp:Content>

