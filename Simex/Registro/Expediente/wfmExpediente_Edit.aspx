<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmExpediente_Edit.aspx.vb" Inherits="smx.wfmExpediente_Edit" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="InteresadoSolicitante" tagprefix="uc5" %>

<%@ Register namespace="Spire.Barcode.WebUI" tagprefix="WebUI" %>
<%@ Register Assembly="Spire.Barcode" Namespace="Spire.Barcode.WebUI" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
    <div>
        <uc4:SolicitanteResponsable ID="EncargadoResponsable" runat="server" 
        TipoEntidad="Encargado o Responsable" idMostrar="A, I, C" 
        MostrarApoderado="True" MostrarCliente="True" MostrarInstitucion="True" />


        <uc5:InteresadoSolicitante ID="InteresadoSolicitante" runat="server" 
        TipoEntidad="Interesado o Solicitante" MostrarApoderado="False" 
        MostrarCliente="True" MostrarInstitucion="True">
        </uc5:InteresadoSolicitante>
    </div>

<div class="DD">
                
                    
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 187px">
                    <asp:Label ID="Label119" runat="server" Font-Bold="True" 
                        Text="Datos del Expediente:"></asp:Label>                                                                                    
                                                  
                            </td>
                            <td>
                                <uc1:TextBox ID="txtCodigoExpediente" runat="server" FieldName="id" Habilitado="True" MaxLength="17" Obligatorio="True" SoloLectura="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">                                                                                    
                                                  
                    <asp:Label ID="Label120" runat="server" Text="Servicio"></asp:Label>
                                       
                            </td>
                            <td>
                                       
                    <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                        FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" 
                        textFieldName="Nombre" Obligatorio="True" AditionalCondition="IdModulo=1"/>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">

                    <asp:Label ID="Label121" runat="server" Text="Sub Servicio"></asp:Label>
               
                                       
                            </td>
                            <td>
               
                                       
            <uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="False" 
                        FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" 
                        TableName="SubServicios" textFieldName="Nombre" postBack="True" Obligatorio="True" />

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">

                    <asp:Label ID="Label123" runat="server" Text="Recibo"></asp:Label>
                        
                            </td>
                            <td>
                        
                        <uc1:TextBox ID="txtNumRecibo" runat="server" FieldName="NumRecibo" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">
                    <asp:Label ID="Label122" runat="server" Text="Departamento"></asp:Label>
                        
                            </td>
                            <td>
                        
                    <uc2:ComboBox ID="cboDepartamentoExpediente" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" TableName="Departamento" 
                        textFieldName="Nombre" postBack="True" Obligatorio="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">
                    <asp:Label ID="Label124" runat="server" Text="Municipio"></asp:Label>
                        
                            </td>
                            <td>
                        
                    <uc2:ComboBox ID="cboMunicipioExpediente" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" TableName="Municipio" 
                        textFieldName="Nombre" idParentComboBox="idDepartamento" Obligatorio="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">
                    <asp:Label ID="Label125" runat="server" Text="Observaciones"></asp:Label>
                        
                            </td>
                            <td>
                        
                    <uc1:TextBox ID="txtObservacionesExpediente" runat="server" Height="200" 
                            width="400" FieldName="Comentario" Apariencia="Multiline" />

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">&nbsp;</td>
                            <td>

                        <asp:HyperLink ID="linkMain" runat="server" 
                            NavigateUrl="~/Registro/Expediente/wfmExpediente_List.aspx" 
                            Visible="False">[linkMain]</asp:HyperLink>
                        
                        <asp:HyperLink ID="LinkMe" runat="server" 
                            NavigateUrl="~/Registro/Expediente/wfmExpediente_Add.aspx" 
                            Visible="False">[LinkMe]</asp:HyperLink>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px; height: 17px;"></td>
                            <td style="height: 17px">

            <cc1:BarCodeControl ID="bCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">&nbsp;</td>
                            <td>

            <cc1:BarCodeControl ID="bCode2" runat="server" Height="50px" ImageHeight="50" ImageWidth="50" ShowText="False" Type="QRCode" Width="50px" BarHeight="50" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 187px; height: 32px;"></td>
                            <td style="height: 32px">

                                </td>
                        </tr>
                        <tr>
                            <td style="width: 187px">&nbsp;</td>
                            <td>


                            </td>
                        </tr>
                    </table>  
       
</div>   
        </ContentTemplate>
    </asp:UpdatePanel>                                  
</asp:Content>
