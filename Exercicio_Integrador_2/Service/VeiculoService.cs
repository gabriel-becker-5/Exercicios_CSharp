using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _veiculoRepository;

        public VeiculoService(VeiculoRepository veiculorepository)
        {
            _veiculoRepository = veiculorepository;
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

            if (tipoVeiculo.ToUpper() == "M")
            {
                Moto novoVeiculo = new Moto(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
            }
            else if (tipoVeiculo.ToUpper() == "A")
            {
                Carro novoVeiculo = new Carro(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
            }
            else
            {
                Caminhao novoVeiculo = new Caminhao(placaVeiculo, marcaVeiculo, modeloVeiculo, anoFabricacao);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
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
            List<Veiculo> listaVeiculos = _veiculoRepository.ListarTodosVeiculos();
            foreach (Veiculo veiculo in listaVeiculos)
            {
                Console.WriteLine(veiculo.ApresentarDadosVeiculo());
            }
            Console.WriteLine();
        }
    }
}