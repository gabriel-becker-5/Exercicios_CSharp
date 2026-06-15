/* Classe Cliente - Herda de Pessoa.
Atributos: DataCadastro, TotalGasto
Métodos: AtualizarTotalGasto() */

namespace Exercicio_Integrador_2.Pessoas
{
    public class Cliente : Pessoa
    {
        public DateTime DataCadastro { get; private set; }
        public decimal TotalGasto {  get; private set; }

        public Cliente(int id, string nome, string telefone, string email, DateTime datacadastro, decimal totalgasto) : base(id, nome, telefone, email)
        {
            DataCadastro = DateTime.UtcNow;
            TotalGasto = 0;
        }

        public void AtualizarTotalGasto() // PENDENTE, FALTA OS OBJETOS NECESSÁRIOS
        {
        }
    }
}