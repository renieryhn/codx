﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfmDetExpedientePublico.aspx.vb" Inherits="smx.wfmDetExpedientePublico" MasterPageFile="~/Consulta.Master" %>
<%@ MasterType VirtualPath="~/Consulta.Master"%>
<%@ Register src="~/Controles/TextBox.ascx" tagname="TextBox" tagprefix="uc1" %>



<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <div class="DD">
    <asp:Label ID="Label1" runat="server" Text="Número de Expediente"></asp:Label>
    <uc1:TextBox ID="txtNumExpediente" runat="server" Obligatorio="True" 
        MaxLength="15" MensajeError="Debe introducir el Número de Expediente" />
        </div>
</asp:Content>



