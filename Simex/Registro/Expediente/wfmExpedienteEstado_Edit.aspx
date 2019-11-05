﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmExpedienteEstado_Edit.aspx.vb" Inherits="smx.wfmSeguimientoExpediente_Edit" MasterPageFile="../../SubMenu.Master" %>
<%@ MasterType VirtualPath="~/SubMenu.Master"%>
<%@ Register src="../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc1" %>
<%@ Register src="../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc2" %>
<%@ Register src="../../Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc3" %>


<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
            <asp:Panel runat="server" Width="933px" ID="Panel1" Height="24px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label10" runat="server" Text="Estado a Modificar"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Fecha de Recepción"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Recibido por"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Fecha Asignación"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Asignado A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <uc1:ComboBox ID="cboEstadoActual" runat="server" habilitado="False" 
                                AutoFill="False" TableName="pEstado_List" />
                        </td>
                        <td>
                            <uc2:DateControl ID="dtcFechaRecepcion" runat="server" FechaHora="true" 
                                FieldName="FechaRecepcion" SoloLectura="True" />
                        </td>
                        <td>
                            <uc3:TextBox ID="txtRecibidoPor" runat="server" FieldName="RecibidoPor" 
                                SoloLectura="True" />
                        </td>
                        <td>
                            <uc2:DateControl ID="dtcFechaAsignacion" runat="server" FechaHora="True" 
                                FieldName="FechaAsignacion" SoloLectura="True" />
                        </td>
                        <td>
                            <uc3:TextBox ID="txtAsignadoA" runat="server" FieldName="AsignadoA" 
                                SoloLectura="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label15" runat="server" Text=" Nuevo Estado"></asp:Label>
                        </td>
                        <td colspan="2">
                            <uc1:ComboBox ID="cboNuevoEstado" runat="server" AutoFill="true" 
                                TableName="pEstado_List" FieldName="idEstado" postBack="True" 
                                Procedimiento="True"/>
                        </td>
                        <td>
                            <asp:Button ID="btnAceptar" runat="server" Text="Cambiar Estado" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            <asp:Label ID="Label16" runat="server" Text="Nuevo Empleado"></asp:Label>
                        </td>
                        <td colspan="2">
                            <uc1:ComboBox ID="cboNuevoEmpleado" runat="server" Obligatorio="True" 
                                TableName="pPersonaEstadoRol_List" AutoFill="False" FieldName="idEmpleado" 
                                Procedimiento="True" />
                        </td>
                        <td>
                            <uc3:TextBox ID="txtComentarioActual" runat="server" FieldName="Modificacion" 
                                MaxLength="4000" Visible="False" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 184px">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:HyperLink ID="linkMain" runat="server" 
                                NavigateUrl="~/Registro/Expediente/wfmSeguimientoExpediente.aspx" 
                                Visible="False">[linkMain]</asp:HyperLink>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

            </asp:Panel>
        
        </asp:Content>


