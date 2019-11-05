<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Propiedades.Master" CodeBehind="wfmFirma_Add.aspx.vb" Inherits="smx.wfmFirma_Add" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<%@ Register src="../../../Controles/DateControl.ascx" tagname="DateControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="DD">
    <table style="width: 100%">
        <tr>
            <td style="width: 175px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
    
                    </td>
            <td>
    
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" width="50" />
    
                    </td>
        </tr>
        <tr>
            <td style="width: 175px">
                <asp:Label ID="Label2" runat="server" Text="Empleado"></asp:Label>
                    </td>
            <td>
                    <uc2:ComboBox ID="cboEmpleados" runat="server" AutoFill="True" 
                        Consulta="SELECT ID, isnull(Nombre1, '') + ' ' + isnull(Nombre2,'')  + ' ' + isnull(Apellido1,'')  + ' '  + isnull(Apellido2, '') as Nombre FROM Empleados where IdEstado='A'" 
                        FieldName="idEmpleado" idFieldName="ID" textFieldName="Nombre" />
                    </td>
        </tr>
        <tr>
            <td style="width: 175px">
                       <asp:Label ID="Label5" runat="server" Text="Acuerdo"></asp:Label>
                    
                        </td>
            <td>
                    
                        <uc1:TextBox ID="txtAcuerdo" runat="server" MaxLength="100" width="400" 
                            FieldName="Acuerdo" />
                    
                    </td>
        </tr>
        <tr>
            <td style="width: 175px">
                    
                    <asp:Label ID="Label6" runat="server" Text="Acuerdo Especial"></asp:Label>
                    
                        </td>
            <td>
                    
                        <uc1:TextBox ID="txtAcuerdoEspecial" runat="server" 
                            MaxLength="100" width="400" FieldName="AcuerdoEspecial" />
                    
                    </td>
        </tr>
        <tr>
            <td style="width: 175px">
                    
                    <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
                    
                        </td>
            <td>
                    
                        <uc1:TextBox ID="txtDescripcion" runat="server" 
                            MaxLength="100" width="400" FieldName="Descripcion" />
                    
                    </td>
        </tr>
        <tr>
            <td style="width: 175px">
                       <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                    
                        
                    
                    <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Firma/wfmFirma_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
                
                <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/Firma/wfmFirma_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
            </td>
            <td>
                    
                        
                    
                        <uc3:DateControl ID="dtcFecha" runat="server" FechaHora="False" 
                            FieldName="Fecha" />
                    
                        
                    
                    </td>
        </tr>
    </table>
        </div>
</asp:Content>
