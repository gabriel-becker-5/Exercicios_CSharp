using Exercicio_Integrador_2.Models;

namespace Exercicio_Integrador_2.Repository
{
    public class AgendamentoRepository
    {
        public List<Agendamento> Agendamentos { get; private set; }

        public AgendamentoRepository()
        {
        }

    public int QtdAgendamentosCriados()
        {
            return Agendamentos.Count();
        }

        public void CadastrarAgendamento(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }

        public void CancelarAgendamento(Agendamento agendamento)
        {
            agendamento.CancelarAgendamento();
        }

        public Agendamento PesquisarAgendamentoPorID(int id)
        {
            return Agendamentos.FirstOrDefault(a => a.Id == id);
        }

        public Agendamento PesquisarAgendamentoPorID(string idString)
        {
            int id;
            bool ehIdValida = int.TryParse(idString, out id);
            return Agendamentos.FirstOrDefault(a => a.Id == id);
        }

        public List<Agendamento> ListarAgendamentos()
        {
            return Agendamentos;
        }
    }
}