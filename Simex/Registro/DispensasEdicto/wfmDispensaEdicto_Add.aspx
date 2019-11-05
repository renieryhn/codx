﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmDispensaEdicto_Add.aspx.vb" Inherits="smx.wfmDispensaEdicto_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register src="~/Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../Controles/SolicitanteResponsable.ascx" tagname="SolicitanteResponsable" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">                      
    <div style="position: absolute; top: 176px; left: 353px;">
                        <asp:Label ID="Label39" runat="server" Text="Número de acuerdo"></asp:Label>              
                        <uc1:TextBox ID="txtNumeroAcuerdo" runat="server" FieldName="NumAcuerdoEdicto" 
                            Obligatorio="True" Habilitado="False" />
         </div>      
         <div style="position: absolute; top: 211px; left: 106px; height: 107px; width: 404px;" 
        align="center">
         
             <uc3:SolicitanteResponsable ID="ClienteEl" runat="server" 
                 MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" 
                 TipoEntidad="El" />
         
         </div>
           <div style="position: absolute; top: 384px; left: 108px; height: 102px; width: 376px;" 
        align="center">
         
             <uc3:SolicitanteResponsable ID="ClienteElla" runat="server" 
                   MostrarApoderado="False" MostrarCliente="True" MostrarInstitucion="False" 
                   TipoEntidad="Ella" />
         
         </div>
                 <div style="position: absolute; top: 565px; left: 272px;">
               
                    <asp:Label ID="Label40" runat="server" Text="Departamento"></asp:Label>
                        
                    <uc2:ComboBox ID="cboDepartamentoDispensaEdicto" runat="server" AutoFill="True" 
                        FieldName="idDepartamento" idFieldName="id" postBack="True" 
                        TableName="Departamento" textFieldName="Nombre" />
                        <br />
                    <asp:Label ID="Label41" runat="server" Text="Municipio"></asp:Label>
                        
                    <uc2:ComboBox ID="cboMunicipioDispensaEdicto" runat="server" AutoFill="False" 
                        FieldName="idMunicipio" idFieldName="id" idParentComboBox="idDepartamento" 
                        TableName="Municipio" textFieldName="Nombre" />
                        <br />
                    <asp:Label ID="Label42" runat="server" Text="Firma Autorizada"></asp:Label>
                     <uc2:ComboBox ID="cboFirmaAutorizada" runat="server" AutoFill="True" 
                                Consulta="SELECT Firmas.id , isnull(Empleados.Nombre1, '') + ' ' + isnull(Empleados.Nombre2, '') + ' ' + isnull(Empleados.Apellido1, '') + ' ' + isnull(Empleados.Apellido2, '') AS Nombre FROM Firmas INNER JOIN Empleados ON Firmas.idEmpleado = Empleados.ID where estado='A' order by Nombre" 
                                FieldName="idFirmaAutorizada" idFieldName="idEmpleado" 
                                textFieldName="Nombre" />
                     <br />
                     <asp:Label ID="Label64" runat="server" Text="Edicto Presencial"></asp:Label>
                        
                            <uc2:ComboBox ID="cboTipoEdicto" runat="server" AutoFill="True" 
                                idFieldName="id" Obligatorio="True" 
                                TableName="Si_No" textFieldName="Nombre" />
                                <br />
                            <asp:HyperLink ID="linkMain" runat="server" 
                                NavigateUrl="~/Registro/DispensasEdicto/wfmDispensaEdicto_List.aspx" 
                                Visible="False">[linkMain]</asp:HyperLink>
                        <asp:HyperLink ID="LinkMe" runat="server" 
                                NavigateUrl="~/Registro/DispensasEdicto/wfmDispensaEdicto_Add.aspx" 
                                Visible="False">[LinkMe]</asp:HyperLink>
                    
    </div>
                         
</asp:Content>
