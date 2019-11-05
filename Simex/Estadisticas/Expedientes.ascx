<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Expedientes.ascx.vb" Inherits="smx.EExpedientes" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div style ="background-color:black; height:700px;">


<div style="float: left; width: 450px; height: 450px;">
    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Height="400px" Width="400px" Skin="BlackMetroTouch">
        <PlotArea>
            <Series>
                <telerik:PieSeries DataFieldY="MarketShare" NameField="Name" ExplodeField="IsExploded">
                    <LabelsAppearance DataFormatString="{0}%">
                    </LabelsAppearance>
                    <TooltipsAppearance Color="White" DataFormatString="{0}%"></TooltipsAppearance>
                </telerik:PieSeries>
            </Series>
            <YAxis>
            </YAxis>
        </PlotArea>
        <ChartTitle Text="Tipos de Trámites Trabjados">
        </ChartTitle>
    </telerik:RadHtmlChart>
</div>
<div style="float: right; height: 450px; background-color: black;">
    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart2" Height="400px" Width="400px" Skin="BlackMetroTouch" BackColor="#212121">
        <PlotArea>
            <Series>
                <telerik:AreaSeries Name="Trabajados en 2014" DataFieldY="MarketShare2010">
                    <TooltipsAppearance Color="White" Visible="true"></TooltipsAppearance>
                </telerik:AreaSeries>
                <telerik:LineSeries Name="Trabajados en 2015" DataFieldY="MarketShare2011">
                    <TooltipsAppearance Color="White" Visible="true"></TooltipsAppearance>
                </telerik:LineSeries>
            </Series>
            <XAxis>
                <Items>
                    <telerik:AxisItem LabelText="Enero"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Febrero"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Marzo"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Abril"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Mayo"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Junio"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Julio"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Agosto"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Septiembre"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Octubre"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Noviembre"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Diciembre"></telerik:AxisItem>
                </Items>
                <LabelsAppearance RotationAngle="90">
                </LabelsAppearance>
            </XAxis>
        </PlotArea>
        <Legend>
            <Appearance Position="Bottom">
            </Appearance>
        </Legend>
        <ChartTitle Text="Cantidad de Expedientes">
        </ChartTitle>
    </telerik:RadHtmlChart>
</div>


</div>