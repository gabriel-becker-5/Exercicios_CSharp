using Exercicio_Integrador_2.Pessoas;
using System.Text;

namespace Exercicio_Integrador_2.Models
{
    public class OrdemServico
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public Funcionario FuncionarioResponsavel { get; private set; }
        public List<Servico> ListaServicos { get; private set; }
        public List<Peca> ListaPecas { get; private set; }
        public DateTime DataAberturaOS { get; private set; }
        public StatusOrdemServico Status { get; private set; }

        public OrdemServico(int id, Cliente cliente, Veiculo veiculo, Funcionario funcionarioResponsavel, 
                            List<Servico> listaservicos, List<Peca> listapecas, DateTime dataaberturaOS, 
                            StatusOrdemServico status)
        {
            Id = id;
            Cliente = cliente;
            Veiculo = veiculo;
            FuncionarioResponsavel = funcionarioResponsavel;
            ListaServicos = listaservicos;
            ListaPecas = listapecas;
            DataAberturaOS = dataaberturaOS;
            Status = status;
        }

        public void FinalizarOrdemServico()
        {
            Status = StatusOrdemServico.Finalizada;
        }

        public void CancelarOrdemServico()
        {
            Status = StatusOrdemServico.Cancelada;
        }

        public string DetalharOrdemServico()
        {
            StringBuilder sb = new StringBuilder();
            decimal valorTotalPecas = 0;
            decimal valorTotalServicos = 0;

            sb.AppendLine($"====================== Ordem de Serviço nº: {Id} ======================");
            sb.AppendLine($"Status: {Status} | Data Abertura: {DataAberturaOS}");
            sb.AppendLine($"Cliente: {Cliente.Nome} - {Cliente.GetType().Name}");
            sb.AppendLine($"Veículo: {Veiculo.Placa}  |  {Veiculo.Marca} {Veiculo.Modelo} {Veiculo.AnoFabricacao}");
            sb.AppendLine($"Responsável: {FuncionarioResponsavel.Nome} | {FuncionarioResponsavel.Cargo}");
            sb.AppendLine("--------------------------------------------------------------------");
            sb.AppendLine("| Relação de Peças & Serviços");
            sb.AppendLine("-------------------------------------------------------------------");

            foreach (Peca peca in ListaPecas)
            {
                sb.AppendLine($"- {peca.Nome} | Valor Unitário: {peca.PrecoUnitario:C2} | Quantidade: 1");
                valorTotalPecas += peca.PrecoUnitario;
            }
            
            foreach (Servico servico in ListaServicos)
            {
                sb.AppendLine($"- {servico.Nome} | Valor Hora: {servico.ValorBase:C2} | Tempo Execução: {servico.TempoEstimadoHoras} hora(s)");
                valorTotalServicos += servico.ValorBase * servico.TempoEstimadoHoras;
            }

            decimal valorTotalOS = valorTotalPecas + valorTotalServicos;

            sb.AppendLine("--------------------------------------------------------------------");
            sb.AppendLine($"Peças: {valorTotalPecas:C2}");
            sb.AppendLine($"Serviços: {valorTotalServicos:C2}");
            sb.AppendLine($"Valor Total: {valorTotalOS:C2}");
            sb.AppendLine("====================================================================");

            return sb.ToString();
        }
    }
}