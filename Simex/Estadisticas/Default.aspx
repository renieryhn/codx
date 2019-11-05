<%@ Page Language="VB" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="smx._EstadisticasDefault" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">

			function employeeMouseOver(sender)
			{
				sender.className = "rlvHover";
			}

			function employeeMouseOut(sender)
			{
				sender.className = "rlvItem";
			}

			function employeeMouseOutSelected(sender)
			{
				sender.className = "rlvSelected";
			}
			function DateSelected(sender, eventArgs) {
			    if (!Page_ClientValidate())
			        eventArgs.set_cancel(true);
			}
			
            </script>

    <telerik:RadAjaxManager runat="server" EnableAJAX="true" ID="RadAjaxManager1">
     <AjaxSettings>	      
		    <telerik:AjaxSetting AjaxControlID="PagerSlider">
			    <UpdatedControls>
				    <telerik:AjaxUpdatedControl ControlID="rList" />
                   
			    </UpdatedControls>
		    </telerik:AjaxSetting>
		    <telerik:AjaxSetting AjaxControlID="rList">
			    <UpdatedControls>
                   
			    </UpdatedControls>
		    </telerik:AjaxSetting>
         	
                        <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadTabStrip1"></telerik:AjaxUpdatedControl>
                        <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="LoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadMultiPage1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>

      </AjaxSettings>
</telerik:RadAjaxManager>


    <div class="box" style="background-color: #000000; color: #FFFFFF; font-family: Tahoma; font-size: medium; width: 98.8%; height: 630px; left: 2px;">
    <div class="rlv" >
        <telerik:RadListView ID="rList" runat="server" AllowPaging="true" DataKeyNames="id"  PageSize="5" Width="100%" AllowCustomPaging="True">
            <LayoutTemplate>
                <table border="0" cellpadding="0" cellspacing="7" class="rlv">
                    <tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <td class="rlvItem" onmouseout="employeeMouseOut(this)" onmouseover="employeeMouseOver(this)">
                    <asp:LinkButton ID="btnList" runat="server" CommandName="Select" OnClientClick="Seleccionar(this)">
							<telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Width="70px" Height="70px"
								ResizeMode="Fit" ImageUrl='<%#Eval("FotoURL")%>'
								AlternateText='<%# Eval("NombreEmpleado")%>'
								CssClass="photo" />
							<%# Eval("NombreEmpleado")%>
							<asp:Label ID="PercentageLabel" runat="server" class="percentage" Text='
								<%#Eval("id").ToString()%>'></asp:Label>
						</asp:LinkButton>
                </td>
            </ItemTemplate>
            <SelectedItemTemplate>
                <td class="rlvSelected" onmouseout="employeeMouseOutSelected(this)" onmouseover="employeeMouseOver(this)">
                    <asp:LinkButton ID="btnSel" runat="server" CommandName="Select" OnClientClick="Seleccionar(this)" >
							<telerik:RadBinaryImage ID="RadBinaryImage2" runat="server" Width="70px" Height="70px"
								ResizeMode="Fit" ImageUrl='<%#Eval("FotoURL")%>'
								AlternateText='<%# Eval("NombreEmpleado")%>'
								CssClass="photo" />
							<%# Eval("NombreEmpleado")%>
							<asp:Label ID="PercentageLabel0" runat="server" class="percentage" Text='
								<%#Eval("id")%>'></asp:Label>
						</asp:LinkButton>
                </td>
            </SelectedItemTemplate>
        </telerik:RadListView>
        <asp:HiddenField ID="hfID" runat="server" />
        <br />
         <div class="tabStripHeader">
        <telerik:RadSlider ID="PagerSlider" runat="server" CssClass="slider"
			    DecreaseText="Anterior" IncreaseText="Seguiente" DragText='<%# "Página " + (rList.CurrentPageIndex + 1).ToString() + " de " + rList.PageCount.ToString()%>'
			    AutoPostBack="true" OnValueChanged="PagerSlider_ValueChanged">
		    </telerik:RadSlider>

       		    <div class="datePickers">
			    <span class="sText">Seleccione la fecha desde: </span>
			        
			    <telerik:RadDatePicker ID="fDesde" AutoPostBack="true" runat="server" MinDate="01/01/1980"
				    MaxDate="12/12/2030"  >
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" Culture="es-ES" FastNavigationNextText="&amp;lt;&amp;lt;"></Calendar>

                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"  AutoPostBack="True" LabelWidth="40%" >
                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                    <FocusedStyle Resize="None"></FocusedStyle>

                    <DisabledStyle Resize="None"></DisabledStyle>

                    <InvalidStyle Resize="None"></InvalidStyle>

                    <HoveredStyle Resize="None"></HoveredStyle>

                    <EnabledStyle Resize="None"></EnabledStyle>
                    </DateInput>

                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>

				    <ClientEvents OnDateSelected="DateSelected" />
			    </telerik:RadDatePicker>
			    <asp:RequiredFieldValidator ID="StartDateValidator" runat="server" ErrorMessage="*"
				    ControlToValidate="fDesde"></asp:RequiredFieldValidator>
			    hasta<span class="sText">: </span>
			    <telerik:RadDatePicker ID="fHasta" AutoPostBack="true" runat="server" MinDate="01/01/1980"
				    MaxDate="12/31/2030" >
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" Culture="es-ES" FastNavigationNextText="&amp;lt;&amp;lt;" Skin="Black"></Calendar>

                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"  AutoPostBack="True" LabelWidth="40%" >
                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                    <FocusedStyle Resize="None"></FocusedStyle>

                    <DisabledStyle Resize="None"></DisabledStyle>

                    <InvalidStyle Resize="None"></InvalidStyle>

                    <HoveredStyle Resize="None"></HoveredStyle>

                    <EnabledStyle Resize="None"></EnabledStyle>
                    </DateInput>

                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>

				    <ClientEvents OnDateSelected="DateSelected" />
			    </telerik:RadDatePicker>
			    <asp:RequiredFieldValidator ID="EndDataValidator" runat="server" ErrorMessage="*"
				    ControlToValidate="fHasta"></asp:RequiredFieldValidator>
				<asp:CompareValidator ID="CompareValidator1" runat="Server" ControlToCompare="fDesde"
                    ControlToValidate="fHasta" Operator="GreaterThan" ErrorMessage="* El rango de fechas no es válido." Display="Dynamic" />
		    </div>
</div>
    </div>
        <div  class="userDetails" style="background-position: left bottom;  width: 180px; position: absolute; top: 170px; left: 5px; height: 81%;">
  	
			<asp:UpdatePanel ID="upUser" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <telerik:RadBinaryImage ID="PicEmpleado" runat="server" BorderStyle="None" Height="180px" ImageAlign="Middle" Width="180px" top="2px" left="2px"/>
                    <br />
                    <asp:Label ID="txtNombre" runat="server" CssClass="fName" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="178px"></asp:Label>

            <telerik:RadRadialGauge ID="RadRadialGauge1" runat="server" Height="100px" Skin="Black" Width="170px">
                <Pointer Color="Aqua">
                </Pointer>
                <Scale Max="500">
                </Scale>
            </telerik:RadRadialGauge>
                    <asp:Label ID="txtSinRecibir" runat="server" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" CssClass="fName" Font-Bold="False" Width="178px">Sin Recibir</asp:Label>
            <telerik:RadRadialGauge ID="RadRadialGauge2" runat="server" Height="100px" Skin="Glow" Width="170px">
                <Pointer Color="Lime" Value="100">
                </Pointer>
                <Scale Max="500">
                </Scale>
            </telerik:RadRadialGauge>
                    <br />
                    <asp:Label ID="txtSinEnviar" runat="server" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" CssClass="fName" Font-Bold="False" Width="180px">En Trabajo</asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>	
            </div>


        <div style="background-position: left bottom; width: 1130px; position: absolute; top: 170px; left: 190px; height: 81%;">

                <telerik:RadTabStrip ID="rTab" runat="server" Skin="Black" SelectedIndex="0" MultiPageID="RadMultiPage1" BackColor="#212121" >
                </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
        </telerik:RadMultiPage>
        </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .fName {
            text-align: center;
        }
    </style>
</asp:Content>



