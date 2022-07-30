using Acordo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Servico
{
    public class AcordoServico
    {
        public AcordoRepositorio _acordoRepositorio;

        public AcordoServico()
        {
            _acordoRepositorio = new AcordoRepositorio();
        }

        public void SalvarAcordo(String nome, String email, String telefone, String cpf, String cnpj, Decimal valorAcordo)
        {
            try
            {
                _acordoRepositorio.Salvar(nome, email, telefone, cpf, cnpj, valorAcordo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
