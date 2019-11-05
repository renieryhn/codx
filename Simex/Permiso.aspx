<%@ Page Language="VB" MasterPageFile="" CodeBehind="Permiso.aspx.vb" Inherits="smx._Permiso" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>

    <form id="form1" runat="server">

    <div style="font-family: tahoma; font-size: medium; vertical-align: middle; text-align: center; height: 548px; background-color: #FFFFFF;">
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/permiso.jpg" Width="500px" ImageAlign="Middle" style="text-align: center" BorderColor="#333333" BorderStyle="Solid" BorderWidth="3px" />
            <br />
            <br />
            No tiene acceso a esta función del sistema, 
            <br />
            si necesita acceso por favor pongase en contacto con el Administrador del sistema.<br />
            Ext.2056<br />
            <br />
            <a href="mailto:reniery@gmail.com">reniery@gmail.com</a><br />
            <br />
            <asp:Label ID="lblMSG" runat="server"></asp:Label>
            <br />
&nbsp;<br />
            <asp:Button ID="btnVolver" runat="server" Height="61px" Text="Volver" Width="164px" />
        </div>



</form>




