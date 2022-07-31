using Acordo.Entidade;
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

                            bool isCpf = cpfCnpj.Length == 11 ? true : false;

                            string cpf = null;
                            string cnpj = null;

                            if (isCpf)
                                cpf = cpfCnpj;
                            else
                                cnpj = cpfCnpj;

                            bool resultadoValidacao = ValidarCampos(nome, telefone, email, cpf, cnpj, valorAcordo);

                            if (!resultadoValidacao)
                                continue;

                            Decimal valorAcordoConvertido = Decimal.Parse(valorAcordo);
                            DateTime dataAcordoConvertido = DateTime.Parse(dataAcordo);

                            AcordoImportacao acordoImportacao = _acordoRepositorio.BuscarAcordoImportacaoPorNome(nome);

                            if (acordoImportacao != null)
                                continue;

                            _acordoRepositorio.SalvarImportacao(nome, email, telefone, cpf, cnpj, valorAcordoConvertido, dataAcordoConvertido);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<String> BuscarNomesDosAcordos()
        {
            try
            {
                return _acordoRepositorio.BuscarNomesDosAcordos().Distinct().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<AcordoHistorico> ListarAcordosHistorico(string nome, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return _acordoRepositorio.ListarAcordosHistorico(nome, dataInicio, dataFim).ToList();
            }
            catch (Exception ex)
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

        public static bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf.Length != 11)
                return false;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private static bool ValidarCampos(String nome, String telefone, String email, String cpf, String cnpj, string valorAcordo)
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

            if (!String.IsNullOrEmpty(cpf))
            {
                if (!AcordoServico.ValidarCPF(cpf))
                {
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(cnpj))
            {
                if (!AcordoServico.ValidarCNPJ(cnpj))
                {
                    return false;
                }
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
