using Exercicio_Integrador_2.Pessoas;
using System.Text;

namespace Exercicio_Integrador_2.Models
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public List<Servico> ListaServicos { get; private set; }
        public List<Peca> ListaPecas { get; private set; }
        public DateTime DataAgendamento { get; private set; }
        public StatusOrdemServico Status { get; private set; }

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

        public string DetalharAgendamento()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"======================= Agendamento nº: {Id} ========================");
            sb.AppendLine($"Status: {Status} | Data Agendamento: {DataAgendamento}");
            sb.AppendLine($"Cliente: {Cliente.Nome} - {Cliente.GetType().Name}");
            sb.AppendLine($"Veículo: {Veiculo.Placa}  |  {Veiculo.Marca} {Veiculo.Modelo} {Veiculo.AnoFabricacao}");
            sb.AppendLine($"-------------------------------------------------------------------");
            sb.AppendLine($"| Relação de Peças & Serviços Agendados");
            sb.AppendLine($"-------------------------------------------------------------------");
            foreach (Peca peca in ListaPecas)
            {
                sb.AppendLine($"- {peca.Nome} | Valor Unitário: {peca.PrecoUnitario:C2} | Quantidade: 1");
            }
            foreach (Servico servico in ListaServicos)
            {
                sb.AppendLine($"- {servico.Nome} | Valor Hora: {servico.ValorBase:C2} | Tempo Execução: {servico.TempoEstimadoHoras} hora(s)");
            }
            sb.AppendLine($"===================================================================");

            return sb.ToString();
        }
    }
}