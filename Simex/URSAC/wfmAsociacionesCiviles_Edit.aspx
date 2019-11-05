<%@ Page  Language="vb" AutoEventWireup="false" CodeBehind="wfmAsociacionesCiviles_Edit.aspx.vb" Inherits="smx.wfmAsociacionesCiviles_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ListBox" tagprefix="uc2" %>
<%@ Register src="../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
      <div class="DD">
   <table style="width: 100%">
        <tr>
            <td style="width: 158px; height: 24px;">

                    Número de Registro</td>
            <td style="height: 24px">
                    <uc1:TextBox ID="txtNumRegistro" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="NumRegistro" Align="Izquierda" />
                        <asp:Label ID="lblCancel" runat="server" BackColor="#CCCCCC" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="CANCELADA" Visible="False"></asp:Label>
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
            <td style="width: 158px; height: 25px;">

                    Expediente Relacionado</td>
            <td style="height: 25px">
                
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 180px">
                
                    <uc1:TextBox ID="txtNumExpediente" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NumExpediente" Int="False" Align="Izquierda" 
                        MaxLength="20" width="120" />
                            </td>
                            <td style="width: 38px">
                                <asp:ImageButton ID="btnValidateExpediente" runat="server" ImageUrl="~/Imagenes/validate-icon.png" style="margin-left: 0px" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                        </td>
        </tr>
        <tr>
            <td style="height: 15px;" colspan="2">

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
            
                <uc4:SolicitanteResponsable ID="EncargadoResponsable" runat="server" 
                    TipoEntidad="Encargado" idMostrar="A, I, C" 
                    MostrarApoderado="True" MostrarCliente="False" MostrarInstitucion="False" />
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
                    idFieldName="id" idParentComboBox="idDepartamento" TableName="Municipio" textFieldName="Nombre" />
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
            <td style="width: 144px; height: 26px;">
                Subtipo de Asociación</td>
            <td style="height: 26px">
                <uc2:ComboBox ID="cboSubtipo" runat="server" AutoFill="False" FieldName="IdSubTipoAsociacion"
                    idFieldName="Id" idParentComboBox="idTipo" 
                    TableName="UR_Subtipo" textFieldName="Nombre" postBack="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 158px">
                    Estado</td>
            <td>
                
                    <asp:RadioButton ID="rActivo" runat="server" Checked="True" Text="Activa" ValidationGroup="ESTADO" AutoPostBack="True" />
                    <asp:RadioButton ID="rInactivo" runat="server" Text="Inactiva" ValidationGroup="ESTADO" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 158px">
                    &nbsp;</td>
            <td>
                
                    &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">
                    &nbsp;</td>
            <td>
                
                    &nbsp;</td>
        </tr>
    </table> 
          <p>
      <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/URSAC/wfmAsociacionesCiviles_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
         
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/URSAC/wfmAsociacionesCiviles_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
         </p>
          </div>
</asp:Content>


