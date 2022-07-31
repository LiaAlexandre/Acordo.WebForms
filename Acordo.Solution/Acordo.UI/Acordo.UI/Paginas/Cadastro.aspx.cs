using Acordo.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acordo.UI.Paginas
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cadastrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                String nome = txtNome.Text;
                String telefone = RemoverCaracteresEspeciais(txtTelefone.Text);
                String email = txtEmail.Text;
                String cpfCnpj = RemoverCaracteresEspeciais(txtCpfCnpj.Text);
                string valorAcordo = txtValorAcordo.Text;

                bool resultadoValicadao = validarCampos(nome, telefone, email, cpfCnpj, valorAcordo);

                bool isCpf = txtCpfCnpj.MaxLength == 11 ? true : false;

                if (!resultadoValicadao)
                    return;

                Decimal valorAcordoConvertido = Decimal.Parse(valorAcordo);

                AcordoServico acordoServico = new AcordoServico();


                if (isCpf)
                    acordoServico.SalvarAcordo(nome, email, telefone, cpfCnpj, null, valorAcordoConvertido);
                else
                    acordoServico.SalvarAcordo(nome, email, telefone, null, cpfCnpj, valorAcordoConvertido);


                lblMensagem.Text = "Cadastro inserido!";
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro no sistema";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
            }
        }

        private string RemoverCaracteresEspeciais(string texto)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(texto.Replace(" ", ""), replacement);
        }

        private bool validarCampos(String nome, String telefone, String email, String cpfCnpj, string valorAcordo)
        {
            Decimal valorAcordoConvertido = 0;

            if (!Decimal.TryParse(txtValorAcordo.Text, out valorAcordoConvertido))
            {
                lblMensagem.Text = "O campo: [Valor do Acordo] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            if (!ValidarTelefone(telefone))
            {
                lblMensagem.Text = "O campo: [Telefone] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            if (!ValidarEmail(email))
            {
                lblMensagem.Text = "O campo: [Email] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            return true;
        }

        private static bool ValidarEmail(string email)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static bool ValidarTelefone(string telefone)
        {
            string strModelo = "\\d{9}";
            if (System.Text.RegularExpressions.Regex.IsMatch(telefone, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}