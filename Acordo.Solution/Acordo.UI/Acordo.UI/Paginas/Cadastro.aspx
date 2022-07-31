<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Acordo.UI.Paginas.Cadastro" %>

<asp:Content ID="BodyCadastro" ContentPlaceHolderID="MainContent" runat="server" Visible="false">
    <div class="mainModal">
        <asp:Panel ID="CadastroPanel" runat="server" ForeColor="White" class="modalContent">
        <div class="modal-header">
            <Label class="close">x</Label>
            <Label class="close">-</Label>
            <Label class="closeText">Cadastro</Label>
        </div>
            <div class="modal-body" style="left: 0px; top: 0px; height: 299px">
                <table>
                    <tr>
                        <td class="tdCadastro">
                            <asp:Panel ID="Panel1" runat="server" BorderStyle="None">
                                <asp:Label ID="Label6" runat="server" Text="Nome:" CssClass="labelClass"></asp:Label>
                                <asp:TextBox ID="txtNome" runat="server" ForeColor="#333333"></asp:TextBox>
                            </asp:Panel>
                            <asp:Panel ID="Panel7" runat="server">
                                <asp:Label ID="Label7" runat="server" Text="E-mail:" CssClass="labelClass"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" ForeColor="#666666"></asp:TextBox>
                            </asp:Panel>
                            <asp:Panel ID="Panel8" runat="server">
                                <asp:Label ID="Label8" runat="server" Text="Valor Acordo:" CssClass="labelClass"></asp:Label>
                                <asp:TextBox ID="txtValorAcordo" runat="server" ForeColor="#666666"></asp:TextBox>
                            </asp:Panel>

                        </td>
                        <td class="tdCadastro">
                            <asp:Panel ID="Panel3" runat="server" BorderStyle="None">
                                <asp:Label ID="Label2" runat="server" Text="Telefone:" CssClass="labelClass"></asp:Label>
                                <asp:TextBox ID="txtTelefone" runat="server" ForeColor="#333333"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel5" runat="server">
                                <asp:Label ID="Label4" runat="server" Text="CPF/CNPJ:" CssClass="labelClass"></asp:Label>
                                <asp:TextBox ID="txtCpfCnpj" runat="server" ForeColor="#666666" class="cpfOuCnpj"></asp:TextBox>
                            </asp:Panel>
                            <asp:Button ID="cadastrarButton" runat="server" OnClick="cadastrarButton_Click" Text="CADASTRAR" CssClass="buttonCadastro" BorderStyle="None" Font-Bold="True" />
                        </td>
                    </tr>
                </table>
            <asp:Label ID="lblMensagem" runat="server" Text="Cadastro Inserido" align-text="center" Visible="False" Font-Bold="True" Font-Size="20pt"></asp:Label>
            </div>

            <div class="modal-footer">
            </div>
        </asp:Panel>
    </div>
</asp:Content>
