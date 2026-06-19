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
            
            // PENDENTE - CHAMAR SERVICE PARA VALIDAR
            //bool ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
            //while (!ehDataValida || dataHoraAgendamento == null)
            //{
            //    Console.WriteLine("Digite uma data válida!");
            //    Console.Write("Data e Hora do Agendamento (DD/MM/AAAA HH:MM): ");
            //    dataHoraAgendamentoString = Console.ReadLine();
            //    ehDataValida = DateTime.TryParse(dataHoraAgendamentoString, out dataHoraAgendamento);
            //}

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

            Agendamento novoAgendamento = new Agendamento(_agendamentoRepository.QtdAgendamentosCriados() + 1,
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


        public void CadastrarAgendamento()
        {
            _agendamentoService.CadastrarAgendamento();
        }

        public void ListarAgendamentos()
        {
            _agendamentoService.ListarAgendamentos();
        }

        public void BuscaAgendamento()
        {
            _agendamentoService.BuscarAgendamento();
        }

        public void CancelarAgendamento()
        {
            _agendamentoService.CancelarAgendamento();
        }
    }
}