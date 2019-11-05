<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmDiasFestivos_Edit.aspx.vb" Inherits="smx.wfmDiasFestivos_Edit" MasterPageFile="~/Propiedades.Master" %>
<%@ MasterType VirtualPath="~/Propiedades.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="cphContenido">
      <div class="DD">
          <table style="width: 100%">
              <tr>
                  <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
   
                    </td>
                  <td>
   
                    <uc1:TextBox ID="txtCodigo" runat="server" Apariencia="SingleText" 
                        Habilitado="False" Int="True" FieldName="id" Align="Izquierda" />
                  </td>
              </tr>
              <tr>
                  <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
      
                    </td>
                  <td>
      
                    <uc1:TextBox ID="txtNombre" runat="server" Habilitado="True" 
                        Obligatorio="True" FieldName="Nombre" Int="False" Align="Izquierda" 
                        MaxLength="50" width="250" />
                  </td>
              </tr>
              <tr>
            <td style="width: 99px; height: 26px;">
                    Día</td>
            <td style="height: 26px">
                
                    <asp:TextBox ID="txtDia" runat="server" Width="50px" MaxLength="2"></asp:TextBox>
                    <asp:NumericUpDownExtender ID="txtDia_NumericUpDownExtender" runat="server" 
                        Enabled="True" Maximum="31" 
                        Minimum="1" RefValues="" ServiceDownMethod="" 
                        ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                        TargetButtonUpID="" TargetControlID="txtDia" Width="100">
                    </asp:NumericUpDownExtender>
                </td>
              </tr>
              <tr>
            <td style="width: 99px">
                    Mes</td>
            <td>
                
                    <asp:TextBox ID="txtMes" runat="server" Width="50px" MaxLength="2"></asp:TextBox>
                    <asp:NumericUpDownExtender ID="txtMes_NumericUpDownExtender" runat="server" 
                        Enabled="True" Maximum="12" 
                        Minimum="1" RefValues="" ServiceDownMethod="" 
                        ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                        TargetButtonUpID="" TargetControlID="txtMes" Width="100">
                    </asp:NumericUpDownExtender>
                </td>
              </tr>
              <tr>
            <td style="width: 99px">
                    Año</td>
            <td>
                
                    <asp:TextBox ID="txtAño" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                    <asp:NumericUpDownExtender ID="txtAño_NumericUpDownExtender" runat="server" 
                        Enabled="True" Maximum="2030" 
                        Minimum="2000" RefValues="" ServiceDownMethod="" 
                        ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                        TargetButtonUpID="" TargetControlID="txtAño" Width="100">
                    </asp:NumericUpDownExtender>
                &nbsp;(Deje en blanco este campo si el día festivo se aplica a todos los años)</td>
              </tr>
          </table>
      <p>
      <asp:HyperLink ID="linkMain" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/DiasFestivos/wfmDiasFestivos_List.aspx" 
                        Visible="False">[linkMain]</asp:HyperLink>
         
                    <asp:HyperLink ID="linkMe" runat="server" 
                        NavigateUrl="~/Mantenimientos/Generales/DiasFestivos/wfmDiasFestivos_Add.aspx" 
                        Visible="False">[linkMe]</asp:HyperLink>
         </p>
          </div>
</asp:Content>


