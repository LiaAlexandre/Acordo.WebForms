<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exportar.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Acordo.UI.Paginas.Exportar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="contentPlaceHolder">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Exportar" BackColor="Black"  class="contentPlaceHolder">
    <asp:Panel ID="Panel2" runat="server" BackColor="Black">
        <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="nome1" Value="nome1"></asp:ListItem>
            <asp:ListItem Text="nome2" Value="nome2"></asp:ListItem>
            <asp:ListItem Text="nome3" Value="nome3"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Data:"></asp:Label>
        <input id="dataInicio" type="date" placeholder="dd-mm-yyyy" />
        <input id="dataFim" type="date" placeholder="dd-mm-yyyy" />
        <asp:Panel ID="Panel3" runat="server">
            <asp:GridView ID="GridView1" runat="server" autogeneratecolumns="true" emptydatatext="No data available." allowpaging="True">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Data" 
                        InsertVisible="False" ReadOnly="True" SortExpression="Data" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" 
                        SortExpression="Nome" />
                    <asp:BoundField DataField="Telefone" HeaderText="Telefone" 
                        SortExpression="Telefone" />
                    <asp:BoundField DataField="CPF/CNPJ" HeaderText="CPF/CNPJ" 
                        SortExpression="CPF/CNPJ" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" 
                        SortExpression="Valor" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Button ID="Button1" runat="server" Text="Exportar" BackColor="#000066" BorderStyle="None" ForeColor="White" Font-Bold="True" />
    </asp:Panel>
    </asp:Panel>
</asp:Content>
