﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">

     <asp:Panel ID="loginPanel" runat="server" HorizontalAlign="Center" 
        Width="850px">
    <h2>Inicio de Sesión</h2>
    <br />
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtUsuario" ErrorMessage="Ingrese un Usuario por favor" 
            ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtContraseña" 
            ErrorMessage="Ingrese una Contraseña por favor" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:LinkButton ID="lbIngresar" runat="server" onclick="lbIngresar_Click">Ingresar</asp:LinkButton>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblMensage" runat="server" 
            Text="Usuario o Contraseña incorrectas!" ForeColor="#FF3300" Visible="False"></asp:Label>
            <br />
        <asp:Label ID="lblMensage2" runat="server" 
            Text="Usuario inhabilitado!" ForeColor="#FF3300" Visible="False"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" 
            ForeColor="#FF3300" />
    </asp:Panel>
<br />


</asp:Content>
