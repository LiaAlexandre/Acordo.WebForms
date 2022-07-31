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
                String telefone = AcordoServico.RemoverCaracteresEspeciais(txtTelefone.Text);
                String email = txtEmail.Text;
                String cpfCnpj = AcordoServico.RemoverCaracteresEspeciais(txtCpfCnpj.Text);
                string valorAcordo = txtValorAcordo.Text;

                bool isCpf = cpfCnpj.Length == 11 ? true : false;

                string cpf = null;
                string cnpj = null;

                if (isCpf)
                    cpf = cpfCnpj;
                else
                    cnpj = cpfCnpj;

                bool resultadoValicadao = validarCampos(nome, telefone, email, cpf, cnpj, valorAcordo);

                if (!resultadoValicadao)
                    return;

                Decimal valorAcordoConvertido = Decimal.Parse(valorAcordo);

                AcordoServico acordoServico = new AcordoServico();


                acordoServico.SalvarAcordo(nome, email, telefone, cpf, cnpj, valorAcordoConvertido);

                lblMensagem.Text = "Cadastro inserido!";
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Visible = true;
            }
            catch (Exception)
            {
                lblMensagem.Text = "Erro no sistema";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
            }
        }


        private bool validarCampos(String nome, String telefone, String email, String cpf, String cnpj, String valorAcordo)
        {
            Decimal valorAcordoConvertido = 0;

            if (!Decimal.TryParse(txtValorAcordo.Text, out valorAcordoConvertido))
            {
                lblMensagem.Text = "O campo: [Valor do Acordo] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            if (!AcordoServico.ValidarTelefone(telefone))
            {
                lblMensagem.Text = "O campo: [Telefone] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            if (!AcordoServico.ValidarEmail(email))
            {
                lblMensagem.Text = "O campo: [Email] foi informado incorretamente";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Visible = true;
                return false;
            }

            if (!String.IsNullOrEmpty(cpf))
            {
                if (!AcordoServico.ValidarCPF(cpf))
                {
                    lblMensagem.Text = "O campo: [CPF] foi informado incorretamente";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Visible = true;
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(cnpj))
            {
                if (!AcordoServico.ValidarCNPJ(cnpj))
                {
                    lblMensagem.Text = "O campo: [CNPJ] foi informado incorretamente";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Visible = true;
                    return false;
                }
            }

                return true;
        }

        
    }
}