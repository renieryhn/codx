<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmacion.aspx.vb" Inherits="smx.Confirmacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
          .btn {
  background: #3498db;
  background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
  background-image: -moz-linear-gradient(top, #3498db, #2980b9);
  background-image: -ms-linear-gradient(top, #3498db, #2980b9);
  background-image: -o-linear-gradient(top, #3498db, #2980b9);
  background-image: linear-gradient(to bottom, #3498db, #2980b9);
  -webkit-border-radius: 28;
  -moz-border-radius: 28;
  border-radius: 28px;
  font-family: Arial;
  color: #ffffff;
  font-size: 20px;
  padding: 10px 20px 10px 20px;
  text-decoration: none;
}
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <h3><em>Su Constraseña ha sido enviada a la dirección indicada.<br />
        Por favor revise su Email y entre de nuevo al sistema.<br />
            <span class="auto-style1"><strong>NOTA:</strong></span> <span class="auto-style1">Algunas ocaciones puede tardar hasta 5 minutos en recibir el correo,
            <br />
            si después de este tiempo no recibe nada, por favor revise tambien en su vandeja de SPAM</span></em></h3>
        .<br />
        <br />
        <asp:Button ID="btnAceptar" runat="server" BackColor="#3399FF" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px" Height="54px" Text="Volver a la pantalla de inicio de sesión" CssClass="btn" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="288px" ImageUrl="~/Imagenes/Confirmacion.jpg" Width="313px" />
    
    </div>
    </form>
</body>
</html>
