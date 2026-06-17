/* Exercício 5 - Serviço Assíncrono com HttpClient
Crie Servicos/CotacaoService.cs com o método: async Task<decimal> ObterCotacaoDolarAsync()
Use HttpClient para buscar: "https://economia.awesomeapi.com.br/json/last/USD-BRL"
Use Newtonsoft.json (Jsonconvert.DeserializeObject<dynamic>) para extrair o campo 'bid' como decimal.
No Main, busque a cotação com await e exiba: "Cotação do Dólar: R$ {cotacaoDolar}. Trate erros com try/catch. */

using Newtonsoft.Json;

namespace Aula_19_Exercicios.Servicos
{
    public class CotacaoService
    {




        public async Task<decimal> ObterCotacaoDolarAsync()
        {
            try
            {
                string URL = "https://economia.awesomeapi.com.br/json/last/USD-BRL";
                using HttpClient clientCotacaoDolar = new HttpClient();
                string resposta = await clientCotacaoDolar.GetStringAsync(URL);
                var dados = JsonConvert.DeserializeObject<dynamic>(resposta);
                return (decimal)dados["USDBRL"]["bid"];
            }
            catch (Exception)
            {
                return 0; // fallback para falhas na API
            }

        }
    }
}