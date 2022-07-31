using Acordo.Entidade;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Servico
{
    public class CidadeServico
    {
        public CidadeServico() { }

        public string BuscarInformacoesCidade(string nomeCidade)
        {
            try
            {
                JsonApiCidade jsonCidade = null;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.openweathermap.org/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("data/2.5/weather?q=" + nomeCidade + "&appid=f160813f37f1c53618d1b6bea557c64c&lang=pt_br&units=metric").Result;

                if (response.IsSuccessStatusCode)
                {
                    jsonCidade = JsonConvert.DeserializeObject<JsonApiCidade>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new Exception("Cidade não encontrada");
                }

                string retorno = String.Empty;

                if (!String.IsNullOrEmpty(jsonCidade.name))
                    retorno = retorno + jsonCidade.name;

                if (jsonCidade.sys != null && !String.IsNullOrEmpty(jsonCidade.sys.country))
                    retorno = retorno + ", " + jsonCidade.sys.country;

                retorno = retorno + " - " + DateTime.Today.ToString("D");

                if (jsonCidade.main != null && !String.IsNullOrEmpty(jsonCidade.main.temp_min))
                    retorno = retorno + " - " + jsonCidade.main.temp_min + "ºC";

                if (jsonCidade.main != null && !String.IsNullOrEmpty(jsonCidade.main.temp_max))
                    retorno = retorno + " / " + jsonCidade.main.temp_max + "ºC";

                return retorno;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
