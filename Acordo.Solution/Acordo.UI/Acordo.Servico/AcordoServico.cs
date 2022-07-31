using Acordo.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void SalvarAcordosEmLote(string diretorio)
        {
            try
            {
                var files = Directory.GetFiles(diretorio);
                foreach(var file in files)
                {
                    using (var reader = new StreamReader(file))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');

                            String nome = values[0];
                            String telefone = values[1];
                            String email = values[2];
                            String cpfCnpj = values[3];
                            String valorAcordo = values[4];
                            String dataAcordo = values[5];

                            if (nome == "Nome")
                                continue;

                            bool resultadoValidacao = ValidarCampos(nome, telefone, email, cpfCnpj, valorAcordo);

                            if (!resultadoValidacao)
                                continue;

                            Decimal valorAcordoConvertido = Decimal.Parse(valorAcordo);
                            DateTime dataAcordoConvertido = DateTime.Parse(dataAcordo);

                            _acordoRepositorio.SalvarImportacao(nome, email, telefone, cpfCnpj, cpfCnpj, valorAcordoConvertido, dataAcordoConvertido);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarEmail(string email)
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

        public static bool ValidarTelefone(string telefone)
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

        private static bool ValidarCampos(String nome, String telefone, String email, String cpfCnpj, string valorAcordo)
        {
            Decimal valorAcordoConvertido = 0;

            if (!Decimal.TryParse(valorAcordo, out valorAcordoConvertido))
            {
                return false;
            }

            if (!AcordoServico.ValidarTelefone(telefone))
            {
                return false;
            }

            if (!AcordoServico.ValidarEmail(email))
            {
                return false;
            }

            return true;
        }

        public static string RemoverCaracteresEspeciais(string texto)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(texto.Replace(" ", ""), replacement);
        }
    }
}
