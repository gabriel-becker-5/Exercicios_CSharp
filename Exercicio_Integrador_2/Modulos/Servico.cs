/* Classe Serviço - Representa um serviço executado pela oficina.
Atributos: Id, Nome, ValorBase, TempoEstimadoHoras
Exemplos de Serviços: Troca de óleo, Alinhamento, Balanceamento, Revisão, Diagnóstico eletrônico */

namespace Exercicio_Integrador_2.Modulos
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
    }
}