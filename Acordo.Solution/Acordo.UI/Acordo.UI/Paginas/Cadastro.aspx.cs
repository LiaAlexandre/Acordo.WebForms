using System;
using System.Collections.Generic;
using System.Linq;
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
            String nome = txtNome.Text;
            String telefone = txtTelefone.Text;
            String email = txtEmail.Text;
            String cpfCnpj = txtCpfCnpj.Text;
            string valorAcordo = txtValorAcordo.Text;

            bool resultadoValicadao = validarCampos(nome, telefone, email, cpfCnpj, valorAcordo);

            if (!resultadoValicadao)
                return;

            Decimal valorAcordoConvertido = Decimal.Parse(valorAcordo);

            lblMensagem.Text = "Cadastro inserido!";
            lblMensagem.ForeColor = System.Drawing.Color.Green;
            lblMensagem.Visible = true;
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