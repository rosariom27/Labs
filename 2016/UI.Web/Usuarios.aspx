<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">

     <asp:Panel ID="gridPanel" runat="server">
            <asp:gridView ID="gridView" runat="server" AutoGenerateColumns="false" 
              SelectedRowStyle-BackColor="Black"
              SelectedRowStyle-ForeColor="White"
              DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged"  >
              <Columns>
                  <%--<asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                  <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                  <asp:BoundField HeaderText="EMail" DataField="EMail" />--%>
                  <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                  <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                  <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
              </Columns>
            </asp:gridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" >
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
            <br />
        </asp:Panel>

        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click1">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
        </asp:Panel>

        <asp:Panel ID="formActionsPanel" runat="server">

            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
        </asp:Panel>
    

</asp:Content>
