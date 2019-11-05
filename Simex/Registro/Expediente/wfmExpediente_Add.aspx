<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmExpediente_Add.aspx.vb" Inherits="smx.wfmExpediente_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc4" %>
<%@ Register src="~/Controles/SolicitanteResponsable.ascx" tagname="InteresadoSolicitante" tagprefix="uc5" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
            
                <uc4:SolicitanteResponsable ID="EncargadoResponsable" runat="server" 
                    TipoEntidad="Encargado o Responsable" idMostrar="A, I, C" 
                    MostrarApoderado="True" MostrarCliente="True" MostrarInstitucion="True" MostrarClientesMultiples="True" />
            </td>
        </tr>
        <tr>
            <td>
            
                <uc5:InteresadoSolicitante ID="InteresadoSolicitante" runat="server" 
                    TipoEntidad="Interesado o Solicitante" MostrarApoderado="False" 
                    MostrarCliente="True" MostrarInstitucion="True" MostrarClientesMultiples="True">
                </uc5:InteresadoSolicitante>
        </tr>
        <tr>
            <td>
    <div class ="DD">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 32%"></td>
                                <td colspan="4">
                                    <asp:Label ID="Label119" runat="server" Font-Bold="True" Text="Datos del Expediente:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td style="width: 13%">
                                    <asp:Label ID="Label120" runat="server" Text="Servicio"></asp:Label>
                                </td>
                                <td style="width: 653px">
                                    <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" FieldName="idServicio" idFieldName="id" Obligatorio="True" postBack="True" TableName="Servicios" textFieldName="Nombre" AditionalCondition="IdModulo=1" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td style="width: 13%">
                                    <asp:Label ID="Label121" runat="server" Text="Sub Servicio"></asp:Label>
                                </td>
                                <td style="width: 653px">
                                    <uc2:ComboBox ID="cboSubServicio" runat="server" AditionalCondition="indEstado='A'" AutoFill="False" FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" postBack="True" TableName="SubServicios" textFieldName="Nombre" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td style="width: 13%">
                                    <asp:Label ID="Label123" runat="server" Text="Recibo"></asp:Label>
                                </td>
                                <td style="width: 653px">
                                    <uc1:TextBox ID="txtNumRecibo" runat="server" FieldName="NumRecibo" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td style="width: 13%">
                                    <asp:Label ID="Label122" runat="server" Text="Departamento"></asp:Label>
                                </td>
                                <td style="width: 653px">
                                    <uc2:ComboBox ID="cboDepartamentoExpediente" runat="server" AutoFill="True" FieldName="idDepartamento" idFieldName="id" postBack="True" TableName="Departamento" textFieldName="Nombre" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td style="width: 13%">
                                    <asp:Label ID="Label124" runat="server" Text="Municipio"></asp:Label>
                                </td>
                                <td style="width: 653px">
                                    <uc2:ComboBox ID="cboMunicipioExpediente" runat="server" AutoFill="False" FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" TableName="Municipio" textFieldName="Nombre" />
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%; height: 24px;"></td>
                                <td style="width: 13%; height: 24px;">
                                    <asp:Label ID="Label125" runat="server" Text="Observaciones"></asp:Label>
                                </td>
                                <td style="width: 653px; height: 24px;">
                                    <uc1:TextBox ID="txtObservacionesExpediente" runat="server" Apariencia="Multiline" FieldName="Comentario" Height="100" width="200" />
                                </td>
                                <td colspan="2" style="height: 24px"></td>
                            </tr>
                            <tr>
                                <td style="width: 32%; height: 38px;"></td>
                                <td colspan="4" style="height: 38px; text-align: left;">
                                    <telerik:RadListBox ID="rlstRequisitos" runat="server" ButtonSettings-HorizontalAlign="Right" CheckBoxes="true" Height="300px" Localization-CheckAll="Marcar Todos los Requisitos" SelectionMode="Multiple" ShowCheckAll="true" Width="100%">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 32%; height: 82px;">&nbsp;</td>
                                <td colspan="4" style="height: 82px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td style="width: 45%">&nbsp;</td>
                                <td style="width: 6%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 32%">&nbsp;</td>
                                <td colspan="2">
                                    <asp:HyperLink ID="linkMain" runat="server" NavigateUrl="~/Reportes/ExReporter.aspx" Visible="False">[linkMain]</asp:HyperLink>
                                </td>
                                <td style="width: 45%">
                                    <asp:HyperLink ID="LinkMe" runat="server" NavigateUrl="~/Registro/Expediente/wfmExpediente_Add.aspx" Visible="False">[LinkMe]</asp:HyperLink>
                                </td>
                                <td style="width: 6%">&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
    </div>

        </tr>
        <tr>
            <td>


        </tr>
        <tr>
            <td>

                      
        </tr>
    </table> 
                                </td>
              
    <%--</td>
    </tr>
    </table>--%>

</asp:Content>
