


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="Acordo.UI.Paginas.Relatorios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="contentPlaceHolder">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Relatorios" BackColor="Black" class="contentPlaceHolder">
    <asp:Panel ID="Panel2" runat="server" BackColor="Black">
        <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        <asp:DropDownList ID="drpNomes" runat="server"  OnTextChanged="drpNomes_TextChanged" OnSelectedIndexChanged="drpNomes_SelectedIndexChanged">
            <asp:ListItem Text="nome1" Value="nome1"></asp:ListItem>
            <asp:ListItem Text="nome2" Value="nome2"></asp:ListItem>
            <asp:ListItem Text="nome3" Value="nome3"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Data:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtDataInicio" type="date" placeholder="dd-mm-yyyy" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtDataFim" type="date" placeholder="dd-mm-yyyy" runat="server"></asp:TextBox>
&nbsp;<asp:Panel ID="Panel3" runat="server">
            <asp:GridView ID="grdAcordosHistorico" runat="server" autogeneratecolumns="true" emptydatatext="Sem dados, favor realizar a busca" allowpaging="True" BackColor="White">
            </asp:GridView>
        </asp:Panel>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" BackColor="#000066" BorderStyle="None" ForeColor="White" Font-Bold="True" OnClick="btnBuscar_Click" />
    </asp:Panel>
        </asp:Panel>
</asp:Content>
