using Acordo.Repositorio.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Repositorio
{
    public class AcordoRepositorio: BaseRepositorio
    {
        public void Salvar(String nome, String email, String telefone, String cpf, String cnpj, Decimal valorDoAcordo)
        {
            var query = "SP_INSERT_CRC_ACORDO_MESATUAL";
            var param = new DynamicParameters();
            param.Add("@paramIDACORDO", new Random().Next(50000));
            param.Add("@paramNomeAcordo", nome);
            param.Add("@paramEmailAcordo", email);
            param.Add("@paramTelefone", telefone);
            param.Add("@paramCPF", cpf);
            param.Add("@paramCNPJ", cnpj);
            param.Add("@paramValorAcordo", valorDoAcordo);

           SqlMapper.Execute(_connectionFactory.GetConnection, query, param, null, null, CommandType.StoredProcedure);
        }
    }
}
