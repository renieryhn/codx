Imports System.Collections.Generic

Partial Class EExpedientes
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        End If
    End Sub

    Sub LoadData()
        'Left chart datasource
        Dim browsers As New List(Of Browser)()
        browsers.Add(New Browser("Varios", 23.48, True))
        browsers.Add(New Browser("Personería Jurídicas", 28.57, False))
        browsers.Add(New Browser("Extrangerías", 40.98, False))
        browsers.Add(New Browser("Quejas", 2.43, False))
        browsers.Add(New Browser("Denuncias", 3.99, False))
        RadHtmlChart1.DataSource = browsers
        RadHtmlChart1.DataBind()

        'right chart datasource
        Dim chromeData As New List(Of MarketShareData)()
        chromeData.Add(New MarketShareData(10.8, 23.8))
        chromeData.Add(New MarketShareData(11.6, 24.1))
        chromeData.Add(New MarketShareData(12.3, 25.0))
        chromeData.Add(New MarketShareData(13.6, 25.6))
        chromeData.Add(New MarketShareData(14.5, 25.9))
        chromeData.Add(New MarketShareData(15.9, 27.9))
        chromeData.Add(New MarketShareData(16.7, 29.4))
        chromeData.Add(New MarketShareData(17.0, 30.3))
        chromeData.Add(New MarketShareData(17.3, 30.5))
        chromeData.Add(New MarketShareData(19.2, 32.3))
        chromeData.Add(New MarketShareData(20.5, 33.4))
        chromeData.Add(New MarketShareData(22.4, 34.6))

        RadHtmlChart2.DataSource = chromeData
        RadHtmlChart2.DataBind()
    End Sub
End Class

Public Class MarketShareDataE
    Public Sub New(marketShare2010 As Double, marketShare2011 As Double)
        _marketShare2010 = marketShare2010
        _marketShare2011 = marketShare2011
    End Sub
    Private _marketShare2010 As Double
    Public Property MarketShare2010() As Double
        Get
            Return _marketShare2010
        End Get
        Set(value As Double)
            _marketShare2010 = value
        End Set
    End Property
    Private _marketShare2011 As Double
    Public Property MarketShare2011() As Double
        Get
            Return _marketShare2011
        End Get
        Set(value As Double)
            _marketShare2011 = value
        End Set
    End Property
End Class

Public Class BrowserE
    Public Sub New(name As String, marketShare As Double, isExploded As Boolean)
        _name = name
        _marketShare = marketShare
        _isExploded = isExploded
    End Sub
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _marketShare As Double
    Public Property MarketShare() As Double
        Get
            Return _marketShare
        End Get
        Set(value As Double)
            _marketShare = value
        End Set
    End Property
    Private _isExploded As Boolean
    Public Property IsExploded() As Boolean
        Get
            Return _isExploded
        End Get
        Set(value As Boolean)
            _isExploded = value
        End Set
    End Property
End Class
