using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Entidade
{
    public class AcordoHistorico
    {
        public DateTime Data { get; set; }

        public String Nome { get; set; }

        public String CPF_CNPJ { get; set; }

        public String Telefone { get; set; }

        public Decimal Valor { get; set; }
    }
}
