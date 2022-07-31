using Acordo.Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acordo.UI.Paginas
{
    public partial class Importar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {

                string nomeDoArquivo = ComporNomeDoArquivo();
                string caminhoDoArquivo;
                string nomeDaPasta = "/ultimasimportacoes";
                nomeDaPasta = Server.MapPath("../ultimasimportacoes");

                if (inputArquivo.Value != "")
                {
                    if (!Directory.Exists(nomeDaPasta))
                    {
                        Directory.CreateDirectory(nomeDaPasta);
                    }

                    caminhoDoArquivo = nomeDaPasta + "\\" + nomeDoArquivo;

                    inputArquivo.PostedFile.SaveAs(caminhoDoArquivo);

                    AcordoServico acordoServico = new AcordoServico();

                    acordoServico.SalvarAcordosEmLote(nomeDaPasta);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private string ComporNomeDoArquivo()
        {
            return 
                DateTime.Today.Month.ToString().PadLeft(2, '0') + 
                DateTime.Today.Day.ToString().PadLeft(2, '0') + 
                DateTime.Today.Year.ToString() + "-" +
                DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                DateTime.Now.Second.ToString().PadLeft(2, '0') +
                ".cvs";
        }
    }
}