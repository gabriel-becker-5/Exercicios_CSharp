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