<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SolicitanteResponsable.ascx.vb" Inherits="smx.SolicitanteResponsable" %>
<%@ Register src="ComboBox.ascx" tagname="combobox" tagprefix="uc2" %>
<%@ Register src="TextBox.ascx" tagname="textbox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link type="text/css" rel="stylesheet" href="../../Modal.css" />

<style type="text/css">
   .SFrame{
        background: #deefff; /* Old browsers */
        background: -moz-linear-gradient(top,  #deefff 0%, #98bede 100%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#deefff), color-stop(100%,#98bede)); /* Chrome,Safari4+ */
        background: -webkit-linear-gradient(top,  #deefff 0%,#98bede 100%); /* Chrome10+,Safari5.1+ */
        background: -o-linear-gradient(top,  #deefff 0%,#98bede 100%); /* Opera 11.10+ */
        background: -ms-linear-gradient(top,  #deefff 0%,#98bede 100%); /* IE10+ */
        background: linear-gradient(to bottom,  #deefff 0%,#98bede 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#deefff', endColorstr='#98bede',GradientType=0 ); /* IE6-9 */
        font-family:Tahoma;
        font-size:small ;
        color:black;  

    }
    .SFrameOrange {
        background: rgb(246,230,180); /* Old browsers */
        background: -moz-linear-gradient(-45deg,  rgba(246,230,180,1) 0%, rgba(237,144,23,1) 100%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, right bottom, color-stop(0%,rgba(246,230,180,1)), color-stop(100%,rgba(237,144,23,1))); /* Chrome,Safari4+ */
        background: -webkit-linear-gradient(-45deg,  rgba(246,230,180,1) 0%,rgba(237,144,23,1) 100%); /* Chrome10+,Safari5.1+ */
        background: -o-linear-gradient(-45deg,  rgba(246,230,180,1) 0%,rgba(237,144,23,1) 100%); /* Opera 11.10+ */
        background: -ms-linear-gradient(-45deg,  rgba(246,230,180,1) 0%,rgba(237,144,23,1) 100%); /* IE10+ */
        background: linear-gradient(135deg,  rgba(246,230,180,1) 0%,rgba(237,144,23,1) 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f6e6b4', endColorstr='#ed9017',GradientType=1 ); /* IE6-9 fallback on horizontal gradient */
        font-family:Tahoma;
        font-size:small ;
    }
.sDialog {
width: 450px;
height: 400px;
border: 5px rgb(89,89,89) solid;
padding: 10px;
margin: 10px;
background: rgb(6, 6, 6);

color: rgb(255, 255, 255);
font-size: inherit;
font-weight: inherit;
font-family: inherit;
font-style: inherit;

text-decoration: inherit;
text-align: left;

line-height: 1.45em;
-webkit-border-radius: 30px;
-moz-border-radius: 30px;
border-radius: 30px;

-moz-box-shadow:  1px 20px 31px 0px rgb(0, 0, 0);
-webkit-box-shadow:  1px 20px 31px 0px rgb(0, 0, 0);
box-shadow:  1px 20px 31px 0px rgb(0, 0, 0);
    }

    .auto-style1 {
        font-family:Tahoma;
        font-size:small;
    }
    .auto-style2 {
        width: 329px;
                font-family:Tahoma;
        font-size:small ;
    }
    .auto-style3 {
        width: 637px;
                font-family:Tahoma;
        font-size:small ;
    }
    .auto-style5 {
        width: 126px;
                font-family:Tahoma;
        font-size:small;
        height: 43px;
    }
    .auto-style7 {
        width: 108px;
                font-family:Tahoma;
        font-size:small;
        text-align: left;
    }
    .auto-style8 {
        width: 637px;
        height: 36px;
                font-family:Tahoma;
        font-size:small;
    }
    .auto-style9 {
        width: 109px;
                font-family:Tahoma;
        font-size:small;
        height: 43px;
    }
    .auto-style12 {
        font-family:Tahoma;
        font-size:small;
    }
    .auto-style18 {
        width: 214px;
        height: 43px;
    }
    .auto-style19 {
        width: 56px;
        height: 43px;
    }
    .auto-style20 {
        width: 69px;
        height: 43px;
    }
    .auto-style21 {
        width: 53px;
        height: 43px;
    }
    .auto-style22 {
        font-family: Tahoma;
        font-size: small;
    }
    .auto-style23 {
        width: 318px;
        font-family: Tahoma;
        font-size: small;
    }
    .auto-style24 {
        font-family: Tahoma;
        font-size: small;
        height: 27px;
    }
    .auto-style25 {
        width: 68px;
        height: 43px;
    }
    </style>

        <table align="center">
        <tr>
            <td class="auto-style8">
                        <asp:Label ID="lblTipoPersona" runat="server" Font-Bold="True"></asp:Label>
                        <uc2:combobox ID="cboTipoSolicitante" runat="server" AutoFill="False" 
                            idFieldName="id" postBack="True" TableName="pTipoSolicitante_List" 
                            textFieldName="Nombre" Obligatorio="True" />
                </td>
        </tr>
        <tr>
            <td class="auto-style3">
            
<asp:UpdatePanel ID="upMainCliente" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="pnlCliente" runat="server" Width="650px" style="text-align: left">
             <table style="border: thin solid #CCCCCC; width: 533px" align="center" class="SFrame">
                <tr>
                    <td align="center" class="auto-style9">
                        <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>
                    </td>
                    <td align="center" class="auto-style18">
               
                        <uc1:TextBox ID="txtClienteResponsable" runat="server" 
                            FieldName="idClienteResponsable" 
                            MensajeError="Este campo es requerido." Obligatorio="False" />
               
                    </td>
                    <td align="center" class="auto-style19">
                        <asp:Button ID="btnMostrarPopupEl" runat="server" Text="Buscar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                    </td>
                    <td align="center" class="auto-style20">
                        <asp:Button ID="btnVerificarEl" runat="server" Text="Verificar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                    </td>
                    <td align="center" class="auto-style25">
                        <asp:Button ID="btnNuevoEl" runat="server" Text="Nuevo" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                    </td>
                </tr>
        </table>

        <table style ="border: thin solid #FF6600; width: 459px; background-color: #FFFFCC;" align="center" class="SFrame">
                    <tr>
                        <td class="auto-style24">

                            <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <uc1:TextBox ID="txtNombresEl" runat="server" FieldName="Nombre" Habilitado="True" MaxLength="60" SoloLectura="True" />
                        </td>
                        <td class="auto-style24" colspan="2">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style12">
                            <asp:Label ID="Label5" runat="server" Text="Nacionalidad"></asp:Label>
                            &nbsp;
                            <uc1:TextBox ID="txtNacionalidad" runat="server" FieldName="NombrePais" SoloLectura="True" />
                        </td>
                        <td class="auto-style1" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style12" colspan="3" id="130">
                            <asp:Button ID="btnAdd" runat="server" BorderWidth="1px" Text="Agregar" Width="130px" CssClass="btn" Height="30px" />
                            <asp:Button ID="btnDellst" runat="server" BorderWidth="1px" Text="Quitar" Width="130px" CssClass="btn" Height="30px" />
                            <asp:Button ID="btnTitula" runat="server" BorderWidth="1px" Text="Titular" Width="130px" CssClass="btn" Height="30px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style22" rowspan="3" colspan="2">
                            <asp:UpdatePanel ID="upLista" runat="server"  UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDellst" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnUp" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDown" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:ListBox ID="lstClientes" runat="server" Width="389px"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style23">
                            <asp:ImageButton ID="btnUp" runat="server" BorderStyle="None" BorderWidth="1px" Height="24px" ImageUrl="~/Imagenes/up.png" Text="Up" Width="24px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style23">
                            <asp:ImageButton ID="btnDown" runat="server" BorderStyle="None" BorderWidth="1px" Height="24px" ImageUrl="~/Imagenes/down.png" Text="Up" Width="24px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style23">&nbsp;</td>
                    </tr>
            </table>
      </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upMainApoderado" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
    <asp:Panel ID="pnlApoderado" runat="server" Width="650px" BorderStyle="None">
                        <table style="border: thin solid #FF6600; width: 533px" align="center" class="SFrame">
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label9" runat="server" Text="Apoderado"></asp:Label>
                                </td>
                                <td class="auto-style18">
                                    <uc1:TextBox ID="txtApoderadoResponsable" runat="server" FieldName="idApoderadoResponsable" Int="True" 
                                        MensajeError="Favor Ingresar un valor para el apoderado"  />
                                </td>
                                <td class="auto-style19">
                                    <asp:Button ID="btnMostrarBusquedaApoderado" runat="server" Text="Buscar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                                <td class="auto-style20">
                                    <asp:Button ID="btnVerificarApoderado" runat="server" 
                Text="Verificar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                                <td class="auto-style21">
                                    <asp:Button ID="btnNuevoApoderado" runat="server" 
                Text="Nuevo" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                            </tr>
                        </table>
                        <table style="border: thin solid #FF6600; width: 459px; background-color: #FFFFCC;" align="center" class="SFrame">
                            <tr>
                                <td style="width: 80px; text-align: left;">
                                    <asp:Label ID="Label16" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <uc1:TextBox ID="txtNombreApoderado" runat="server" 
                FieldName="Nombre" Habilitado="True" MaxLength="60" SoloLectura="True" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upMainInstitucion" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
    <asp:Panel ID="pnlInstitucion" runat="server" Width="650px">
                        <table style="border: thin solid #FF6600; width: 533px" align="center" class="SFrame">
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label56" runat="server" Text="Institución"></asp:Label>
                                </td>
                                <td style="width: 214px">
                                    <uc1:TextBox ID="txtInstitucionResponsable" runat="server" 
                FieldName="idInstitucionResponsable" Int="True" 
                                        MensajeError="Favor ingresar un valor para la institución" />
                                </td>
                                <td style="width: 56px">
                                    <asp:Button ID="btnMostrarBusquedaInstitucion" runat="server" 
                Text="Buscar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                                <td style="width: 69px">
                                    <asp:Button ID="btnVerificarInstitucion" runat="server" 
                Text="Verificar" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                                <td style="width: 53px">
                                    <asp:Button ID="btnNuevoInstitucion" runat="server" 
                Text="Nuevo" BorderWidth="1px" CssClass="btn" Height="30px" Width="100px" />
                                </td>
                            </tr>
                        </table>
                        <table style="border: thin solid #FF6600; width: 459px; background-color: #FFFFCC;" align="center" class="SFrame">
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label58" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtNombreInstitucion" runat="server" 
                FieldName="Nombre" Habilitado="True" MaxLength="100" SoloLectura="True" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label59" runat="server" Text="Siglas"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtSiglas" runat="server" FieldName="Siglas" 
                                        Habilitado="True" MaxLength="20" width="200" SoloLectura="True" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

</td>
        </tr>
         
    </table> 


<asp:UpdatePanel ID="uppnlBuscarApoderado" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
    <ContentTemplate>
        <asp:Button runat="server" ID="hiddenEX1" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeBuscarApoderado" runat="server" PopupControlID="pnlBuscarApoderado" 
        TargetControlID="hiddenEX1" CancelControlID="btnCerrarBusquedaApoderado"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" >
        </asp:ModalPopupExtender>
            <asp:Panel ID="pnlBuscarApoderado" runat="server" Style="display: none" >
                <div class="signup">
                    <div class="signup-ct">
                        <div class="signup-header">
                            <div class="modal_close">
                                <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                            </div>
                            <h2>Búsqueda de Apoderados</h2>
                        </div>
                        <div>
                            <div class="txt-fld">
                                <label for="">
                                Colegiación</label>
                                <uc1:TextBox ID="txtNumColegiacion" runat="server" FieldName="Id" Habilitado="True" MaxLength="15" />
                            </div>
                            <div class="txt-fld">
                                <label for="">
                                Nombre</label>
                                <uc1:TextBox ID="txtNombreApoderadoBuscar" runat="server" FieldName="Nombre" Habilitado="True" MaxLength="30" width="200" />
                            </div> 
                            <div class="txt-fld">
                                <label for="">
                                Departamento</label>
                                <uc2:ComboBox ID="cboDepartamentoApoderadoBuscar" runat="server" AutoFill="True" FieldName="idDepartamento" idFieldName="id" postBack="True" TableName="Departamento" textFieldName="Nombre" OnClientClick="return false"/>
                            </div>
                            <div class="txt-fld">
                                <label for="">
                                Municipio</label>                         
                               <uc2:ComboBox ID="cboMunicipioApoderadoBuscar" runat="server" AutoFill="False" FieldName="idMunicipio" idParentComboBox="idDepartamento" idFieldName="id" TableName="Municipio" textFieldName="Nombre" />
                            </div>
                            <div class="btn-fld">
                                <asp:Button ID="btnBuscarApoderado" runat="server" BorderStyle="None" CssClass="button" Text="Buscar" />
                            </div>
                            <div class="txt-fld">
                                <asp:GridView ID="gvDatosApoderado" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="mGrid" DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="5">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSeleccionarApoderado" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="id" HeaderText="Colegiación" />
                                        <asp:BoundField DataField="NumIdentidad" HeaderText="Identidad" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                        <ItemStyle Width="500px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="#FF3300" />
                                    <FooterStyle ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="pgr" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                            </div>
                            <div class="btn-fld">
                                <asp:Button ID="btnCerrarBusquedaApoderado" runat="server" BorderStyle="None" CssClass="button" Text="Cancelar" />
                            </div>
                        </div>
                    </div>
                </div>    
            </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="uppnlBuscarCliente" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnBuscarEl" />
    </Triggers>
     <ContentTemplate>
    <asp:Button runat="server" ID="hfBuscarCliente" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeBuscarCliente" runat="server" PopupControlID="pnlBuscarCliente" 
    TargetControlID="hfBuscarCliente" CancelControlID="btnCerrarEl"
    RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" >
    </asp:ModalPopupExtender>
        <asp:Panel ID="pnlBuscarCliente" runat="server"  style="display: none;">
            <div class="signup">
                <div class="signup-ct">
                    <div class="signup-header">
                        <div class="modal_close">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                        </div>
                        <h2>Búsqueda de Clientes</h2>
                    </div>
                    <div>
                        <div class="txt-fld">
                            <label for="">Identidad</label>
                            <uc1:TextBox ID="txtIdentidadElBuscar" runat="server" FieldName="NumIdentidad" 
                                    Habilitado="True" MaxLength="15" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Nombre</label>
                            <uc1:TextBox ID="txtNombresElBuscar" runat="server" FieldName="Nombres" 
                                    Habilitado="True" MaxLength="60" width="200" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Nacionalidad</label>
                            <uc2:ComboBox ID="cboNacionalidadElBuscar" runat="server" AutoFill="True" 
                                    FieldName="idPais" idFieldName="id" TableName="Paises" 
                                    textFieldName="Nombre" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Departamento</label>
                    
        <uc2:ComboBox ID="cboDepartamentoElBuscar" runat="server" AutoFill="True" 
                                    FieldName="idDepartamento" idFieldName="id" TableName="Departamento" 
                                    textFieldName="Nombre" postBack="True" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Municipio</label>
                            <uc2:ComboBox ID="cboMunicipioElBuscar" runat="server" AutoFill="False" 
                                    FieldName="idMunicipio" idFieldName="id" TableName="Municipio" 
                                    textFieldName="Nombre" idParentComboBox="IdDepartamento" />
                        </div>
                        <div class="btn-fld">
                            <asp:Button ID="btnBuscarEl" runat="server" Text="Buscar" CssClass="button"/>
                        </div>
                        <div class="txt-fld">
                            <asp:UpdatePanel ID="upPanDatosCliente" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
    <ContentTemplate>
                            <asp:GridView ID="gvDatosEl" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="mGrid" DataKeyNames="Id" EmptyDataText="No se encontraron registros" PagerSettings-Position="Top" PageSize="5" Width="463px" Font-Size="Small">
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="id" HeaderText="Codigo" Visible="true" />
                                    <asp:BoundField DataField="NumIdentidad" HeaderText="Identidad" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="idPais" HeaderText="idPais" Visible="False" />
                                    <asp:BoundField DataField="NombrePais" HeaderText="Pais" />
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#FF3300" />
                                <FooterStyle ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Position="Top" />
                                <PagerStyle CssClass="pgr" ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                            </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
                        </div>
                        <div class="btn-fld">
                            <asp:Button ID="btnCerrarEl" runat="server" Text="Cancelar" CssClass="button"/>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="uppnlBuscarInstitucion" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Button runat="server" ID="hfBuscarInstitucion" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeBuscarInstitucion" runat="server" PopupControlID="pnlBuscarInstitucion"
            TargetControlID="hfBuscarInstitucion" CancelControlID="btnCancelarBusquedaInstitucion"
            RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        </asp:ModalPopupExtender >
        <asp:Panel ID="pnlBuscarInstitucion" runat="server" Style="display: none" >
            <div class="signup">
                <div class="signup-ct">
                    <div class="signup-header">
                        <div class="modal_close">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                        </div>
                        <h2>Búsqueda de Institución</h2>
                    </div>
                    <div>
                        <div class="txt-fld">
                            <label for="">Nombre</label>
                             <uc1:TextBox ID="txtNombreInstitucionBuscar" runat="server" FieldName="Nombre" 
                            Habilitado="True" MaxLength="30" width="200" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Siglas</label>
                             <uc1:TextBox ID="txtSiglasInstitucion" runat="server" FieldName="Siglas" 
                            Habilitado="True" MaxLength="15" />
                        </div>
                        <div class="txt-fld">
                            <label for="">R.T.N.</label>
                            <uc1:TextBox ID="txtRTNInstitucion" runat="server" FieldName="RTN" 
                            Habilitado="True" MaxLength="30" width="200" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Contacto</label>
                            <uc1:TextBox ID="txtNombreContacto" runat="server" FieldName="NombreContacto" 
                            Habilitado="True" MaxLength="150" width="200" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Nacionalidad</label>
                            <uc2:ComboBox ID="cboPaisInstitucionBuscar" runat="server" AutoFill="True" 
                            FieldName="idPais" idFieldName="id" TableName="Paises" 
                            textFieldName="Nombre" />
                        </div>
                        <div class="btn-fld">
                            <asp:Button ID="btnBuscarInstitucion" runat="server" BorderStyle="None" Text="Buscar" CssClass="button" CausesValidation="False"  />                       
                        </div>
                        <div class="txt-fld">
                        <asp:GridView ID="gvDatosInstitucionBusqueda" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3"  ForeColor="Black"
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="5"  CssClass="mGrid" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="464px">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                            CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="Codigo" Visible="true" />
                                <asp:BoundField DataField="RTN" HeaderText="RTN"  Visible="False" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Siglas" HeaderText="Siglas" />
                                <asp:BoundField DataField="NombrePais" HeaderText="Nacionalidad" Visible="False"  />
                            </Columns>
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" CssClass="pgr" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                        </div>
                        <div class="btn-fld">
                            <asp:Button ID="btnCancelarBusquedaInstitucion" runat="server" Text="Cerrar" CssClass="button"/>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upPnlApoderadoAdd" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Button runat="server" ID="hbApoderadoAdd" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAgregarApoderado" runat="server" PopupControlID="pnlApoderadoAdd" 
        TargetControlID="hbApoderadoAdd"    CancelControlID="btnCancelarApoderadoAdd"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
        </asp:ModalPopupExtender>
         <asp:Panel ID="pnlApoderadoAdd" runat="server" Style="display: none" >
            <div class="signup-ct">
                <div class="signup">
                <div class="signup-header">
                        <div class="modal_close">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                        </div>
                        <h2>Registrar Apoderado</h2>
                   </div>
                <div class="AddData">
                        <div class="txt-fld">
                            <label for="">Colegiación</label>
                            <uc1:TextBox ID="txtColegiacion" runat="server" Habilitado="True" Obligatorio="True" FieldName="Id" Int="False" Align="Izquierda" MaxLength="15" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Identidad</label>
                            <uc1:TextBox ID="txtNumIdentidadApoderadoAdd" runat="server" Habilitado="True" 
                            Obligatorio="False" FieldName="NumIdentidad" Int="False" Align="Izquierda" 
                            MaxLength="15" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Primer Nombre</label>
                            <uc1:TextBox ID="txtPrimerNombreApoderado" runat="server" Align="Izquierda" 
                                FieldName="Nombre1" Habilitado="True" Int="False" MaxLength="15" 
                                Obligatorio="True" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Segundo Nombre</label>
                            <uc1:TextBox ID="txtSegundoNombreApoderado" runat="server" Align="Izquierda" 
                                FieldName="Nombre2" Habilitado="True" Int="False" MaxLength="15" 
                                Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Primer Apellido</label>
                            <uc1:TextBox ID="txtPrimerApellidoApoderado" runat="server" Align="Izquierda" 
                            FieldName="Apellido1" Habilitado="True" Int="False" MaxLength="15" 
                            Obligatorio="True" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Segundo Apellido</label>
                            <uc1:TextBox ID="txtSegundoApellidoApoderado" runat="server" Align="Izquierda" 
                            FieldName="Apellido2" Habilitado="True" Int="False" MaxLength="15" 
                            Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Tel. Domicilio</label>
                            <uc1:TextBox ID="txtTelefonoDomicilioApoderado" runat="server" 
                            Align="Izquierda" FieldName="TelefonoDomicilio" Habilitado="True" Int="False" 
                            MaxLength="10" Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Tel. Trabajo</label>
                            <uc1:TextBox ID="txtTelefonoTrabajoApoderado" runat="server" Align="Izquierda" 
                            FieldName="TelefonoTrabajo" Habilitado="True" Int="False" MaxLength="10" 
                            Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Fax</label>
                            <uc1:TextBox ID="txtFaxApoderado" runat="server" Align="Izquierda" 
                            FieldName="NumFax" Habilitado="True" Int="False" MaxLength="10" 
                            Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Celular 1</label>
                    <uc1:TextBox ID="txtTelefonoMovil1Apoderado" runat="server" Align="Izquierda" 
                        FieldName="TelMovil1" Habilitado="True" Int="False" MaxLength="10" 
                        Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Celular 2</label>
                    <uc1:TextBox ID="txtTelefonoMovil2Apoderado" runat="server" Align="Izquierda" 
                        FieldName="TelMovil2" Habilitado="True" Int="False" MaxLength="10" 
                        Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Email 1</label>
                    <uc1:TextBox ID="txtEmail1Apoderado" runat="server" Align="Izquierda" 
                        EnableViewState="True" FieldName="Email1" Habilitado="True" Int="False" 
                        MaxLength="50" Obligatorio="True" width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Email 2</label>
                    <uc1:TextBox ID="txtEmail2Apoderado" runat="server" Align="Izquierda" 
                        EnableViewState="True" FieldName="Email2" Habilitado="True" Int="False" 
                        MaxLength="50" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Dirección Domicilio</label>
                    <uc1:TextBox ID="txtDireccionDomicilioApoderado" runat="server" 
                        Align="Izquierda" Apariencia="Multiline" EnableViewState="True" 
                        FieldName="DireccionDomicilio" Habilitado="True" Height="100" Int="False" 
                        MaxLength="400" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Dirección Trabajo</label>
                    <uc1:TextBox ID="txtDireccionTrabajoApoderado" runat="server" Align="Izquierda" 
                        Apariencia="Multiline" EnableViewState="True" FieldName="DireccionTrabajo" 
                        Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                        width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Departamento</label>
                    <uc2:ComboBox ID="cboDepartamentoApoderadoAdd" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Municipio</label>
                    <uc2:ComboBox ID="cboMunicipioApoderadoAdd" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        TableName="Municipio" textFieldName="Nombre" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Observaciones</label>
                    <uc1:TextBox ID="txtObservacionesApoderado" runat="server" Align="Izquierda" 
                        Apariencia="Multiline" EnableViewState="True" FieldName="Observaciones" 
                        Habilitado="True" Height="110" Int="False" MaxLength="1000" Obligatorio="False" 
                        width="300" />
                        </div>
                    </div>
                <div class="btn-fld">
                    <asp:Button ID="btnCancelarApoderadoAdd" runat="server" Text="Cancelar" class="buttonCancel"/>
                     <div class="btn2">
                        <asp:Button ID="btnGuardarApoderado" runat="server" Text="Aceptar" class="button"/>
                    </div>
                </div>
                </div> 
            </div> 
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upPnlClienteAdd" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Button runat="server" ID="hbtnClienteAdd" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAgregarCliente" runat="server" PopupControlID="pnlDatosClienteEl" 
                      TargetControlID="hbtnClienteAdd"    CancelControlID="btnCancelarClienteEl"
            RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled" >
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDatosClienteEl" runat="server"  Style="display: none">
               <div class="signup">
                   <div class="signup-ct">
                    <div class="signup-header">
                            <div class="modal_close">
                                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                            </div>
                            <h2>Registrar Cliente</h2>
                       </div>
                    <div class="AddData">
                        <div class="txt-fld">
                             <label for="">Código</label>
                            <uc1:TextBox ID="txtCodigo0" runat="server" Align="Izquierda" 
                                    Apariencia="SingleText" FieldName="id" Habilitado="False" Int="True" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Identidad</label>
                            <uc1:TextBox ID="txtNumIdentidad" runat="server" Align="Izquierda" 
                                    FieldName="NumIdentidad" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Pasaporte</label>
                            <uc1:TextBox ID="txtPasaporte" runat="server" Align="Izquierda" 
                                    FieldName="Pasaporte" Habilitado="True" Int="False" MaxLength="20" 
                                    Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Primer Nombre</label>
                            <uc1:TextBox ID="txtNombre1" runat="server" Align="Izquierda" 
                                    FieldName="Nombre1" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="True" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Segundo Nombre</label>
                            <uc1:TextBox ID="txtNombre2" runat="server" Align="Izquierda" 
                                    FieldName="Nombre2" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Primer Apellido</label>
                            <uc1:TextBox ID="txtApellido1" runat="server" Align="Izquierda" 
                                    FieldName="Apellido1" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="True" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Segundo Apellido</label>
                            <uc1:TextBox ID="txtApellido2" runat="server" Align="Izquierda" 
                                    FieldName="Apellido2" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                             <label for="">País</label>
                            <uc2:ComboBox ID="cboPais" runat="server" AutoFill="True" FieldName="idPais" 
                                    idFieldName="id" TableName="Paises" textFieldName="Nombre" 
                                    Obligatorio="True" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Tel. Domicilio</label>
                             <uc1:TextBox ID="txtTelefonoDomicilio" runat="server" Align="Izquierda" 
                                    FieldName="TelefonoDomicilio" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Tel. Trabajo</label>
                            <uc1:TextBox ID="txtTelefonoTrabajo" runat="server" Align="Izquierda" 
                                    FieldName="TelefonoTrabajo" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Fax</label>
                            <uc1:TextBox ID="txtNumFax" runat="server" Align="Izquierda" FieldName="NumFax" 
                                    Habilitado="True" Int="False" MaxLength="10" Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Celular 1</label>
                                   <uc1:TextBox ID="txtTelefonoMovil1" runat="server" Align="Izquierda" 
                                    FieldName="TelMovil1" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Celular 2</label>
                            <uc1:TextBox ID="txtTelefonoMovil2" runat="server" Align="Izquierda" 
                                    FieldName="TelMovil2" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Email 1</label>
                              <uc1:TextBox ID="txtEmail1" runat="server" Align="Izquierda" 
                                    EnableViewState="True" FieldName="Email1" Habilitado="True" Int="False" 
                                    MaxLength="50" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Email 2</label>
                            <uc1:TextBox ID="txtEmail2" runat="server" Align="Izquierda" 
                                    EnableViewState="True" FieldName="Email2" Habilitado="True" Int="False" 
                                    MaxLength="50" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Dir. Domicilio</label>
                            <uc1:TextBox ID="txtDireccionDomicilio" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="DireccionDomicilio" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                    width="400" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Dir. Trabajo</label>
                             <uc1:TextBox ID="txtDireccionTrabajo" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="DireccionTrabajo" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                    width="200" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Departamento</label>
                            <uc2:ComboBox ID="cboDepartamentoClienteNuevo" runat="server" AutoFill="True" 
                                    FieldName="idDepartamento" idFieldName="id" postBack="True" 
                                    TableName="Departamento" textFieldName="Nombre" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Municipio</label>
                            <uc2:ComboBox ID="cboMunicipioClienteNuevo" runat="server" AutoFill="False" 
                                    FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                                    TableName="Municipio" textFieldName="Nombre" />
                        </div>
                        <div class="txt-fld">
                             <label for="">Observaciones</label>
                            <uc1:TextBox ID="txtObservaciones" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="Observaciones" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="1000" Obligatorio="False" 
                                    width="400" />
                        </div>
                    </div>
                    <div class="btn-fld">
                        <asp:Button ID="btnCancelarClienteEl" runat="server" Text="Cancelar"  class="buttonCancel"  />
                         <div class="btn2">
                            <asp:Button ID="btnGuardarClienteEl" runat="server" Text="Aceptar"  class="button" />
                        </div>
                    </div>
                </div> 
        
        
                   </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upPnlInstitucionAdd" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
     <asp:ModalPopupExtender ID="mpeAgregarInstitucion" runat="server" PopupControlID="pnlInstitucionAdd" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarInstitucionAdd"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
         <asp:Panel ID="pnlInstitucionAdd" runat="server" Style="display: none" >
            <div class="signup">
                <div class="signup-ct">
                    <div class="signup-header">
                            <div class="modal_close">
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/Imagenes/modal_close.png" />
                            </div>
                            <h2>Registrar Institución</h2>
                        </div>
                    <div class="AddData">
                        <div class="txt-fld">
                            <label for="">RTN</label>
                            <uc1:TextBox ID="txtRTNInstitucionAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="RTN" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Nombre Institución</label>
                                 <uc1:TextBox ID="txtNombreInstitucionAdd" runat="server" Align="Izquierda" 
                                 Apariencia="Multiline" FieldName="Nombre" Habilitado="True" Int="False" MaxLength="399" 
                                Obligatorio="True" width="250" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Siglas</label>
                        <uc1:TextBox ID="txtSiglasInstitucionAdd" runat="server" Align="Izquierda" 
                                FieldName="Siglas" Habilitado="True" Int="False" MaxLength="20" 
                                Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Nacionalidad</label>
                                                <uc2:ComboBox ID="cboPaisInstitucionAdd" runat="server" AutoFill="True" 
                        FieldName="idPais" idFieldName="id" TableName="Paises" 
                        textFieldName="Nombre" Obligatorio="True" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Teléfono 1</label>
                                     <uc1:TextBox ID="txtTelefono1InstitucionAdd" runat="server" Align="Izquierda" 
                        FieldName="Telefono1" Habilitado="True" Int="False" MaxLength="10" 
                        Obligatorio="True" width="100" />
                        </div>
                         <div class="txt-fld">
                            <label for="">Teléfono 2</label>
                             <uc1:TextBox ID="txtTelefono2InstitucionAdd" runat="server" Align="Izquierda" 
                        FieldName="Telefono2" Habilitado="True" Int="False" MaxLength="10" 
                        Obligatorio="False" width="100" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Fax</label>
                             <uc1:TextBox ID="txtNumFaxInstitucionAdd" runat="server" Align="Izquierda" 
                                FieldName="NumFax" Habilitado="True" Int="False" MaxLength="10" 
                                Obligatorio="False" width="100" />
                        </div>
                       <div class="txt-fld">
                            <label for="">Dirección 1</label>
                              <uc1:TextBox ID="txtDireccion1InstitucionAdd" runat="server" Align="Izquierda" 
                                Apariencia="Multiline" EnableViewState="True" FieldName="Direccion1" 
                                Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                width="250" />
                        </div>
                         <div class="txt-fld">
                            <label for="">Dirección 2</label>
                                 <uc1:TextBox ID="txtDireccion2InstitucionAdd" runat="server" Align="Izquierda" 
                                Apariencia="Multiline" EnableViewState="True" FieldName="Direccion2" 
                                Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                width="250" />
                        </div>
                         <div class="txt-fld">
                            <label for="">Nombre Contacto</label>
                            <uc1:TextBox ID="txtNombreContactoInstitucionAdd" runat="server" 
                                Align="Izquierda" FieldName="NombreContacto" Habilitado="True" Int="False" 
                                MaxLength="150" Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Extensión</label>
 <uc1:TextBox ID="txtExtensionTelefonicaContacto" runat="server" 
                                Align="Izquierda" FieldName="ExtensionTelefonica" Habilitado="True" Int="False" 
                                MaxLength="20" Obligatorio="False" width="150" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Celular</label>
                            <uc1:TextBox ID="txtTelMovilContacto" runat="server" Align="Izquierda" 
                                FieldName="TelMovilContacto" Habilitado="True" Int="False" MaxLength="20" 
                                Obligatorio="False" width="50" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Cargo</label>
 <uc1:TextBox ID="txtCargoContacto" runat="server" Align="Izquierda" 
                                FieldName="CargoContacto" Habilitado="True" Int="False" MaxLength="150" 
                                Obligatorio="False" width="200" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Email </label>
                                   <uc1:TextBox ID="txtEmailContactoInstitucion" runat="server" Align="Izquierda" 
                                EnableViewState="True" FieldName="EmailContacto" Habilitado="True" Int="False" 
                                MaxLength="150" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Sitio Web</label>
                            <uc1:TextBox ID="txtSitioWebContacto" runat="server" Align="Izquierda" 
                                EnableViewState="True" FieldName="SitioWEB" Habilitado="True" Int="False" 
                                MaxLength="50" Obligatorio="False" width="250" />
                        </div>
                        <div class="txt-fld">
                            <label for="">Observaciones</label>
                            <uc1:TextBox ID="txtObservacionesInstitucion" runat="server" Align="Izquierda" 
                                Apariencia="Multiline" FieldName="TelMovil1" Habilitado="True" Height="150" 
                                Int="False" MaxLength="800" Obligatorio="False" width="250" />
                        </div>
                    </div>
                    <div class="btn-fld">
                        <asp:Button ID="btnCancelarInstitucionAdd" runat="server" Text="Cancelar" Class="buttonCancel" />
                         <div class="btn2">
                            <asp:Button ID="btnGuardarInstitucion" runat="server" Text="Aceptar" Class="button" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>