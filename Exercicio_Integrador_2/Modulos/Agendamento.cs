/* Classe Agendamento - Representa um horário reservado.
Atributos: Id, Cliente, Veiculo, DataHora, Servico
Métodos: Confirmar(), Cancelar() */

using Exercicio_Integrador_2.Excecoes;
using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Veiculos;

namespace Exercicio_Integrador_2.Modulos
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; } 
        public Veiculo Veiculo { get; private set;}
        public List<Servico> ListaServicos { get; private set; }
        public List<Peca> ListaPecas { get; private set; }
        public DateTime DataAgendamento { get; private set; }
        public StatusOrdemServico Status { get; private set; }        

        public bool ConflitaCom(Agendamento agendamento)
        {
            bool possuiConflito = DataAgendamento.Day == agendamento.DataAgendamento.Day &&
                   DataAgendamento.Month == agendamento.DataAgendamento.Month &&
                   DataAgendamento.Year == agendamento.DataAgendamento.Year &&
                   DataAgendamento.Hour == agendamento.DataAgendamento.Hour &&
                   DataAgendamento.Minute == agendamento.DataAgendamento.Minute;
            if (possuiConflito)
            {
                throw new HorarioIndisponivelException();
            }
            return possuiConflito;
        }

        public Agendamento(int id, Cliente cliente, Veiculo veiculo, List<Servico> listaservicos, 
            List<Peca> listapecas, DateTime dataagendamento, StatusOrdemServico status)
        {
            Id = id;
            Cliente = cliente;
            Veiculo = veiculo;
            ListaServicos = listaservicos;
            ListaPecas = listapecas;
            DataAgendamento = dataagendamento;
            Status = status;
        }

        public void FinalizarAgendamento()
        {
            Status = StatusOrdemServico.Finalizada;
        }

        public void CancelarAgendamento()
        {
            Status = StatusOrdemServico.Cancelada;
        }

        public void DetalharAgendamento()
        {
            Console.WriteLine($"======================= Agendamento nº: {Id} ========================");
            Console.WriteLine($"Status: {Status} | Data Agendamento: {DataAgendamento}");
            Console.WriteLine($"Cliente: {Cliente.Nome} - {Cliente.GetType().Name}");
            Console.WriteLine($"Veículo: {Veiculo.Placa}  |  {Veiculo.Marca} {Veiculo.Modelo} {Veiculo.AnoFabricacao}");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("| Relação de Peças & Serviços Agendados ");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (Peca peca in ListaPecas)
            {
                Console.WriteLine($"- {peca.Nome} | Valor Unitário: {peca.PrecoUnitario:C2} | Quantidade: 1");
            }
            foreach (Servico servico in ListaServicos)
            {
                Console.WriteLine($"- {servico.Nome} | Valor Hora: {servico.ValorBase:C2} | Tempo Execução: {servico.TempoEstimadoHoras} hora(s)");
            }
            Console.WriteLine("===================================================================");
        }
    }
}