using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class VeiculoController
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoservice)
        {
            _veiculoService = veiculoservice;
        }

        public void CadastrarVeiculo()
        {
            Console.WriteLine("=== Cadastrar Veículo ===");
            Console.Write("Placa: ");
            string placaVeiculo = Console.ReadLine();

            Console.Write("Marca: ");
            string marcaVeiculo = Console.ReadLine();

            Console.Write("Modelo: ");
            string modeloVeiculo = Console.ReadLine();

            Console.Write("Ano de Fabricação: ");
            string anoFabricacaoString = Console.ReadLine();
            int anoFabricacao;
            bool ehAnoFabricacaoValido = int.TryParse(anoFabricacaoString, out anoFabricacao);

            while (!ehAnoFabricacaoValido || anoFabricacao <= 0)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Ano de Fabricação: ");
                anoFabricacaoString = Console.ReadLine();
                ehAnoFabricacaoValido = int.TryParse(anoFabricacaoString, out anoFabricacao);
            }

            string tipoVeiculo;
            do
            {
                Console.Write("Tipo de Veículo | M - Motocicleta | A - Automóvel | C - Caminhão : ");
                tipoVeiculo = Console.ReadLine();
            } while (tipoVeiculo.ToUpper() != "M" && tipoVeiculo.ToUpper() != "A" && tipoVeiculo.ToUpper() != "C");

            try
            {
                _veiculoService.CadastrarVeiculo(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacaoString, tipoVeiculo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Veículo cadastrado com sucesso.");
            Console.WriteLine();
            placaVeiculo = "";
            marcaVeiculo = "";
            modeloVeiculo = "";
            anoFabricacao = 0;
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("=== Listar Veículos ===");
            foreach (Veiculo veiculo in _veiculoService.ListarVeiculos())
            {
                Console.WriteLine(veiculo.ApresentarDadosVeiculo());
            }
            Console.WriteLine();
        }
    }
}