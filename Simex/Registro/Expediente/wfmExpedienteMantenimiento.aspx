<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmExpedienteMantenimiento.aspx.vb" Inherits="smx.wfmExpedienteMantenimiento" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register src="../../Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc3" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc2" %>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register src="../../Controles/TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="position: absolute; top: 141px; left: 7px; height: 106px; width: 741px;">
    
    <asp:Button ID="btnEvaluarDictamen" runat="server" Text="Evaluar Dictamen" BorderStyle="Solid" BorderWidth="1px" Width="220px" CssClass="btn" Height="28px" />
    <asp:Button ID="btnEvaluarResolucion" runat="server" Text="Evaluar Resolución" Width="220px" CssClass="btn" Height="28px" />
    
    <br />
    <asp:Button ID="btnAnularNumeroResolucion" runat="server" Text="Anular Numero Resolución" Height="28px" Width="220px" CssClass="btn" />
    <asp:Button ID="btnAnularNumeroDictamen" runat="server" Text="Anular Numero Dictamen" Height="28px" Width="220px" CssClass="btn" />
    <br />
    
    <asp:Button ID="btnCambiarEncargadoExpediente" runat="server" Text="Cambiar Encargado de Expediente" Height="28px" Width="220px" Enabled="False" CssClass="btn" />
    <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar Comentarios" Width="220px" Height="28px" CssClass="btn" />
    
</div>

<div style="position: absolute; top: -2px; left: 227px; height: 135px;">
    <asp:Label ID="Label11" runat="server" Text="Fecha"></asp:Label>
    <br />

    <uc2:DateControl ID="dtcFechaRecepcion" runat="server" FechaHora="False" FieldName="FechaRecepcion" SoloLectura="True" />

    <br />
    <asp:Label ID="Label19" runat="server" Text="Fecha de Dictamen"></asp:Label>
    <br />
    <uc2:DateControl ID="dtcFechaDictamen" runat="server" FechaHora="False" 
        FieldName="FechaDictamen" SoloLectura="True" />
    </div>

<div style="position: absolute; top: -2px; left: 398px; width: 168px; height: 129px;">
    <asp:Label ID="Label12" runat="server" Text="Responsable"></asp:Label>
    <br />
    <uc3:TextBox ID="txtRecibidoPor" runat="server" FieldName="RecibidoPor" SoloLectura="True" />
    <br />
    <asp:Label ID="Label20" runat="server" Text="Numero de Resolución"></asp:Label>
    <br />
    <uc1:textbox ID="txtNumeroResolucion" runat="server" Apariencia="SingleText" 
        FieldName="NumResolucion" SoloLectura="True" />
</div>


<div style="position: absolute; top: -2px; left: 573px; height: 168px;">
    <asp:Label ID="Label13" runat="server" Text="Fecha Asignación"></asp:Label>
    <br />
    
    <uc2:DateControl ID="dtcFechaAsignacion" runat="server" FechaHora="True" 
        FieldName="FechaAsignacion" SoloLectura="True" />
    
    <br />
    <asp:Label ID="Label21" runat="server" Text="Fecha de Resolución"></asp:Label>
    <br />
    <uc2:DateControl ID="dtcFechaResolucion" runat="server" FechaHora="False" 
        FieldName="FechaResolucion" SoloLectura="True" />
    <br />
</div>

<div style="position: absolute; top: -2px; left: 742px;">
    <asp:Label ID="Label14" runat="server" Text="Asignado A"></asp:Label>
    <br />
    <uc3:TextBox ID="txtAsignadoA" runat="server" FieldName="AsignadoA" SoloLectura="True" />
</div>
    <div style="position: absolute; top: -2px; left: 7px; width: 220px; height: 133px;">
    <asp:Label ID="Label10" runat="server" Text="Estado Actual"></asp:Label>
    <br />
    <uc1:textbox ID="txtEstadoActual" runat="server" FieldName="Estado" 
        SoloLectura="True" />
    <br />
    <asp:Label ID="Label18" runat="server" Text="Numero de Dictamen"></asp:Label>
    <br />
    <uc1:textbox ID="txtNumDictamen" runat="server" Apariencia="SingleText" FieldName="NumDictamen" Habilitado="True" SoloLectura="True" />
    <br />
    <br />
    <br />    
        <br />
       <br />
</div>

<asp:UpdatePanel ID="upAgregarComentario" runat="server">
    <ContentTemplate>
        <div id="pnlAgregarComentario" style="overflow:scroll; height:378px; width:489px; background-color: #000000; position: absolute; top: 338px; left: -199px; background-image: url('../../Imagenes/main_bg.gif'); margin-left: 10px;">      
            <asp:Label ID="Label17" runat="server" Text="Comentario"></asp:Label>
            <br />
            <uc1:TextBox ID="txtComentarios" runat="server" Height="300" MaxLength="4000" width="400" Apariencia="Multiline" />
            <br />
            <asp:Button ID="btnInsertarComentario" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<table>
    <tr>
    <td>
<div id ="anularDictamen" 
        style="overflow:scroll; position: absolute; top: 733px; left: -195px; height: 376px; background-color: #000000; width: 693px; background-image: url('../../Imagenes/main_bg.gif');">
        <br />
        <asp:Button ID="btnAnularDictamen" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
    <asp:Button ID="btnCancelarDictamen" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
        <br />
    <asp:label ID="JustificacionDictamen" runat="server" Text="Justificación dictamen" ForeColor="White"></asp:label>
    <uc1:textbox ID="txtJustificacionDictamen" runat="server" FieldName="Justificacion" 
        MaxLength="500" Apariencia="Multiline" Height="150" width="400" 
        Obligatorio="True" />    
    <asp:Repeater ID="ListadoDictamenRepeater" runat="server" EnableTheming="True">
        <HeaderTemplate>
            <table class="AnularDictamen">
                <tr style="background-color: #696969; color: White;">
                    <th>Anular</th>                   
                    <th>ID</th>
                    <th>Dictamen</th>
                    <th>Expediente</th>
                    <th>Fecha</th>
                    <th>Evaluación</th>
                    <th>Usuario</th>
                    <th>Fecha Cambio</th>
                    <th>Justificación</th>
                </tr>           
        </HeaderTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: Teal">
                <td><asp:CheckBox ID="AnularDictamen" runat="server" Checked='<%# Eval("Anular") %>' /></td>
                <td><asp:Label ID="idDictamen" runat="server" Text='<%# Eval("id") %>' /></td>
                <td><asp:Label ID="Dictamen" runat="server" Text='<%# Eval("NumDictamen") %>' /></td>
                <td><asp:label ID="ExpedienteDictamen" runat="server" Text='<%# Eval("idExpediente") %>' /></td>
                <td><asp:Label ID="FechaDictamen" runat="server" Text='<%# Eval("Fecha") %>' /></td>
                <td><asp:Label ID="EvaluacionDictamen" runat="server" Text='<%# Eval("Tipo") %>' /></td>
                <td><asp:Label ID="idUsuarioDictamen" runat="server" Text='<%# Eval("idusuario") %>' /></td>
                <td><asp:Label ID="FechaCambioDictamen" runat="server" Text='<%# Eval("fModificacion") %>' /></td>
                <td><asp:Label ID="JustificacionDictamen" runat="server" Text='<%# Eval("Justificacion") %>' /></td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color: Aqua">
                <td><asp:CheckBox ID="AnularDictamen" runat="server" Checked='<%# Eval("Anular") %>' /></td>
                <td><asp:Label ID="idDictamen" runat="server" Text='<%# Eval("id") %>' /></td>
                <td><asp:Label ID="Resolución" runat="server" Text='<%# Eval("NumDictamen") %>' /></td>
                <td><asp:label ID="ExpedienteDictamen" runat="server" Text='<%# Eval("idExpediente") %>' /></td>
                <td><asp:Label ID="FechaDictamen" runat="server" Text='<%# Eval("Fecha") %>' /></td>
                <td><asp:Label ID="EvaluacionDictamen" runat="server" Text='<%# Eval("Tipo") %>' /></td>
                <td><asp:Label ID="idUsuarioDictamen" runat="server" Text='<%# Eval("idusuario") %>' /></td>
                <td><asp:Label ID="FechaCambioDictamen" runat="server" Text='<%# Eval("fModificacion") %>' /></td>
                <td><asp:Label ID="JustificacionDictamen" runat="server" Text='<%# Eval("Justificacion") %>' /></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>    
   
    </div>
    
    </td>
    <td>
<div id ="anularresolucion" 
        style="overflow:scroll; position: absolute; top: 343px; left: 305px; height: 375px; background-color: #000000; width: 751px; background-image: url('../../Imagenes/main_bg.gif');">
        <br />
        <asp:Button ID="btnAnularResolucion" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
    <asp:Button ID="btnCancelarResolucion" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />    
        <br />
        <asp:label ID="Justificacion" runat="server" Text="Justificación" ForeColor="White"></asp:label>
    <uc1:textbox ID="txtJustificacion" runat="server" FieldName="Justificacion" 
        MaxLength="500" Apariencia="Multiline" Height="150" width="400" 
        Obligatorio="True" />
        <br />
    <asp:Repeater ID="ListadoResolucionesRepeater" runat="server">
        <HeaderTemplate>
            <table class="ListadoResoluciones">
                <tr style="background-color: #696969; color: White;">
                    <th>Anular</th>                   
                    <th>ID</th>
                    <th>Resolución</th>
                    <th>Expediente</th>
                    <th>Fecha</th>
                    <th>Evaluación</th>
                    <th>Usuario</th>
                    <th>Fecha Cambio</th>
                    <th>Justificación</th>
                </tr>
            
        </HeaderTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: Teal">
                <td><asp:CheckBox ID="Anular" runat="server" Checked='<%# Eval("Anular") %>' /></td>
                <td><asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' /></td>
                <td><asp:Label ID="Resolución" runat="server" Text='<%# Eval("NumeroResolucion") %>' /></td>
                <td><asp:label ID="Expediente" runat="server" Text='<%# Eval("idExpediente") %>' /></td>
                <td><asp:Label ID="Fecha" runat="server" Text='<%# Eval("Fecha") %>' /></td>
                <td><asp:Label ID="Evaluacion" runat="server" Text='<%# Eval("Tipo") %>' /></td>
                <td><asp:Label ID="idUsuario" runat="server" Text='<%# Eval("idUsuario") %>' /></td>
                <td><asp:Label ID="FechaCambio" runat="server" Text='<%# Eval("fModificacion") %>' /></td>
                <td><asp:Label ID="Justificacion" runat="server" Text='<%# Eval("Justificacion") %>' /></td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color: Aqua">
                <td><asp:CheckBox ID="Anular" runat="server" Checked='<%# Eval("Anular") %>' /></td>
                <td><asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' /></td>
                <td><asp:Label ID="Resolución" runat="server" Text='<%# Eval("NumeroResolucion") %>' /></td>
                <td><asp:Label ID="Expediente" runat="server" text='<%# Eval("idExpediente") %>' /></td>
                <td><asp:Label ID="Fecha" runat="server" Text='<%# Eval("Fecha") %>' /></td>
                <td><asp:Label ID="Evaluacion" runat="server" Text='<%# Eval("Tipo") %>' /></td>
                <td><asp:Label ID="idUsuario" runat="server" Text='<%# Eval("idUsuario") %>' /></td>
                <td><asp:Label ID="FechaCambio" runat="server" Text='<%# Eval("fModificacion") %>' /></td>
                <td><asp:Label ID="Justificacion" runat="server" Text='<%# Eval("Justificacion") %>' /></td>
            </tr>
        </ItemTemplate>      
    </asp:Repeater> 
</div>
</td>
    </tr>
    </table>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />

         <asp:ModalPopupExtender ID="mpeAgregarComentario" runat="server" PopupControlID="pnlAgregarComentario" 
        TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelar"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        </asp:ModalPopupExtender>

        <asp:ModalPopupExtender ID="mpeAnularResolucion" runat="server" PopupControlID="anularresolucion" 
        TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarResolucion"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        </asp:ModalPopupExtender>

        <asp:ModalPopupExtender ID="mpeAnularDictamen" runat="server" PopupControlID="anularDictamen" 
        TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarDictamen"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        </asp:ModalPopupExtender>

   <script language="javascript" type="text/javascript">
     function onEntryAdded(sender, eventArgs) {
        /* if (sender.get_count  == 0) {
             eventArgs.set_cancel(true);
         }
         else {
             $(".rddtInner").removeClass("rddtFocused");
         }*/
     }
     function OnClientEntryAdding1(sender, eventArgs) {
         var entry = eventArgs.get_entry()
         if (entry.get_value() >= 10000) {
             eventArgs.set_cancel(true);
         }
     }
    </script> 
        
</asp:Content>
