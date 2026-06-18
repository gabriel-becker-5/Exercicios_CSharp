using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;

namespace Exercicio_Integrador_2.Repository
{
    public class AgendamentoRepository
    {
        ClienteRepository _clienteRepository;
        VeiculoRepository _veiculoRepository;
        ServicoRepository _servicoRepository;
        PecaRepository _pecaRepository;
        public List<Agendamento> Agendamentos { get; set; }

        public AgendamentoRepository(ClienteRepository clienterepository,
                                     VeiculoRepository veiculorepository,
                                     ServicoRepository servicorepository,
                                     PecaRepository pecarepository)
        {
            _clienteRepository = clienterepository;
            _veiculoRepository = veiculorepository;
            _servicoRepository = servicorepository;
            _pecaRepository = pecarepository;

            Agendamentos = new List<Agendamento>
            {
            new Agendamento(
                1,
                _clienteRepository.PesquisarClientePorID(6),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                _servicoRepository.ListarServicosEscolhidos([1,2,4,5]),
                _pecaRepository.ListarPecasEscolhidas([1,2,3,4,5,6,7]),
                DateTime.UtcNow.AddDays(5),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                2,
                _clienteRepository.PesquisarClientePorID(1),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                _servicoRepository.ListarServicosEscolhidos([2,4,5,6]),
                _pecaRepository.ListarPecasEscolhidas([2,5,8,11]),
                DateTime.UtcNow.AddHours(6),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                3,
                _clienteRepository.PesquisarClientePorID(3),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                _servicoRepository.ListarServicosEscolhidos([1,2,3,4,5,6]),
                _pecaRepository.ListarPecasEscolhidas([1,3,6,9,12,15]),
                DateTime.UtcNow.AddDays(1),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                4,
                _clienteRepository.PesquisarClientePorID(5),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                _servicoRepository.ListarServicosEscolhidos([1,2,7]),
                _pecaRepository.ListarPecasEscolhidas([4,7]),
                DateTime.UtcNow.AddHours(15),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                5,
                _clienteRepository.PesquisarClientePorID(2),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                _servicoRepository.ListarServicosEscolhidos([1,3,7]),
                _pecaRepository.ListarPecasEscolhidas([2,10,13,14]),
                DateTime.UtcNow.AddDays(3),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                6,
                _clienteRepository.PesquisarClientePorID(4),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                _servicoRepository.ListarServicosEscolhidos([3,4,5,6,7]),
                _pecaRepository.ListarPecasEscolhidas([1,5,7,8,11]),
                DateTime.UtcNow.AddDays(10),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                7,
                _clienteRepository.PesquisarClientePorID(6),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                _servicoRepository.ListarServicosEscolhidos([3,4,5,6]),
                _pecaRepository.ListarPecasEscolhidas([3,6,12]),
                DateTime.UtcNow.AddHours(20),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                8,
                _clienteRepository.PesquisarClientePorID(1),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                _servicoRepository.ListarServicosEscolhidos([3,6,7]),
                _pecaRepository.ListarPecasEscolhidas([9,10,14,15]),
                DateTime.UtcNow.AddHours(2),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                9,
                _clienteRepository.PesquisarClientePorID(3),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                _servicoRepository.ListarServicosEscolhidos([2,4,6]),
                _pecaRepository.ListarPecasEscolhidas([1,2,4,6,8,10]),
                DateTime.UtcNow.AddDays(4),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                10,
                _clienteRepository.PesquisarClientePorID(5),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                _servicoRepository.ListarServicosEscolhidos([3,4,7]),
                _pecaRepository.ListarPecasEscolhidas([5,11,13]),
                DateTime.UtcNow.AddHours(6),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                11,
                _clienteRepository.PesquisarClientePorID(2),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                _servicoRepository.ListarServicosEscolhidos([1,5,6]),
                _pecaRepository.ListarPecasEscolhidas([3,7,9,12,15]),
                DateTime.UtcNow.AddDays(6),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                12,
                _clienteRepository.PesquisarClientePorID(4),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                _servicoRepository.ListarServicosEscolhidos([3,4,7]),
                _pecaRepository.ListarPecasEscolhidas([2,14]),
                DateTime.UtcNow.AddDays(9),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                13,
                _clienteRepository.PesquisarClientePorID(6),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                _servicoRepository.ListarServicosEscolhidos([1,4,5,6,7]),
                _pecaRepository.ListarPecasEscolhidas([1,4,5,8,13]),
                DateTime.UtcNow.AddHours(1),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                14,
                _clienteRepository.PesquisarClientePorID(1),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                _servicoRepository.ListarServicosEscolhidos([1,4,5]),
                _pecaRepository.ListarPecasEscolhidas([6,7,10,11,12]),
                DateTime.UtcNow.AddHours(4),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                15,
                _clienteRepository.PesquisarClientePorID(3),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                _servicoRepository.ListarServicosEscolhidos([2,5,6]),
                _pecaRepository.ListarPecasEscolhidas([3,6,7,9]),
                DateTime.UtcNow.AddDays(2),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                16,
                _clienteRepository.PesquisarClientePorID(5),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                _servicoRepository.ListarServicosEscolhidos([1,2,3]),
                _pecaRepository.ListarPecasEscolhidas([2,5,8,14,15]),
                DateTime.UtcNow.AddHours(15),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                17,
                _clienteRepository.PesquisarClientePorID(2),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                _servicoRepository.ListarServicosEscolhidos([2,4,7]),
                _pecaRepository.ListarPecasEscolhidas([1,6,7,13]),
                DateTime.UtcNow.AddDays(7),
                StatusOrdemServico.Agendada
                ),

            new Agendamento(
                18,
                _clienteRepository.PesquisarClientePorID(4),
                _veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                _servicoRepository.ListarServicosEscolhidos([3,4,6,7]),
                _pecaRepository.ListarPecasEscolhidas([4,10,11,12]),
                DateTime.UtcNow.AddDays(4),
                StatusOrdemServico.Agendada
                )
            };

        }
        public int QtdAgendamentosCriados()
        {
            return Agendamentos.Count();
        }
        public void CadastrarAgendamento(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }

        public Agendamento PesquisarAgendamentoPorID(int id)
        {
            return Agendamentos.FirstOrDefault(a => a.Id == id);
        }

        public List<Agendamento> ListarAgendamentos()
        {
            return Agendamentos;
        }
    }
}