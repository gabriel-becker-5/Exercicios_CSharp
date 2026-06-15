/* Classe Agendamento - Representa um horário reservado.
Atributos: Id, Cliente, Veiculo, DataHora, Servico
Métodos: Confirmar(), Cancelar() */

using Exercicio_Integrador_2.Pessoas;
using Exercicio_Integrador_2.Veiculos;

namespace Exercicio_Integrador_2.Modulos
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Veiculo Veiculo { get; private set;}
        public DateTime DataHora { get; private set; }
        public List<Servico> Servico { get; private set; }
        public List<Peca> Peca { get; private set; }
        public StatusOrdemServico Status { get; private set; }

        public Agendamento(int id, Cliente cliente, Veiculo veiculo, DateTime datahora, 
            List<Servico> servico, List<Peca> peca, StatusOrdemServico status)
        {
            Id = id;
            Cliente = cliente;
            Veiculo = veiculo;
            DataHora = datahora;
            Servico = servico;
            Peca = peca;
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
            Console.WriteLine($"Status: {Status} | Data Agendamento: {DataHora}");
            Console.WriteLine($"Cliente: {Cliente.Nome} - {Cliente.GetType().Name}");
            Console.WriteLine($"Veículo: {Veiculo.Placa}  |  {Veiculo.Marca} {Veiculo.Modelo} {Veiculo.AnoFabricacao}");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("| Relação de Peças & Serviços Agendados ");
            Console.WriteLine("-------------------------------------------------------------------");

            foreach (Peca peca in Peca)
            {
                Console.WriteLine($"- {peca.Nome} | Valor Unitário: {peca.PrecoUnitario:C2} | Quantidade: 1");
            }
            foreach (Servico servico in Servico)
            {
                Console.WriteLine($"- {servico.Nome} | Valor Hora: {servico.ValorBase:C2} | Tempo Execução: {servico.TempoEstimadoHoras} hora(s)");
            }
            Console.WriteLine("===================================================================");
        }
    }
}