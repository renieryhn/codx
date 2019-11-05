﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmTramites_Add.aspx.vb" Inherits="smx.wfmTramites_Add" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
    <div class="DD">
   <table style="width: 100%">
        <tr>
            <td style="width: 158px; height: 24px;">

                    Número de Registro</td>
            <td style="height: 24px">
                    <uc1:TextBox ID="txtNumRegistro" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="NumRegistro" Align="Izquierda" />
                        </td>
        </tr>
        <tr>
            <td style="width: 158px; height: 25px;">

                    Fecha de Registro</td>
            <td style="height: 25px">
                <uc3:DateControl ID="dtcFechaRegistro" runat="server" FechaHora="False" 
                    FieldName="FechaRegistro" Obligatorio="True" />
                        </td>
        </tr>
        <tr>
            <td style="width: 158px; height: 12px;">
            
                <uc4:SolicitanteResponsable ID="Asociacion" runat="server" 
                    TipoEntidad="Asociacion" idMostrar="A, I, C" 
                    MostrarApoderado="False" MostrarCliente="False" MostrarInstitucion="True" TipoEntidadCombo="1" />
            </td>
            <td style="height: 12px">
                
                </td>
        </tr>
        <tr>
            <td style="width: 158px; height: 9px;">
            
                <uc4:SolicitanteResponsable ID="EncargadoResponsable" runat="server" MostrarApoderado="True" MostrarCliente="True" MostrarInstitucion="False" ClientesMultiples="False" />
            </td>
            <td style="height: 9px">
                
                </td>
        </tr>
        <tr>
            <td style="height: 9px;" colspan="2">
                    <strong>Datos de Ubicación y Clasificación</strong></td>
        </tr>
        <tr>
            <td class="style4" style="width: 148px">
                Departamento
            </td>
            <td>
                <uc2:ComboBox ID="cboDepartamento" runat="server" AutoFill="True" FieldName="idDepartamento"
                    idFieldName="id" Obligatorio="True" TableName="Departamento" textFieldName="Nombre"
                    postBack="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 144px">
                Municipio
            </td>
            <td>
                <uc2:ListBox ID="cboMunicipio" runat="server" AutoFill="False" FieldName="idMunicipio"
                    idFieldName="id" idParentComboBox="idDepartamento" TableName="Municipio" textFieldName="Nombre" postBack="True" />
            </td>
        </tr>
        <tr>
            <td class="style4" style="width: 148px">
                Tipo de Asociación</td>
            <td>
                <uc2:ComboBox ID="cboTipoAsoc" runat="server" AutoFill="True" FieldName="IdTipoAsociacion"
                    idFieldName="Id" postBack="True" TableName="UR_Tipo" textFieldName="Nombre" EnableTheming="True" Obligatorio="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 158px">
                    <b>Folio:</b></td>
            <td>
                
                    <uc1:TextBox ID="txtTomo" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Tomo" Int="True" Align="Izquierda" 
                        MaxLength="20" width="120" />
                            </td>
        </tr>
        <tr>
            <td style="width: 158px; height: 18px;">
                    <b>Tomo:</b></td>
            <td style="height: 18px">
                
                    <uc1:TextBox ID="txtFolio" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Folio" Int="True" Align="Izquierda" 
                        MaxLength="20" width="120" />
                            </td>
        </tr>
        <tr>
            <td style="width: 158px">
                    Notas Marginales</td>
            <td>
                
                    <uc1:TextBox ID="txtNotasMarginales" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NotasMarginales" Int="False" Align="Izquierda" 
                        MaxLength="4000" width="400" />
                            </td>
        </tr>
    </table> 
    <p>
    <asp:HyperLink ID="linkMain" runat="server"                 
        NavigateUrl="~/Otros/Tramites/wfmTramites_List.aspx" 
        Visible="False">[linkMain]</asp:HyperLink>          
    <asp:HyperLink ID="linkMe" runat="server"                    
        NavigateUrl="~/Otros/Tramites/wfmTramites_Add.aspx" 
        Visible="False">[linkMe]</asp:HyperLink>
    </p>
    </div>

    <script type="text/javascript">
        function popup() {
            window.open("Formulario web1.aspx");
        }
    </script>

</asp:Content>



