using Exercicio_Integrador_2.Excecoes;
using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;
using Exercicio_Integrador_2.Service;

namespace Exercicio_Integrador_2.Controller
{
    public class AgendamentoController
    {
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoservice)
        {
            _agendamentoService = agendamentoservice;
        }

        public void CadastrarAgendamento()
        {
            Console.WriteLine("=== Criar novo Agendamento ===");
            Console.Write("ID do Cliente: ");
            string idDoClienteString = Console.ReadLine();
            bool verificaCliente = _agendamentoService.CadastroClienteEhValido(idDoClienteString);

            while (!verificaCliente)
            {
                Console.WriteLine("Informe uma ID válida!");
                Console.Write("ID do Cliente: ");
                idDoClienteString = Console.ReadLine();
                verificaCliente = _agendamentoService.CadastroClienteEhValido(idDoClienteString);
            }

            Console.Write("Placa do Veículo: ");
            string placaDoVeiculo = Console.ReadLine();
            bool verificaPlaca = _agendamentoService.PlacaEhValida(placaDoVeiculo);

            while (!verificaPlaca)
            {
                Console.WriteLine("Informe um veículo válido!");
                Console.Write("Placa do Veículo: ");
                placaDoVeiculo = Console.ReadLine();
                verificaPlaca = _agendamentoService.PlacaEhValida(placaDoVeiculo);
            }

            Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
            DateTime dataHoraAgendamento;
            string dataHoraAgendamentoString = Console.ReadLine();
            bool ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
            bool ehHorarioDisponivel = _agendamentoService.EhHorarioDisponivel(dataHoraAgendamento);

            while (!ehDataValida || dataHoraAgendamento == null || !ehHorarioDisponivel)
            {
                if (!ehHorarioDisponivel)
                {
                    Console.WriteLine("Horário indisponível ou já ocupado.");
                }
                else
                { 
                    Console.WriteLine("Digite uma data válida!");
                }

                Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
                dataHoraAgendamentoString = Console.ReadLine();
                ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
                ehHorarioDisponivel = _agendamentoService.EhHorarioDisponivel(dataHoraAgendamento);
            }

            string maisServicos = "";
            List<string> ServicosSelecionados = [];

            while (maisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idDoServicoString = Console.ReadLine();
                bool verificaServico = _agendamentoService.ServicoEhValido(idDoServicoString);

                while (!verificaServico)
                {
                    Console.WriteLine("Informe um Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idDoServicoString = Console.ReadLine();
                    verificaServico = _agendamentoService.ServicoEhValido(idDoServicoString);
                }

                ServicosSelecionados.Add(idDoServicoString);

                Console.Write("Há mais Serviços para adicionar? (S/N): ");
                maisServicos = Console.ReadLine();
                while (maisServicos.ToUpper() != "S" && maisServicos.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Serviços para adicionar? (S/N): ");
                    maisServicos = Console.ReadLine();
                }
            }

            string maisPecas = "";
            List<string> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool verificaPeca = _agendamentoService.PecaEhValida(idDaPecaString);

                while (!verificaPeca)
                {
                    Console.WriteLine("Informe uma Peça válida!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    verificaPeca = _agendamentoService.PecaEhValida(idDaPecaString);
                }

                PecasSelecionadas.Add(idDaPecaString);

                Console.Write("Há mais Peças para adicionar? (S/N): ");
                maisPecas = Console.ReadLine();
                while (maisPecas.ToUpper() != "S" && maisPecas.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Peças para adicionar? (S/N): ");
                    maisPecas = Console.ReadLine();
                }
            }

            try
            {
                _agendamentoService.CadastrarAgendamento(idDoClienteString, 
                                                         placaDoVeiculo, 
                                                         dataHoraAgendamento, 
                                                         ServicosSelecionados, 
                                                         PecasSelecionadas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine();
                return; // PENDENTE - VALIDAR SE RETURN É O COMPORTAMENTO ESPERADO
            }
            Console.WriteLine("Agendamento realizado com sucesso.");
            Console.WriteLine();
        }

        public void CancelarAgendamento()
        {
            Console.WriteLine();
            Console.WriteLine("=== Cancelar Agendamento ===");
            Console.Write("Número do Agendamento: ");
            string numeroAgendamentoString = Console.ReadLine();
            bool ehAgendamentoValido = _agendamentoService.EhAgendamentoCadastrado(numeroAgendamentoString);

            while (!ehAgendamentoValido)
            {
                Console.WriteLine("Informe um Agendamento válido!");
                Console.Write("Número do Agendamento: ");
                numeroAgendamentoString = Console.ReadLine();
                ehAgendamentoValido = _agendamentoService.EhAgendamentoCadastrado(numeroAgendamentoString);
            }

            string confirmaCancelamento = "";
            Console.WriteLine();
            Console.Write("Confirma o Cancelamento do agendamento? (S | N): ");
            confirmaCancelamento = Console.ReadLine();

            while (confirmaCancelamento.ToUpper() != "S" && confirmaCancelamento.ToUpper() != "N")
            {
                Console.WriteLine("Opção inválida!");
                Console.Write("Confirma o Cancelamento do agendamento? (S | N): ");
                confirmaCancelamento = Console.ReadLine();
            }

            if (confirmaCancelamento.ToUpper() == "S")
            {
                _agendamentoService.CancelarAgendamento(numeroAgendamentoString);
                Console.WriteLine("Agendamento cancelado com sucesso.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Agendamento não foi cancelado.");
                Console.WriteLine();
            }
        }

        public void ListarAgendamentos()
        {
            Console.WriteLine("=== Listar Agendamentos ===");
            foreach (Agendamento agendamento in _agendamentoService.ListarAgendamentos())
            {
                Console.WriteLine(agendamento.DetalharAgendamento());
            }
        }

        public void BuscaAgendamento()
        {
            Console.WriteLine("=== Buscar Agendamento ===");
            Console.Write("Número do Agendamento: ");
            string idDoAgendamentoString = Console.ReadLine();
            bool ehAgendamentoValido = _agendamentoService.EhAgendamentoCadastrado(idDoAgendamentoString);

            while (!ehAgendamentoValido)
            {
                Console.WriteLine("Digite um ID válido!");
                Console.Write("Número do Agendamento: ");
                idDoAgendamentoString = Console.ReadLine();
                ehAgendamentoValido = _agendamentoService.EhAgendamentoCadastrado(idDoAgendamentoString);
            }

            Console.WriteLine();
            Console.WriteLine(_agendamentoService.BuscarAgendamento(idDoAgendamentoString));
        }
    }
}