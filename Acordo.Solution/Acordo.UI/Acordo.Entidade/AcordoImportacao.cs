using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Entidade
{
    public class AcordoImportacao
    {
        public Int64 IDAcordoImportacao { get; set; }

        public DateTime DataAcordoImportacao { get; set; }

        public String NomeAcordoImportacao { get; set; }

        public String EmailAcordoImportacao { get; set; }

        public String CPFImportacao { get; set; }

        public String CNPJImportacao { get; set; }

        public String Telefone { get; set; }

        public Decimal ValorAcordoImportacao { get; set; }

        public DateTime DataImportacao { get; set; }
    }
}
