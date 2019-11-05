<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Dictamenes.ascx.vb" Inherits="smx.Dictamenes" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div style="float: left; width: 450px; height: 450px;">
    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Height="400px" Width="400px" Skin="Glow">
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
        <ChartTitle Text="Average browser shares in 2011">
        </ChartTitle>
    </telerik:RadHtmlChart>
</div>
<div style="float: right; height: 450px;">
    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart2" Height="400px" Width="400px" Skin="Glow">
        <PlotArea>
            <Series>
                <telerik:AreaSeries Name="Market share in 2010" DataFieldY="MarketShare2010">
                    <TooltipsAppearance Color="White" Visible="true"></TooltipsAppearance>
                </telerik:AreaSeries>
                <telerik:LineSeries Name="Market share in 2011" DataFieldY="MarketShare2011">
                    <TooltipsAppearance Color="White" Visible="true"></TooltipsAppearance>
                </telerik:LineSeries>
            </Series>
            <XAxis>
                <Items>
                    <telerik:AxisItem LabelText="January"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="Februrary"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="March"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="April"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="May"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="June"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="July"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="August"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="September"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="October"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="November"></telerik:AxisItem>
                    <telerik:AxisItem LabelText="December"></telerik:AxisItem>
                </Items>
                <LabelsAppearance RotationAngle="90">
                </LabelsAppearance>
            </XAxis>
        </PlotArea>
        <Legend>
            <Appearance Position="Bottom">
            </Appearance>
        </Legend>
        <ChartTitle Text="Chrome market share">
        </ChartTitle>
    </telerik:RadHtmlChart>
</div>