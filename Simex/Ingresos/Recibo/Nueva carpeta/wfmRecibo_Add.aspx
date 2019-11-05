﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmRecibo_Add.aspx.vb" Inherits="smx.wfmRecibo_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="~/Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
<div class="clear" style="overflow: visible">
          
    <table style="width: 100%">
        <tr>
            
            <td colspan="4">
                        <asp:Label ID="Label43" runat="server" Font-Bold="True" 
                            Text="Datos del encabezado del recibo"></asp:Label>
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label45" runat="server" Text="Oficina"></asp:Label>
                </td>
            <td style="width: 849px" colspan="3">
                 <asp:Panel ID="Panel1" runat="server">
              
                        <uc2:ComboBox ID="cboOficina" runat="server" AutoFill="True" 
                            FieldName="idOficina" idFieldName="id" TableName="Oficina" 
                            textFieldName="Nombre" Obligatorio="True" />
                 </asp:Panel>        
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label46" runat="server" Text="Número recibo Finanzas"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc1:TextBox ID="txtNumeroRecibo" runat="server" Align="Izquierda" 
                            FieldName="NumReciboFinanzas" Habilitado="True" Int="False" MaxLength="8" 
                            Obligatorio="True" width="50" />
               
                </td>
            <td style="width: 94px">
               
                        <asp:Label ID="Label47" runat="server" Text="Fecha Emisión"></asp:Label>
               
                </td>
            <td style="width: 421px">
               
                        <uc3:DateControl ID="dteFechaEmision" runat="server" FechaHora="False" 
                            FieldName="FechaEmision" />
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
               
                        <asp:Label ID="Label4" runat="server" Text="Verificación del recibo"></asp:Label>
               
                </td>
            <td style="width: 318px">
               
                        <uc1:TextBox ID="txtVerificacionNumeroRecibo" runat="server" Align="Izquierda" 
                            FieldName="Nombre" Habilitado="True" Int="False" MaxLength="8" 
                            Obligatorio="True" width="50" />
               
                </td>
            <td style="width: 94px">
               
                        <asp:Label ID="Label6" runat="server" Text="Fecha Pago"></asp:Label>
               
                </td>
            <td style="width: 421px">
               
                        <uc3:DateControl ID="dteFechaPago" runat="server" FechaHora="False" 
                            FieldName="Fechapago" />
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label7" runat="server" Text="Servicio"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc2:ComboBox ID="cboServicio" runat="server" AutoFill="True" 
                            FieldName="idServicio" idFieldName="id" postBack="True" TableName="Servicios" 
                            textFieldName="Nombre" />
               
                </td>
            <td style="width: 94px">
               
                        </td>
            <td style="width: 421px">

                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
               
                        <asp:Label ID="Label8" runat="server" Text="Sub Servicio"></asp:Label>
               
                </td>
            <td style="width: 318px">
               
               <uc2:ComboBox ID="cboSubServicio" runat="server" AutoFill="False" 
                            FieldName="idSubServicio" idFieldName="Codigo" idParentComboBox="idServicio" 
                            TableName="SubServicios" textFieldName="Nombre" 
                    AditionalCondition="indEstado='A'" postBack="True" />
               
                </td>
            <td style="width: 94px">
               
                        </td>
            <td style="width: 421px">

                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        </td>
            <td style="width: 849px" colspan="3">
               
             <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
       <%-- <fieldset>--%>
      <%--  </fieldset>--%>
        </contenttemplate>
    </asp:UpdatePanel>
                                
                
                        
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td colspan="4">
                        <asp:Label ID="Label39" runat="server" Font-Bold="True" 
                            Text="Datos del detalle del recibo"></asp:Label>
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label48" runat="server" Text="Valor Dolares"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc1:TextBox ID="txtValorDolares" runat="server" Align="Izquierda" 
                            FieldName="ValorDolares" Habilitado="False" Int="False" MaxLength="15" 
                            Obligatorio="False" width="80" />
               
                </td>
            <td style="width: 94px">
               
                        <asp:Label ID="Label49" runat="server" Text="Valor Lempiras"></asp:Label>
               
                </td>
            <td style="width: 421px">
               
                        <uc1:TextBox ID="txtValor" runat="server" Align="Izquierda" FieldName="Valor" 
                            Habilitado="True" Int="False" MaxLength="15" Obligatorio="True" width="80" />
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label50" runat="server" Text="Tasa Cambio"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc1:TextBox ID="txtTasaCambio" runat="server" Align="Izquierda" 
                            FieldName="TasaCambio" Habilitado="False" Int="False" MaxLength="15" 
                            Obligatorio="False" width="80" />
               
                </td>
            <td style="width: 94px">
               
                        <asp:Label ID="Label51" runat="server" Text="Cantidad"></asp:Label>
               
                </td>
            <td style="width: 421px">
               
                        <asp:TextBox ID="txtCantidad" runat="server" Width="100px"></asp:TextBox>
                        <asp:NumericUpDownExtender ID="txtCantidad_NumericUpDownExtender" 
                            runat="server" Enabled="True" Maximum="1.7976931348623157E+308" 
                            Minimum="1" RefValues="" ServiceDownMethod="" 
                            ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                            TargetButtonUpID="" TargetControlID="txtCantidad" Width="50">
                        </asp:NumericUpDownExtender>
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label52" runat="server" Text="Total Dolares"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc1:TextBox ID="txtTotalDolares" runat="server" Align="Izquierda" 
                            FieldName="TotalDOlares" Habilitado="False" Int="False" MaxLength="15" 
                            Obligatorio="False" width="80" />
               
                </td>
            <td style="width: 94px">
               
                        <asp:Label ID="Label53" runat="server" Text="Total Lempiras"></asp:Label>
               
                </td>
            <td style="width: 421px">
               
                        <uc1:TextBox ID="txtValorTotalLempiras" runat="server" Align="Izquierda" 
                            FieldName="TotalLempiras" Habilitado="False" Int="False" MaxLength="15" 
                            Obligatorio="False" width="80" />
               
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        <asp:Label ID="Label54" runat="server" Text="Pagado"></asp:Label>
                </td>
            <td style="width: 318px">
               
                        <uc2:ComboBox ID="cboEstadoRecibo" runat="server" AutoFill="True" 
                            FieldName="indPagado" idFieldName="id" postBack="False" TableName="Si_No" 
                            textFieldName="Nombre" />
               
                </td>
            <td style="width: 94px">
               
                        </td>
            <td style="width: 421px">
               
                        </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td style="width: 148px">
                        </td>
            <td style="width: 318px">
               
                        </td>
            <td style="width: 94px">
               
                        </td>
            <td style="width: 421px">
               
                        </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td colspan="4">
                        <asp:Label ID="Label55" runat="server" Font-Bold="True" 
                            Text="Datos del Solicitante del recibo: "></asp:Label>
                        <uc2:ComboBox ID="cboTipoSolicitante" runat="server" AutoFill="True" 
                            idFieldName="id" postBack="True" TableName="TipoSolicitante" 
                            textFieldName="Nombre" Obligatorio="True" />
                </td>
            <td style="width: 1%">
                </td>
        </tr>
        <tr>
            <td colspan="5">
            <asp:Panel ID="pnlCliente" runat="server">
             <table style="width: 461px">
                <tr>
                    <td style="width: 34px">
                        <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>
                    </td>
                    <td style="width: 214px">
               
                        <uc1:TextBox ID="txtCodigoEl" runat="server" FieldName="idCliente" 
                            Obligatorio="False" />
               
                    </td>
                    <td style="width: 56px">
                        <asp:Button ID="btnMostrarPopupEl" runat="server" Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 69px">
                        <asp:Button ID="btnVerificarEl" runat="server" Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 53px">
                        <asp:Button ID="btnNuevoEl" runat="server" Text="Nuevo" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
        </table>
        <table style ="width: 416px" border="2">
                    <tr>
                        <td style="width: 80px">

                            <asp:Label ID="Label2" runat="server" Text="Identidad"></asp:Label>
                        </td>
                        <td style="width: 318px">
                            <uc1:TextBox ID="txtIdentidadEl" runat="server" Habilitado="False" 
                                FieldName="NumIdentidad" MaxLength="15" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px">
                            <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                        </td>
                        <td style="width: 318px">
                            <uc1:TextBox ID="txtNombresEl" runat="server" FieldName="Nombre" 
                                Habilitado="False" MaxLength="30" width="200" />
                        </td>
                    </tr>
                    <tr>    
                        <td style="width: 80px">
                            <asp:Label ID="Label5" runat="server" Text="Nacionalidad"></asp:Label>
                        </td>
                        <td style="width: 318px">
                            <uc2:ComboBox ID="cboNacionalidadEl" runat="server" FieldName="idPais" 
                            idFieldName="id" TableName="Paises" textFieldName="Nombre" 
                            AutoFill="True" habilitado="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px">
                            </td>
                        <td style="width: 318px">
                            </td>
                    </tr>
            </table>
      </asp:Panel>
      <asp:Panel ID="pnlApoderado" runat="server">
                        <table style="width: 461px">
                            <tr>
                                <td style="width: 34px">
                                    <asp:Label ID="Label9" runat="server" Text="Apoderado"></asp:Label>
                                </td>
                                <td style="width: 214px">
                                    <uc1:TextBox ID="txtCodigoApoderado" runat="server" 
                FieldName="idApoderado" Obligatorio="False" Int="True" />
                                </td>
                                <td style="width: 56px">
                                    <asp:Button ID="btnMostrarBusquedaApoderado" runat="server" 
                Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                                <td style="width: 69px">
                                    <asp:Button ID="btnVerificarApoderado" runat="server" 
                Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                                <td style="width: 53px">
                                    <asp:Button ID="btnNuevoApoderado" runat="server" 
                Text="Nuevo" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                            </tr>
                        </table>
                        <table border="2" style="width: 416px">
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label10" runat="server" Text="Identidad"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtIdentidadApoderado" runat="server" 
                FieldName="NumIdentidad" Habilitado="False" MaxLength="15" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label16" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtNombreApoderado" runat="server" 
                FieldName="Nombre" Habilitado="False" MaxLength="30" width="200" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                    <asp:Panel ID="pnlInstitucion" runat="server">
                        <table style="width: 461px">
                            <tr>
                                <td style="width: 34px">
                                    <asp:Label ID="Label56" runat="server" Text="Institución"></asp:Label>
                                </td>
                                <td style="width: 214px">
                                    <uc1:TextBox ID="txtCodigoInstitucion" runat="server" 
                FieldName="idInstitucion" Obligatorio="False" Int="True" />
                                </td>
                                <td style="width: 56px">
                                    <asp:Button ID="btnMostrarBusquedaInstitucion" runat="server" 
                Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                                <td style="width: 69px">
                                    <asp:Button ID="btnVerificarInstitucion" runat="server" 
                Text="Verificar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                                <td style="width: 53px">
                                    <asp:Button ID="btnNuevoInstitucion" runat="server" 
                Text="Nuevo" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                            </tr>
                        </table>
                        <table border="2" style="width: 416px">
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label57" runat="server" Text="RTN"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtRTN" runat="server" 
                FieldName="RTN" Habilitado="False" MaxLength="15" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label58" runat="server" Text="Nombre"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtNombreInstitucion" runat="server" 
                FieldName="Nombre" Habilitado="False" MaxLength="30" width="200" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="Label59" runat="server" Text="Siglas"></asp:Label>
                                </td>
                                <td style="width: 318px">
                                    <uc1:TextBox ID="txtSiglas" runat="server" FieldName="Siglas" 
                                        Habilitado="False" MaxLength="20" width="200" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
  <asp:Panel runat="server" CssClass="modalPopup" ID="pnlBuscarCliente" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
      
            <table style="width: 100%">
                <tr>
                    <td style="width: 86px">
                        </td>
                    <td style="width: 63%">
                        <asp:Button ID="btnBuscarEl" runat="server" Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        <asp:Button ID="btnCerrarEl" runat="server" Text="Cerrar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 28%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 86px">
                        <asp:Label ID="Label11" runat="server" Text="Identidad"></asp:Label>
                    </td>
                    <td style="width: 91%" colspan="2">
                        <uc1:TextBox ID="txtIdentidadElBuscar" runat="server" FieldName="NumIdentidad" 
                            Habilitado="True" MaxLength="15" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 86px">
                        <asp:Label ID="Label12" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td style="width: 91%" colspan="2">
                        <uc1:TextBox ID="txtNombresElBuscar" runat="server" FieldName="Nombres" 
                            Habilitado="True" MaxLength="30" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 86px">
                        <asp:Label ID="Label13" runat="server" Text="Nacionalidad"></asp:Label>
                    </td>
                    <td style="width: 91%" colspan="2">
                        <uc2:ComboBox ID="cboNacionalidadElBuscar" runat="server" AutoFill="True" 
                            FieldName="idPais" idFieldName="id" TableName="Paises" 
                            textFieldName="Nombre" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 86px">
                        <asp:Label ID="Label14" runat="server" Text="Departamento"></asp:Label>
                    </td>
                    <td style="width: 91%" colspan="2">
                        <uc2:ComboBox ID="cboDepartamentoElBuscar" runat="server" AutoFill="True" 
                            FieldName="idDepartamento" idFieldName="id" TableName="Departamento" 
                            textFieldName="Nombre" postBack="True" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 86px">
                        <asp:Label ID="Label15" runat="server" Text="Municipio"></asp:Label>
                    </td>
                    <td style="width: 91%" colspan="2">
                        <uc2:ComboBox ID="cboMunicipioElBuscar" runat="server" AutoFill="False" 
                            FieldName="idMunicipio" idFieldName="id" TableName="Municipio" 
                            textFieldName="Nombre" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvDatosEl" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="Codigo" />
                                <asp:BoundField DataField="NumIdentidad" HeaderText="Identidad" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="idPais" HeaderText="idPais" />
                                <asp:BoundField DataField="NombrePais" HeaderText="Pais" />
                                <asp:BoundField DataField="TelefonoTrabajo" HeaderText="Tel. Trabajo" />
                                <asp:BoundField DataField="TelMovil1" HeaderText="Tel. Movil" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#FF3300" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
         
        <%--</ContentTemplate>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Panel>
                </td>
        </tr>
        <tr>
            <td colspan="5">
            <div>
                <asp:Panel ID="pnlDatosClienteEl" runat="server" BackColor="#999999" 
                    CssClass="modalPopup" EnableTheming="True" ScrollBars="Auto" Style="display:  inherit;
                width: 1000; padding: 0px;">
                    <table class="style1">
                        <tr>
                            <td align="left" class="style2" style="margin-left: 160px">
                                <asp:Label ID="Label19" runat="server" Text="Código"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtCodigo" runat="server" Align="Izquierda" 
                                    Apariencia="SingleText" FieldName="id" Habilitado="False" Int="True" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label20" runat="server" Text="# Identidad"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtNumIdentidad" runat="server" Align="Izquierda" 
                                    FieldName="NumIdentidad" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label21" runat="server" Text="# Pasaporte"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtPasaporte" runat="server" Align="Izquierda" 
                                    FieldName="Pasaporte" Habilitado="True" Int="False" MaxLength="20" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label22" runat="server" Text="Primer Nombre"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtNombre1" runat="server" Align="Izquierda" 
                                    FieldName="Nombre1" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label23" runat="server" Text="Segundo Nombre"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtNombre2" runat="server" Align="Izquierda" 
                                    FieldName="Nombre2" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label24" runat="server" Text="Primer Apellido"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtApellido1" runat="server" Align="Izquierda" 
                                    FieldName="Apellido1" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label25" runat="server" Text="Segundo Apellido"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtApellido2" runat="server" Align="Izquierda" 
                                    FieldName="Apellido2" Habilitado="True" Int="False" MaxLength="15" 
                                    Obligatorio="False" width="150" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label26" runat="server" Text="Pais"></asp:Label>
                            </td>
                            <td>
                                <uc2:ComboBox ID="cboPais" runat="server" AutoFill="True" FieldName="idPais" 
                                    idFieldName="id" TableName="Paises" textFieldName="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label27" runat="server" Text="Teléfono Domicilio"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtTelefonoDomicilio" runat="server" Align="Izquierda" 
                                    FieldName="TelefonoDomicilio" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label28" runat="server" Text="Teléfono Trabajo"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtTelefonoTrabajo" runat="server" Align="Izquierda" 
                                    FieldName="TelefonoTrabajo" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label29" runat="server" Text="Fax"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtNumFax" runat="server" Align="Izquierda" FieldName="NumFax" 
                                    Habilitado="True" Int="False" MaxLength="10" Obligatorio="False" width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label30" runat="server" Text="Teléfono Móvil 1"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtTelefonoMovil1" runat="server" Align="Izquierda" 
                                    FieldName="TelMovil1" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label31" runat="server" Text="Teléfono Móvil 2"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtTelefonoMovil2" runat="server" Align="Izquierda" 
                                    FieldName="TelMovil2" Habilitado="True" Int="False" MaxLength="10" 
                                    Obligatorio="False" width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label32" runat="server" Text="Email 1"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtEmail1" runat="server" Align="Izquierda" 
                                    EnableViewState="True" FieldName="Email1" Habilitado="True" Int="False" 
                                    MaxLength="50" Obligatorio="False" width="250" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label33" runat="server" Text="Email 2"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtEmail2" runat="server" Align="Izquierda" 
                                    EnableViewState="True" FieldName="Email2" Habilitado="True" Int="False" 
                                    MaxLength="50" Obligatorio="False" width="250" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label34" runat="server" Text="Dirección Domicilio"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtDireccionDomicilio" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="DireccionDomicilio" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                    width="400" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label35" runat="server" Text="Dirección Trabajo"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtDireccionTrabajo" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="DireccionTrabajo" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                    width="200" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label36" runat="server" Text="Departamento"></asp:Label>
                            </td>
                            <td>
                                <uc2:ComboBox ID="cboDepartamentoClienteNuevo" runat="server" AutoFill="True" 
                                    FieldName="idDepartamento" idFieldName="id" postBack="True" 
                                    TableName="Departamento" textFieldName="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label37" runat="server" Text="Municipio"></asp:Label>
                            </td>
                            <td>
                                <uc2:ComboBox ID="cboMunicipioClienteNuevo" runat="server" AutoFill="False" 
                                    FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                                    TableName="Municipio" textFieldName="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Label ID="Label38" runat="server" Text="Observaciones"></asp:Label>
                            </td>
                            <td>
                                <uc1:TextBox ID="txtObservaciones" runat="server" Align="Izquierda" 
                                    Apariencia="Multiline" EnableViewState="True" FieldName="Observaciones" 
                                    Habilitado="True" Height="100" Int="False" MaxLength="1000" Obligatorio="False" 
                                    width="400" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                <asp:Button ID="btnGaurdarClienteEl" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarClienteEl" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
             </div>
                                </td>
        </tr>
        <tr>
            <td colspan="5">
            <div>
             <asp:Panel runat="server" CssClass="modalPopup" ID="pnlBuscarApoderado" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
               <table style="width: 100%">
                <tr>
                    <td style="width: 125px">
                        </td>
                    <td style="width: 59%">
                        <asp:Button ID="btnBuscarApoderado" runat="server" Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        <asp:Button ID="btnCerrarBusquedaApoderado" runat="server" Text="Cerrar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 28%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label17" runat="server" Text="Identidad"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtIdentidadApoderadoBuscar" runat="server" FieldName="NumIdentidad" 
                            Habilitado="True" MaxLength="15" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label18" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtNombreApoderadoBuscar" runat="server" FieldName="Nombres" 
                            Habilitado="True" MaxLength="30" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px; height: 24px;">
                        <asp:Label ID="Label40" runat="server" Text="Número Colegiación"></asp:Label>
                    </td>
                    <td style="width: 87%; height: 24px;" colspan="2">
                        <uc1:TextBox ID="txtNumColegiacion" runat="server" FieldName="ID" 
                            Habilitado="True" MaxLength="30" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label41" runat="server" Text="Departamento"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc2:ComboBox ID="cboDepartamentoApoderadoBuscar" runat="server" AutoFill="True" 
                            FieldName="idDepartamento" idFieldName="id" TableName="Departamento" 
                            textFieldName="Nombre" postBack="True" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label42" runat="server" Text="Municipio"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc2:ComboBox ID="cboMunicipioApoderadoBuscar" runat="server" AutoFill="False" 
                            FieldName="idMunicipio" idFieldName="id" TableName="Municipio" 
                            textFieldName="Nombre" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvDatosApoderado" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="15" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="Colegiación" />
                                <asp:BoundField DataField="NumIdentidad" HeaderText="Identidad" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="TelefonoTrabajo" HeaderText="Tel. Trabajo" />
                                <asp:BoundField DataField="TelMovil1" HeaderText="Tel. Movil" />
                                <asp:BoundField DataField="Email1" HeaderText="Correo" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#FF3300" />
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
         
      
</asp:Panel>
                </div>
                </td>
        </tr>
        <tr>
            <td colspan="5">
                <table style="width: 100%">
                    <tr>
                        <td colspan="3">
                            <div>
                            <asp:Panel ID="pnlApoderadoAdd" runat="server" BackColor="#999999" 
                    CssClass="modalPopup" EnableTheming="True" ScrollBars="Auto" Style="display:  inherit;
                width: 1000; padding: 0px;">
                <table class="style1">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label61" runat="server" Text="# Identidad"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNumIdentidadApoderadoAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NumIdentidad" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label62" runat="server" Text="Primer Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtPrimerNombreApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Nombre1" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label63" runat="server" Text="Segundo Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtSegundoNombreApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Nombre2" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label64" runat="server" Text="Primer Apellido"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtPrimerApellidoApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Apellido1" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label65" runat="server" Text="Segundo Apellido"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtSegundoApellidoApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Apellido2" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label66" runat="server" Text="Teléfono Domicilio"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtTelefonoDomicilioApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelefonoDomicilio" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label67" runat="server" Text="Teléfono Trabajo"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtTelefonoTrabajoApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelefonoTrabajo" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label68" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtFaxApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NumFax" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label69" runat="server" Text="Teléfono Móvil 1"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtTelefonoMovil1Apoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelMovil1" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label70" runat="server" Text="Teléfono Móvil 2"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtTelefonoMovil2Apoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelMovil2" Int="False" Align="Izquierda" 
                        MaxLength="10" width="100" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label71" runat="server" Text="Email 1"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtEmail1Apoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Email1" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" EnableViewState="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label72" runat="server" Text="Email 2"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtEmail2Apoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Email2" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" EnableViewState="True" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label73" runat="server" Text="Dirección Domicilio"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtDireccionDomicilioApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="DireccionDomicilio" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label74" runat="server" Text="Dirección Trabajo"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtDireccionTrabajoApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="DireccionTrabajo" Int="False" Align="Izquierda" 
                        MaxLength="400" width="250" EnableViewState="True" Height="100" 
                        Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label75" runat="server" Text="Departamento"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboDepartamentoApoderadoAdd" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label76" runat="server" Text="Municipio"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboMunicipioApoderadoAdd" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        TableName="Municipio" textFieldName="Nombre" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label77" runat="server" Text="Observaciones"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtObservacionesApoderado" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Observaciones" Int="False" Align="Izquierda" 
                        MaxLength="1000" width="400" EnableViewState="True" Height="200" 
                        Apariencia="Multiline" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Button ID="btnGuardarApoderado" runat="server" 
                        Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                </td>
                <td>
                    <asp:Button ID="btnCancelarApoderadoAdd" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                </td>
            </tr>
        </table>
                </asp:Panel>
                            </div>
                            </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                       <div>
                       <asp:Panel runat="server" CssClass="modalPopup" ID="pnlBuscarInstitucion" Style="display:  inherit;
                width: 700px; padding: 10px" BackColor="#999999">
               <table style="width: 100%">
                <tr>
                    <td style="width: 125px">
                        </td>
                    <td style="width: 59%">
                        <asp:Button ID="btnBuscarInstitucion" runat="server" Text="Buscar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        <asp:Button ID="btnCancelarBusquedaInstitucion" runat="server" Text="Cerrar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td style="width: 28%">
                        </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label60" runat="server" Text="Siglas"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtSiglasInstitucion" runat="server" FieldName="Siglas" 
                            Habilitado="True" MaxLength="15" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label78" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtNombreInstitucionBuscar" runat="server" FieldName="Nombre" 
                            Habilitado="True" MaxLength="30" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label79" runat="server" Text="RTN"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtRTNInstitucion" runat="server" FieldName="RTN" 
                            Habilitado="True" MaxLength="30" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label80" runat="server" Text="Nombre Contacto"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc1:TextBox ID="txtNombreContacto" runat="server" FieldName="NombreContacto" 
                            Habilitado="True" MaxLength="50" width="200" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="Label81" runat="server" Text="Nacionalidad"></asp:Label>
                    </td>
                    <td style="width: 87%" colspan="2">
                        <uc2:ComboBox ID="cboPaisInstitucionBuscar" runat="server" AutoFill="True" 
                            FieldName="idPais" idFieldName="id" TableName="Paises" 
                            textFieldName="Nombre" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvDatosInstitucionBusqueda" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
                            DataKeyNames="Id" EmptyDataText="No se encontraron registros" PageSize="15" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="Codigo" />
                                <asp:BoundField DataField="RTN" HeaderText="RTN" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Siglas" HeaderText="Siglas" />
                                <asp:BoundField DataField="NombrePais" HeaderText="Nacionalidad" />
                                <asp:BoundField DataField="Telefono1" HeaderText="Telefono" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#FF3300" />
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
         
      
</asp:Panel>
                            </div>
                            </td>
                        <td>
                            
                            </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div>
                            <div>
                            <asp:Panel ID="pnlInstitucionAdd" runat="server" BackColor="#999999" 
                    CssClass="modalPopup" EnableTheming="True" ScrollBars="Auto" Style="display:  inherit;
                width: 1000; padding: 0px;">
                <table class="style1">
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label83" runat="server" Text="RTN"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtRTNInstitucionAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="RTN" Int="False" Align="Izquierda" 
                        MaxLength="15" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label84" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombreInstitucionAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label85" runat="server" Text="Siglas"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtSiglasInstitucionAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="Siglas" Int="False" Align="Izquierda" 
                        MaxLength="20" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label102" runat="server" Text="Nacionalidad"></asp:Label>
                </td>
                <td>
                    <uc2:ComboBox ID="cboPaisInstitucionAdd" runat="server" AutoFill="True" 
                        FieldName="idPais" idFieldName="id" TableName="Paises" textFieldName="Nombre" />
                </td>
            </tr>
                    <tr>
                        <td align="left" class="style2" colspan="2">
                            <asp:Label ID="Label103" runat="server" Font-Bold="True" Text="Teléfonos"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Label90" runat="server" Text="Teléfono 1"></asp:Label>
                        </td>
                        <td>
                            <uc1:TextBox ID="txtTelefono1InstitucionAdd" runat="server" Align="Izquierda" 
                                FieldName="Telefono1" Habilitado="True" Int="False" MaxLength="10" 
                                Obligatorio="False" width="100" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Label91" runat="server" Text="Teléfono 2"></asp:Label>
                        </td>
                        <td>
                            <uc1:TextBox ID="txtTelefono2InstitucionAdd" runat="server" Align="Izquierda" 
                                FieldName="Telefono2" Habilitado="True" Int="False" MaxLength="10" 
                                Obligatorio="False" width="100" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Label110" runat="server" Text="Fax"></asp:Label>
                        </td>
                        <td>
                            <uc1:TextBox ID="txtNumFaxInstitucionAdd" runat="server" Align="Izquierda" 
                                FieldName="NumFax" Habilitado="True" Int="False" MaxLength="10" 
                                Obligatorio="False" width="100" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2" colspan="2">
                            <asp:Label ID="Label104" runat="server" Font-Bold="True" Text="Direcciones"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Label97" runat="server" Text="Dirección 1"></asp:Label>
                        </td>
                        <td>
                            <uc1:TextBox ID="txtDireccion1InstitucionAdd" runat="server" Align="Izquierda" 
                                Apariencia="Multiline" EnableViewState="True" FieldName="Direccion1" 
                                Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                width="250" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Label ID="Label98" runat="server" Text="Dirección 2"></asp:Label>
                        </td>
                        <td>
                            <uc1:TextBox ID="txtDireccion2InstitucionAdd" runat="server" Align="Izquierda" 
                                Apariencia="Multiline" EnableViewState="True" FieldName="Direccion2" 
                                Habilitado="True" Height="100" Int="False" MaxLength="400" Obligatorio="False" 
                                width="250" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2" colspan="2">
                            <asp:Label ID="Label105" runat="server" Font-Bold="True" Text="Contacto"></asp:Label>
                        </td>
                    </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label87" runat="server" Text="Nombre Contacto"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtNombreContactoInstitucionAdd" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="NombreContacto" Int="False" Align="Izquierda" 
                        MaxLength="50" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label88" runat="server" Text="Extensión"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtExtensionTelefonicaContacto" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="ExtensionTelefonica" Int="False" Align="Izquierda" 
                        MaxLength="20" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label106" runat="server" Text="Tel. Movil"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtTelMovilContacto" runat="server" Align="Izquierda" 
                        FieldName="TelMovilContacto" Habilitado="True" Int="False" MaxLength="20" 
                        Obligatorio="False" width="150" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label107" runat="server" Text="Cargo"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtCargoContacto" runat="server" Align="Izquierda" 
                        FieldName="CargoContacto" Habilitado="True" Int="False" MaxLength="100" 
                        Obligatorio="False" width="200" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label108" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtEmailContactoInstitucion" runat="server" Align="Izquierda" 
                        EnableViewState="True" FieldName="EmailContacto" Habilitado="True" Int="False" 
                        MaxLength="50" Obligatorio="False" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label109" runat="server" Text="Sitio Web"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtSitioWebContacto" runat="server" Align="Izquierda" 
                        EnableViewState="True" FieldName="SitioWEB" Habilitado="True" Int="False" 
                        MaxLength="50" Obligatorio="False" width="250" />
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    <asp:Label ID="Label93" runat="server" Text="Observaciones"></asp:Label>
                </td>
                <td>
                    <uc1:TextBox ID="txtObservacionesInstitucion" runat="server" Habilitado="True" 
                        Obligatorio="False" FieldName="TelMovil1" Int="False" Align="Izquierda" 
                        MaxLength="800" width="250" Apariencia="Multiline" Height="150" />
                </td>
            </tr>
                    <tr>
                        <td align="left" class="style2">
                            <asp:Button ID="btnGuardarInstitucion" runat="server" Text="Aceptar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelarInstitucionAdd" runat="server" Text="Cancelar" BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                    </tr>
             </table>
             </asp:panel>
                            </div>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 412px">
                            <asp:HyperLink ID="linkMain" runat="server" 
                                NavigateUrl="~/Ingresos/Recibo/wfmRecibo_List.aspx" 
                                Visible="False">[linkMain]</asp:HyperLink>
                        </td>
                        <td style="width: 105px">
                            </td>
                        <td>
                            <asp:HyperLink ID="LinkMe" runat="server" 
                                NavigateUrl="~/Ingresos/Recibo/wfmRecibo_Add.aspx" 
                                Visible="False">[LinkMe]</asp:HyperLink>
                        </td>
                        
                        <td>
                            </td>
                    </tr>
                </table>
                                </td>
        </tr>
    </table> 
    <%--</td>
    </tr>
    </table>--%>
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
         <asp:ModalPopupExtender ID="mpeBuscarCliente" runat="server" PopupControlID="pnlBuscarCliente" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCerrarEl"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeAgregarCliente" runat="server" PopupControlID="pnlDatosClienteEl" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarClienteEl"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeBuscarApoderado" runat="server" PopupControlID="pnlBuscarApoderado" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCerrarBusquedaApoderado"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeAgregarApoderado" runat="server" PopupControlID="pnlApoderadoAdd" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarApoderadoAdd"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="mpeBuscarInstitucion" runat="server" PopupControlID="pnlBuscarInstitucion" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarBusquedaInstitucion"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
     <asp:ModalPopupExtender ID="mpeAgregarInstitucion" runat="server" PopupControlID="pnlInstitucionAdd" 
                  TargetControlID="hiddenTargetControlForModalPopup"    CancelControlID="btnCancelarInstitucionAdd"
        RepositionMode="RepositionOnWindowScroll" EnableViewState="True" ViewStateMode="Enabled">
    </asp:ModalPopupExtender>
   </div>   
        </div>             
</asp:Content>
