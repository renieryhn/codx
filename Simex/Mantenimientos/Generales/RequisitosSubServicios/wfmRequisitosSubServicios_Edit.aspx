<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmRequisitosSubServicios_Edit.aspx.vb" Inherits="smx.wfmRequisitosSubServicios_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../../../Controles/ComboBox.ascx" tagname="ComboBox" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <table class="DD" style="width: 571px">
        <tr>
            <td class="style2" align="left" style="width: 122px">
                    </td>
            <td colspan="3">
                    <uc1:TextBox ID="txtidSubServicio" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="idSubServicio" 
                    Align="Izquierda" Visible="False" />
                </td>
            <td style="width: 100px">
                    </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 122px">
                </td>
            <td colspan="3">
                    <uc1:TextBox ID="txtidRequisito" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="idRequisito" 
                    Align="Izquierda" Visible="False" />
                </td>
            <td style="width: 100px">
                </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="height: 30px; width: 122px">
                    SubServicio</td>
            <td style="height: 30px; width: 165px" colspan="2">
                <uc2:ComboBox ID="cboSubServicios" runat="server" AutoFill="True" 
                        FieldName="idSubServicio" idFieldName="Codigo" Obligatorio="False" 
                        TableName="SubServicios" textFieldName="Nombre" AditionalCondition="indEstado='A'" />
            </td>
            <td colspan="2" style="height: 30px">
            </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="height: 30px; width: 122px">
                    Requsito</td>
            <td style="height: 30px; width: 165px" colspan="2">
                <uc2:ComboBox ID="cboRequisitos" runat="server" AutoFill="True" 
                        FieldName="idRequisito" idFieldName="id" TableName="Requisitos" 
                        textFieldName="Nombre" Ordenacion="Nombre" />
            </td>
            <td colspan="2" style="height: 30px">
                    </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="height: 23px; width: 122px">
                    Estado</td>
            <td style="height: 23px; width: 69px;">
                <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
            </td>
            <td style="height: 23px">
                    </td>
            <td colspan="2" style="height: 23px">
                    </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="height: 23px; width: 122px">
                    </td>
            <td style="height: 23px; width: 69px;">
                    </td>
            <td style="height: 23px">
                    </td>
            <td colspan="2" style="height: 23px">
                    </td>
        </tr>
        <tr>
            <td class="style2" align="left" style="width: 122px">
                    <asp:HyperLink ID="linkMain" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
            </td>
            <td colspan="4">
                <asp:HyperLink ID="linkMe" runat="server" 
                        
                        NavigateUrl="~/Mantenimientos/Generales/RequisitosSubServicios/wfmRequisitosSubServicios_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>

