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
            bool ehAnoFabricacaoValido = _veiculoService.EhAnoFabricacaoValido(anoFabricacaoString);

            while (!ehAnoFabricacaoValido)
            {
                Console.WriteLine("Digite um número válido!");
                Console.Write("Ano de Fabricação: ");
                anoFabricacaoString = Console.ReadLine();
                ehAnoFabricacaoValido = _veiculoService.EhAnoFabricacaoValido(anoFabricacaoString);
            }


            // PENDENTE MÉTODO VERIFICAR TIPO DE VEÍCULO
            Console.Write("Tipo de Veículo | M - Motocicleta | A - Automóvel | C - Caminhão : ");
            string tipoVeiculo = Console.ReadLine();
            bool ehTipoVeiculoValido = _veiculoService.TipoVeiculoEhValido(tipoVeiculo);

            while (!ehTipoVeiculoValido)
            {
                Console.WriteLine("Informe um tipo de veículo válido!");
                Console.Write("Tipo de Veículo | M - Motocicleta | A - Automóvel | C - Caminhão : ");
                tipoVeiculo = Console.ReadLine();
                ehTipoVeiculoValido = _veiculoService.TipoVeiculoEhValido(tipoVeiculo);
            }

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