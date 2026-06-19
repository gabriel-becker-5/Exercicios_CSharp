using Exercicio_Integrador_2.Excecoes;
using Exercicio_Integrador_2.Models;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Repository;

namespace Exercicio_Integrador_2.Service
{
    public class AgendamentoService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly VeiculoRepository _veiculoRepository;
        private readonly ServicoRepository _servicoRepository;
        private readonly PecaRepository _pecaRepository;
        private readonly AgendamentoRepository _agendamentoRepository;

        public AgendamentoService(AgendamentoRepository agendamentoRepository, 
                                  ClienteRepository clienterepository,
                                  VeiculoRepository veiculorepository,
                                  ServicoRepository servicorepository,
                                  PecaRepository pecarepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _clienteRepository = clienterepository;
            _veiculoRepository = veiculorepository;
            _servicoRepository = servicorepository;
            _pecaRepository = pecarepository;
        }

        public void CadastrarAgendamento()
        {
            Console.WriteLine("=== Criar novo Agendamento ===");
            int idDoCliente;
            Console.Write("ID do Cliente: ");
            string idDoClienteString = Console.ReadLine();
            bool ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);

            Cliente clienteSelecionado = _clienteRepository.PesquisarClientePorID(idDoCliente);

            while (clienteSelecionado == null)
            {
                Console.WriteLine("Informe uma ID válida!");
                Console.Write("ID do Cliente: ");
                idDoClienteString = Console.ReadLine();
                ehIdValida = int.TryParse(idDoClienteString, out idDoCliente);
                clienteSelecionado = _clienteRepository.PesquisarClientePorID(idDoCliente);
            }

            Console.Write("Placa do Veículo: ");
            string placaDoVeiculo = Console.ReadLine();
            Veiculo veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaDoVeiculo);

            while (veiculoSelecionado == null)
            {
                Console.WriteLine("Informe um veículo válido!");
                Console.Write("Placa do Veículo: ");
                placaDoVeiculo = Console.ReadLine();
                veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaDoVeiculo);
            }

            Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
            DateTime dataHoraAgendamento;
            string dataHoraAgendamentoString = Console.ReadLine();
            bool ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);

            while (!ehDataValida || dataHoraAgendamento == null)
            {
                Console.WriteLine("Digite uma data válida!");
                Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
                dataHoraAgendamentoString = Console.ReadLine();
                ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
            }

            string maisServicos = "";
            int idDoServico;
            List<Servico> ServicosSelecionados = [];

            while (maisServicos.ToUpper() != "N")
            {
                Console.Write("ID do Serviço: ");
                string idDoServicoString = Console.ReadLine();
                bool ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                Servico servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idDoServico);

                while (servicoParaAddOS == null)
                {
                    Console.WriteLine("Informe um ID de Serviço válido!");
                    Console.Write("ID do Serviço: ");
                    idDoServicoString = Console.ReadLine();
                    ehIdServicoValida = int.TryParse(idDoServicoString, out idDoServico);
                    servicoParaAddOS = _servicoRepository.PesquisarServicoPorID(idDoServico);
                }

                ServicosSelecionados.Add(servicoParaAddOS);

                maisServicos = "";
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
            int idDaPeca;
            List<Peca> PecasSelecionadas = [];

            while (maisPecas.ToUpper() != "N")
            {
                Console.Write("ID da Peça: ");
                string idDaPecaString = Console.ReadLine();
                bool ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                Peca pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);

                while (pecasParaAddOS == null)
                {
                    Console.WriteLine("Digite um ID de Peça válido!");
                    Console.Write("ID da Peça: ");
                    idDaPecaString = Console.ReadLine();
                    ehIdPecaValida = int.TryParse(idDaPecaString, out idDaPeca);
                    pecasParaAddOS = _pecaRepository.PesquisarPecaPorID(idDaPeca);
                }

                PecasSelecionadas.Add(pecasParaAddOS);

                maisPecas = "";
                Console.Write("Há mais Peças para adicionar? (S/N): ");
                maisPecas = Console.ReadLine();
                while (maisPecas.ToUpper() != "S" && maisPecas.ToUpper() != "N")
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("Há mais Peças para adicionar? (S/N): ");
                    maisPecas = Console.ReadLine();
                }
            }

            Agendamento novoAgendamento = new Agendamento(_agendamentoRepository.QtdAgendamentosCriados()+1, 
                                                          clienteSelecionado, 
                                                          veiculoSelecionado,
                                                          ServicosSelecionados, 
                                                          PecasSelecionadas, 
                                                          dataHoraAgendamento, 
                                                          StatusOrdemServico.Agendada);

            try
            {
                bool possuiConflito = _agendamentoRepository.Agendamentos.Any(a => a.ConflitaCom(novoAgendamento));
            }
            catch (HorarioIndisponivelException ex)
            {
                Console.WriteLine("Conflito de Agenda! " + ex.Message);
                Console.WriteLine();
                return; // RETURN É O ESPERADO AQUI?
            }

            _agendamentoRepository.CadastrarAgendamento(novoAgendamento);
            Console.WriteLine("Agendamento realizado com sucesso.");
            Console.WriteLine();
        }

        public void CancelarAgendamento()
        {
            Console.WriteLine();
            Console.WriteLine("=== Cancelar Agendamento ===");
            Console.Write("Informe o número do Agendamento: ");
            int ordemServico;
            string ordemServicoString = Console.ReadLine();
            bool ehOSValida = int.TryParse(ordemServicoString, out ordemServico);
            Agendamento agendamentoParaCancelar = _agendamentoRepository.PesquisarAgendamentoPorID(ordemServico);

            while (agendamentoParaCancelar == null)
            {
                Console.WriteLine("Informe um Agendamento válido!");
                Console.Write("Informe o número do Agendamento: ");
                ordemServicoString = Console.ReadLine();
                ehOSValida = int.TryParse(ordemServicoString, out ordemServico);
                agendamentoParaCancelar = _agendamentoRepository.PesquisarAgendamentoPorID(ordemServico);
            }

            Console.WriteLine();
            Console.WriteLine(agendamentoParaCancelar.DetalharAgendamento());

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
                _agendamentoRepository.PesquisarAgendamentoPorID(ordemServico).CancelarAgendamento();
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
            List<Agendamento> listaDeAgendamentos = _agendamentoRepository.ListarAgendamentos();
            foreach (Agendamento agendamento in listaDeAgendamentos)
            {
                Console.WriteLine();
                Console.WriteLine(agendamento.DetalharAgendamento());
            }
            Console.WriteLine();
        }

        public void BuscarAgendamento()
        {
            Console.WriteLine("=== Buscar Agendamento ===");
            Console.Write("Informe o ID do Agendamento: ");
            int idDoAgendamento;
            string idDoAgendamentoString = Console.ReadLine();
            bool ehIdAgendamentoValida = int.TryParse(idDoAgendamentoString, out idDoAgendamento);

            while (!ehIdAgendamentoValida || idDoAgendamento <= 0)
            {
                Console.WriteLine("Digite um ID válido!");
                Console.Write("Informe o ID do Agendamento: ");
                idDoAgendamentoString = Console.ReadLine();
                ehIdAgendamentoValida = int.TryParse(idDoAgendamentoString, out idDoAgendamento);
            }

            Console.WriteLine(_agendamentoRepository.PesquisarAgendamentoPorID(idDoAgendamento).DetalharAgendamento());
        }
    }
}