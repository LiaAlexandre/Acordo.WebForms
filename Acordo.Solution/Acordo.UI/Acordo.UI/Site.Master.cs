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
           // Response.Write("<script language='javascript'>window.open('/Paginas/Cadastro.aspx');</script>");
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
    }
}