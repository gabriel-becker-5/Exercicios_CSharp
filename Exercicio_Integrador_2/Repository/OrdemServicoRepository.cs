using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class OrdemServicoRepository
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly ServicoRepository _servicoRepository;
        private readonly PecaRepository _pecaRepository;
        private readonly FuncionarioRepository _funcionarioRepository;
        public List<OrdemServico> OrdensDeServico { get; set; }

        public OrdemServicoRepository(ClienteRepository clienterepository,
                                      VeiculoRepository veiculorepository,
                                      ServicoRepository servicorepository,
                                      PecaRepository pecarepository,
                                      FuncionarioRepository funcionariorepository)
        {
            _clienteRepository = clienterepository;
            _veiculoRepository = veiculorepository;
            _servicoRepository = servicorepository;
            _pecaRepository = pecarepository;
            _funcionarioRepository = funcionariorepository;

            OrdensDeServico = new List<OrdemServico>
            {
                new OrdemServico(
                    1,
                    _clienteRepository.PesquisarClientePorID(1),
                    _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A00"),
                    _funcionarioRepository.PesquisarFuncionarioPorID(1),
                    _servicoRepository.ListarServicosEscolhidos([1,3,5]),
                    _pecaRepository.ListarPecasEscolhidas([1,4,8,12,15]),
                    DateTime.UtcNow,
                    StatusOrdemServico.Aberta
                ),

                new OrdemServico(
                    2,
                    _clienteRepository.PesquisarClientePorID(2),
                    _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A01"),
                    _funcionarioRepository.PesquisarFuncionarioPorID(2),
                    _servicoRepository.ListarServicosEscolhidos([2,4,6,7]),
                    _pecaRepository.ListarPecasEscolhidas([2,3,5,7,11,14]),
                    DateTime.UtcNow,
                    StatusOrdemServico.Aberta
                ),

                new OrdemServico(
                    3,
                    _clienteRepository.PesquisarClientePorID(5),
                    _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                    _funcionarioRepository.PesquisarFuncionarioPorID(2),
                    _servicoRepository.ListarServicosEscolhidos([1]),
                    _pecaRepository.ListarPecasEscolhidas([6,9,10,11]),
                    DateTime.UtcNow,
                    StatusOrdemServico.EmAndamento
                ),

                new OrdemServico(
                    4,
                    _clienteRepository.PesquisarClientePorID(3),
                    _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                    _funcionarioRepository.PesquisarFuncionarioPorID(2),
                    _servicoRepository.ListarServicosEscolhidos([3,5,7]),
                    _pecaRepository.ListarPecasEscolhidas([1,4,5,6,13]),
                    DateTime.UtcNow,
                    StatusOrdemServico.AguardaPecas
                ),

                new OrdemServico(
                    5,
                    _clienteRepository.PesquisarClientePorID(6),
                    _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                    _funcionarioRepository.PesquisarFuncionarioPorID(3),
                    _servicoRepository.ListarServicosEscolhidos([1,2,4,5,6]),
                    _pecaRepository.ListarPecasEscolhidas([3,5,8,9,11,12,14,15]),
                    DateTime.UtcNow,
                    StatusOrdemServico.Finalizada
                )
            };
        }

        public int QtdOrdensServicoCriadas()
        {
            return OrdensDeServico.Count();
        }

        public void CadastrarOS(OrdemServico os)
        {
            OrdensDeServico.Add(os);
        }

        public OrdemServico PesquisarOSporID(int id)
        {
            return OrdensDeServico.FirstOrDefault(os => os.Id == id);
        }

        public List<OrdemServico> ListarTodasOS()
        {
            return OrdensDeServico;
        }
    }
}