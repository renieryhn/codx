<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.master" CodeBehind="Tramites.aspx.vb" Inherits="smx.Tramites" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="auto-style1">
            <strong>Mes:</strong><telerik:RadDropDownList ID="RadDropDownList1" runat="server" AutoPostBack="True" SelectedText="Enero" SelectedValue="1" Skin="Glow">
            <Items>
                <telerik:DropDownListItem runat="server" Selected="True" Text="Enero" Value="1" />
                <telerik:DropDownListItem runat="server" Text="Febrero" Value="2" />
                <telerik:DropDownListItem runat="server" Text="Marzo" Value="3" />
                <telerik:DropDownListItem runat="server" Text="Abril" Value="4" />
                <telerik:DropDownListItem runat="server" Text="Mayo" Value="5" />
                <telerik:DropDownListItem runat="server" Text="Junio" Value="6" />
                <telerik:DropDownListItem runat="server" Text="Julio" Value="7" />
                <telerik:DropDownListItem runat="server" Text="Agosto" Value="8" />
                <telerik:DropDownListItem runat="server" Text="Septiembre" Value="9" />
                <telerik:DropDownListItem runat="server" Text="Octubre" Value="10" />
                <telerik:DropDownListItem runat="server" Text="Noviembre" Value="11" />
                <telerik:DropDownListItem runat="server" Text="Diciembre" Value="12" />
            </Items>
        </telerik:RadDropDownList>
        &nbsp;<br />
        <br />
        </div>
        <telerik:RadTabStrip ID="rTab" runat="server" Height="29px" SelectedIndex="0" Skin="Glow">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="1" Selected="True" Text="Sin Asignar">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="2" Text="Asignados">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="3" Text="En Proceso">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="5" Text="Rechazados">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="6" Text="Finalizados">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadGrid ID="rGrid" runat="server" Culture="es-ES" DataSourceID="SqlDataSource1" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" ShowGroupPanel="True" Skin="Glow" AllowAutomaticUpdates="True" AllowMultiRowSelection="True" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="3px" EnableHeaderContextAggregatesMenu="True" EnableHeaderContextFilterMenu="True" EnableHeaderContextMenu="True" GridLines="Horizontal">
            <SortingSettings SortedAscToolTip="Orden asc" SortedBackColor="Maroon" SortedDescToolTip="Orden desc" SortToolTip="Clic para ordenar" />
            <ExportSettings>
                <Pdf AllowCopy="True">
                </Pdf>
            </ExportSettings>
            <ValidationSettings EnableModelValidation="False" EnableValidation="False" />
            <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True" ActiveRowIndex="0" AllowKeyboardNavigation="True" EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                <Selecting CellSelectionMode="None" AllowRowSelect="True"/>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView DataSourceID="SqlDataSource1" AllowAutomaticUpdates="False" DataKeyNames="IDSolicitud" EditMode="PopUp" EnableHeaderContextAggregatesMenu="True" ShowFooter="True">
                <CommandItemSettings ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowExportToWordButton="True" />
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="41px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="41px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridCheckBoxColumn DataType="System.Boolean" FilterControlAltText="Filter cSel column" HeaderText="Seleccionar" UniqueName="cSel">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="IDSolicitud" DataType="System.Int32" FilterControlAltText="Filter IDSolicitud column" HeaderText="Id Solicitud" ReadOnly="True" SortExpression="IDSolicitud" UniqueName="IDSolicitud">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IdTipoSolicitud" DataType="System.Int32" Display="False" FilterControlAltText="Filter IdTipoSolicitud column" HeaderText="Tipo de Solicitud" ReadOnly="True" SortExpression="IdTipoSolicitud" UniqueName="IdTipoSolicitud">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NumRegistro" DataType="System.Int64" FilterControlAltText="Filter NumRegistro column" HeaderText="Registro" SortExpression="NumRegistro" UniqueName="NumRegistro">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FechaCreacion" DataType="System.DateTime" FilterControlAltText="Filter FechaCreacion column" HeaderText="Fecha de Creación" SortExpression="FechaCreacion" UniqueName="FechaCreacion">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Estado" FilterControlAltText="Filter Estado column" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TipoSolicitud" FilterControlAltText="Filter TipoSolicitud column" HeaderText="Tipo de Solicitud" SortExpression="TipoSolicitud" UniqueName="TipoSolicitud">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Observaciones" FilterControlAltText="Filter Observaciones column" HeaderText="Observaciones" SortExpression="Observaciones" UniqueName="Observaciones">
<ColumnValidationSettings>
<ModelErrorMessage Text=""></ModelErrorMessage>
</ColumnValidationSettings>
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <SelectedItemStyle BackColor="#FF9933" BorderColor="#FF6600" BorderStyle="Solid" BorderWidth="1px" />
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:URSACConnectionString %>" SelectCommand="SELECT Solicitudes.IDSolicitud,Solicitudes.NumRegistro, Solicitudes.FechaCreacion, Estados.NombreEstado AS Estado, TipoSolicitud.Nombre AS TipoSolicitud, TipoSolicitud.IdTipoSolicitud, Solicitudes.Observaciones  FROM Solicitudes INNER JOIN Estados ON Solicitudes.IDEstado = Estados.IDEstado INNER JOIN TipoSolicitud ON Solicitudes.IdTipoSolicitud = TipoSolicitud.IdTipoSolicitud WHERE (Estados.IDEstado = 1) And Month(Solicitudes.FechaCreacion)=@Mes and Estados.IDEstado=@IdEstado">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadDropDownList1" DefaultValue="11" Name="Mes" PropertyName="SelectedValue" />
                <asp:SessionParameter DefaultValue="1" Name="IdEstado" SessionField="IdEstado" />
            </SelectParameters>
        </asp:SqlDataSource>
        Acciones:<br />
        <telerik:RadButton ID="btnAsignar" runat="server" Skin="Glow" Text="Asignar">
        </telerik:RadButton>
&nbsp;<telerik:RadButton ID="btnRechazar" runat="server" Skin="Glow" Text="Rechazar">
        </telerik:RadButton>
&nbsp;
        <telerik:RadButton ID="btnFinalizar" runat="server" Skin="Glow" Text="Finalizar">
        </telerik:RadButton>
        &nbsp;
        <asp:Label ID="lblOficial" runat="server" Text="Oficial Jurídico" Font-Bold="True" Font-Names="Tahoma"></asp:Label>
&nbsp;<telerik:RadDropDownTree ID="cboEmpleado" runat="server" CheckNodeOnClick="True" Culture="es-ES" DataFieldID="" DataFieldParentID="" DataTextField="" DataValueField="" EnableFiltering="True" ExpandNodeOnSingleClick="True" Height="16px" OnClientEntryAdded="onEntryAdded" OnClientEntryAdding="OnClientEntryAdding1" Width="183px" Skin="Glow">
                            <DropDownSettings AutoWidth="Enabled" CloseDropDownOnSelection="True" Height="270px" Width="120px" />
                            <FilterSettings Highlight="Matches" EmptyMessage="No hay resultados..." Filter="Contains" MinFilterLength="3" />
                        </telerik:RadDropDownTree>

        <br />
        <asp:Label ID="lblMSG" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
        <br />

    </div>

      <script language="javascript" type="text/javascript">
          function onEntryAdded(sender, eventArgs) {
              /* if (sender.get_count  == 0) {
                   eventArgs.set_cancel(true);
               }
               else {
                   $(".rddtInner").removeClass("rddtFocused");
      
               }*/
          }
          function OnClientEntryAdding1(sender, eventArgs) {
              var entry = eventArgs.get_entry()
              if (entry.get_value() >= 10000) {
                  eventArgs.set_cancel(true);
              }
          }
          function ClientSideClick(myButton) {
              // Client side validation
              if (typeof (Page_ClientValidate) == 'function') {
                  if (Page_ClientValidate() == false)
                  { return false; }
              }

              //make sure the button is not of type "submit" but "button"
              if (myButton.getAttribute('type') == 'button') {
                  // disable the button
                  myButton.disabled = true;
                  myButton.className = "btn-inactive";
                  myButton.value = "procesando...";
              }
              return true;
          }
          document.onkeydown = KeyDownHandler;
          document.onkeyup = KeyUpHandler;
          var CTRL = false;
          var SHIFT = false;
          var ALT = false;
          var CHAR_CODE = -1;
          function KeyDownHandler(e) {
              var x = '';
              if (document.all) {
                  var evnt = window.event;
                  x = evnt.keyCode;
              }
              else {
                  x = e.keyCode;
              }
              DetectKeys(x, true);

              

         if (CTRL == true) {
             lblBrand = "True";
         }
         else {
             lblBrand = "False";
         }
        
    }
    function KeyUpHandler(e) {
        var x = '';
        if (document.all) {
            var evnt = window.event;
            x = evnt.keyCode;
        }
        else {
            x = e.keyCode;
        }
        DetectKeys(x, false);
    }
    function DetectKeys(KeyCode, IsKeyDown) {
        if (KeyCode == '16') {
            SHIFT = IsKeyDown;
        }
        else if (KeyCode == '17') {
            CTRL = IsKeyDown;
        }
        else if (KeyCode == '18') {
            ALT = IsKeyDown;
        }
        else {
            if (IsKeyDown)
                CHAR_CODE = KeyCode;
            else
                CHAR_CODE = -1;
        }
    }
    </script> 
</asp:Content>
