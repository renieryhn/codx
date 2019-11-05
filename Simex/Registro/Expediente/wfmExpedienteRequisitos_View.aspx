<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SubMenu.Master" CodeBehind="wfmExpedienteRequisitos_View.aspx.vb" Inherits="smx.ExpedienteRequisitos" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="DD">
    <asp:Button ID="Button1" runat="server" Text="Aceptar" CssClass="Boton" />
    <asp:Button ID="Button2" runat="server" Text="Cancelar" BorderWidth="1px" CssClass="Boton" />
    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" BorderWidth="1px" CssClass="Boton" />

 <div style = "border: thin solid #808080">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Registro/Expediente/wfmSeguimientoExpediente.aspx" 
        Visible="False">Regresar</asp:HyperLink>
<asp:Repeater ID="ExpedienteRequisitosRepeater" runat="server">
         <HeaderTemplate>
        <table class="ExpedienteRequisito">
          <tr style="background-color: #696969; color:whitesmoke ;">
            <th>ID</th>
            <th>Requisitos</th>
            <th>Cumplido</th>
      </HeaderTemplate>
      <AlternatingItemTemplate>
        <tr style = "background-color:white; font-size:12px">
             <td><asp:Label ID ="IdRequisito" Text = '<%# Eval("id") %>' runat = "server" /></td>
            <td><asp:Label ID ="RequisitoNombre" Text = '<%# Eval("Nombre") %>' runat = "server" /></td>
            <td><asp:CheckBox ID = "Valor" Checked ='<%# Eval("Valor") %>'  runat="server" /></td>
             <td><asp:Label ID ="Nuevo" Text = '<%# Eval("Nuevo") %>' runat = "server" /></td>
        </tr>
      </AlternatingItemTemplate>
      <ItemTemplate>
        <tr style = "background-color: #FFCC99; font-size:12px">
             <td><asp:Label ID ="IdRequisito" Text = '<%# Eval("id") %>' runat = "server" /></td>
            <td><asp:Label ID ="RequisitoNombre" Text = '<%# Eval("Nombre") %>' runat = "server" /></td>
            <td><asp:CheckBox ID = "Valor" Checked ='<%# Eval("Valor") %>'  runat="server" /></td>
             <td><asp:Label ID ="Nuevo" Text = '<%# Eval("Nuevo") %>' runat = "server" /></td>
        </tr>
      </ItemTemplate>
    </asp:Repeater>
</div>

        </div>
</asp:Content>
