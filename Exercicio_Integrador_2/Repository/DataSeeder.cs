using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public static class DataSeeder
    {
        public static void Popular(AgendamentoRepository agendamentoRepository,
                                   ClienteRepository clienteRepository,
                                   VeiculoRepository veiculoRepository,
                                   ServicoRepository servicoRepository,
                                   PecaRepository pecaRepository,
                                   OrdemServicoRepository ordemServicoRepository,
                                   FuncionarioRepository funcionarioRepository
                                   )
        {
            agendamentoRepository.CadastrarAgendamento(new Agendamento(1,
                clienteRepository.PesquisarClientePorID(6),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                servicoRepository.ListarServicosEscolhidos([1, 2, 4, 5]),
                pecaRepository.ListarPecasEscolhidas([1, 2, 3, 4, 5, 6, 7]),
                DateTime.UtcNow.AddDays(5),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(2,
                clienteRepository.PesquisarClientePorID(1),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                servicoRepository.ListarServicosEscolhidos([2, 4, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([2, 5, 8, 11]),
                DateTime.UtcNow.AddHours(6),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(3,
                clienteRepository.PesquisarClientePorID(3),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                servicoRepository.ListarServicosEscolhidos([1, 2, 3, 4, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([1, 3, 6, 9, 12, 15]),
                DateTime.UtcNow.AddDays(1),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(4,
                clienteRepository.PesquisarClientePorID(5),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                servicoRepository.ListarServicosEscolhidos([1, 2, 7]),
                pecaRepository.ListarPecasEscolhidas([4, 7]),
                DateTime.UtcNow.AddHours(15),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(5,
                clienteRepository.PesquisarClientePorID(2),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                servicoRepository.ListarServicosEscolhidos([1, 3, 7]),
                pecaRepository.ListarPecasEscolhidas([2, 10, 13, 14]),
                DateTime.UtcNow.AddDays(3),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(6,
                clienteRepository.PesquisarClientePorID(4),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                servicoRepository.ListarServicosEscolhidos([3, 4, 5, 6, 7]),
                pecaRepository.ListarPecasEscolhidas([1, 5, 7, 8, 11]),
                DateTime.UtcNow.AddDays(10),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(7,
                clienteRepository.PesquisarClientePorID(6),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                servicoRepository.ListarServicosEscolhidos([3, 4, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([3, 6, 12]),
                DateTime.UtcNow.AddHours(20),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(8,
                clienteRepository.PesquisarClientePorID(1),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                servicoRepository.ListarServicosEscolhidos([3, 6, 7]),
                pecaRepository.ListarPecasEscolhidas([9, 10, 14, 15]),
                DateTime.UtcNow.AddHours(2),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(9,
                clienteRepository.PesquisarClientePorID(3),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                servicoRepository.ListarServicosEscolhidos([2, 4, 6]),
                pecaRepository.ListarPecasEscolhidas([1, 2, 4, 6, 8, 10]),
                DateTime.UtcNow.AddDays(4),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(10,
                clienteRepository.PesquisarClientePorID(5),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                servicoRepository.ListarServicosEscolhidos([3, 4, 7]),
                pecaRepository.ListarPecasEscolhidas([5, 11, 13]),
                DateTime.UtcNow.AddHours(6),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(11,
                clienteRepository.PesquisarClientePorID(2),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                servicoRepository.ListarServicosEscolhidos([1, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([3, 7, 9, 12, 15]),
                DateTime.UtcNow.AddDays(6),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(12,
                clienteRepository.PesquisarClientePorID(4),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                servicoRepository.ListarServicosEscolhidos([3, 4, 7]),
                pecaRepository.ListarPecasEscolhidas([2, 14]),
                DateTime.UtcNow.AddDays(9),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(13,
                clienteRepository.PesquisarClientePorID(6),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                servicoRepository.ListarServicosEscolhidos([1, 4, 5, 6, 7]),
                pecaRepository.ListarPecasEscolhidas([1, 4, 5, 8, 13]),
                DateTime.UtcNow.AddHours(1),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(14,
                clienteRepository.PesquisarClientePorID(1),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A05"),
                servicoRepository.ListarServicosEscolhidos([1, 4, 5]),
                pecaRepository.ListarPecasEscolhidas([6, 7, 10, 11, 12]),
                DateTime.UtcNow.AddHours(4),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(15,
                clienteRepository.PesquisarClientePorID(3),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                servicoRepository.ListarServicosEscolhidos([2, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([3, 6, 7, 9]),
                DateTime.UtcNow.AddDays(2),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(16,
                clienteRepository.PesquisarClientePorID(5),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                servicoRepository.ListarServicosEscolhidos([1, 2, 3]),
                pecaRepository.ListarPecasEscolhidas([2, 5, 8, 14, 15]),
                DateTime.UtcNow.AddHours(15),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(17,
                clienteRepository.PesquisarClientePorID(2),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A09"),
                servicoRepository.ListarServicosEscolhidos([2, 4, 7]),
                pecaRepository.ListarPecasEscolhidas([1, 6, 7, 13]),
                DateTime.UtcNow.AddDays(7),
                StatusOrdemServico.Agendada
                ));

            agendamentoRepository.CadastrarAgendamento(new Agendamento(18,
                clienteRepository.PesquisarClientePorID(4),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A04"),
                servicoRepository.ListarServicosEscolhidos([3, 4, 6, 7]),
                pecaRepository.ListarPecasEscolhidas([4, 10, 11, 12]),
                DateTime.UtcNow.AddDays(4),
                StatusOrdemServico.Agendada
                ));

            ordemServicoRepository.CadastrarOS(new OrdemServico(1,
                clienteRepository.PesquisarClientePorID(1),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A00"),
                funcionarioRepository.PesquisarFuncionarioPorID(1),
                servicoRepository.ListarServicosEscolhidos([1, 3, 5]),
                pecaRepository.ListarPecasEscolhidas([1, 4, 8, 12, 15]),
                DateTime.UtcNow,
                StatusOrdemServico.Aberta
                ));

            ordemServicoRepository.CadastrarOS(new OrdemServico(2,
                clienteRepository.PesquisarClientePorID(2),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A01"),
                funcionarioRepository.PesquisarFuncionarioPorID(2),
                servicoRepository.ListarServicosEscolhidos([2, 4, 6, 7]),
                pecaRepository.ListarPecasEscolhidas([2, 3, 5, 7, 11, 14]),
                DateTime.UtcNow,
                StatusOrdemServico.Aberta
                ));

            ordemServicoRepository.CadastrarOS(new OrdemServico(3,
                clienteRepository.PesquisarClientePorID(5),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A11"),
                funcionarioRepository.PesquisarFuncionarioPorID(2),
                servicoRepository.ListarServicosEscolhidos([1]),
                pecaRepository.ListarPecasEscolhidas([6, 9, 10, 11]),
                DateTime.UtcNow,
                StatusOrdemServico.EmAndamento
                ));

            ordemServicoRepository.CadastrarOS(new OrdemServico(4,
                clienteRepository.PesquisarClientePorID(3),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A02"),
                funcionarioRepository.PesquisarFuncionarioPorID(2),
                servicoRepository.ListarServicosEscolhidos([3, 5, 7]),
                pecaRepository.ListarPecasEscolhidas([1, 4, 5, 6, 13]),
                DateTime.UtcNow,
                StatusOrdemServico.AguardaPecas
                ));

            ordemServicoRepository.CadastrarOS(new OrdemServico(5,
                clienteRepository.PesquisarClientePorID(6),
                veiculoRepository.PesquisarVeiculoPorPlaca("AAA-0A15"),
                funcionarioRepository.PesquisarFuncionarioPorID(3),
                servicoRepository.ListarServicosEscolhidos([1, 2, 4, 5, 6]),
                pecaRepository.ListarPecasEscolhidas([3, 5, 8, 9, 11, 12, 14, 15]),
                DateTime.UtcNow,
                StatusOrdemServico.Finalizada
                ));
        }
    }
}