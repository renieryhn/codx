<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmAcreditaciones_Add.aspx.vb" Inherits="smx.wfmAcreditaciones_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="InstitucionR" tagprefix="uc4" %>
<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="ClienteR" tagprefix="uc5" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="DD" style="height:700px;">
        <div >
        <uc5:ClienteR ID="Representante" runat="server" 
        TipoEntidad="Nombre del Representante" idMostrar="C" 
        MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" TipoEntidadCombo="2"/>
            </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
     
            <uc4:InstitucionR ID="Institucion" runat="server" 
            TipoEntidad="Institución que Representa" idMostrar="I" 
            MostrarApoderado="False" MostrarCliente="False" MostrarInstitucion="True" TipoEntidadCombo="1" />


        </asp:PlaceHolder>
            <div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

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
        NavigateUrl="~/Otros/Acreditaciones/wfmAcreditaciones_Add.aspx" 
        Visible="False">[linkMe]</asp:HyperLink>
    </div>

</asp:Content>
