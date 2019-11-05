<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="URSubMenu.Master" EnableEventValidation="false" CodeBehind="wfmRegistroTramitesEnLinea.aspx.vb" Inherits="smx.wfmRegistroTramitesEnLinea" %>
<%@ MasterType VirtualPath="URSubMenu.Master"%>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="stylesheet" href="../Modal.css" />
    <script type = "text/javascript">
        var isShift = false;
        function keyUP(keyCode) 
        {
            if (keyCode == 16)
            {
                isShift = false;
            }
        }
        function isNumeric(keyCode) 
        {
            if (keyCode == 16) 
            {
                isShift = true;
            }
            return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 || (keyCode >= 96 && keyCode <= 105)) && isShift == false);
        }
    </script>

   <div id="Forma" style="width: 166%; height: 235%; border: thin none #E0E0E0; position: relative; top: 15px; left: -5px;" >

    <br />

        <asp:Button ID="btnNuevaClave" runat="server" Text="Generar Nueva Contraseña" CssClass="Boton" Height="45px" Width="244px" />
            
     <asp:ModalPopupExtender ID="mpeFormulario" runat="server" PopupControlID="pnlForm" 
                  TargetControlID="btnNuevaClave" BackgroundCssClass="lean_overlay"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" DropShadow="True">
    </asp:ModalPopupExtender>

    <br />
       </div>

    <asp:Panel ID="pnlForm" runat="server" >
        <div id="signup">
             <div id="signup-ct">
                <div id="signup-header">
                    <div class="modal_close">
                        <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                    </div>
                    <h2>Generar contraseña para transacciones en linea</h2>
                </div>
                 <asp:UpdatePanel ID="upPan" runat="server">
    <ContentTemplate>
                <form action="" >
                    <div class="txt-fld">
                         <label for="">Enviar a:</label>
                         <br />
                         <br />
                        <asp:RadioButton ID="rApo" runat="server" Text="Apoderado" AutoPostBack="True" Font-Size="XX-Small" GroupName="Sel" Checked="True" />
                         <br />
                         <br />
                        <asp:RadioButton ID="rEmpresa" runat="server" Text="Contacto Asociación" AutoPostBack="True" GroupName="Sel" />
                         <br />
                         <br />
                        <asp:RadioButton ID="rMiembro" runat="server" Text="Miembro de JD" AutoPostBack="True" GroupName="Sel" />    
                           <br />
                         <br />                     
                    </div>
                    <div class="txt-fld">
                         <label for="">Persona:</label>
                         <asp:DropDownList ID="cmbMiembro" runat="server" AutoPostBack="True">
                         </asp:DropDownList>
                         <br />
                         <br />
                        <asp:TextBox ID="txtDestinatario" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="txt-fld">
                         <label for="">Email:</label>
                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                         &nbsp;<asp:RegularExpressionValidator ID="rEmail" runat="server" ControlToValidate="txtCorreo" ErrorMessage="El Email no es correcto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="txt-fld">
                         <asp:TextBox ID="txtMsg" Visible ="false"  runat="server"></asp:TextBox>
                    </div>
                <div class="btn-fld">
                    <asp:Button ID="btnGenerar" class="button" runat="server" Text="Generar y Enviar Contraseña" />
                </div>
                </form>
    </ContentTemplate>
</asp:UpdatePanel>
             </div>
        </div>
    </asp:Panel>
</asp:Content>
