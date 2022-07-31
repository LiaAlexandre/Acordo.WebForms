﻿<%@ Page Title="Importar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Importar.aspx.cs" Inherits="Acordo.UI.Paginas.Importar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="contentPlaceHolder">


    <div class="mainModal">
        <asp:Panel ID="CadastroPanel" runat="server" ForeColor="White" class="modalContent">
            <div class="modal-header">
                <label class="close">x</label>
                <label class="close">-</label>
                <label class="closeText">Importar</label>
            </div>
            <div class="modal-body" style="left: 0px; top: 0px; height: 299px">
                <table>
                    <tr>
                        <td class="tdCadastro">
                                <asp:Label ID="lblArquivo" runat="server" Text="Arquivo" ForeColor="White"></asp:Label>
                            <br />
                            <br />  
                                <input id="inputArquivo" type="file" runat="server" NAME="oFile" hidden  Text="BUSCA .CSV" Font-Size="Large" ForeColor="White" BackColor="#000066" Font-Bold="True" Visible="true" />
                                <asp:Button ID="btnEnviar" runat="server" type="submit"  /><br />
                                <asp:Label ID="lblResultadoImportacao" runat="server" Text="Importação Realizada com Sucesso" ForeColor="Lime" Font-Size="Larger" Visible="false"></asp:Label>
                                <br />
                                <asp:Button ID="btnImportar" runat="server" Text="IMPORTAR" Font-Size="Large" ForeColor="White" BackColor="#000066" Font-Bold="True" OnClick="btnImportar_Click" />

                        </td>
                    </tr>
                </table>
            </div>

            <div class="modal-footer">
            </div>
        </asp:Panel>
    </div>


</asp:Content>
