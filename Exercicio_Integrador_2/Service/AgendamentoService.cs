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

        public AgendamentoService(AgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public bool CadastroClienteEhValido(string idClienteString)
        {
            int idCliente;
            bool ehIdValida = int.TryParse(idClienteString, out idCliente);
            Cliente clienteSelecionado = _clienteRepository.PesquisarClientePorID(idCliente);
            if (clienteSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public bool PlacaEhValida(string placaVeiculo)
        {
            Veiculo veiculoSelecionado = _veiculoRepository.PesquisarVeiculoPorPlaca(placaVeiculo);
            if (veiculoSelecionado == null)
            {
                return false;
            }
            return true;
        }

        public bool ServicoEhValido(string idServicoString)
        {
            int idServico;
            bool ehIdValida = int.TryParse(idServicoString, out idServico);
            Servico servicoSelecionado = _servicoRepository.PesquisarServicoPorID(idServico);
            if (servicoSelecionado == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }
        public bool PecaEhValida(string idPecaString)
        {
            int idPeca;
            bool ehIdValida = int.TryParse(idPecaString, out idPeca);
            Peca pecaSelecionada = _pecaRepository.PesquisarPecaPorID(idPeca);
            if (pecaSelecionada == null || ehIdValida == false)
            {
                return false;
            }
            return true;
        }

        public void CadastrarAgendamento(string idClienteString, 
                                         string placa, 
                                         DateTime dataHoraAgendamento,
                                         List<string> servicosListString,
                                         List<string> pecasListString)
        {
            List<Servico> servicosSelecionados = [];
            foreach (string servico in servicosListString)
            {
                Servico _servicoAtual = _servicoRepository.PesquisarServicoPorID(int.Parse(servico));
                servicosSelecionados.Add(_servicoAtual);
            }

            List<Peca> pecasSelecionadas = [];
            foreach (string peca in pecasListString)
            {
                Peca _pecaAtual = _pecaRepository.PesquisarPecaPorID(int.Parse(peca));
                pecasSelecionadas.Add(_pecaAtual);
            }

            Agendamento novoAgendamento = new Agendamento(_agendamentoRepository.QtdAgendamentosCriados()+1, 
                                                          _clienteRepository.PesquisarClientePorID(int.Parse(idClienteString)),
                                                          _veiculoRepository.PesquisarVeiculoPorPlaca(placa), 
                                                          servicosSelecionados, 
                                                          pecasSelecionadas, 
                                                          dataHoraAgendamento, 
                                                          StatusOrdemServico.Agendada);

            _agendamentoRepository.CadastrarAgendamento(novoAgendamento);
        }

        public bool EhHorarioDisponivel(DateTime dataHoraAgendamento)
        {
            int agendamentosNoHorario = _agendamentoRepository.Agendamentos.Count(a => a.DataAgendamento.Day == dataHoraAgendamento.Day && 
                                                                          a.DataAgendamento.Month == dataHoraAgendamento.Month &&
                                                                          a.DataAgendamento.Year == dataHoraAgendamento.Year &&
                                                                          a.DataAgendamento.Hour == dataHoraAgendamento.Hour);
            if (agendamentosNoHorario > 1)
            {
                return false;
            }
            return true;
        }

        public bool EhAgendamentoCadastrado(string idAgendamentoString)
        {
            int idAgendamento;
            bool ehIdAgendamentoValido = int.TryParse(idAgendamentoString, out idAgendamento);
            Agendamento agendamentoSelecionado = _agendamentoRepository.PesquisarAgendamentoPorID(idAgendamento);
            if (agendamentoSelecionado == null || ehIdAgendamentoValido == false)
            {
                return false;
            }
            return true;
        }

        public void CancelarAgendamento(int idAgendamento)
        {
            _agendamentoRepository.PesquisarAgendamentoPorID(idAgendamento).CancelarAgendamento();    
        }

        public void CancelarAgendamento(string idAgendamentoString)
        {
            int idAgendamento;
            bool ehIdValida = int.TryParse(idAgendamentoString, out idAgendamento);
            _agendamentoRepository.PesquisarAgendamentoPorID(idAgendamento).CancelarAgendamento();
        }

        public List<Agendamento> ListarAgendamentos()
        {
            return _agendamentoRepository.ListarAgendamentos();
        }

        public string BuscarAgendamento(string idAgendamentoString)
        {
            return _agendamentoRepository.PesquisarAgendamentoPorID(idAgendamentoString).DetalharAgendamento();
        }
    }
}