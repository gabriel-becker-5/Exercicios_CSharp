namespace Exercicio_Integrador_2.Models
{
    public class Servico
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorBase { get; private set; }
        public decimal TempoEstimadoHoras { get; private set; }

        public Servico(int id, string nome, decimal valorbase, decimal tempoestimadohoras)
        {
            Id = id;
            Nome = nome;
            ValorBase = valorbase;
            TempoEstimadoHoras = tempoestimadohoras;
        }

        public string DetalharServico()
        {
            return $"ID: {Id} | Descrição: {Nome} | Valor Hora: {ValorBase:C2} | Tempo Estimado: {TempoEstimadoHoras} horas";
        }
    }
}