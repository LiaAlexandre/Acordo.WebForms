<%@ Page Title="Importar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Importar.aspx.cs" Inherits="Acordo.UI.Paginas.Importar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Black" GroupingText="Importar" ForeColor="White" Font-Size="Medium" Height="500px" Width="500px">
        <asp:Label ID="Label1" runat="server" Text="Arquivo" ForeColor="White"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="BUSCA .CSV" Font-Size="Large" ForeColor="White" BackColor="#000066" Font-Bold="True" Visible="true" /><br />
        <asp:Label ID="Label2" runat="server" Text="Importação Realizada com Sucesso" ForeColor="Lime" Font-Size="Larger" Visible="false"></asp:Label> <br />
        <asp:Button ID="Button2" runat="server" Text="IMPORTAR" Font-Size="Large" ForeColor="White" BackColor="#000066" Font-Bold="True" />
    </asp:Panel>
</asp:Content>
