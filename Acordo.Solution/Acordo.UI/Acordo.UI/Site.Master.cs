using Acordo.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acordo.UI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Paginas/Cadastro.aspx");
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Paginas/Relatorios.aspx");
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Paginas/Importar.aspx");
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Paginas/Exportar.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void txtCidade_TextChanged(object sender, EventArgs e)
        {
            try
            {

                String cidade = txtCidade.Text;

                if (cidade.Length < 3)
                    return;

                CidadeServico cidadeServico = new CidadeServico();

                string mensagem = cidadeServico.BuscarInformacoesCidade(cidade);

                lblCidadeStatus.Text = mensagem;
                lblCidadeStatus.Visible = true;
                lblCidadeStatus.ForeColor = System.Drawing.Color.Gray;
            }
            catch(Exception ex)
            {
                lblCidadeStatus.Text = ex.Message;
                lblCidadeStatus.Visible = true;
                lblCidadeStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}