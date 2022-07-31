<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Acordo.UI.Paginas.Relatorios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="contentPlaceHolder">

    <div class="mainModal">
        <asp:Panel ID="CadastroPanel" runat="server" ForeColor="White" class="modalContent">
            <div class="modal-header">
                <label class="close">x</label>
                <label class="close">-</label>
                <label class="closeText">Relatórios</label>
            </div>
            <div class="modal-body" style="left: 0px; top: 0px; height: 299px">
                <table>
                    <tr>
                        <td class="tdCadastro">
                            <asp:Panel ID="Panel2" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                                <asp:DropDownList ID="drpNomes" runat="server" OnTextChanged="drpNomes_TextChanged" OnSelectedIndexChanged="drpNomes_SelectedIndexChanged" CssClass="dropDownNomes" ForeColor="Black">
                                    <asp:ListItem Text="nome1" Value="nome1"></asp:ListItem>
                                    <asp:ListItem Text="nome2" Value="nome2"></asp:ListItem>
                                    <asp:ListItem Text="nome3" Value="nome3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label2" runat="server" Text="Data:"></asp:Label>
                                &nbsp;<asp:TextBox ID="txtDataInicio" type="date" placeholder="dd-mm-yyyy" runat="server" ForeColor="Black"></asp:TextBox>
                                <asp:TextBox ID="txtDataFim" type="date" placeholder="dd-mm-yyyy" runat="server" ForeColor="Black"></asp:TextBox>
                                &nbsp;<asp:Panel ID="Panel3" runat="server">
                                    <asp:GridView ID="grdAcordosHistorico" runat="server" AutoGenerateColumns="true" EmptyDataText="Sem dados, favor realizar a busca" AllowPaging="True" BackColor="White" ForeColor="Black" CssClass="gridRelatorio">
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="buttonRelatorio" BorderStyle="None" Font-Bold="True" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
    <div class="modal-footer">
    </div>
    </asp:Panel>
    </div>
</asp:Content>
