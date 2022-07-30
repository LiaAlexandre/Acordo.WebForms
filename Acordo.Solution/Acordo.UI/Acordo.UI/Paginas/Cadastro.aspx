<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Acordo.UI.Paginas.Cadastro" %>

<asp:Content ID="BodyCadastro" ContentPlaceHolderID="MainContent" runat="server" Visible="false">
    <asp:Panel ID="CadastroPanel" runat="server" BackColor="Black" ForeColor="White" Direction="LeftToRight" Height="250px" Width="350px" GroupingText="Cadastro">
        <asp:Panel ID="Panel2" runat="server" BackColor="Black" BorderStyle="None" Direction="LeftToRight" Height="35px" HorizontalAlign="Center" Width="230px">
        <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" BackColor="Black" BorderColor="Black" BorderStyle="None" Direction="LeftToRight" Height="35px" HorizontalAlign="Center" Width="230px">
            <asp:Label ID="Label2" runat="server" Text="Telefone:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" BackColor="Black" Direction="LeftToRight" Height="35px" HorizontalAlign="Center" Width="250px">
            <asp:Label ID="Label3" runat="server" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" BackColor="Black" Direction="LeftToRight" Height="35px" HorizontalAlign="Center" Width="230px">
            <asp:Label ID="Label4" runat="server" Text="CPF/CNPJ:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" BackColor="Black" Direction="LeftToRight" Height="35px" HorizontalAlign="Center" Width="230px">
            <asp:Label ID="Label5" runat="server" Text="Valor Acordo:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Button ID="cadastrarButton" runat="server" OnClick="Button1_Click" Text="CADASTRAR" BackColor="#000066" BorderStyle="None" Font-Bold="True" ForeColor="White" />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Cadastro Inserido" align-text="center" ForeColor="Lime" Font-Size="Large" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>
