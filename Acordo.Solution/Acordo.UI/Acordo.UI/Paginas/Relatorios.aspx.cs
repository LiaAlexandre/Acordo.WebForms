using Acordo.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acordo.UI.Paginas
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AcordoServico acordoServico = new AcordoServico();

                grdAcordosHistorico.DataSource = null;
                grdAcordosHistorico.DataBind();

                if (!drpNomes.AutoPostBack)
                {
                    drpNomes.DataSource = acordoServico.BuscarNomesDosAcordos();
                    drpNomes.DataBind();
                    drpNomes.AutoPostBack = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = drpNomes.SelectedValue;
                DateTime dataInicio = DateTime.Parse(txtDataInicio.Text);
                DateTime dataFim = DateTime.Parse(txtDataFim.Text);

                AcordoServico acordoServico = new AcordoServico();

                var lista = acordoServico.ListarAcordosHistorico(nome, dataInicio, dataFim);
                grdAcordosHistorico.DataSource = lista;
                grdAcordosHistorico.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void drpNomes_TextChanged(object sender, EventArgs e)
        {

        }

        protected void drpNomes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}