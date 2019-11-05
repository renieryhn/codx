﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmInstituciones_Edit.aspx.vb" Inherits="smx.wfmInstituciones_Edit" MasterPageFile="~/Propiedades.Master" %>

<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <table class="DD" style="width: 503px">
        <tr>
            <td class="style2" align="left" style="width: 141px">
                <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    RTN</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtRTN" runat="server" FieldName="RTN" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="150" width="250" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Siglas</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtSiglas" runat="server" FieldName="Siglas" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Nacionalidad</td>
            <td style="width: 232px">
                <uc2:ComboBox ID="cboPais" runat="server" AutoFill="True" FieldName="idPais" 
                        idFieldName="id" TableName="Paises" textFieldName="Nombre" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Telefono1</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtTelefono1" runat="server" FieldName="Telefono1" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Telefono2</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtTelefono2" runat="server" FieldName="Telefono2" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Fax</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtNumFax" runat="server" FieldName="NumFax" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Domicilio1</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtDireccion1" runat="server" Apariencia="Multiline" 
                        FieldName="Direccion1"  MaxLength="400" width="250" EnableViewState="True" Height="100" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Domicilio2</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtDireccion2" runat="server" Apariencia="Multiline" 
                        FieldName="Direccion2"  MaxLength="400" width="250" EnableViewState="True" Height="100"/>
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Nombre Contacto</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtNombreContacto" runat="server" FieldName="NombreContacto" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Extension</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtExtensionTelefonica" runat="server" 
                        FieldName="ExtensionTelefonica" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Telefono Movil</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtTelMovilContacto" runat="server" 
                        FieldName="TelMovilContacto" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Puesto o Cargo</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtCargoContacto" runat="server" FieldName="CargoContacto" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Email</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtEmailContacto" runat="server" FieldName="EmailContacto" MaxLength="100" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    Sitio WEB</td>
            <td style="width: 232px">
                <uc1:TextBox ID="txtSitioWEB" runat="server" FieldName="SitioWEB" />
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    </td>
            <td style="width: 232px">
                    </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 141px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Instituciones/wfmInstituciones_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
            </td>
            <td style="width: 232px">
                <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/Instituciones/wfmInstituciones_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>


