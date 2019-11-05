<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmApoderados_Edit.aspx.vb" Inherits="smx.wfmApoderados_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
       <div class="DD">
<table class="style1" style="width: 100%">
            <tr>
                <td class="style2" align="left" style="margin-left: 160px; width: 99px;">
                    No.&nbsp; Colegiación</td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label10" runat="server" Text="Fax"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtNumFax" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NumFax" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label2" runat="server" Text="No. Identidad"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtNumIdentidad" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NumIdentidad" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label11" runat="server" Text="Teléfono Móvil 1"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtTelefonoMovil1" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelMovil1" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label3" runat="server" Text="Primer Nombre"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtNombre1" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Nombre1" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label12" runat="server" Text="Teléfono Móvil 2"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtTelefonoMovil2" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelMovil2" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label4" runat="server" Text="Segundo Nombre"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtNombre2" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Nombre2" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label13" runat="server" Text="Email 1"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtEmail1" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Email1" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" EnableViewState="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label5" runat="server" Text="Primer Apellido"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtApellido1" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Apellido1" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label14" runat="server" Text="Email 2"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtEmail2" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Email2" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" EnableViewState="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label6" runat="server" Text="Segundo Apellido"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtApellido2" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Apellido2" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label17" runat="server" Text="Departamento"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc2:ComboBox ID="cboDepartamento" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label8" runat="server" Text="Teléfono Domicilio"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtTelefonoDomicilio" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelefonoDomicilio" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label18" runat="server" Text="Municipio"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc2:ComboBox ID="cboMunicipio" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        TableName="Municipio" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label9" runat="server" Text="Teléfono Trabajo"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtTelefonoTrabajo" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelefonoTrabajo" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 340px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label15" runat="server" Text="Dirección Domicilio"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtDireccionDomicilio" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="DireccionDomicilio" Int="False" Align="Izquierda" 
                        MaxLength="400" width="200" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
                <td style="width: 91px">
                    <asp:Label ID="Label16" runat="server" Text="Dirección Trabajo"></asp:Label>
                </td>
                <td style="width: 340px">
                    <uc1:TextBox ID="txtDireccionTrabajo" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="DireccionTrabajo" Int="False" Align="Izquierda" 
                        MaxLength="400" width="200" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:Label ID="Label19" runat="server" Text="Observaciones"></asp:Label>
                </td>
                <td style="width: 119px">
                    <uc1:TextBox ID="txtObservaciones" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Observaciones" Int="False" Align="Izquierda" 
                        MaxLength="1000" width="200" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 340px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" align="left" style="width: 99px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Apoderados/wfmApoderados_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                </td>
                <td style="width: 119px">
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Apoderados/wfmApoderados_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
                </td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 340px">
                    &nbsp;</td>
            </tr>
        </table>
           </div>
</asp:Content>
