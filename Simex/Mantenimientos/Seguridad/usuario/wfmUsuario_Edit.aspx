<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmUsuario_Edit.aspx.vb" Inherits="smx.wfmMenuEdit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
<div class="DD">
    <table style="width: 100%">
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>                
            </td>
            <td style="width: 293px">                
<uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
            </td>
            <td>                
                Fotografía</td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td style="width: 293px">
<uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" MaxLength="50" width="300" />
            </td>
            <td rowspan="8">
                <asp:Image ID="imgFoto" runat="server" AlternateText="No hay Foto" BackColor="Black" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" Height="230px" ImageUrl="~/Fotos/oficial.png" Width="226px" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="width: 293px">
<uc1:TextBox ID="txtPassword" runat="server" Apariencia="Password" Obligatorio="False" FieldName="PassWord" Align="Izquierda" MaxLength="25" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label>      
            </td>
            <td style="width: 293px">      
<uc2:ListBox ID="cbRol" runat="server" idFieldName="id" Obligatorio="True" TableName="Rol" textFieldName="Nombre" FieldName="idRol" AutoFill="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
            </td>
            <td style="width: 293px">
<uc3:DateControl ID="dtFecha" runat="server" FieldName="Fecha" Obligatorio="True" FechaHora="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label6" runat="server" Text="Inactivo"></asp:Label>
            </td>
            <td style="width: 293px">
<asp:CheckBox ID="cbActivo" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label10" runat="server" Text="Empleado"></asp:Label>                
            </td>
            <td style="width: 293px">                
<uc2:ListBox ID="cbEmpleado" runat="server" idFieldName="id" Obligatorio="True" 
TableName="Empleados" 
        textFieldName="isnull(Nombre1, '') + ' '+ isnull(Apellido1, '') as Nombre" 
        FieldName="idEmpleado" AutoFill="True" Ordenacion="Nombre1" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
<asp:Label ID="Label8" runat="server" Text="Carga de trabajo"></asp:Label>

            </td>
            <td style="width: 293px">

<asp:CheckBox ID="cbCargaTrabajo" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px; height: 15px;">
<asp:Label ID="Label9" runat="server" Text="Ubicación"></asp:Label>
                
            </td>
            <td style="width: 293px; height: 15px">
                
<uc2:ListBox ID="cbUbicacion" runat="server" idFieldName="id" Obligatorio="True" TableName="Ubicacion" textFieldName="Nombre" 
FieldName="idUbicacion" AutoFill="True" postBack="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">
                Asignación Automática</td>
            <td style="width: 293px">
                
<asp:CheckBox ID="cbAsignacionAuto" runat="server" AutoPostBack="True" />
            </td>
            <td>
                
                <asp:Button ID="btnQuitar" runat="server" Height="30px" Text="Quitar Foto" Width="99px" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">Asignación Orden:</td>
            <td style="width: 293px">
<uc1:TextBox ID="txtAsignacionOrden" runat="server" Habilitado="True" 
Obligatorio="True" FieldName="AsignacionOrden" Int="True" Align="Izquierda" MaxLength="2" width="50" ValorMaximo="1" ValorMinimo="99" />
            </td>
            <td>
                <asp:FileUpload ID="upFoto" runat="server" Height="30px" />
                <asp:Button ID="btnCargar" runat="server" Height="30px" Text="Cargar Foto" Width="99px" />
            </td>
        </tr>
        <tr>
            <td style="height: 18px; background-color: #999999;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 149px; height: 18px;"></td>
            <td style="height: 18px;" colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 120px">Servicio:</td>
                        <td style="width: 294px">
                                       
                        <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                            FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" 
                            textFieldName="Nombre" />

                                </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 120px">Porcentaje de Carga:</td>
                        <td style="width: 294px">
<uc1:TextBox ID="txtPorcentaje" runat="server" Habilitado="True" 
Obligatorio="True" FieldName="PorcentajeCarga" Int="True" Align="Izquierda" MaxLength="2" width="128" Height="17" ValorMaximo="100" ValorMinimo="0" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 149px; height: 18px;">&nbsp;</td>
            <td style="height: 18px;" colspan="2">
                <asp:Button ID="btnAdd" runat="server" Height="30px" Text="Agregar criterio" Width="260px" />
            </td>
        </tr>
        <tr>
            <td style="width: 149px">&nbsp;</td>
            <td colspan="2">
                <asp:GridView ID="gvCarga" runat="server" AutoGenerateColumns="False" Width="421px">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Del" Text="Eliminar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="ID">
                        <ItemStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Servicio">
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PorcentajeCarga" HeaderText="Porcentaje de Carga">
                        <ItemStyle Width="80px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 149px">&nbsp;</td>
            <td style="width: 293px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<br />
                
<asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_List.aspx" 
Visible="False">[HyperLink1]</asp:HyperLink>
                
<asp:HyperLink ID="linkMe" runat="server" NavigateUrl="~/Mantenimientos/Seguridad/usuario/wfmUsuario_Add.aspx" 
Visible="False">[linkMe]</asp:HyperLink>
               </div>
</asp:Content>
