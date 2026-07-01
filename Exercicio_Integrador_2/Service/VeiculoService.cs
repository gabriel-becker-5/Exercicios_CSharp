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

        public void CadastrarVeiculo(string placa, 
                                     string marca, 
                                     string modelo, 
                                     string anofabricacao, 
                                     string tipoveiculo)
        {   
            int AnoFabricacaoInt;
            int.TryParse(anofabricacao, out AnoFabricacaoInt);

            if (tipoveiculo.ToUpper() == "M")
            {
                Moto novoVeiculo = new Moto(placa, marca, modelo, AnoFabricacaoInt);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
            }
            else if (tipoveiculo.ToUpper() == "A")
            {
                Carro novoVeiculo = new Carro(placa, marca, modelo, AnoFabricacaoInt);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
            }
            else
            {
                Caminhao novoVeiculo = new Caminhao(placa, marca, modelo, AnoFabricacaoInt);
                _veiculoRepository.CadastrarVeiculo(novoVeiculo);
            }
        }

        public List<Veiculo> ListarVeiculos()
        {
            return _veiculoRepository.ListarTodosVeiculos();
        }
    }
}